using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Entity;
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

            var wcDef = WorkflowDefinitionConverter.Convert(def);
            _host.Registry.RegisterWorkflow(wcDef);

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
