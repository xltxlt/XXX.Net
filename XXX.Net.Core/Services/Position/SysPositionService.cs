using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Config.Dto;
using XXX.Net.Core.Services.Position.Dto;

namespace XXX.Net.Core.Services.Position
{
    public class SysPositionService : BaseService<SysPosition, SysPositionDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysPositionService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
    }
}
