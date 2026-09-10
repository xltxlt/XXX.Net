using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Admin;

namespace XXX.Net.Core.Services.Option.Attributes
{
    public class OtherOptionSource
    {
        /// <summary>
        /// 关联字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 数据源名称
        /// </summary>
        public string OptionSoureName { get; set; }

        /// <summary>
        /// 选项来源
        /// </summary>
        public OptionAttribute OptionAttr { get; set; }

        /// <summary>
        /// 当前选项源使用的固定查询条件
        /// </summary>
        public List<PagedCustomWhere> Where { get; set; } = new();

        /// <summary>
        /// 是否为树形
        /// </summary>
        public bool TreeOption { get; set; }
    }
}
