
using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using IdGen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.Extensions;
using XXX.Net.Core.Services.Base;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    [ApiDescriptionSettings("Workflow")]
    public class PmFlowTempService : BaseService<PmFlowTemp, PmFlowTempDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        private readonly IWorkFlowRepository<WorkflowDefinition> _workflowDefinitionRepo;
        private readonly IWorkFlowRepository<WorkflowNodeForm> _workflowNodeFormRepo;

        public PmFlowTempService(IMSRepository msRepository,
            IWorkFlowRepository<WorkflowDefinition> workflowDefinitionRepo,
            IWorkFlowRepository<WorkflowNodeForm> workflowNodeFormRepo,
            ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _workflowDefinitionRepo = workflowDefinitionRepo;
            _workflowNodeFormRepo = workflowNodeFormRepo;
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Delete", Order = 600), HttpPost]
        [DisplayName("删除")]
        [UnitOfWork]
        public override async Task Delete(long id)
        {

            await _msRepository.Master<PmFlowTemp>().DeleteNowAsync(id);

            var mlDefinition = await _workflowDefinitionRepo.GetListAsync(w => w.PmFlowTempId == id);
            var definitionIds = mlDefinition.Select(s => s.Id);
            if (definitionIds.Count() > 0) await _workflowNodeFormRepo.DeleteAsync(w => definitionIds.Contains(w.WorkflowDeginitionId));
            await _workflowDefinitionRepo.DeleteAsync(w => w.PmFlowTempId == id);
            return;
        }
        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchDelete", Order = 600), HttpPost]
        [DisplayName("批量删除")]
        [UnitOfWork]
        public override async Task BatchDelete(List<long> ids)
        {
            await _msRepository.Master<PmFlowTemp>().DeleteNowAsync(ids);
            var mlDefinition = await _workflowDefinitionRepo.GetListAsync(w => ids.Contains(w.PmFlowTempId));
            var definitionIds = mlDefinition.Select(s => s.Id);
            if (definitionIds.Count() > 0) await _workflowNodeFormRepo.DeleteAsync(w => definitionIds.Contains(w.WorkflowDeginitionId));
            await _workflowDefinitionRepo.DeleteAsync(w => ids.Contains(w.PmFlowTempId));
            return;
        }

        /// <summary>
        /// 逻辑删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "LogicDelete", Order = 610), HttpPost]
        [DisplayName("逻辑删除")]
        public override async Task LogicDelete(long id)
        {
            var mOldEntity = await _msRepository.Master<PmFlowTemp>().FindOrDefaultAsync(id);
            if (mOldEntity == null) throw Oops.Oh("无对应数据");
            mOldEntity.Deleted = true;
            await _msRepository.Master<PmFlowTemp>().UpdateIncludeAsync(mOldEntity, new[] {
               "Deleted"
            });
            var mlDefinition = await _workflowDefinitionRepo.GetListAsync(w => w.PmFlowTempId == id);
            var definitionIds = mlDefinition.Select(s => s.Id);
            if (definitionIds.Count() > 0) await _workflowNodeFormRepo.DeleteAsync(w => definitionIds.Contains(w.WorkflowDeginitionId));
            await _workflowDefinitionRepo.DeleteAsync(w => w.PmFlowTempId == id);
            return;
        }
        /// <summary>
        /// 逻辑删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchLogicDelete", Order = 620), HttpPost]
        [DisplayName("逻辑删除")]
        [UnitOfWork]
        public override async Task BatchLogicDelete(List<long> ids)
        {

            var mlOldEntity = await _msRepository.Master<PmFlowTemp>().AsQueryable().Where(w => ids.Contains(w.Id)).ToListAsync();
            if (mlOldEntity == null || mlOldEntity.Count() == 0) throw Oops.Oh("无对应数据");
            foreach (var item in mlOldEntity)
            {
                item.Deleted = true;
            }
            await _msRepository.Master<PmFlowTemp>().UpdateAsync(mlOldEntity);
            var mlDefinition = await _workflowDefinitionRepo.GetListAsync(w => ids.Contains(w.PmFlowTempId));
            var definitionIds = mlDefinition.Select(s => s.Id);
            if (definitionIds.Count() > 0) await _workflowNodeFormRepo.DeleteAsync(w => definitionIds.Contains(w.WorkflowDeginitionId));
            await _workflowDefinitionRepo.DeleteAsync(w => ids.Contains(w.PmFlowTempId));
            return;
        }


    }
}
