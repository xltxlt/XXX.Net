using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 流程定义服务：保存/查询/发布流程定义（MongoDB 存储，发布时转换为 WorkflowCore 并注册）
    /// </summary>
    [ApiDescriptionSettings("Workflow")]
    public class WorkflowDefinitionService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowDefinition> _repo;
        private readonly IWorkFlowRepository<WorkflowNodeForm> _nodeFormRepo;
        private readonly IWorkflowHost _host;
        private readonly IMSRepository _msRepository;

        public WorkflowDefinitionService(IWorkFlowRepository<WorkflowDefinition> repo, IWorkFlowRepository<WorkflowNodeForm> nodeFormRepo, IWorkflowHost host, IMSRepository msRepository)
        {
            _repo = repo;
            _host = host;
            _msRepository = msRepository;
            _nodeFormRepo = nodeFormRepo;
        }

        /// <summary>
        /// 保存流程定义（新增或更新）
        /// </summary>
        [HttpPost]
        [UnitOfWork]
        public async Task<WorkflowDefinition> Save(WorkflowDefinitionDto workflowDefinitionDto)
        {
            var dto = workflowDefinitionDto.WorkflowDefinition;
            var WorkflowNodeForms = workflowDefinitionDto.WorkflowNodeForm;
            if (string.IsNullOrEmpty(dto.WorkflowId))
            {
                dto.WorkflowId = Guid.NewGuid().ToString("N");
            }
            var existing = await _repo.GetListAsync(d => d.WorkflowId == dto.WorkflowId);
            var oldEntity = existing.LastOrDefault();
            var version = oldEntity != null ? (oldEntity.Version + 1) : 1;
            var mPmFlowTemp= await _msRepository.Master<PmFlowTemp>().AsQueryable().Where(w=>w.Id== workflowDefinitionDto.PmFlowTempId).FirstOrDefaultAsync();
            if (mPmFlowTemp == null) {
                throw Oops.Oh("未找到对应的实体类");
            }
            
            
            WorkflowDefinition? entity = new WorkflowDefinition();
            entity.WorkflowId = dto.WorkflowId;
            entity.Name = dto.Name;
            entity.Nodes = dto.Nodes ?? new List<VueFlowModel.VfWorkflowNode>();
            entity.Edges = dto.Edges ?? new List<VueFlowModel.VfWorkflowEdge>();
            entity.Status = "draft";
            entity.Version = version;
            await _repo.InsertAsync(entity);
            var mlAddNodeFormTemp = new List<WorkflowNodeForm>();
            foreach (var nodeFormTemp in WorkflowNodeForms) {
                nodeFormTemp.WorkflowDeginitionId = entity.Id;
                nodeFormTemp.WorkflowId = entity.WorkflowId;
                nodeFormTemp.Version = entity.Version;
                mlAddNodeFormTemp.Add(nodeFormTemp);
            }
           
            await _nodeFormRepo.InsertManyAsync(mlAddNodeFormTemp);

            mPmFlowTemp.WorkflowId = dto.WorkflowId;
            mPmFlowTemp.LastVersion = version;
            mPmFlowTemp.WorkflowDefinitionId = entity.Id;
            await _msRepository.Master<PmFlowTemp>().UpdateAsync(mPmFlowTemp);
            return entity;
        }

        /// <summary>
        /// 发布流程：转换为 WorkflowCore 定义并注册
        /// </summary>
        [HttpPost]
        public async Task<WorkflowDefinition> Publish(string workflowId)
        {
            var entity = (await _repo.GetListAsync(d => d.WorkflowId == workflowId)).FirstOrDefault()
                ?? throw new InvalidOperationException("流程定义不存在");

            var wcDef = WorkflowDefinitionConverter.Convert(entity);
            _host.Registry.RegisterWorkflow(wcDef);

            entity.Status = "published";
            await _repo.UpdateAsync(entity.Id, entity);
            return entity;
        }

        /// <summary>
        /// 流程定义列表
        /// </summary>
        [HttpGet]
        public async Task<List<WorkflowDefinition>> List()
        {
            return await _repo.GetListAsync(_ => true);
        }

        /// <summary>
        /// 流程定义详情
        /// </summary>
        [HttpGet]
        public async Task<WorkflowDefinition> Detail(string workflowDefinitionId)
        {
            return (await _repo.GetListAsync(d => d.Id == workflowDefinitionId)).LastOrDefault()
                ?? throw new InvalidOperationException("流程定义不存在");
        }
    }
}
