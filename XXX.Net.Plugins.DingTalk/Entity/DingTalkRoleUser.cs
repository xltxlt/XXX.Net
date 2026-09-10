
//

//


using XXX.Net.Core.BaseEntitys.Entity;
using Furion.DatabaseAccessor;
using XXX.Net.Core.DbContextLocator;

namespace XXX.NET.Plugin.DingTalk;

/// <summary>
/// 钉钉角色信息
/// </summary>
public class DingTalkRoleUser : BaseEntity, IEntity<MasterDbContextLocator, SlaveDbContextLocator>
{
    /// <summary>所属租户。</summary>
    public long TenantId { get; set; }
    /// <summary>
    /// 钉钉用户id
    /// </summary>
    [Required, MaxLength(64)]
    public virtual string? DingTalkUserId { get; set; }

    /// <summary>关联的系统角色 Id。</summary>
    public long? SysRoleId { get; set; }

    /// <summary>
    /// 角色组id
    /// </summary>
    [Required]
    public virtual long groupId { get; set; }

    /// <summary>
    /// 角色组名称
    /// </summary>
    [MaxLength(64)]
    public string? groupName { get; set; }

    /// <summary>
    /// 角色id
    /// </summary>
    [Required]
    public virtual long roleId { get; set; }

    /// <summary>
    /// 角色名
    /// </summary>
    [MaxLength(64)]
    public string? roleName { get; set; }
}
