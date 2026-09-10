using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    public class PageFields
    {

        /// <summary>
        /// 文本
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int FieldType { get; set; } = 0;

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public string BgColor { get; set; } = string.Empty;

        

        /// <summary>
        /// 事件名
        /// </summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>
        /// 数据
        /// </summary>
        public Object? Data { get; set; }
    }
}
