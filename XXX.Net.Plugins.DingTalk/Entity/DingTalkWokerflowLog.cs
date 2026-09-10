
using Furion.DatabaseAccessor;
using XXX.Net.Core.DbContextLocator;

namespace XXX.NET.Plugin.DingTalk;

public class DingTalkWokerflowLog: IEntity<MasterDbContextLocator, SlaveDbContextLocator>
{
    /// <summary>
    /// 审批实例ID
    /// </summary>
    public string instanceId { get; set; } = string.Empty;

    /// <summary>
    /// 审批单号
    /// </summary>
    public string? WorkflowId { get; set; }

    /// <summary>
    /// 来源单据
    /// </summary>
    public string SourceDocument { get; set; } = string.Empty;

    /// <summary>
    /// 审批完成时间
    /// </summary>
    public DateTime? EndTime { get; set; }

    /// <summary>
    /// 其他信息
    /// </summary>
    public Dictionary<string, object>? other_info { get; set; }

    /// <summary>
    /// 是否回传结果给第三方
    /// </summary>
    public bool? isReturn { get; set; }

    /// <summary>
    /// 审批状态
    /// </summary>
    /// <remarks>
    /// RUNNING：审批中 TERMINATED：已撤销 COMPLETED：审批完成
    /// /// </remarks>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// 任务ID
    /// </summary>
    public long? taskId { get; set; }

    /// <summary>
    /// 审批结果 agree：同意 refuse：拒绝
    /// </summary>
    public string? Result { get; set; }

    /// <summary>
    /// 创建者姓名
    /// </summary>
    public string? CreateUserName { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public virtual DateTime? UpdateTime { get; set; }
}