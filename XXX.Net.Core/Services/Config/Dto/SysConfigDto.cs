using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Config.Dto
{
    public class SysConfigDto:BaseTenantUpdate
    {
        /// <summary>配置键</summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>配置值</summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>说明</summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
    }
}
