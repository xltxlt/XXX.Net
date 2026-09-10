using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys
{
    public class BaseDataSource
    {
        public string FieldName { get; set; } 


        /// <summary>数据源类型</summary>
        public int DataSourceType { get; set; } = 0;


        /// <summary>数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址）</summary>
        public string DataSourceValue { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public int HttpType { get; set; } = (int)HttpTypeEnum.HttpPost;

        /// <summary>
        /// 数据源参数（JSON格式）
        /// </summary>
        public string DataSourcePars { get; set; } = null;

        /// <summary>
        /// headers
        /// </summary>
        public string DataSourceHeaders { get; set; } = null;
    }
}
