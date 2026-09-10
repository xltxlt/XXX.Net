using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    public class PageBasicsInfo
    {
        public PageBasicsInfo() { }
        public string PageName { get; set; } = string.Empty;

        /// <summary>
        /// 页面编码
        /// </summary>
        public string PageCode { get; set; } = string.Empty;

        /// <summary>
        /// 是否自定义页面
        /// </summary>
        public bool IsCustom { get; set; } = false;

        /// <summary>
        /// 是否树形页面
        /// </summary>
        public bool IsTreePage { get; set; } = false;
        /// <summary>
        /// 是否分页
        /// </summary>
        public bool IsPagination { get; set; } = true;
        /// <summary>
        /// 最大表格按钮数量
        /// </summary>
        public int MaxTableButton { get; set; } = 5;

    }
}
