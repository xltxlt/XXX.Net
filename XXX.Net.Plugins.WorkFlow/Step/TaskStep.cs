using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Models;
using XXX.Net.Plugins.WorkFlow.Notification;
using XXX.Net.Core.Entity.Sys;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using WorkflowDefinitionEntity = XXX.Net.Plugins.WorkFlow.Entity.WorkflowDefinition;
using WorkflowInstanceEntity = XXX.Net.Plugins.WorkFlow.Entity.WorkflowInstance;
using WorkflowNodeModel = XXX.Net.Plugins.WorkFlow.VueFlowModel.VfWorkflowNode;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 任务节点：创建待办并等待处理人完成（保存/完成/跳过）。
    /// 第一次执行：解析处理人、创建待办、WaitForEvent 挂起；
    /// 事件唤醒后（用户提交表单）：写入表单数据、流转到下一步。
    /// </summary>
    public class TaskStep : StepBody
    {
        public const string EventName = "TaskCompleted";

        private readonly IWorkFlowRepository<WorkflowTask> _taskRepo;
        private readonly IWorkFlowRepository<WorkflowDefinitionEntity> _definitionRepo;
        private readonly IWorkFlowRepository<WorkflowInstanceEntity> _instanceRepo;
        private readonly IWorkFlowRepository<WorkflowHistory> _historyRepo;
        private readonly IMSRepository _msRepository;
        private readonly IEnumerable<IWorkflowMessageSender> _messageSenders;

        public TaskStep(
            IWorkFlowRepository<WorkflowTask> taskRepo,
            IWorkFlowRepository<WorkflowDefinitionEntity> definitionRepo,
            IWorkFlowRepository<WorkflowInstanceEntity> instanceRepo,
            IWorkFlowRepository<WorkflowHistory> historyRepo,
            IMSRepository msRepository,
            IEnumerable<IWorkflowMessageSender> messageSenders)
        {
            _taskRepo = taskRepo;
            _definitionRepo = definitionRepo;
            _instanceRepo = instanceRepo;
            _historyRepo = historyRepo;
            _msRepository = msRepository;
            _messageSenders = messageSenders;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return RunCoreAsync(context).GetAwaiter().GetResult();
        }

        private async Task<ExecutionResult> RunCoreAsync(IStepExecutionContext context)
        {
            var nodeId = context.Step.ExternalId ?? context.Step.Id.ToString();
            var flowData = (context.Workflow.Data as FlowData) ?? new FlowData();
            var instanceId = context.Workflow.Id;

            // 事件已唤醒：用户提交了表单（保存/完成/跳过）
            if (context.ExecutionPointer.EventPublished || context.ExecutionPointer.EventData != null)
            {
                if (context.ExecutionPointer.EventData is TaskSubmitEvent submit)
                {
                    await MergeFormDataAsync(instanceId, nodeId, submit);
                    await _historyRepo.InsertAsync(new WorkflowHistory
                    {
                        InstanceId = instanceId,
                        NodeId = nodeId,
                        NodeName = context.Step.Name ?? nodeId,
                        OperatorId = submit.OperatorId,
                        OperatorName = submit.OperatorName,
                        Action = submit.Action,
                        Comment = submit.Comment,
                        OperatedTime = DateTime.Now,
                    });
                }
                return ExecutionResult.Next();
            }

            // 第一次执行：解析处理人并创建待办
            var definition = await FindDefinitionAsync(flowData.WorkflowId, context.Workflow.Version);
            var node = definition?.Nodes.FirstOrDefault(n => n.Id == nodeId);
            var taskConfig = await ResolveTaskConfigAsync(node);
            var assigneeIds = taskConfig.ResponsibleUserIds;
            var nodeName = node?.Name ?? nodeId;

            if (assigneeIds.Count == 0)
            {
                await _historyRepo.InsertAsync(new WorkflowHistory
                {
                    InstanceId = instanceId,
                    NodeId = nodeId,
                    NodeName = nodeName,
                    Action = "auto",
                    OperatedTime = DateTime.Now,
                });
                return ExecutionResult.Next();
            }

            var task = new WorkflowTask
            {
                InstanceId = instanceId,
                WorkflowId = flowData.WorkflowId,
                WorkflowDefinitionId = definition?.Id ?? string.Empty,
                NodeId = nodeId,
                NodeName = nodeName,
                AssigneeId = assigneeIds[0],
                ResponsibleUserIds = taskConfig.ResponsibleUserIds,
                ResponsibleDepartmentIds = taskConfig.ResponsibleDepartmentIds,
                CcUserIds = taskConfig.CcUserIds,
                EstimatedDurationDays = taskConfig.EstimatedDurationDays,
                ReminderBeforeDays = taskConfig.ReminderBeforeDays,
                DueTime = DateTime.Now.AddDays(taskConfig.EstimatedDurationDays),
                ReminderTime = DateTime.Now.AddDays(taskConfig.EstimatedDurationDays - taskConfig.ReminderBeforeDays),
                Status = "pending",
            };
            await _taskRepo.InsertAsync(task);
            await SendMessageAsync(new WorkflowMessage
            {
                Title = $"待办任务：{nodeName}",
                Content = $"您有一个待办任务「{nodeName}」，请在 {task.DueTime:yyyy-MM-dd HH:mm} 前处理。",
                InstanceId = instanceId,
                TaskId = task.Id,
                RecipientUserIds = task.ResponsibleUserIds.Concat(task.CcUserIds).Distinct().ToList(),
            });

            var taskId = task.Id;
            flowData.Variables["TaskId_" + nodeId] = taskId;
            flowData.InstanceId = instanceId;
            context.Workflow.Data = flowData;

            return ExecutionResult.WaitForEvent(EventName, taskId, DateTime.UtcNow);
        }

        private async Task<WorkflowDefinitionEntity?> FindDefinitionAsync(string workflowId, int version)
        {
            var defs = await _definitionRepo.GetListAsync(d => d.WorkflowId == workflowId);
            return defs.FirstOrDefault(d => d.Version == version) ?? defs.OrderByDescending(d => d.Version).FirstOrDefault();
        }

        private async Task MergeFormDataAsync(string instanceId, string nodeId, TaskSubmitEvent submit)
        {
            var instances = await _instanceRepo.GetListAsync(i => i.InstanceId == instanceId);
            var instance = instances.FirstOrDefault();
            if (instance == null) return;

            var all = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(instance.DataJson))
            {
                try { all = JsonSerializer.Deserialize<Dictionary<string, object>>(instance.DataJson) ?? new(); }
                catch { all = new(); }
            }
            all[nodeId] = submit.FormData ?? new Dictionary<string, object>();
            instance.DataJson = JsonSerializer.Serialize(all);
            await _instanceRepo.UpdateAsync(instance.Id, instance);
        }

        private async Task<TaskNodeConfig> ResolveTaskConfigAsync(WorkflowNodeModel? node)
        {
            var config = ParseTaskConfig(node);
            if (config.ResponsibleDepartmentIds.Count > 0)
            {
                var departmentUserIds = await _msRepository.Master<SysUserDepRole>()
                    .AsQueryable()
                    .Where(x => config.ResponsibleDepartmentIds.Contains(x.DepartmentId) && !x.Deleted)
                    .Select(x => x.UserId)
                    .Distinct()
                    .ToListAsync();
                config.ResponsibleUserIds = config.ResponsibleUserIds.Concat(departmentUserIds).Distinct().ToList();
            }
            return config;
        }

        private static TaskNodeConfig ParseTaskConfig(WorkflowNodeModel? node)
        {
            var config = new TaskNodeConfig();
            if (node == null || string.IsNullOrWhiteSpace(node.Config)) return config;
            try
            {
                using var doc = JsonDocument.Parse(node.Config);
                var root = doc.RootElement;
                config.ResponsibleUserIds = ReadLongList(root, "responsibleUserIds", "assigneeIds");
                config.ResponsibleDepartmentIds = ReadLongList(root, "responsibleDepartmentIds");
                config.CcUserIds = ReadLongList(root, "ccUserIds");
                config.EstimatedDurationDays = ReadInt(root, "estimatedDurationDays");
                config.ReminderBeforeDays = ReadInt(root, "reminderBeforeDays");
            }
            catch (JsonException) { }
            return config;
        }

        private static List<long> ReadLongList(JsonElement root, params string[] names)
        {
            foreach (var name in names)
            {
                if (!root.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.Array) continue;
                return value.EnumerateArray()
                    .Select(x => x.ValueKind == JsonValueKind.Number && x.TryGetInt64(out var id) ? id : long.TryParse(x.GetString(), out id) ? id : 0)
                    .Where(id => id > 0)
                    .Distinct()
                    .ToList();
            }
            return new List<long>();
        }

        private static int ReadInt(JsonElement root, string name)
        {
            return root.TryGetProperty(name, out var value) && value.TryGetInt32(out var result) ? result : 0;
        }

        private async Task SendMessageAsync(WorkflowMessage message)
        {
            foreach (var sender in _messageSenders)
                await sender.SendAsync(message);
        }

        private sealed class TaskNodeConfig
        {
            public List<long> ResponsibleUserIds { get; set; } = new List<long>();
            public List<long> ResponsibleDepartmentIds { get; set; } = new List<long>();
            public List<long> CcUserIds { get; set; } = new List<long>();
            public int EstimatedDurationDays { get; set; }
            public int ReminderBeforeDays { get; set; }
        }

    }
}
