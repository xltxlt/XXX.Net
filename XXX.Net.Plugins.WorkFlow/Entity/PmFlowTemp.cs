using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Plugins.WorkFlow.Entity
{
    public class PmFlowTemp : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<PmFlowTemp, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = string.Empty;
        /// <summary>
        /// 模板Id
        /// </summary>
        public string WorkflowId { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string WorkflowDefinitionId { get; set; } = string.Empty;
        /// <summary>
        /// 模板版本
        /// </summary>
        public Int32 LastVersion { get; set; }

        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// 是否全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;

        public void Configure(EntityTypeBuilder<PmFlowTemp> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {

            BaseTenantEntity.BaseConfigure<PmFlowTemp>(entityBuilder);
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
