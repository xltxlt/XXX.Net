using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Dep.Dto
{
    public class UserDepRolesDto
    {
        public long UserId { get; set; }

        public Dictionary<long, List<long>> DepRoles { get; set; }
    }
}
