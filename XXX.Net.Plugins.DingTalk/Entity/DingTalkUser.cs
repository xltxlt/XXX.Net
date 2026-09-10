
//

//


using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.DingTalk;

/// <summary>
/// 钉钉用户表
/// </summary>
public class DingTalkUser : BaseEntity
{
    /// <summary>
    /// 系统用户Id
    /// </summary>
    public long SysUserId { get; set; }

    /// <summary>
    /// 系统用户
    /// </summary>
    [JsonIgnore]
    public SysUser SysUser { get; set; }

    /// <summary>
    /// 钉钉用户id
    /// </summary>
    [Required, MaxLength(64)]
    public virtual string? DingTalkUserId { get; set; }

    /// <summary>
    /// UnionId
    /// </summary>
    [MaxLength(64)]
    public string? UnionId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    [MaxLength(64)]
    public string? Name { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    [MaxLength(16)]
    public string? Mobile { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public int? Sex { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [MaxLength(256)]
    public string? Avatar { get; set; }

    /// <summary>
    /// 工号
    /// </summary>
    [MaxLength(16)]
    public string? JobNumber { get; set; }

    /// <summary>
    /// 主部门Id
    /// </summary>
    [MaxLength(16)]
    public string? DeptId { get; set; }

    /// <summary>
    /// 主部门
    /// </summary>
    [MaxLength(16)]
    public string? Dept { get; set; }

    /// <summary>
    /// 职位
    /// </summary>
    [MaxLength(16)]
    public string? Position { get; set; }
}