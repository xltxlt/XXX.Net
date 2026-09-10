using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    public class PmFlowTempDto: BaseTenantUpdate
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }=string.Empty;
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 是否全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
    }
}
