using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXX.Net.Core.Services.Base.Dto;

namespace XXX.Net.Core
{
    public class PagedOptions: IPagedTreeOutput<PagedOptions>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; } = null;

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disaebled { get; set; } = false;

        /// <summary>
        /// 说明
        /// </summary>
        public string Desc { get; set; } = string.Empty;


        /// <summary>
        /// 子元素
        /// </summary>

        public List<PagedOptions> Children { get; set; } = new();
    }
}
