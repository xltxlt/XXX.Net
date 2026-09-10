using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Option.Attribute;
using SharpCompress.Compressors.Arj;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Dto
{
    public class BaseTenantUpdateTree<TTreeEntiy> : BaseUpdateTree<TTreeEntiy> where TTreeEntiy:BaseTreeEntity,new ()
    {
        /// <summary>
        /// 租户
        /// </summary>
        [OptionEntity(typeof(SysTenant), nameof(SysTenant.Id), nameof(SysTenant.Name))]
        public long TenantId { get; set; }
    }
}
