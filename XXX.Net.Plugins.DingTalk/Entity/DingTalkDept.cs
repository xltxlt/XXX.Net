using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;

namespace XXX.NET.Plugin.DingTalk
{
    /// <summary>
    /// 钉钉部门信息
    /// </summary>
    [Table("ding_talk_dept")]
public class DingTalkDept : BaseTenantTreeEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<DingTalkDept, MasterDbContextLocator, SlaveDbContextLocator>
    {
        

        /// <summary>关联的系统部门 Id。</summary>
        public long? SysDepartmentId { get; set; }


        /// <summary>钉钉企业内部门 Id；需与 TenantId 组合使用。</summary>
        [Required]
        public long DeptId { get; set; }
        public void Configure(EntityTypeBuilder<DingTalkDept> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {

            BaseTenantTreeEntity.BaseConfigure<DingTalkDept>(entityBuilder);
        }

    }
}
