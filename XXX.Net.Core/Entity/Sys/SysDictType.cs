using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using XXX.Net.Core.BaseEntitys.Dto;
namespace XXX.Net.Core.Entity.Sys
{
    public class SysDictType : BaseParentSonEntity<SysDictData>, ITenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysDictType, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>类型编码</summary>
        public string Code { get; set; } = string.Empty;


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
        public long TenantId { get; set; }

        public void Configure(EntityTypeBuilder<SysDictType> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            BaseParentSonEntity<SysDictData>.BaseConfigure<SysDictType>(entityBuilder);
            //entityBuilder.Property(e => e.Name).HasMaxLength(64);
            //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
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