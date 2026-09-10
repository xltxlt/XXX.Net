using Furion.DatabaseAccessor;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.BaseEntitys.Entity
{

    public  class BaseEntity:BasePrimaryKey
    {
    
        public bool Deleted { get; set; }


        public DateTime CreatedTime { get; set; }

        public long CreatedBy { get; set; }

        public string CreatedByName { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public long? UpdatedBy { get; set; }

        public string UpdatedByName { get; set; }

        public string Name { get; set; }
        public static void BaseConfigure<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : BaseEntity
        {
            entity.Property(x => x.Id).HasValueGenerator<SnowflakeValueGenerator>();
            entity.Property(x => x.Name).HasMaxLength(128);
            entity.Property(x => x.CreatedByName).HasMaxLength(64);
            entity.Property(x => x.UpdatedByName).HasMaxLength(64);
            entity.Property(x => x.CreatedTime).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
            entity.Property(x => x.UpdatedTime).HasColumnType("datetime");
            entity.HasQueryFilter(x => !x.Deleted);
        }
    }
}
