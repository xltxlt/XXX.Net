using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Models;
using XXX.Net.Plugins.WorkFlow.Notification;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.VueFlowModel;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 项目进度工作流引擎。
    ///
    /// 不依赖 WorkflowCore。
    ///
    /// 核心思想：
    ///
    /// WorkflowInstance.CurrentNodeId
    ///          ↓
    /// 当前节点
    ///          ↓
    /// WorkflowDefinition.Edges
    ///          ↓
    /// 下一个节点
    ///          ↓
    /// EnterNodeAsync
    ///
    /// Task 节点：
    ///     创建 WorkflowTask
    ///     CurrentNodeId 停留在当前节点
    ///     等待用户提交
    ///
    /// 用户完成：
    ///     WorkflowTask pending -> completed
    ///     推进 WorkflowInstance
    ///     创建下一个 Task
    ///
    /// 整个流程完全由数据库状态驱动。
    /// </summary>
    public class WorkflowEngine
    {
        private readonly IWorkFlowRepository<WorkflowDefinition> _definitionRepo;
        private readonly IWorkFlowRepository<WorkflowInstance> _instanceRepo;
        private readonly IWorkFlowRepository<WorkflowTask> _taskRepo;
        private readonly IWorkFlowRepository<WorkflowHistory> _historyRepo;

        private readonly IEnumerable<IWorkflowMessageSender> _messageSenders;

        /// <summary>
        /// 防止同一个实例在当前进程内被多个请求同时推进。
        ///
        /// 注意：
        /// 这是第一层保护。
        /// Mongo CAS 是第二层保护。
        /// </summary>
        private static readonly System.Collections.Concurrent.ConcurrentDictionary<
            string,
            SemaphoreSlim> _instanceLocks = new();

        public WorkflowEngine(
            IWorkFlowRepository<WorkflowDefinition> definitionRepo,
            IWorkFlowRepository<WorkflowInstance> instanceRepo,
            IWorkFlowRepository<WorkflowTask> taskRepo,
            IWorkFlowRepository<WorkflowHistory> historyRepo,
            IEnumerable<IWorkflowMessageSender> messageSenders)
        {
            _definitionRepo = definitionRepo;
            _instanceRepo = instanceRepo;
            _taskRepo = taskRepo;
            _historyRepo = historyRepo;
            _messageSenders = messageSenders;
        }

        #region 启动流程

        /// <summary>
        /// 启动普通流程。
        /// </summary>
        public async Task<string> StartAsync(
            string workflowId,
            int version,
            long tenantId,
            string taskName,
            Dictionary<string, object>? variables = null)
        {
            if (string.IsNullOrWhiteSpace(workflowId))
                throw new ArgumentException("WorkflowId 不能为空", nameof(workflowId));

            if (string.IsNullOrWhiteSpace(taskName))
                throw new ArgumentException("任务名称不能为空", nameof(taskName));

            var definition = await GetDefinitionAsync(workflowId, version);

            ValidateDefinition(definition);

            var instanceId = Guid.NewGuid().ToString("N");

            var flowVariables = NormalizeDictionary(variables);

            var instance = new WorkflowInstance
            {
                TenantId = tenantId > 0 ? tenantId : definition.TenantId,
                InstanceId = instanceId,
                WorkflowId = definition.WorkflowId,
                TaskName = taskName,
                Version = definition.Version,
                Status = "running",
                CurrentNodeId = string.Empty,
                DataJson = JsonSerializer.Serialize(flowVariables)
            };

            await _instanceRepo.InsertAsync(instance);

            await AddHistoryAsync(
                instanceId,
                string.Empty,
                "流程启动",
                0,
                string.Empty,
                "start",
                string.Empty);

            var startNode = definition.Nodes
                .FirstOrDefault(x =>
                    string.Equals(x.Type, "start", StringComparison.OrdinalIgnoreCase));

            if (startNode == null)
                throw new InvalidOperationException("流程定义缺少开始节点");

            await ExecuteFromNodeAsync(
                instance,
                definition,
                startNode.Id);

            return instanceId;
        }

        #endregion

        #region 完成任务

        /// <summary>
        /// 完成任务。
        ///
        /// 这里是整个工作流最核心的方法。
        ///
        /// pending
        ///      ↓ CAS
        /// completed
        ///      ↓
        /// 当前节点 → 下一节点
        /// </summary>
        public async Task CompleteTaskAsync(
            string taskId,
            long operatorId,
            string operatorName,
            Dictionary<string, object>? formData,
            string? comment)
        {
            await SubmitTaskAsync(
                taskId,
                "complete",
                operatorId,
                operatorName,
                formData,
                comment);
        }

        /// <summary>
        /// 跳过任务。
        /// </summary>
        public async Task SkipTaskAsync(
            string taskId,
            long operatorId,
            string operatorName,
            string? comment)
        {
            await SubmitTaskAsync(
                taskId,
                "skip",
                operatorId,
                operatorName,
                null,
                comment);
        }

        private async Task SubmitTaskAsync(
            string taskId,
            string action,
            long operatorId,
            string operatorName,
            Dictionary<string, object>? formData,
            string? comment)
        {
            if (string.IsNullOrWhiteSpace(taskId))
                throw new ArgumentException("TaskId 不能为空");

            if (action != "complete" && action != "skip")
                throw new ArgumentException($"不支持的任务操作：{action}");

            var task = await _taskRepo.GetOneAsync(x => x.Id == taskId);

            if (task == null)
                throw new InvalidOperationException("待办任务不存在");

            if (task.AssigneeId != operatorId)
                throw new UnauthorizedAccessException("只能处理分配给自己的待办");

            if (task.Status != "pending")
            {
                // 幂等处理。
                //
                // 用户连续点击两次：
                // 第一次成功：
                //     pending -> completed
                //
                // 第二次：
                //     completed
                //
                // 不再重复推进流程。
                return;
            }

            var instance = await GetInstanceAsync(task.InstanceId);

            var definition = await GetDefinitionAsync(
                task.WorkflowId,
                instance.Version);

            var form = NormalizeDictionary(formData);

            task.FormDataJson = JsonSerializer.Serialize(form);
            task.Comment = comment ?? string.Empty;
            task.Status = action == "complete"
                ? "completed"
                : "skipped";

            // CAS：
            //
            // 只有数据库里的任务还是 pending 时才允许更新。
            //
            // 防止：
            // 浏览器 A + 浏览器 B
            // 同时点击完成。
            var updated = await _taskRepo.UpdateAsync(
                task.Id,
                task,
                x => x.Status == "pending");

            if (!updated)
            {
                // 已经被其他请求处理。
                return;
            }

            // 保存表单数据
            await MergeFormDataAsync(
                instance,
                task.NodeId,
                form);

            // 写历史
            await AddHistoryAsync(
                instance.InstanceId,
                task.NodeId,
                task.NodeName,
                operatorId,
                operatorName,
                action,
                comment ?? string.Empty);

            // 通知
            await SendTaskMessageAsync(
                task,
                action,
                operatorName);

            // 只有 CAS 成功的请求才能推进流程。
            await MoveNextAsync(
                instance,
                definition,
                task.NodeId);
        }

        #endregion

        #region 保存任务

        /// <summary>
        /// 保存任务。
        ///
        /// save 不推进流程。
        /// </summary>
        public async Task SaveTaskAsync(
            string taskId,
            long operatorId,
            Dictionary<string, object>? formData,
            string? comment)
        {
            var task = await _taskRepo.GetOneAsync(x => x.Id == taskId);

            if (task == null)
                throw new InvalidOperationException("待办不存在");

            if (task.AssigneeId != operatorId)
                throw new UnauthorizedAccessException("只能处理分配给自己的待办");

            if (task.Status != "pending")
                throw new InvalidOperationException("待办已经处理");

            task.FormDataJson = JsonSerializer.Serialize(
                NormalizeDictionary(formData));

            task.Comment = comment ?? string.Empty;

            await _taskRepo.UpdateAsync(
                task.Id,
                task,
                x => x.Status == "pending");
        }

        #endregion

        #region 回退

        /// <summary>
        /// 回退到指定节点。
        ///
        /// 例如：
        ///
        /// A → B → C → D
        ///
        /// 当前 D
        /// 回退 C
        ///
        /// D pending → cancelled
        /// CurrentNodeId = C
        /// C → 创建新的 pending Task
        /// </summary>
        public async Task RollbackAsync(
            string instanceId,
            string targetNodeId,
            long operatorId,
            string operatorName,
            string? comment)
        {
            if (string.IsNullOrWhiteSpace(instanceId))
                throw new ArgumentException("InstanceId 不能为空");

            if (string.IsNullOrWhiteSpace(targetNodeId))
                throw new ArgumentException("TargetNodeId 不能为空");

            await WithInstanceLockAsync(
                instanceId,
                async () =>
                {
                    var instance = await GetInstanceAsync(instanceId);

                    if (instance.Status != "running")
                        throw new InvalidOperationException(
                            $"当前流程状态为 {instance.Status}，不能回退");

                    var definition = await GetDefinitionAsync(
                        instance.WorkflowId,
                        instance.Version);

                    var targetNode = definition.Nodes
                        .FirstOrDefault(x => x.Id == targetNodeId);

                    if (targetNode == null)
                        throw new InvalidOperationException(
                            $"回退节点不存在：{targetNodeId}");

                    // 当前任务取消
                    var currentTasks = await _taskRepo.GetListAsync(
                        x =>
                            x.InstanceId == instanceId &&
                            x.NodeId == instance.CurrentNodeId &&
                            x.Status == "pending");

                    foreach (var task in currentTasks)
                    {
                        task.Status = "cancelled";

                        await _taskRepo.UpdateAsync(
                            task.Id,
                            task,
                            x => x.Status == "pending");
                    }

                    var oldNodeId = instance.CurrentNodeId;

                    instance.CurrentNodeId = targetNodeId;

                    await _instanceRepo.UpdateAsync(
                        instance.Id,
                        instance);

                    await AddHistoryAsync(
                        instanceId,
                        targetNodeId,
                        targetNode.Name,
                        operatorId,
                        operatorName,
                        "rollback",
                        comment ?? $"从 {oldNodeId} 回退到 {targetNodeId}");

                    await EnterNodeAsync(
                        instance,
                        definition,
                        targetNode);
                });
        }

        #endregion

        #region 取消

        /// <summary>
        /// 取消流程。
        /// </summary>
        public async Task CancelAsync(
            string instanceId,
            long operatorId,
            string operatorName,
            string? comment)
        {
            await WithInstanceLockAsync(
                instanceId,
                async () =>
                {
                    var instance = await GetInstanceAsync(instanceId);

                    if (instance.Status != "running")
                        return;

                    instance.Status = "cancelled";

                    await _instanceRepo.UpdateAsync(
                        instance.Id,
                        instance);

                    var tasks = await _taskRepo.GetListAsync(
                        x =>
                            x.InstanceId == instanceId &&
                            x.Status == "pending");

                    foreach (var task in tasks)
                    {
                        task.Status = "cancelled";

                        await _taskRepo.UpdateAsync(
                            task.Id,
                            task,
                            x => x.Status == "pending");
                    }

                    await AddHistoryAsync(
                        instanceId,
                        instance.CurrentNodeId,
                        string.Empty,
                        operatorId,
                        operatorName,
                        "cancel",
                        comment ?? string.Empty);
                });
        }

        #endregion

        #region 节点执行

        /// <summary>
        /// 从指定节点开始执行。
        /// </summary>
        private async Task ExecuteFromNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            string nodeId)
        {
            await WithInstanceLockAsync(
                instance.InstanceId,
                async () =>
                {
                    await ExecuteFromNodeCoreAsync(
                        instance,
                        definition,
                        nodeId);
                });
        }

        private async Task ExecuteFromNodeCoreAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            string nodeId)
        {
            var node = definition.Nodes
                .FirstOrDefault(x => x.Id == nodeId);

            if (node == null)
                throw new InvalidOperationException(
                    $"流程节点不存在：{nodeId}");

            await EnterNodeAsync(
                instance,
                definition,
                node);
        }

        /// <summary>
        /// 进入节点。
        ///
        /// 节点类型：
        ///
        /// start
        /// task
        /// approval
        /// condition
        /// notification
        /// service
        /// delay
        /// end
        /// </summary>
        private async Task EnterNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            if (instance.Status != "running")
                return;

            switch ((node.Type ?? string.Empty).ToLowerInvariant())
            {
                case "start":
                    await EnterStartNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "task":
                case "approval":
                    await EnterTaskNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "condition":
                    await EnterConditionNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "notification":
                    await EnterNotificationNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "service":
                    await EnterServiceNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "delay":
                    await EnterDelayNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "end":
                    await EnterEndNodeAsync(
                        instance,
                        definition,
                        node);
                    break;

                case "parent":
                    await MoveNextAsync(
                        instance,
                        definition,
                        node.Id);
                    break;

                default:
                    throw new InvalidOperationException(
                        $"不支持的流程节点类型：{node.Type}");
            }
        }

        #endregion

        #region Start

        private async Task EnterStartNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            await AddHistoryAsync(
                instance.InstanceId,
                node.Id,
                node.Name,
                0,
                string.Empty,
                "start",
                string.Empty);

            await MoveNextAsync(
                instance,
                definition,
                node.Id);
        }

        #endregion

        #region Task

        private async Task EnterTaskNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            instance.CurrentNodeId = node.Id;

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);
            var taskKey = BuildTaskKey(
    instance.InstanceId,
    node.Id);
            // 防止重复创建待办
            var existing = await _taskRepo.GetOneAsync(
      x => x.TaskKey == taskKey);

            if (existing != null)
                return;

            var config = ParseTaskConfig(node);

            // 部门人员解析
            var assigneeIds = config.ResponsibleUserIds
                .Distinct()
                .Where(x => x > 0)
                .ToList();

            // 当前系统保持和原 TaskStep 一样：
            // 第一个人作为 AssigneeId。
            //
            // ResponsibleUserIds 保存全部处理人。
            if (assigneeIds.Count == 0)
            {
                await AddHistoryAsync(
                    instance.InstanceId,
                    node.Id,
                    node.Name,
                    0,
                    string.Empty,
                    "auto",
                    "未配置处理人，自动通过");

                await MoveNextAsync(
                    instance,
                    definition,
                    node.Id);

                return;
            }

            var now = DateTime.Now;

            var estimatedDays = Math.Max(
                config.EstimatedDurationDays,
                0);

            var reminderDays = Math.Max(
                config.ReminderBeforeDays,
                0);
            var key = BuildTaskKey(
    instance.InstanceId,
    node.Id);

            var task = new WorkflowTask
            {
                InstanceId = instance.InstanceId,
                TenantId = definition.TenantId,
                WorkflowId = definition.WorkflowId,
                WorkflowDefinitionId = definition.Id,
                NodeId = node.Id,
                NodeName = string.IsNullOrWhiteSpace(node.Name)
                    ? node.Id
                    : node.Name,

                AssigneeId = assigneeIds[0],
                TaskKey= key,
                ResponsibleUserIds = assigneeIds,
                ResponsibleDepartmentIds =
                    config.ResponsibleDepartmentIds,

                CcUserIds =
                    config.CcUserIds,

                EstimatedDurationDays =
                    estimatedDays,

                ReminderBeforeDays =
                    reminderDays,

                DueTime = now.AddDays(estimatedDays),

                ReminderTime = now.AddDays(
                    Math.Max(
                        estimatedDays - reminderDays,
                        0)),

                Status = "pending"
            };

            await _taskRepo.InsertAsync(task);

            // 保存当前任务 ID
            var variables = ReadVariables(instance);

            variables["TaskId_" + node.Id] = task.Id;

            instance.DataJson =
                JsonSerializer.Serialize(variables);

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);

            await SendMessageAsync(
                new WorkflowMessage
                {
                    Title = $"待办任务：{task.NodeName}",
                    TenantId = task.TenantId,
                    Content =
                        $"您有一个待办任务「{task.NodeName}」，" +
                        $"请在 {task.DueTime:yyyy-MM-dd HH:mm} 前处理。",
                    InstanceId = task.InstanceId,
                    TaskId = task.Id,
                    RecipientUserIds =
                        task.ResponsibleUserIds
                            .Concat(task.CcUserIds)
                            .Distinct()
                            .ToList()
                });
        }

        #endregion

        #region Condition

        /// <summary>
        /// 条件节点统一使用 JSON DSL 执行；同时兼容旧版字符串表达式。
        /// </summary>
        private static bool EvaluateCondition(
            string expression,
            Dictionary<string, object> variables)
        {
            return WorkflowConditionEvaluator.Evaluate(
                expression,
                variables);
        }

        #endregion

        #region Notification

        private async Task EnterNotificationNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            instance.CurrentNodeId = node.Id;

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);

            var config = ParseNotificationConfig(node);

            if (config.UserIds.Count > 0)
            {
                await SendMessageAsync(
                    new WorkflowMessage
                    {
                        Title = string.IsNullOrWhiteSpace(config.Title)
                            ? node.Name
                            : config.Title,

                        TenantId = definition.TenantId,

                        Content = string.IsNullOrWhiteSpace(config.Content)
                            ? $"流程节点「{node.Name}」通知"
                            : config.Content,

                        InstanceId = instance.InstanceId,

                        RecipientUserIds = config.UserIds
                    });
            }

            await AddHistoryAsync(
                instance.InstanceId,
                node.Id,
                node.Name,
                0,
                string.Empty,
                "notification",
                string.Empty);

            await MoveNextAsync(
                instance,
                definition,
                node.Id);
        }

        #endregion

        #region Service

        private async Task EnterServiceNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            instance.CurrentNodeId = node.Id;

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);

            /*
             * Service 节点这里先作为自动节点。
             *
             * 如果后面你需要：
             *
             * ServiceCode = "xxx"
             *
             * 可以增加：
             *
             * IWorkflowServiceHandler
             *
             * 根据 node.Config["serviceCode"]
             * 动态调用对应业务服务。
             */

            await AddHistoryAsync(
                instance.InstanceId,
                node.Id,
                node.Name,
                0,
                string.Empty,
                "service",
                string.Empty);

            await MoveNextAsync(
                instance,
                definition,
                node.Id);
        }

        #endregion

        #region Delay

        private async Task EnterDelayNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            instance.CurrentNodeId = node.Id;

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);

            /*
             * 第一版不要在这里 Thread.Sleep。
             *
             * 应该保存：
             *
             * WaitUntil
             *
             * 然后由 Furion Schedule / HostedService
             * 定期扫描 delay 节点。
             *
             * 当前先记录历史。
             */

            await AddHistoryAsync(
                instance.InstanceId,
                node.Id,
                node.Name,
                0,
                string.Empty,
                "delay",
                string.Empty);
        }

        #endregion

        #region End

        private async Task EnterEndNodeAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            VfWorkflowNode node)
        {
            instance.CurrentNodeId = node.Id;
            instance.Status = "completed";

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);

            await AddHistoryAsync(
                instance.InstanceId,
                node.Id,
                node.Name,
                0,
                string.Empty,
                "end",
                "流程完成");

            // 关闭所有遗留 pending task
            var tasks = await _taskRepo.GetListAsync(
                x =>
                    x.InstanceId == instance.InstanceId &&
                    x.Status == "pending");

            foreach (var task in tasks)
            {
                task.Status = "cancelled";

                await _taskRepo.UpdateAsync(
                    task.Id,
                    task,
                    x => x.Status == "pending");
            }
        }

        #endregion

        #region 流程推进

        /// <summary>
        /// 当前节点完成后寻找下一节点。
        /// </summary>
        private async Task MoveNextAsync(
            WorkflowInstance instance,
            WorkflowDefinition definition,
            string currentNodeId)
        {
            var edges = GetOutgoingEdges(
                definition,
                currentNodeId);

            if (edges.Count == 0)
            {
                var currentNode = definition.Nodes
                    .FirstOrDefault(x => x.Id == currentNodeId);

                if (currentNode != null &&
                    !string.Equals(
                        currentNode.Type,
                        "end",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        $"节点「{currentNode.Name}」没有后续节点");
                }

                return;
            }

            // 当前版本：
            //
            // 普通 task / approval：
            //     只能有一个默认出口。
            //
            // condition：
            //     在 EnterConditionNodeAsync 中处理。
            //
            // 如果普通节点配置多个出口，
            // 默认取第一条。
            var nextEdge = edges.FirstOrDefault();

            if (nextEdge == null ||
                string.IsNullOrWhiteSpace(nextEdge.Target))
            {
                throw new InvalidOperationException(
                    $"节点没有有效的后续边：{currentNodeId}");
            }

            var nextNode = definition.Nodes
                .FirstOrDefault(x =>
                    x.Id == nextEdge.Target);

            if (nextNode == null)
                throw new InvalidOperationException(
                    $"后续节点不存在：{nextEdge.Target}");

            await ExecuteFromNodeCoreAsync(
                instance,
                definition,
                nextNode.Id);
        }

        #endregion

        #region Definition

        private async Task<WorkflowDefinition> GetDefinitionAsync(
            string workflowId,
            int version)
        {
            var definitions = await _definitionRepo.GetListAsync(
                x =>
                    x.WorkflowId == workflowId &&
                    x.Status == "published");

            var definition = definitions
                .FirstOrDefault(x => x.Version == version);

            if (definition == null)
            {
                definition = definitions
                    .OrderByDescending(x => x.Version)
                    .FirstOrDefault();
            }

            return definition
                ?? throw new InvalidOperationException(
                    $"流程定义不存在：{workflowId} v{version}");
        }

        private static void ValidateDefinition(
            WorkflowDefinition definition)
        {
            if (definition.Nodes == null ||
                definition.Nodes.Count == 0)
            {
                throw new InvalidOperationException(
                    "流程定义没有节点");
            }

            var startNodes = definition.Nodes
                .Where(x =>
                    string.Equals(
                        x.Type,
                        "start",
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (startNodes.Count != 1)
                throw new InvalidOperationException(
                    $"流程必须且只能有一个开始节点，当前：{startNodes.Count}");

            var endNodes = definition.Nodes
                .Where(x =>
                    string.Equals(
                        x.Type,
                        "end",
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (endNodes.Count == 0)
                throw new InvalidOperationException(
                    "流程至少需要一个结束节点");

            var nodeIds = new HashSet<string>(
                definition.Nodes
                    .Select(x => x.Id)
                    .Where(x => !string.IsNullOrWhiteSpace(x)));

            foreach (var edge in definition.Edges ?? new List<VfWorkflowEdge>())
            {
                if (!nodeIds.Contains(edge.Source))
                    throw new InvalidOperationException(
                        $"流程边 Source 节点不存在：{edge.Source}");

                if (!nodeIds.Contains(edge.Target))
                    throw new InvalidOperationException(
                        $"流程边 Target 节点不存在：{edge.Target}");
            }
        }

        private static List<VfWorkflowEdge> GetOutgoingEdges(
            WorkflowDefinition definition,
            string nodeId)
        {
            return (definition.Edges ?? new List<VfWorkflowEdge>())
                .Where(x => x.Source == nodeId)
                .ToList();
        }

        #endregion

        #region History

        private async Task AddHistoryAsync(
            string instanceId,
            string nodeId,
            string nodeName,
            long operatorId,
            string operatorName,
            string action,
            string comment)
        {
            await _historyRepo.InsertAsync(
                new WorkflowHistory
                {
                    InstanceId = instanceId,
                    NodeId = nodeId,
                    NodeName = nodeName ?? string.Empty,
                    OperatorId = operatorId,
                    OperatorName = operatorName ?? string.Empty,
                    Action = action,
                    Comment = comment ?? string.Empty,
                    OperatedTime = DateTime.Now
                });
        }

        #endregion

        #region Instance

        private async Task<WorkflowInstance> GetInstanceAsync(
            string instanceId)
        {
            var instance = await _instanceRepo.GetOneAsync(
                x => x.InstanceId == instanceId);

            return instance
                ?? throw new InvalidOperationException(
                    $"流程实例不存在：{instanceId}");
        }

        #endregion

        #region FormData

        private static Dictionary<string, object> ReadVariables(
            WorkflowInstance instance)
        {
            if (string.IsNullOrWhiteSpace(instance.DataJson))
                return new Dictionary<string, object>();

            try
            {
                using var doc =
                    JsonDocument.Parse(instance.DataJson);

                return NormalizeDictionary(
                    JsonElementToDictionary(doc.RootElement));
            }
            catch
            {
                return new Dictionary<string, object>();
            }
        }

        private async Task MergeFormDataAsync(
            WorkflowInstance instance,
            string nodeId,
            Dictionary<string, object> formData)
        {
            var variables = ReadVariables(instance);

            variables[nodeId] = formData;

            instance.DataJson =
                JsonSerializer.Serialize(variables);

            await _instanceRepo.UpdateAsync(
                instance.Id,
                instance);
        }

        private static Dictionary<string, object>
            JsonElementToDictionary(JsonElement element)
        {
            if (element.ValueKind != JsonValueKind.Object)
                return new Dictionary<string, object>();

            var result = new Dictionary<string, object>();

            foreach (var property in element.EnumerateObject())
            {
                result[property.Name] =
                    NormalizeValue(property.Value);
            }

            return result;
        }

        #endregion

        #region TaskConfig

        private sealed class TaskNodeConfig
        {
            public List<long> ResponsibleUserIds { get; set; }
                = new();

            public List<long> ResponsibleDepartmentIds { get; set; }
                = new();

            public List<long> CcUserIds { get; set; }
                = new();

            public int EstimatedDurationDays { get; set; }

            public int ReminderBeforeDays { get; set; }
        }

        private static TaskNodeConfig ParseTaskConfig(
            VfWorkflowNode node)
        {
            var result = new TaskNodeConfig();

            if (string.IsNullOrWhiteSpace(node.Config))
                return result;

            try
            {
                using var doc =
                    JsonDocument.Parse(node.Config);

                var root = doc.RootElement;

                result.ResponsibleUserIds =
                    ReadLongList(
                        root,
                        "responsibleUserIds",
                        "assigneeIds");

                result.ResponsibleDepartmentIds =
                    ReadLongList(
                        root,
                        "responsibleDepartmentIds");

                result.CcUserIds =
                    ReadLongList(
                        root,
                        "ccUserIds");

                result.EstimatedDurationDays =
                    ReadInt(
                        root,
                        "estimatedDurationDays");

                result.ReminderBeforeDays =
                    ReadInt(
                        root,
                        "reminderBeforeDays");
            }
            catch
            {
                // 配置错误时返回空配置。
            }

            return result;
        }

        #endregion

        #region NotificationConfig

        private sealed class NotificationNodeConfig
        {
            public List<long> UserIds { get; set; }
                = new();

            public string Title { get; set; } = string.Empty;

            public string Content { get; set; } = string.Empty;
        }

        private static NotificationNodeConfig
            ParseNotificationConfig(
                VfWorkflowNode node)
        {
            var result =
                new NotificationNodeConfig();

            if (string.IsNullOrWhiteSpace(node.Config))
                return result;

            try
            {
                using var doc =
                    JsonDocument.Parse(node.Config);

                var root = doc.RootElement;

                result.UserIds =
                    ReadLongList(
                        root,
                        "userIds",
                        "recipientUserIds",
                        "assigneeIds");

                if (root.TryGetProperty(
                        "title",
                        out var title))
                {
                    result.Title =
                        title.GetString() ?? string.Empty;
                }

                if (root.TryGetProperty(
                        "content",
                        out var content))
                {
                    result.Content =
                        content.GetString() ?? string.Empty;
                }
            }
            catch
            {
            }

            return result;
        }

        #endregion

        #region Condition

       

        private static bool CompareValues(
            object? left,
            object? right,
            string op)
        {
            if (left == null && right == null)
                return op == "==" || op == ">=" || op == "<=";

            if (left == null || right == null)
                return op == "!=";

            if (TryDecimal(
                    left,
                    out var leftNumber) &&
                TryDecimal(
                    right,
                    out var rightNumber))
            {
                return op switch
                {
                    "==" => leftNumber == rightNumber,
                    "!=" => leftNumber != rightNumber,
                    ">" => leftNumber > rightNumber,
                    "<" => leftNumber < rightNumber,
                    ">=" => leftNumber >= rightNumber,
                    "<=" => leftNumber <= rightNumber,
                    _ => false
                };
            }

            var leftString =
                Convert.ToString(
                    left,
                    CultureInfo.InvariantCulture) ?? string.Empty;

            var rightString =
                Convert.ToString(
                    right,
                    CultureInfo.InvariantCulture) ?? string.Empty;

            var compare =
                string.Compare(
                    leftString,
                    rightString,
                    StringComparison.OrdinalIgnoreCase);

            return op switch
            {
                "==" => compare == 0,
                "!=" => compare != 0,
                ">" => compare > 0,
                "<" => compare < 0,
                ">=" => compare >= 0,
                "<=" => compare <= 0,
                _ => false
            };
        }

        private static bool TryDecimal(
            object value,
            out decimal result)
        {
            switch (value)
            {
                case decimal decimalValue:
                    result = decimalValue;
                    return true;

                case int intValue:
                    result = intValue;
                    return true;

                case long longValue:
                    result = longValue;
                    return true;

                case double doubleValue:
                    result = (decimal)doubleValue;
                    return true;

                case float floatValue:
                    result = (decimal)floatValue;
                    return true;

                case string stringValue:
                    return decimal.TryParse(
                        stringValue,
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out result);

                default:
                    result = 0;
                    return false;
            }
        }

        private static object ParseConditionValue(
            string value)
        {
            value = value.Trim();

            if (value.StartsWith("\"") &&
                value.EndsWith("\""))
            {
                return value.Substring(
                    1,
                    value.Length - 2);
            }

            if (value.StartsWith("'") &&
                value.EndsWith("'"))
            {
                return value.Substring(
                    1,
                    value.Length - 2);
            }

            if (bool.TryParse(
                    value,
                    out var boolValue))
            {
                return boolValue;
            }

            if (decimal.TryParse(
                    value,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out var decimalValue))
            {
                return decimalValue;
            }

            return value;
        }

        private static bool GetVariableBool(
            string name,
            Dictionary<string, object> variables)
        {
            if (!variables.TryGetValue(
                    name,
                    out var value))
            {
                return false;
            }

            if (value is bool boolValue)
                return boolValue;

            return bool.TryParse(
                value?.ToString(),
                out var result) &&
                result;
        }

        #endregion

        #region Mongo / Repository

        /// <summary>
        /// 为了支持 CAS，需要 Repository 增加带条件的 Update。
        /// </summary>
        private static Dictionary<string, object>
            NormalizeDictionary(
                IDictionary<string, object>? source)
        {
            var result =
                new Dictionary<string, object>();

            if (source == null)
                return result;

            foreach (var item in source)
            {
                result[item.Key] =
                    NormalizeValue(item.Value);
            }

            return result;
        }

        private static object? NormalizeValue(
            object? value)
        {
            if (value == null)
                return null;

            if (value is JsonElement element)
                return NormalizeJsonElement(element);

            if (value is IDictionary<string, object> dictionary)
                return NormalizeDictionary(dictionary);

            if (value is System.Collections.IDictionary dictionary2)
            {
                var result =
                    new Dictionary<string, object>();

                foreach (
                    System.Collections.DictionaryEntry item
                    in dictionary2)
                {
                    var key =
                        item.Key?.ToString();

                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        result[key] =
                            NormalizeValue(item.Value)!;
                    }
                }

                return result;
            }

            if (value is System.Collections.IEnumerable enumerable &&
                value is not string)
            {
                var list =
                    new List<object>();

                foreach (var item in enumerable)
                {
                    list.Add(
                        NormalizeValue(item)!);
                }

                return list;
            }

            return value;
        }

        private static object? NormalizeJsonElement(
            JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return null;

                case JsonValueKind.Object:
                    return JsonElementToDictionary(element);

                case JsonValueKind.Array:
                    return element
                        .EnumerateArray()
                        .Select(NormalizeJsonElement)
                        .ToList();

                case JsonValueKind.String:
                    if (element.TryGetDateTime(
                            out var dateTime))
                    {
                        return dateTime;
                    }

                    return element.GetString()
                           ?? string.Empty;

                case JsonValueKind.Number:
                    if (element.TryGetInt64(
                            out var longValue))
                    {
                        return longValue;
                    }

                    if (element.TryGetDecimal(
                            out var decimalValue))
                    {
                        return decimalValue;
                    }

                    return element.GetDouble();

                case JsonValueKind.True:
                    return true;

                case JsonValueKind.False:
                    return false;

                default:
                    return element.ToString();
            }
        }

        #endregion

        #region Message

        private async Task SendTaskMessageAsync(
            WorkflowTask task,
            string action,
            string operatorName)
        {
            await SendMessageAsync(
                new WorkflowMessage
                {
                    Title =
                        $"任务已{(action == "complete"
                            ? "完成"
                            : "跳过")}：{task.NodeName}",

                    TenantId = task.TenantId,

                    Content =
                        $"任务「{task.NodeName}」已由 " +
                        $"{operatorName}处理。",

                    InstanceId = task.InstanceId,

                    TaskId = task.Id,

                    RecipientUserIds =
                        task.ResponsibleUserIds
                            .Concat(task.CcUserIds)
                            .Append(task.AssigneeId)
                            .Distinct()
                            .ToList()
                });
        }

        private async Task SendMessageAsync(
            WorkflowMessage message)
        {
            foreach (var sender in _messageSenders)
            {
                await sender.SendAsync(message);
            }
        }

        #endregion

        #region Instance Lock

        private static async Task WithInstanceLockAsync(
            string instanceId,
            Func<Task> action)
        {
            var semaphore =
                _instanceLocks.GetOrAdd(
                    instanceId,
                    _ => new SemaphoreSlim(1, 1));

            await semaphore.WaitAsync();

            try
            {
                await action();
            }
            finally
            {
                semaphore.Release();

                // 尽量清理无用锁
                if (semaphore.CurrentCount == 1)
                {
                    _instanceLocks.TryRemove(
                        new KeyValuePair<string, SemaphoreSlim>(
                            instanceId,
                            semaphore));
                }
            }
        }

        #endregion

        #region Helpers

        private static List<long> ReadLongList(
            JsonElement root,
            params string[] names)
        {
            foreach (var name in names)
            {
                if (!root.TryGetProperty(
                        name,
                        out var value))
                {
                    continue;
                }

                if (value.ValueKind !=
                    JsonValueKind.Array)
                {
                    continue;
                }

                return value
                    .EnumerateArray()
                    .Select(x =>
                    {
                        if (x.ValueKind ==
                            JsonValueKind.Number &&
                            x.TryGetInt64(
                                out var id))
                        {
                            return id;
                        }

                        return long.TryParse(
                            x.GetString(),
                            out var id2)
                            ? id2
                            : 0;
                    })
                    .Where(x => x > 0)
                    .Distinct()
                    .ToList();
            }

            return new List<long>();
        }

        private static int ReadInt(
            JsonElement root,
            string name)
        {
            return root.TryGetProperty(
                       name,
                       out var value) &&
                   value.TryGetInt32(
                       out var result)
                ? result
                : 0;
        }
        private static string BuildTaskKey(
    string instanceId,
    string nodeId)
        {
            if (string.IsNullOrWhiteSpace(instanceId))
                throw new ArgumentException(
                    "InstanceId 不能为空",
                    nameof(instanceId));

            if (string.IsNullOrWhiteSpace(nodeId))
                throw new ArgumentException(
                    "NodeId 不能为空",
                    nameof(nodeId));

            return $"{instanceId}:{nodeId}";
        }

        #endregion
    }
}