using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 节点表单设计服务：保存/读取节点表单 JSON（MongoDB 存储）
    /// </summary>

    [ApiDescriptionSettings("Workflow")]

    public class WorkflowNodeFormService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowNodeForm> _repo;

        public WorkflowNodeFormService(IWorkFlowRepository<WorkflowNodeForm> repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<WorkflowNodeForm> Save(WorkflowFormDto dto)
        {
            var existing = await _repo.GetListAsync(f => f.WorkflowId == dto.WorkflowId && f.NodeId == dto.NodeId);
            var entity = existing.FirstOrDefault() ?? new WorkflowNodeForm();

            entity.WorkflowId = dto.WorkflowId;
            entity.NodeId = dto.NodeId;
            entity.FormJson = dto.FormJson ?? "[]";
            entity.AttrDataJson = dto.AttrDataJson ?? "{}";
            entity.ButtonListJson = dto.ButtonListJson ?? "[]";

            if (existing.Count == 0) await _repo.InsertAsync(entity);
            else await _repo.UpdateAsync(entity.Id, entity);
            return entity;
        }

        [HttpGet]
        public async Task<WorkflowNodeForm?> Get(string workflowDeginitionId, string nodeId)
        {
            return (await _repo.GetListAsync(f => f.WorkflowDeginitionId == workflowDeginitionId && f.NodeId == nodeId)).LastOrDefault();
        }
    }
}
