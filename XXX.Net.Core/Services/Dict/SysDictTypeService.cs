using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Dict.Dto;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;

namespace XXX.Net.Core.Services.Dict
{
    public class SysDictTypeService : BaseFatherSonService<SysDictType,SysDictData, SysDictTypeDto,SysDictDataDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysDictTypeService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}
