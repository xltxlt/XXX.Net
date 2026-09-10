using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuTableFieldDto:BaseDataSource
    {

        /// <summary>字段显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>事件名</summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>显示类型</summary>
        public int FieldType { get; set; }

        /// <summary>搜索框类型（文本框/下拉/日期等）</summary>
        public int SearchType { get; set; }

        /// <summary>列宽</summary>
        public string Width { get; set; } = null;


        /// <summary>说明</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 合计行
        /// </summary>
        public bool TotalRow { get; set; }
        /// <summary>
        /// 合计行文本
        /// </summary>
        public string TotalRowText { get; set; }

        /// <summary>
        /// 初始隐藏
        /// </summary>
        public bool InitHide { get; set; } = false;

        /// <summary>
        /// 对齐方式
        /// </summary>

        public int AlignType { get; set; } = 0;

        /// <summary>
        /// 浮动类型
        /// </summary>
        public int FloatType { get; set; } = 0;

        /// <summary>
        /// 应用搜索
        /// </summary>

        public bool SearchField { get; set; } = true;


        /// <summary>
        /// 自定义模板
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// 提示文本
        /// </summary>
        public string Placeholder { get; set; } = string.Empty;
    }
}
