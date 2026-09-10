using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuFieldDto: BaseUpdate
    {
        /// <summary>所属菜单ID</summary>
        public long MenuId { get; set; }

        /// <summary>字段显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>事件名</summary>
        public string EventName { get; set; } = string.Empty;
        /// <summary>对应数据库字段名</summary>
        public string FieldName { get; set; } = string.Empty;

        /// <summary>
        /// 宽度
        /// </summary>
        public string Width { get; set; } = null;


        /// <summary>显示类型</summary>
        [OptionEnum(typeof(PageTableFieldTypeEnum))]
        public int FieldType { get; set; }

        /// <summary>搜索框类型（文本框/下拉/日期等）</summary>
        [OptionEnum(typeof(PageSearchTypeEnum))]
        public int SearchType { get; set; }

        /// <summary>
        /// 浮动类型
        /// </summary>
        [OptionEnum(typeof(MenuFieldFloatTypeEnum))]
        public int FloatType { get; set; } = 0;

        /// <summary>
        /// 合计行
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool TotalRow { get; set; }
        /// <summary>
        /// 合计行文本
        /// </summary>
        public string TotalRowText { get; set; }

        /// <summary>
        /// 初始隐藏
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool InitHide { get; set; } = false;

        /// <summary>
        /// 对齐方式
        /// </summary>

        [OptionEnum(typeof(MenuFieldAlignTypeEnum))]
        public int AlignType { get; set; } = 0;


        /// <summary>
        /// 应用搜索
        /// </summary>

        [OptionEnum(typeof(EnabledEnum))]
        public bool SearchField { get; set; } = true;

        /// <summary>
        /// 模板
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>终端：1=PC 2=App</summary>
        [OptionEnum(typeof(TargetAppEnum))]
        public int Target { get; set; } = 1;
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }


        /// <summary>说明</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 提示文本
        /// </summary>
        public string Placeholder { get; set; } = string.Empty;

        [OptionEnum(typeof(DataSourceTypeEnum))]

        /// <summary>数据源类型：0=无 1=字典 2=数据表 3=枚举 4=API</summary>
        public int DataSourceType { get; set; } = 0;


        /// <summary>数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址）</summary>
        public string DataSourceValue { get; set; } = string.Empty;

        /// <summary>
        /// 数据源参数（JSON格式）
        /// </summary>
        public string DataSourcePars { get; set; } = null;
    }
}
