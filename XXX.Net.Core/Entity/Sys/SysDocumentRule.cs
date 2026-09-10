using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Enums;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysDocumentRule:BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysDocumentRule, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 单据类型，用于区分同一租户下的不同单据规则。
        /// </summary>
        public int DocumentType { get; set; }

        /// <summary>
        /// 单据号规则编码，作为业务生成单据号时的查询标识。
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 单据号前缀。
        /// </summary>
        public string Prefix { get; set; } = string.Empty;
        /// <summary>
        /// 单据号中的日期格式；为空时不生成日期部分。
        /// </summary>
        public string DateFormat { get; set; } = string.Empty;

        /// <summary>
        /// 流水号补零后的最小长度。
        /// </summary>
        public int SequenceLength { get; set; } = 6;

        /// <summary>
        /// 流水号重置周期。
        /// </summary>
        public DocumentNumberResetTypeEnum ResetType { get; set; } = DocumentNumberResetTypeEnum.Daily;

        /// <summary>
        /// 是否启用当前单据号规则。
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 配置单据号规则的数据表映射。
        /// </summary>
        public void Configure(EntityTypeBuilder<SysDocumentRule> builder, DbContext dbContext, Type dbContextLocator)
        {
            BaseTenantEntity.BaseConfigure(builder);

            builder.Property(x => x.Code)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(x => x.Prefix)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.DateFormat)
                .HasMaxLength(50);

            builder.Property(x => x.ResetType)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.HasIndex(x => new
            {
                x.TenantId,
                x.DocumentType
            })
            .IsUnique();
        }
    }
}
