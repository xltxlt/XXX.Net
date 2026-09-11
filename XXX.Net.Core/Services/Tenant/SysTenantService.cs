using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Base.Tree;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Tenant.Dto;
using XXX.Net.Core.Services.User.Dto;

namespace XXX.Net.Core.Services.Tenant
{
    public class SysTenantService : BaseTreeService<SysTenant, SysTenantDto, SysTenantTreeOutput>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysTenantService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
        /// <summary>
        /// 租户列表
        /// </summary>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "TenantList", Order = 400), HttpPost]
        [DisplayName("租户列表")]
        public  async Task<List<SysTenantDto>> TenantList()
        {

            var tPath="/"+ _currentUser.TenantId+"/";
            var mlTenant= await _msRepository.Slave<SysTenant>().AsQueryable().AsNoTracking().Where(x => x.Path.Contains(tPath) || x.Id == _currentUser.TenantId).ToListAsync();
            return mlTenant.Adapt<List<SysTenantDto>>();
        }
    }
}
