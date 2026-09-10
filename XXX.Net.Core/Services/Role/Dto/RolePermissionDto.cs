using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Role.Dto
{
    public class RolePermissionDto
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 菜单权限
        /// </summary>
        public List<RoleMenuPermissionOutput> Menus { get; set; } = new();
    }
}
