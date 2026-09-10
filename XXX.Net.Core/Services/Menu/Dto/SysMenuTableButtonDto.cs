using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuTableButtonDto
    {

        /// <summary>字段显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>事件名称</summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BgColor { get; set; }


        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>说明</summary>
        public string Describe { get; set; } = string.Empty;
    }
}
