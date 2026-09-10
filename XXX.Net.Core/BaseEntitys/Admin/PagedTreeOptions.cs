using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedTreeOptions
    {

        /// <summary>
        /// 父节点
        /// </summary>
        public long ParentId { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>

        public long Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PagedTreeOptions> Children { get; set; } = new List<PagedTreeOptions>();
    }
}
