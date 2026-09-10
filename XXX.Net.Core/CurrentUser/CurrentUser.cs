using XXX.Net.Core.Const;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace XXX.Net.Core.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ClaimsPrincipal User =>
            _httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated == true;

        public long UserId
        {
            get
            {
                var value = User?
                    .FindFirst(ClaimConst.UserId)?
                    .Value;

                return long.TryParse(value, out long id)
                    ? id
                    : 0;
            }
        }

        public string UserName =>
            User?.FindFirst(ClaimConst.UserName)?.Value;

        public long TenantId
        {
            get
            {
                var value = User?
                    .FindFirst(ClaimConst.TenantId)?
                    .Value;

                return long.TryParse(value, out var tenantId)
                    ? tenantId
                    : 0;
            }

        }

        public string RealName=>
           User?.FindFirst(ClaimConst.RealName)?.Value;
    }
}
