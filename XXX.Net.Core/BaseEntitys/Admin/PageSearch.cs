using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core
{
    public class PageSearch
    {
        /// <summary>
        /// 搜索字段类型
        /// </summary>
        public int InputType { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>
        /// 默认值
        /// </summary>
        public object? Value { get; set; } = null;
        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; } = string.Empty;
        /// <summary>
        /// 提示
        /// </summary>
        public string Placeholder { get; set; } = string.Empty;


        /// <summary>数据源类型：0=无 1=字典 2=数据表 3=枚举 4=API</summary>
        public int DataSourceType { get; set; } = 0;


        /// <summary>数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址）</summary>
        public string? DataSourceValue { get; set; }

        /// <summary>
        /// 数据源参数（JSON格式）
        /// </summary>
        public string? DataSourcePars { get; set; }

        /// <summary>
        /// 选项
        /// </summary>
        public List<PagedOptions>? Options = null;
    }
}
