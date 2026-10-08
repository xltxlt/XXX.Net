using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.Services.Base;
using XXX.Net.Plugins.DingTalk.Service.Dto;
using XXX.NET.Plugin.DingTalk;

namespace XXX.Net.Plugins.DingTalk.Service
{
    [ApiDescriptionSettings(DingTalkConst.GroupName, Order = 110)]
    public class DingTalkTenantAppService : BaseTenantService<DingTalkTenantApp, DingTalkTenantAppDto>, IDynamicApiController
    {
        private readonly IMSRepository _msRepository;
        public DingTalkTenantAppService(IMSRepository msRepository, ICurrentUser currentUser) 
            : base(msRepository, currentUser)
        {
            _msRepository = msRepository;
        }

        /// <summary>
        /// 获取详情 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DisplayName("获取详情")]
        [ApiDescriptionSettings(Name = "DetailByTenant", Order = 100), HttpGet]
        public virtual async Task<DingTalkTenantApp> DetailByTenant(long tenantId)
        {
            return await _msRepository.Slave<DingTalkTenantApp>().AsQueryable().Where(w=>w.TenantId==tenantId).FirstOrDefaultAsync()??new DingTalkTenantApp();
        }
    }
}
