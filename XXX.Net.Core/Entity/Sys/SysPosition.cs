using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysPosition : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysPosition, MasterDbContextLocator, SlaveDbContextLocator>
    {


        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>说明</summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
        public void Configure(EntityTypeBuilder<SysPosition> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            BaseTenantEntity.BaseConfigure<SysPosition>(entityBuilder);
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);


            //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
            //entityBuilder.Property(e => e.CreatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.CreatedTime)
            //    .HasDefaultValueSql("(getdate())")
            //    .HasColumnType("datetime");
            //entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);
            //entityBuilder.Property(e => e.General).HasDefaultValue(true);
            //entityBuilder.Property(e => e.UpdatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.UpdatedTime).HasColumnType("datetime");

        }
    }
}