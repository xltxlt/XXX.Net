using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysRoleMenuButton : BasePrimaryKey, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysRoleMenuButton, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public long RoleId { get; set; }

    

        /// <summary>
        /// 按钮
        /// </summary>
        public long MenuButtonId { get; set; }

        [JsonIgnore]
        public virtual SysRole Role { get; set; }



        [JsonIgnore]

        public virtual SysMenuButton MenuButton { get; set; }

        public void Configure(EntityTypeBuilder<SysRoleMenuButton> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder
            .HasOne(x => x.Role)
            .WithMany(x => x.MenuButtons)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);


            entityBuilder
                .HasOne(x => x.MenuButton)
                .WithMany()
                .HasForeignKey(x => x.MenuButtonId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder
                .HasIndex(x => new
                {
                    x.RoleId,
                    x.MenuButtonId
                })
                .IsUnique();
            BasePrimaryKey.BaseConfigure<SysRoleMenuButton>(entityBuilder);
        }
    }
}