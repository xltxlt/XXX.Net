using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Services.Option.Attribute;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace XXX.Net.Core.Entity.Sys
{
    public class SysDepartment : BaseTenantTreeEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>, IEntityTypeBuilder<SysDepartment, MasterDbContextLocator, SlaveDbContextLocator>
    {
        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>简称</summary>
        public string ShortName { get; set; } = null;


        /// <summary>是否为顶级组织</summary>
        public bool IsTopOrg { get; set; }

        /// <summary>域名</summary>
        public string DomainName { get; set; } = null;

        /// <summary>部门主管ID</summary>
        public long? LeaderUserId { get; set; }

        /// <summary>业务大区编码</summary>
        public string BusinessAreaCode { get; set; } = null;

        /// <summary>业务大区ID</summary>
        public long? BusinessAreaId { get; set; }

        /// <summary>钉钉部门ID</summary>
        public long? DingTalkDeptId { get; set; }

        /// <summary>企业信用代码</summary>
        public string CompanyCode { get; set; } = null;

        /// <summary>联系人</summary>
        public string Contacts { get; set; } = null;

        /// <summary>联系人手机</summary>
        public string ContactsPhone { get; set; } = null;

        /// <summary>地址</summary>
        public string ContactsAddress { get; set; } = null;



        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;


        public virtual ICollection<SysUserDepRole> UserDepRoles { get; set; } = new List<SysUserDepRole>();
        public void Configure(EntityTypeBuilder<SysDepartment> entityBuilder, DbContext dbContext, Type dbContextLocator)
        {


            entityBuilder.Property(e => e.Code).HasMaxLength(64);
            entityBuilder.Property(e => e.ShortName).HasMaxLength(64);
            entityBuilder.Property(e => e.DomainName).HasMaxLength(512);
            entityBuilder.Property(e => e.BusinessAreaCode).HasMaxLength(64);
            entityBuilder.Property(e => e.CompanyCode).HasMaxLength(64);
            entityBuilder.Property(e => e.Contacts).HasMaxLength(64);
            entityBuilder.Property(e => e.ContactsPhone).HasMaxLength(32);
            entityBuilder.Property(e => e.ContactsAddress).HasMaxLength(512);
            entityBuilder.Property(e => e.Enabled).HasDefaultValue(true);


            BaseTenantTreeEntity.BaseConfigure<SysDepartment>(entityBuilder);

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