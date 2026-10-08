using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.DingTalk;

/// <summary>
/// 租户对应的钉钉企业应用配置。每个租户可绑定不同的钉钉企业。
/// </summary>
public class DingTalkTenantApp : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>,IEntityTypeBuilder<DingTalkTenantApp, MasterDbContextLocator, SlaveDbContextLocator>
{
    public string CorpId { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string AgentId { get; set; } = string.Empty;
    public string CallbackToken { get; set; } = string.Empty;
    public string CallbackEncodingAesKey { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
    public void Configure(EntityTypeBuilder<DingTalkTenantApp> entityBuilder, DbContext dbContext, Type dbContextLocator)
    {
        entityBuilder.Property(e => e.CorpId).HasMaxLength(128);
        entityBuilder.Property(e => e.ClientId).HasMaxLength(128);
        entityBuilder.Property(e => e.ClientSecret).HasMaxLength(128);
        entityBuilder.Property(e => e.AgentId).HasMaxLength(128);
        entityBuilder.Property(e => e.CallbackToken).HasMaxLength(128);
        entityBuilder.Property(e => e.CallbackEncodingAesKey).HasMaxLength(128);

        BaseTenantEntity.BaseConfigure<DingTalkTenantApp>(entityBuilder);
    }

}
