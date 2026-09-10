using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Entity.Sys;

namespace XXX.Net.Core.Services.Tenant.Dto
{
    public class SysTenantDto:BaseUpdateTree<SysTenant>
    {

        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;


        /// <summary>备注</summary>
        public string Remark { get; set; } = null;
    }
}
