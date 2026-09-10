using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    public class PageRenderDto
    {
        /// <summary>
        /// 页面Id
        /// </summary>
        public long? MenuId { get; set; } 

        /// <summary>
        /// 页面编码
        /// </summary>
        public string MenuCode { get; set; } = string.Empty;

        /// <summary>
        /// 指定某租户下
        /// </summary>
        public string TenantId { get; set; } = string.Empty;
    }
}
