using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace XXX.Net.Core.Entity.Sys {

    public class SysDictData : BaseSonEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysDictData, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>类型编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>值</summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>排序</summary>
        public int Sort { get; set; }
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

        public virtual SysDictType DictType { get; set; }
        public void Configure(EntityTypeBuilder<SysDictData> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Label).HasMaxLength(64);
            entityBuilder.Property(e => e.Value).HasMaxLength(512);
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);
            entityBuilder.Property(e => e.General).HasDefaultValue(true);

            BaseSonEntity.BaseConfigure<SysDictData>(entityBuilder);
            //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
            //entityBuilder.Property(e => e.CreatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.CreatedTime)
            //    .HasDefaultValueSql("(getdate())")
            //    .HasColumnType("datetime");

            //entityBuilder.Property(e => e.UpdatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.UpdatedTime).HasColumnType("datetime");

        }
    }

}

