using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Role.Dto
{
    public class SetRolePermissionDto
    {
        public long RoleId { get; set; }

        public List<long> MenuIds { get; set; } = new();

        public List<long> MenuFieldIds { get; set; } = new();

        public List<long> MenuButtonIds { get; set; } = new();
    }
}
