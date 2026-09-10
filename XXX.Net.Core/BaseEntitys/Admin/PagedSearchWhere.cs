using XXX.Net.Core.BaseEntitys.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedSearchWhere
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; } = string.Empty;
        /// <summary>
        /// 搜索类型
        /// </summary>
        //public PageSearchTypeEnum SearchType { get; set; } = PageSearchTypeEnum.Input;
        public int SearchType { get; set; } =(int) PageSearchTypeEnum.Input;

        /// <summary>
        /// 字段值
        /// </summary>
        public string FieldValue { get; set; } = string.Empty;
    }
}
