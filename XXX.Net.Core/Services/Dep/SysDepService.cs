using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Tree;
using XXX.Net.Core.Services.Org.Dto;
using XXX.Net.Core.Services.Position.Dto;

namespace XXX.Net.Core.Services.Org
{
    public class SysDepService : BaseTreeService<SysDepartment, SysDepDto, SysDepTreeOutput>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysDepService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}
