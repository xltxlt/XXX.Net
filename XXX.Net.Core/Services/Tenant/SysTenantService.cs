using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Tree;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Tenant.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Services.Base.Dto;

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
    }
}
