using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysTenant:BaseTreeEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysTenant, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;


        /// <summary>备注</summary>
        public string Remark { get; set; } = null;

        public void Configure(EntityTypeBuilder<SysTenant> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Code).HasMaxLength(64);

            BaseTreeEntity.BaseConfigure<SysTenant>(entityBuilder);

            entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);
        }
    }
}
