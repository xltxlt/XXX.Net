using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public abstract class BaseTenantParentSonEntity<TSon> : BaseParentSonEntity<TSon>,ITenantEntity
    where TSon : BaseSonEntity
    {

        /// <summary>
        /// 租户
        /// </summary>
        public long TenantId { get; set; }


        public new static void BaseConfigure<TEntity>(
            EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseTenantParentSonEntity<TSon>
        {
            BaseParentSonEntity<TSon>.BaseConfigure(builder);
        }
    }
}
