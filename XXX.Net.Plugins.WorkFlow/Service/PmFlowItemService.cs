using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;\nusing Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Event;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    [ApiDescriptionSettings("Workflow")]

    public class PmFlowItemService : BaseTenantService<PmFlowItem, PmFlowItemDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;

        private readonly IEventBus _eventBus;
        public PmFlowItemService(IEventBus eventBus,IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
            _eventBus = eventBus;
        }

        #region 重写父类 基础方法
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Add", Order = 400), HttpPost]
        [DisplayName("新增")]
        [UnitOfWork]
        public override async Task<PmFlowItem> Add(PmFlowItemDto dto)
        {
            if (dto.PmFlowTempId <= 0)
                throw new InvalidOperationException("请选择流程模板");

            // 项目流程项只保存模板 Id，真正发起时需要知道对应的 WorkflowId。
            // 这里在创建项目流程项时完成绑定，避免 CAP 消费时再依赖用户上下文。
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

            var entity = await base.Add(dto);

            entity.WorkflowId = flowTemp.WorkflowId;
            entity.WorkflowDefinitionId = flowTemp.WorkflowDefinitionId;
            entity.Version = flowTemp.LastVersion;

            await _msRepository.Master<PmFlowItem>()
                .UpdateAsync(entity.Id, entity);

            // 项目流程项事务提交后，通过 CAP 事件异步启动 WorkflowCore。
            await _eventBus.PublishAsync(
                PmEvents.PmItemStart,
                new BaseEvent<PmFlowItem>(PmEvents.PmItemStart, entity));

            return entity;
        }
        #endregion
    }
}