using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Service.Dto;
using XXX.Net.Plugins.WorkFlow.Models;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 流程实例服务：启动流程、查询实例
    /// </summary>
    [ApiDescriptionSettings("Workflow")]

    public class WorkflowInstanceService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowInstance> _instanceRepo;
        private readonly IWorkFlowRepository<WorkflowDefinition> _defRepo;
        private readonly IWorkflowHost _host;

        /// <summary>
        /// 当前应用进程已经注册到 WorkflowCore 的流程定义。
        /// Key = WorkflowId:Version。
        /// 注意：这里记录的是“流程定义是否注册”，不是“流程实例是否启动”。
        /// 一个定义可以被多个 PmFlowItem 启动多次。
        /// </summary>
        private static readonly ConcurrentDictionary<string, byte> _registeredDefinitions =
            new ConcurrentDictionary<string, byte>();

        /// <summary>
        /// 防止多个 PmFlowItem 第一次使用同一个流程定义时并发 RegisterWorkflow。
        /// </summary>
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _registerLocks =
            new ConcurrentDictionary<string, SemaphoreSlim>();

        public WorkflowInstanceService(
            IWorkFlowRepository<WorkflowInstance> instanceRepo,
            IWorkFlowRepository<WorkflowDefinition> defRepo,
            IWorkflowHost host)
        {
            _instanceRepo = instanceRepo;
            _defRepo = defRepo;
            _host = host;
        }

        /// <summary>
        /// 启动流程实例，返回实例 Id
        /// </summary>
        [HttpPost]
        public async Task<string> Start(string workflowId, Dictionary<string, object>? data)
        {
            var def = (await _defRepo.GetListAsync(d => d.WorkflowId == workflowId && d.Status == "published"))
                .OrderByDescending(d => d.Version).FirstOrDefault()
                ?? throw new InvalidOperationException("流程定义不存在");

            EnsureWorkflowRegistered(def);

            var variables = data ?? new Dictionary<string, object>();
            var taskName = variables.TryGetValue("taskName", out var value) ? value?.ToString() : null;
            if (string.IsNullOrWhiteSpace(taskName))
                throw new ArgumentException("任务名称不能为空");

            var flowData = new FlowData
            {
                WorkflowId = workflowId,
                Variables = variables,
            };
            var instanceId = await _host.StartWorkflow(workflowId, def.Version, flowData);

            await _instanceRepo.InsertAsync(new WorkflowInstance
            {
                TenantId = def.TenantId,
                InstanceId = instanceId,
                WorkflowId = workflowId,
                TaskName = taskName,
                Version = def.Version,
                Status = "running",
                DataJson = JsonSerializer.Serialize(data ?? new Dictionary<string, object>()),
            });
            return instanceId;
        }

        /// <summary>
        /// 根据项目流程项启动工作流。
        /// PmFlowItem 创建成功后由 CAP 消费者调用，真正启动 WorkflowCore。
        /// </summary>
        public async Task<string> StartByPmFlowItem(PmFlowItem item, Dictionary<string, object> startFormData)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (!item.Enabled) throw new InvalidOperationException("项目流程项已禁用");
            if (item.Id <= 0) throw new InvalidOperationException("项目流程项 Id 无效");
            if (string.IsNullOrWhiteSpace(item.WorkflowId))
                throw new InvalidOperationException("项目流程项未绑定 WorkflowId");

            var exists = (await _instanceRepo.GetListAsync(x => x.PmFlowItemId == item.Id))
                .FirstOrDefault();
            if (exists != null)
                return exists.InstanceId;

            var def = (await _defRepo.GetListAsync(d =>
                    d.Id == item.WorkflowDefinitionId &&
                    d.WorkflowId == item.WorkflowId &&
                    d.Version == item.Version &&
                    d.Status == "published"))
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"项目流程项绑定的流程定义不存在或未发布：{item.WorkflowId} v{item.Version}");

            if (def.TenantId != item.TenantId)
                throw new InvalidOperationException("流程定义与项目流程项不属于同一租户");

            // 注册的是 WorkflowDefinition，而不是 PmFlowItem。
            // 同一个 WorkflowId + Version 可以被多个 PmFlowItem 共用。
            EnsureWorkflowRegistered(def);

            var startNode = def.Nodes?.FirstOrDefault(x => x.Type == "start");
            if (startNode == null || string.IsNullOrWhiteSpace(startNode.Id))
                throw new InvalidOperationException("流程定义缺少开始节点");

            var startForm = startFormData ?? new Dictionary<string, object>();
            var variables = new Dictionary<string, object>
            {
                ["PmFlowItemId"] = item.Id,
                ["PmFlowTempId"] = item.PmFlowTempId,
                ["taskName"] = string.IsNullOrWhiteSpace(item.Name)
                    ? $"项目流程-{item.Id}"
                    : item.Name,
                ["Name"] = item.Name,
                ["Description"] = item.Description,
                ["PlanStartTime"] = item.PlanStartTime,
                ["PlanEndTime"] = item.PlanEndTime,
                ["StartNodeId"] = startNode.Id,
                ["StartFormData"] = startForm,
                // 与任务节点表单保持相同的数据组织方式：按节点 Id 保存。
                [startNode.Id] = startForm,
            };

            var flowData = new FlowData
            {
                WorkflowId = item.WorkflowId,
                Variables = variables,
            };

            var instanceId = await _host.StartWorkflow(item.WorkflowId, def.Version, flowData);

            await _instanceRepo.InsertAsync(new WorkflowInstance
            {
                TenantId = item.TenantId,
                PmFlowItemId = item.Id,
                InstanceId = instanceId,
                WorkflowId = item.WorkflowId,
                TaskName = variables["taskName"]?.ToString() ?? string.Empty,
                Version = def.Version,
                Status = "running",
                DataJson = JsonSerializer.Serialize(variables),
            });

            return instanceId;
        }

        /// <summary>
        /// 确保指定版本的流程定义已经注册到 WorkflowCore。
        ///
        /// 注册粒度：WorkflowId + Version
        /// 启动限制：PmFlowItemId
        /// 两者不能混为一谈。
        /// </summary>
        private void EnsureWorkflowRegistered(WorkflowDefinition def)
        {
            if (def == null)
                throw new ArgumentNullException(nameof(def));

            if (string.IsNullOrWhiteSpace(def.WorkflowId))
                throw new InvalidOperationException("流程定义 WorkflowId 不能为空");

            if (def.Version <= 0)
                throw new InvalidOperationException("流程定义 Version 无效");

            var key = $"{def.WorkflowId}:{def.Version}";

            if (_registeredDefinitions.ContainsKey(key))
                return;

            var semaphore = _registerLocks.GetOrAdd(
                key,
                _ => new SemaphoreSlim(1, 1));

            semaphore.Wait();
            try
            {
                // Double Check，避免并发线程重复注册。
                if (_registeredDefinitions.ContainsKey(key))
                    return;

                var wcDef = WorkflowDefinitionConverter.Convert(def);
                _host.Registry.RegisterWorkflow(wcDef);

                _registeredDefinitions.TryAdd(key, 0);
            }
            finally
            {
                semaphore.Release();
            }
        }

        [HttpGet]
        public async Task<List<WorkflowInstance>> List()
        {
            return (await _instanceRepo.GetListAsync(_ => true)).OrderByDescending(x => x.CreatedTime).ToList();
        }

        [HttpGet]
        public async Task<WorkflowInstance> Detail(string instanceId)
        {
            return (await _instanceRepo.GetListAsync(i => i.InstanceId == instanceId)).FirstOrDefault()
                ?? throw new InvalidOperationException("流程实例不存在");
        }
    }
}
