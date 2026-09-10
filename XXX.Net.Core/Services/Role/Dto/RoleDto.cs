using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Role.Dto
{
    public class RoleDto : BaseTenantUpdate
    {
        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;


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


        /// <summary>说明</summary>
        public string Description { get; set; } = null;
    }
}
