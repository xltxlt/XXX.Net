using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XXX.Net.Core.DbContextLocator;
using Furion.DatabaseAccessor;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.DingTalk
{
    /// <summary>
    /// 钉钉部门信息
    /// </summary>
    [Table("ding_talk_dept")]
public class DingTalkDept : IEntity<MasterDbContextLocator, SlaveDbContextLocator>
{
        /// <summary>所属租户。部门 Id 仅在钉钉企业内唯一。</summary>
        public long TenantId { get; set; }

        /// <summary>关联的系统部门 Id。</summary>
        public long? SysDepartmentId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>钉钉企业内部门 Id；需与 TenantId 组合使用。</summary>
        [Required]
        public long DeptId { get; set; }

        /// <summary>
        /// 上级部门id
        /// </summary>
        [Column("parent_id")]
        [Required]
        public long ParentId { get; set; }

        /// <summary>
        /// 部门名
        /// </summary>
        [Column("name")]
        [MaxLength(64)]
        public string? Name { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("CreateTime")]
        public DateTime CreateTime { get; set; } // 可配置为插入时自动生成

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("UpdateTime")]
        public DateTime? UpdateTime { get; set; } // 可配置为更新时自动生成

        
    }
}
