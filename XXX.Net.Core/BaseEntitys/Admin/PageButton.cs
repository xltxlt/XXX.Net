using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    /// <summary>
    /// 页面按钮
    /// </summary>
    public class PageButton
    {

        /// <summary>
        /// 文本
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>

        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public string BgColor { get; set; } = string.Empty;

        /// <summary>
        /// 事件名
        /// </summary>
        public string EventName { get; set; } = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public string Describe { get; set; } = string.Empty;
    }
}
