using Furion.DatabaseAccessor;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XXX.Net.Core.Entity.Sys
{
    public class SysMenu:BaseTenantTreeEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysMenu, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; } = string.Empty;

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 权限标识（如 user:list、user:add）
        /// </summary>
        public string Identify { get; set; } = string.Empty;



        /// <summary>
        /// 菜单类型：1=目录 2=页面 3=按钮
        /// </summary>
        public int MenuType { get; set; }

        /// <summary>
        /// 终端：1=PC 2=小程序 3=App 4=全部
        /// </summary>
        public int Target { get; set; } = 4;

        /// <summary>
        /// 路由地址
        /// </summary>
        public string Route { get; set; } = null;

        /// <summary>
        /// 事件名称
        /// </summary>
        public string EventName { get; set; } = null;

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; } = null;

        /// <summary>
        /// 工作台
        /// </summary>
        public string WorkbenchIcon { get; set; } = null;
        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// 全局通用
        /// </summary>
        [OptionEnum(typeof(GeneralEnum))]
        public bool General { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 页面类型
        /// </summary>

        [OptionEnum(typeof(PageTypeEum))]
        public int PageType { get; set; }


        /// <summary>
        /// 最大表格按钮数量
        /// </summary>
        public int MaxTableButton { get; set; } = 5;

        /// <summary>
        /// 所有按钮（真实导航，EF 用）
        /// </summary>
        public virtual ICollection<SysMenuButton> MenuButtons { get; set; } = new List<SysMenuButton>();

        /// <summary>
        /// 菜单字段列表
        /// </summary>
        public virtual ICollection<SysMenuField> MenuFields{ get; set; } = new List<SysMenuField>();


        public void Configure(EntityTypeBuilder<SysMenu> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            
            entityBuilder.Property(e => e.Name).HasMaxLength(64);
            entityBuilder.Property(e => e.Alias).HasMaxLength(64);
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.Identify).HasMaxLength(64);
            entityBuilder.Property(e => e.Route).HasMaxLength(256);
            entityBuilder.Property(e => e.Icon).HasMaxLength(64);
            entityBuilder.Property(e => e.EventName).HasMaxLength(64);
            entityBuilder.Property(e => e.WorkbenchIcon).HasMaxLength(128);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);

            
            entityBuilder.Property(e => e.Enabled).HasDefaultValue(false);
            entityBuilder.Property(e => e.PageType);
            entityBuilder.Property(e => e.General).HasDefaultValue(true);
            entityBuilder.Property(e => e.MaxTableButton).HasDefaultValue(5);

            entityBuilder.HasMany(m => m.MenuButtons)
            .WithOne(b => b.Menu)
            .HasForeignKey(b => b.MenuId)
            .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(m => m.MenuFields)
           .WithOne(b => b.Menu)
           .HasForeignKey(b => b.MenuId)
           .OnDelete(DeleteBehavior.Cascade);


            BaseTenantTreeEntity.BaseConfigure<SysMenu>(entityBuilder);
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
