using System.Threading.Tasks;
using XXX.Net.Plugins.WorkFlow.Notification;

namespace XXX.NET.Plugin.DingTalk.Service.Workflow;

/// <summary>
/// 工作流钉钉通知适配器。
/// 当前保留发送入口，实际钉钉消息投递将在后续统一实现。
/// </summary>
public class DingTalkWorkflowMessageSender : IWorkflowMessageSender, IScoped
{
    public string Channel => "dingtalk";

    public Task SendAsync(WorkflowMessage message)
    {
        // TODO: 接入钉钉工作通知/互动卡片；保留消息契约以支持其它通知渠道并行实现。
        return Task.CompletedTask;
    }
}
