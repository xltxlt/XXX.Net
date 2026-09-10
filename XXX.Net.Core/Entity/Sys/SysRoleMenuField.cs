using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysRoleMenuField  : BasePrimaryKey,IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysRoleMenuField, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public long RoleId { get; set; }


        /// <summary>
        /// 按钮
        /// </summary>
        public long MenuFieldId { get; set; }

        [JsonIgnore]
        public virtual SysRole Role { get; set; }


        [JsonIgnore]

        public virtual SysMenuField MenuField { get; set; }

        public void Configure(EntityTypeBuilder<SysRoleMenuField> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder
              .HasOne(x => x.Role)
              .WithMany(x => x.MenuFields)
              .HasForeignKey(x => x.RoleId)
              .OnDelete(DeleteBehavior.Cascade);


            entityBuilder
                .HasOne(x => x.MenuField)
                .WithMany()
                .HasForeignKey(x => x.MenuFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder
                .HasIndex(x => new
                {
                    x.RoleId,
                    x.MenuFieldId
                })
                .IsUnique();
            BasePrimaryKey.BaseConfigure<SysRoleMenuField>(entityBuilder);
        }
    }
}