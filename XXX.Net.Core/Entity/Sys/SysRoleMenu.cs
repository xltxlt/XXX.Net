using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysRoleMenu : BaseEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysRoleMenu, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// 菜单Id
        /// </summary>
        public long MenuId { get; set; }

        [JsonIgnore]
        public virtual SysRole Role { get; set; }

        [JsonIgnore]

        public virtual SysMenu Menu { get; set; }
        public void Configure(EntityTypeBuilder<SysRoleMenu> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.HasOne(x => x.Role)
               .WithMany(x => x.Menus)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Cascade);

            entityBuilder
                .HasOne(x => x.Menu)
                .WithMany()
                .HasForeignKey(x => x.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder
                .HasIndex(x => new
                {
                    x.RoleId,
                    x.MenuId
                })
                .IsUnique();
            BaseEntity.BaseConfigure<SysRoleMenu>(entityBuilder);
        }
    }
}