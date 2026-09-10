using Furion.JsonSerialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.IdGenerator;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public abstract class BaseParentSonEntity<TSon> : BaseEntity
    where TSon : BaseSonEntity
    {
        /// <summary>
        /// 子级集合
        /// </summary>
        public virtual ICollection<TSon> Children { get; set; }
            = new List<TSon>();

        public new static void BaseConfigure<TEntity>(
            EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseParentSonEntity<TSon>
        {
            BaseEntity.BaseConfigure(builder);

            builder
                .HasMany(x => x.Children)
                .WithOne()                       // 子表没有 ParentItem
                .HasForeignKey(x => x.ParentId)  // 子表 ParentId
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
