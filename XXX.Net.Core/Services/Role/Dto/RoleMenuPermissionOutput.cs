using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Role.Dto
{
    public class RoleMenuPermissionOutput
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 是否拥有菜单权限
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// 按钮
        /// </summary>
        public List<SysMenuCompose> MenuButtons { get; set; } = new();

        /// <summary>
        /// 字段
        /// </summary>
        public List<SysMenuCompose> MenuFields { get; set; } = new();
    }

}
