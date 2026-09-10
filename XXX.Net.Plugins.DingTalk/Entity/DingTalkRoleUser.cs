
//

//


using XXX.Net.Core.BaseEntitys.Entity;

namespace XXX.NET.Plugin.DingTalk;

/// <summary>
/// 钉钉角色信息
/// </summary>
public class DingTalkRoleUser : BaseEntity
{
    /// <summary>
    /// 钉钉用户id
    /// </summary>
    [Required, MaxLength(64)]
    public virtual string? DingTalkUserId { get; set; }

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