using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Menu.Dto;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu
{
    public class SysMenuButtonService : BaseService<SysMenuButton, SysMenuButtonDto>, IDynamicApiController
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysMenuButtonService(IMSRepository msRepository, ICurrentUser currentUser)
            : base(msRepository, currentUser)
        {
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}