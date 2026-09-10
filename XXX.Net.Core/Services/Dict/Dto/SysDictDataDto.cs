using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Dict.Dto
{
    public class SysDictDataDto:BaseUpdate
    {
        /// <summary>显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>值</summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>排序</summary>
        public int Sort { get; set; }
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
