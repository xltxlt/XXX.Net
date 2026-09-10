using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuButtonDto : BaseTenantUpdate
    {

        /// <summary>
        /// 菜单Id
        /// </summary>
        public long MenuId { get; set; }
        /// <summary>
        /// 按钮显示名
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// 背景色
        /// </summary>
        public string BgColor { get; set; } = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// 字段类型
        /// </summary>
        [OptionEnum(typeof(MenuButtonTypeEnum))]
        public int ButtonType { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 目标应用
        [OptionEnum(typeof(TargetAppEnum))]

        public int Target { get; set; } = 1;

        /// <summary>说明</summary>
        public string Describe { get; set; } = string.Empty;
    }
}
