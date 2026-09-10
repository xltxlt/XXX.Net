using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace XXX.Net.Core.Entity.Sys
{
    public class SysRole : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysRole, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;


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


        /// <summary>说明</summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// 菜单
        /// </summary>
        public virtual ICollection<SysRoleMenu> Menus { get; set; } = new List<SysRoleMenu>();
        /// <summary>
        /// 按钮
        /// </summary>
        public virtual ICollection<SysRoleMenuButton> MenuButtons { get; set; } = new List<SysRoleMenuButton>();
        /// <summary>
        /// 按钮
        /// </summary>
        public virtual ICollection<SysRoleMenuField> MenuFields { get; set; } = new List<SysRoleMenuField>();

        public void Configure(EntityTypeBuilder<SysRole> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.Description).HasMaxLength(512);
            entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);
            entityBuilder.Property(e => e.General).HasDefaultValue(true);


            entityBuilder.HasMany(m => m.Menus)
              .WithOne(b => b.Role)
              .HasForeignKey(b => b.RoleId)
              .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(m => m.MenuButtons)
             .WithOne(b => b.Role)
             .HasForeignKey(b => b.RoleId)
             .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasMany(m => m.MenuFields)
             .WithOne(b => b.Role)
             .HasForeignKey(b => b.RoleId)
             .OnDelete(DeleteBehavior.Cascade);

            BaseTenantEntity.BaseConfigure<SysRole>(entityBuilder);
        }
    }
}