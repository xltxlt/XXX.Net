using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.DingTalk
{
    /// <summary>
    /// 钉钉部门信息
    /// </summary>
    [Table("ding_talk_dept")]
    public class DingTalkDept
    {
        /// <summary>
        /// 部门id
        /// </summary>
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // 不自增，由外部赋值
        [Required]
        public long DeptId { get; set; } // 建议属性名改为 DeptId，保留原列名映射

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