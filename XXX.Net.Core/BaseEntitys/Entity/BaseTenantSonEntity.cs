using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public class BaseTenantSonEntity : BaseEntity,ITenantEntity
    {
        /// <summary>
        /// 租户
        /// </summary>
        public long TenantId { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        public static new void BaseConfigure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseTenantSonEntity
        {
            BaseEntity.BaseConfigure(builder);
            builder.HasIndex(x => x.ParentId);

        }
    }
}
