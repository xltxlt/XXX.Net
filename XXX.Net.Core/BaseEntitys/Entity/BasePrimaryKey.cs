using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using XXX.Net.Core.IdGenerator;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public class BasePrimaryKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
        public long Id { get; set; }
        public static void BaseConfigure<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity : BasePrimaryKey
        {
            entity.Property(x => x.Id).HasValueGenerator<SnowflakeValueGenerator>();
        }
    }
}
