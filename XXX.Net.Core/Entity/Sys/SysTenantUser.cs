using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysTenantUser : BaseTenantEntity,
        IEntity<MasterDbContextLocator, SlaveDbContextLocator>,
        IEntityTypeBuilder<SysTenantUser, MasterDbContextLocator, SlaveDbContextLocator>
    {
        public long UserId { get; set; }

        public bool Enabled { get; set; } = true;

        [JsonIgnore]
        public virtual SysUser User { get; set; }

        public void Configure(EntityTypeBuilder<SysTenantUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasIndex(x => new { x.TenantId, x.UserId }).IsUnique();
            entityBuilder.Property(x => x.Enabled).HasDefaultValue(true);

            BaseTenantEntity.BaseConfigure<SysTenantUser>(entityBuilder);
        }
    }
}
