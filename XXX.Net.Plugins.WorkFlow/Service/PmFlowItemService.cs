using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var entity=await base.Add(dto);
            await _eventBus.PublishAsync(PmEvents.PmItemStart,new BaseEvent<PmFlowItem>(PmEvents.PmItemStart,entity));
            return entity;
        }
        #endregion
    }
}