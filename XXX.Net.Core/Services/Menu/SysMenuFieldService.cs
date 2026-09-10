using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Menu.Dto;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu
{
    public class SysMenuFieldService : BaseService<SysMenuField, SysMenuFieldDto>, IDynamicApiController
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysMenuFieldService(IMSRepository msRepository, ICurrentUser currentUser)
            : base(msRepository, currentUser)
        {
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}
