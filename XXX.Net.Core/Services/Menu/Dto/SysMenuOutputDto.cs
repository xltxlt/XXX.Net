using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuOutputDto
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [JsonPropertyName("MenuName")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 菜单别名
        /// </summary>
        public string Alias { get; set; } = string.Empty;
        /// <summary>
        /// 菜单编码
        /// </summary>
        [JsonPropertyName("MenuCode")]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 权限标识
        /// </summary>
        public string Identify { get; set; } = string.Empty;
        /// <summary>
        /// 路由
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

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


        public List<SysMenuTableButtonDto> Buttons { get; set; }
            = new();

        public List<SysMenuHandleButtonDto> TableButtons { get; set; }
            = new();

        public List<SysMenuTableFieldDto> Fields { get; set; }
            = new();

    }
}
