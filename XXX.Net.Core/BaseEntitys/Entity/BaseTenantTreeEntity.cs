using XXX.Net.Core.Entity.Sys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public class BaseTenantTreeEntity:BaseTreeEntity
    {
        public long TenantId { get; set; }
        public virtual SysTenant Tenant { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        public static new void BaseConfigure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseTenantTreeEntity
        {
            BaseTreeEntity.BaseConfigure<TEntity>(builder);

            builder.HasOne(m => m.Tenant)
                       .WithMany()
                       .HasForeignKey(b => b.TenantId)
                       .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
