using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Plugins.WorkFlow.Entity
{
    public class PmFlowItem : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<PmFlowItem, MasterDbContextLocator, SlaveDbContextLocator>
    {   

        public long PmFlowTempId { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        /// <summary>
        ///   计划开始时间
        /// </summary>
        public DateTime PlanStartTime { get; set; }

        /// <summary>
        ///   计划结束时间
        /// </summary>
        public DateTime PlanEndTime { get; set; }

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
        public Int32 Version { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; } = string.Empty;
    

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;

        public void Configure(EntityTypeBuilder<PmFlowItem> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {

            BaseTenantEntity.BaseConfigure<PmFlowItem>(entityBuilder);
            entityBuilder.Property(e => e.WorkflowId).HasMaxLength(64);
            entityBuilder.Property(e => e.WorkflowDefinitionId).HasMaxLength(64);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);

        }
    }
}
