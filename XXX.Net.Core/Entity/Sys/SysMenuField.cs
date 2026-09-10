using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Menu.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System.Text.Json.Serialization;
namespace XXX.Net.Core.Entity.Sys
{
    public class SysMenuField : BaseEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysMenuField, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>所属菜单ID</summary>
        public long MenuId { get; set; }


        /// <summary>字段显示名</summary>
        public string Label { get; set; }

        /// <summary>事件名</summary>
        public string EventName { get; set; } = string.Empty;

        /// <summary>对应数据库字段名</summary>
        public string FieldName { get; set; } 

        /// <summary>显示类型</summary>
        public int FieldType { get; set; }



        /// <summary>搜索框类型（文本框/下拉/日期等）</summary>
        public int SearchType { get; set; }

        /// <summary>
        /// 合计行
        /// </summary>
        public bool TotalRow { get; set; }
        /// <summary>
        /// 合计行文本
        /// </summary>
        public string TotalRowText { get; set; }

        /// <summary>
        /// 初始隐藏
        /// </summary>
        public bool InitHide { get; set; } = false;

        /// <summary>
        /// 对齐方式
        /// </summary>

        public int AlignType { get; set; } = 0;

        /// <summary>
        /// 浮动类型
        /// </summary>
        public int FloatType { get; set; } = 0;

        /// <summary>
        /// 应用搜索
        /// </summary>

        public bool SearchField { get; set; } = true;



        /// <summary>
        /// 自定义模板
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }

        /// <summary>列宽</summary>
        public string Width { get; set; } = null;

        /// <summary>终端：1=PC 2=App</summary>
        public int Target { get; set; } = 1;

        /// <summary>排序</summary>
        public int Sort { get; set; }


        /// <summary>说明</summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 提示文本
        /// </summary>
        public string Placeholder { get; set; } = string.Empty;


        /// <summary>数据源类型：0=无 1=字典 2=数据表 3=枚举 4=API</summary>
        public int DataSourceType { get; set; } = 0;


        /// <summary>数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址）</summary>
        public string DataSourceValue { get; set; } = string.Empty;

        /// <summary>
        /// 数据源参数（JSON格式）
        /// </summary>
        public string DataSourcePars { get; set; } = null;
        /// <summary>
        /// 是否为自定义
        /// </summary>
        public bool IsCustom { get; set; }

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

        public void Configure(EntityTypeBuilder<SysMenuField> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Label).HasMaxLength(64);
            entityBuilder.Property(e => e.EventName).HasMaxLength(64);
            entityBuilder.Property(e => e.FieldName).HasMaxLength(64);
            entityBuilder.Property(e => e.Width).HasMaxLength(32);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);
            entityBuilder.Property(e => e.Placeholder).HasMaxLength(256);
            entityBuilder.Property(e => e.TotalRowText).HasMaxLength(64);
            entityBuilder.Property(e => e.Style).HasMaxLength(256);
            entityBuilder.Property(e => e.Template).HasMaxLength(64);
            entityBuilder.Property(e => e.DataSourceValue).HasMaxLength(64);
            entityBuilder.Property(e => e.DataSourcePars).HasMaxLength(1024);
            entityBuilder.Property(e => e.IsCustom).HasDefaultValue(false);

            BaseEntity.BaseConfigure<SysMenuField>(entityBuilder);

            //entityBuilder.Property(e => e.Id).HasValueGenerator<SnowflakeValueGenerator>();
            //entityBuilder.Property(e => e.CreatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.CreatedTime)
            //    .HasDefaultValueSql("(getdate())")
            //    .HasColumnType("datetime");
            //entityBuilder.Property(e => e.UpdatedByName).HasMaxLength(64);
            //entityBuilder.Property(e => e.UpdatedTime).HasColumnType("datetime");

        }
        public SysMenuField ShallowCopy()
        {
            return (SysMenuField)this.MemberwiseClone();
        }
    }
}
