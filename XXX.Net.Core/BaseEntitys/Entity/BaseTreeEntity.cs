using XXX.Net.Core.Entity.Sys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Entity
{
    public class BaseTreeEntity : BaseEntity
    {


        /// <summary>
        /// /1/2/3/
        /// </summary>
        [AdaptIgnore]
        public string Path {get; set;}

        /// <summary>
        /// 
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ClassLevel { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="builder"></param>
        public static new void BaseConfigure<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseTreeEntity
        {
            BaseEntity.BaseConfigure<TEntity>(builder);

            builder.HasIndex(m => m.ParentId);
            builder.HasIndex(m => m.Path);
        }

        

    }
}
