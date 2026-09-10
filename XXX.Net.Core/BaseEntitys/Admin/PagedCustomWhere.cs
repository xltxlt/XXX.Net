using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedCustomWhere
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FiledName { get; set; } = string.Empty;
        /// <summary>
        /// 搜索类型
        /// </summary>
        public int ConditionalType { get; set; } = 0;
        /// <summary>
        /// 字段值
        /// </summary>
        public string FiledValue { get; set; } = string.Empty;
    }
}
