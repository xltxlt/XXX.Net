using System.Collections.Generic;
using System.Threading.Tasks;

namespace XXX.Net.Plugins.WorkFlow.Notification
{
    /// <summary>
    /// 工作流消息发送扩展点。可由钉钉、邮件、站内信等渠道分别实现。
    /// </summary>
    public interface IWorkflowMessageSender
    {
        string Channel { get; }

        Task SendAsync(WorkflowMessage message);
    }

    /// <summary>
    /// 工作流消息的渠道无关载荷。
    /// </summary>
    public sealed class WorkflowMessage
    {
        public long TenantId { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Content { get; init; } = string.Empty;
        public string InstanceId { get; init; } = string.Empty;
        public string TaskId { get; init; } = string.Empty;
        public IReadOnlyCollection<long> RecipientUserIds { get; init; } = new List<long>();
    }
}
