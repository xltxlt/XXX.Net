using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuDto:BaseTenantUpdateTree<SysMenu>
    {
        /// <summary>所属菜单ID</summary>
        public long MenuId { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; } = string.Empty;

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 权限标识（如 user:list、user:add）
        /// </summary>
        public string Identify { get; set; } = string.Empty;

        /// <summary>
        /// 菜单类型：1=目录 2=页面 3=按钮
        /// </summary>
        [OptionEnum(typeof(MenuTypeEnum))]
        public int MenuType { get; set; }

        /// <summary>
        /// 终端：1=PC 2=小程序 3=App 
        /// </summary>
        [OptionEnum(typeof(TargetAppEnum))]
        public int Target { get; set; } = 1;

        /// <summary>
        /// 路由地址
        /// </summary>
        public string Route { get; set; } = null;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = null;
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; } = null;
        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 页面类型
        /// </summary>

        [OptionEnum(typeof(PageTypeEum))]
        public int PageType { get; set; }

        /// <summary>
        /// 最大表格按钮数量
        /// </summary>
        public int MaxTableButton { get; set; } = 5;
    }
}
