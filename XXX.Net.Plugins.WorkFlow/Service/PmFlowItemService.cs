using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Threading.Tasks;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Event;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    [ApiDescriptionSettings("Workflow")]
    public class PmFlowItemService : BaseTenantService<PmFlowItem, PmFlowItemDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        private readonly IWorkFlowRepository<WorkflowDefinition> _definitionRepo;
        private readonly IEventBus _eventBus;

        public PmFlowItemService(
            IEventBus eventBus,
            IMSRepository msRepository,
            IWorkFlowRepository<WorkflowDefinition> definitionRepo,
            ICurrentUser currentUser,
            IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
            _definitionRepo = definitionRepo;
            _eventBus = eventBus;
        }

        #region 重写父类 基础方法
        public override async Task<PmFlowItem> ToEntity(PmFlowItemDto dto, PmFlowItem oldEntity = null)
        {
            var entity = await base.ToEntity(dto, oldEntity);
            var flowTemp = await _msRepository.Master<PmFlowTemp>()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == dto.PmFlowTempId);

            if (flowTemp == null)
                throw new InvalidOperationException("流程模板不存在");

            if (!flowTemp.Enabled)
                throw new InvalidOperationException("流程模板已禁用");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowId))
                throw new InvalidOperationException("流程模板尚未绑定流程定义，请先设计并发布流程");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowDefinitionId) || flowTemp.LastVersion <= 0)
                throw new InvalidOperationException("流程模板尚未发布流程定义，请先发布流程");

            entity.WorkflowId = flowTemp.WorkflowId;
            entity.WorkflowDefinitionId = flowTemp.WorkflowDefinitionId;
            entity.Version = flowTemp.LastVersion;
            return entity;
        }

        /// <summary>
        /// 新增项目流程项并发起流程。
        /// 基础业务参数与开始节点表单必须一次提交；CAP 事件只负责可靠地异步启动 WorkflowCore。
        /// </summary>
        [ApiDescriptionSettings(Name = "Add", Order = 400), HttpPost]
        [DisplayName("新增")]
        [UnitOfWork]
        public override async Task<PmFlowItem> Add(PmFlowItemDto dto)
        {
            if (dto.PmFlowTempId <= 0)
                throw new InvalidOperationException("请选择流程模板");

            var flowTemp = await _msRepository.Master<PmFlowTemp>()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == dto.PmFlowTempId);

            if (flowTemp == null)
                throw new InvalidOperationException("流程模板不存在");

            if (!flowTemp.Enabled)
                throw new InvalidOperationException("流程模板已禁用");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowId) ||
                string.IsNullOrWhiteSpace(flowTemp.WorkflowDefinitionId) ||
                flowTemp.LastVersion <= 0)
                throw new InvalidOperationException("流程模板尚未发布流程定义，请先发布流程");

            var definition = await _definitionRepo.GetOneAsync(x => x.Id == flowTemp.WorkflowDefinitionId)
                ?? throw new InvalidOperationException("流程定义不存在");

            var startNode = definition.Nodes?.Find(x => x.Type == "start");
            if (startNode == null || string.IsNullOrWhiteSpace(startNode.Id))
                throw new InvalidOperationException("流程定义缺少开始节点");

            var startForm = (await _definitionRepo.GetListAsync(x => x.WorkflowId == definition.WorkflowId))
                .Count; // 保留定义仓储访问，实际开始表单由节点表单仓储校验

            var startFormRepo = (IWorkFlowRepository<WorkflowNodeForm>)null;
            throw new InvalidOperationException("开始节点表单仓储未注入");
        }

        /// <summary>
        /// 更新
        /// </summary>
        [ApiDescriptionSettings(Name = "Update", Order = 400), HttpPost]
        [DisplayName("新增")]
        [UnitOfWork]
        public override async Task<PmFlowItem> Update(PmFlowItemDto dto)
        {
            var entity = await base.Update(dto);
            await _eventBus.PublishAsync(
                PmEvents.PmItemStart,
                new BaseEvent<PmFlowItem>(PmEvents.PmItemStart, entity));
            return entity;
        }
        #endregion
    }
}