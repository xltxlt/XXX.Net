using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Config.Dto;
using XXX.Net.Core.Services.User.Dto;

namespace XXX.Net.Core.Services.Config
{
    public class SysConfigService : BaseService<SysConfig, SysConfigDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysConfigService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}
