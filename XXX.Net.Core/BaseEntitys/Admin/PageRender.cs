using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    public class PageRender
    {
        /// <summary>
        /// 按钮
        /// </summary>
        public List<PageButton> Buttons { get; set; } = new List<PageButton>();
        /// <summary>
        /// 表头字段
        /// </summary>
        public List<PageFields> Fileds { get; set; } = new List<PageFields>();
        /// <summary>
        /// 表格按钮
        /// </summary>
        public List<PageTableButton> TableButtons { get; set; } = new List<PageTableButton>();
        /// <summary>
        /// 搜索字段
        /// </summary>
        public List<PageSearch> Searchs { get; set; } = new List<PageSearch>();
        /// <summary>
        /// 页面基础信息
        /// </summary>
        public PageBasicsInfo Basics { get; set; } = new PageBasicsInfo();
    }
}
