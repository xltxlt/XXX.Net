using XXX.Net.Core.BaseEntitys.Entity;
using Furion.DatabaseAccessor;
using XXX.Net.Core.DbContextLocator;

namespace XXX.NET.Plugin.DingTalk;

/// <summary>
/// 租户对应的钉钉企业应用配置。每个租户可绑定不同的钉钉企业。
/// </summary>
public class DingTalkTenantApp : BaseTenantEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>
{
    public string CorpId { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string AgentId { get; set; } = string.Empty;
    public string CallbackToken { get; set; } = string.Empty;
    public string CallbackEncodingAesKey { get; set; } = string.Empty;
    public bool Enabled { get; set; } = true;
}
