using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Text.Json.Serialization;
namespace XXX.Net.Core.Entity.Sys
{

    public class SysMenuButton : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysMenuButton, MasterDbContextLocator, SlaveDbContextLocator>
    {

        /// <summary>所属菜单ID</summary>
        public long MenuId { get; set; }

        /// <summary>字段显示名</summary>
        public string Label { get; set; } = string.Empty;

        /// <summary>事件名称</summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>字段类型：1=按钮 2=表格按钮</summary>
        public int ButtonType { get; set; }

        /// <summary>图标</summary>
        public string Icon { get; set; } = string.Empty;
        /// <summary>颜色</summary>
        public string Color { get; set; } = string.Empty;
        /// <summary>
        /// 背景色
        /// </summary>
        public string BgColor { get; set; } = string.Empty;

        /// <summary>说明</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>终端：1=PC 2=App</summary>
        public int Target { get; set; } = 1;

        /// <summary>排序</summary>
        public int Sort { get; set; }

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

        [JsonIgnore]
        public virtual SysMenu Menu { get; set; }
        public void Configure(EntityTypeBuilder<SysMenuButton> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Label).HasMaxLength(64);
            entityBuilder.Property(e => e.EventName).HasMaxLength(64);
            entityBuilder.Property(e => e.Icon).HasMaxLength(64);
            entityBuilder.Property(e => e.Color).HasMaxLength(64);
            entityBuilder.Property(e => e.BgColor).HasMaxLength(64);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);

            BaseTenantEntity.BaseConfigure<SysMenuButton>(entityBuilder);
            //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
            //entityBuilder.Property(e => e.CreatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.CreatedTime)
            //    .HasDefaultValueSql("(getdate())")
            //    .HasColumnType("datetime");
            //entityBuilder.Property(e => e.General).HasDefaultValue(true);
            //entityBuilder.Property(e => e.UpdatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.UpdatedTime).HasColumnType("datetime");

        }
        // 公开一个克隆方法
        public SysMenuButton ShallowCopy()
        {
            return (SysMenuButton)this.MemberwiseClone();
        }
    }

}