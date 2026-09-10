using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Dto
{
    public class BaseTenantUpdate:BaseUpdate
    {
        /// <summary>
        /// 租户
        /// </summary>
        [OptionEntity(typeof(SysTenant))]
        public long TenantId { get; set; }

    }
}
