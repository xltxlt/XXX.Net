// -----------------------------------------------------------------------------
// Generate By Furion Tools v4.9.9.74
// -----------------------------------------------------------------------------

using Furion.DatabaseAccessor;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XXX.Net.Core.Entity.Sys;

public partial class SysUser :BaseEntity,  IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysUser, MasterDbContextLocator, SlaveDbContextLocator>
{
    public string Password { get; set; }

    public string Salt { get; set; }

    public string RealName { get; set; }
    public string UserName { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;

    public string Mobile { get; set; }

    public string Email { get; set; }

    public string Code { get; set; }

    public string Avatar { get; set; }


    public long? ManagerUserId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<SysUserDepRole> UserDepRoles { get; set; }
    public void Configure(EntityTypeBuilder<SysUser> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        // 使用无参数构造函数配置，支持设计时和运行时
        entityBuilder.Property(e => e.Avatar).HasMaxLength(512);
        entityBuilder.Property(e => e.Code).HasMaxLength(64);
 
        entityBuilder.Property(e => e.Email).HasMaxLength(128);
        entityBuilder.Property(e => e.Mobile).HasMaxLength(32);
        entityBuilder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(256);
        entityBuilder.Property(e => e.RealName).HasMaxLength(64);
        entityBuilder.Property(e => e.Salt).HasMaxLength(64);
        entityBuilder.Property(e => e.UserName)
           .IsRequired()
           .HasMaxLength(64);
        entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);

        BaseEntity.BaseConfigure<SysUser>(entityBuilder);
        //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
        //entityBuilder.Property(e => e.CreatedByName).HasMaxLength(64);
        //entityBuilder.Property(e => e.CreatedTime)
        //    .HasDefaultValueSql("(getdate())")
        //    .HasColumnType("datetime");
        //entityBuilder.Property(e => e.UpdatedByName).HasMaxLength(64);
        //entityBuilder.Property(e => e.UpdatedTime).HasColumnType("datetime");


    }
}
