using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.Entity.Sys
{
    /// <summary>
    /// 用户在租户组织机构中的角色关联。
    /// </summary>
    public class SysUserDepRole : BaseTenantEntity,
        IEntity<MasterDbContextLocator, SlaveDbContextLocator>,
        IEntityTypeBuilder<SysUserDepRole, MasterDbContextLocator, SlaveDbContextLocator>
    {

        /// <summary>用户 ID。</summary>
        public long UserId { get; set; }

        /// <summary>部门 ID。</summary>
        public long DepartmentId { get; set; }

        /// <summary>角色 ID。</summary>
        public long RoleId { get; set; }

       

        [JsonIgnore]
        public virtual SysUser User { get; set; }

        [JsonIgnore]
        public virtual SysDepartment Department { get; set; }

        [JsonIgnore]
        public virtual SysRole Role { get; set; }

        public void Configure(EntityTypeBuilder<SysUserDepRole> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {

            entityBuilder.HasOne(x => x.User)
                .WithMany(x=>x.UserDepRoles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(x => x.Department)
                .WithMany(x => x.UserDepRoles)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder.HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // 同一用户在同一部门下的同一角色只能配置一次。
            entityBuilder.HasIndex(x => new
            {
                x.TenantId,
                x.UserId,
                x.DepartmentId,
                x.RoleId
            }).IsUnique();

            BaseTenantEntity.BaseConfigure<SysUserDepRole>(entityBuilder);
        }

        public SysUserDepRole Copy()
        {
            return (SysUserDepRole)MemberwiseClone();
        }
    }
}
