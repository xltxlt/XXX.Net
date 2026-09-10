using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuSerachFieldDto: BaseDataSource
    {

        /// <summary>字段显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>事件名</summary>
        public string EventName { get; set; } = string.Empty;


        /// <summary>搜索框类型（文本框/下拉/日期等）</summary>
        public int SearchType { get; set; }

        /// <summary>说明</summary>
        public string Description { get; set; } = string.Empty;



    }
}
