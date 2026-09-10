using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace XXX.Net.Core.Entity.Sys {


    /// <summary>
    /// 系统配置
    /// </summary>
    public class SysConfig : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysConfig, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>配置键</summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>配置值</summary>
        public string Value { get; set; } = string.Empty;

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
        public void Configure(EntityTypeBuilder<SysConfig> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            BaseTenantEntity.BaseConfigure<SysConfig>(entityBuilder);
            entityBuilder.Property(e => e.Key).HasMaxLength(64);
            entityBuilder.Property(e => e.Value).HasMaxLength(512);
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
