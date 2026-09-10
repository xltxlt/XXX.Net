using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PageDetailOption<TOutput>where TOutput:class
    {
        /// <summary>
        /// 详情
        /// </summary>
        public TOutput Detail { get; set; } = null;
        /// <summary>
        /// 选项
        /// </summary>
        public Dictionary<string, List<PagedOptions>> Options { get; set; } = new Dictionary<string, List<PagedOptions>>();


    }
}
