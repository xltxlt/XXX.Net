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

        public TaskStep(
            IWorkFlowRepository<WorkflowTask> taskRepo,
            IWorkFlowRepository<WorkflowDefinitionEntity> definitionRepo,
            IWorkFlowRepository<WorkflowInstanceEntity> instanceRepo,
            IWorkFlowRepository<WorkflowHistory> historyRepo)
        {
            _taskRepo = taskRepo;
            _definitionRepo = definitionRepo;
            _instanceRepo = instanceRepo;
            _historyRepo = historyRepo;
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
            var node = await FindNodeAsync(flowData.WorkflowId, nodeId);
            var assigneeIds = ParseAssigneeIds(node);
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
                NodeId = nodeId,
                NodeName = nodeName,
                AssigneeId = assigneeIds[0],
                Status = "pending",
            };
            await _taskRepo.InsertAsync(task);

            var taskId = task.Id;
            flowData.Variables["TaskId_" + nodeId] = taskId;
            flowData.InstanceId = instanceId;
            context.Workflow.Data = flowData;

            return ExecutionResult.WaitForEvent(EventName, taskId, DateTime.UtcNow);
        }

        private async Task<WorkflowNodeModel?> FindNodeAsync(string workflowId, string nodeId)
        {
            var defs = await _definitionRepo.GetListAsync(d => d.WorkflowId == workflowId);
            return defs.SelectMany(d => d.Nodes).FirstOrDefault(n => n.Id == nodeId);
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

        private static List<long> ParseAssigneeIds(WorkflowNodeModel? node)
        {
            if (node == null || string.IsNullOrEmpty(node.Config)) return new List<long>();
            try
            {
                using var doc = JsonDocument.Parse(node.Config);
                if (doc.RootElement.ValueKind != JsonValueKind.Object) return new List<long>();
                if (!doc.RootElement.TryGetProperty("assigneeIds", out var val)
                    || val.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined) return new List<long>();
                return val.Deserialize<List<long>>() ?? new List<long>();
            }
            catch
            {
                return new List<long>();
            }
        }
    }
}
