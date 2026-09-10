using System.Threading.Tasks;
using XXX.Net.Plugins.WorkFlow.Notification;

namespace XXX.NET.Plugin.DingTalk.Service.Workflow;

/// <summary>
/// 工作流钉钉通知适配器。
/// 将工作流的渠道无关消息转换为钉钉企业工作通知。
/// </summary>
public class DingTalkWorkflowMessageSender : IWorkflowMessageSender, IScoped
{
    private readonly DingTalkTenantService _dingTalkTenantService;

    public DingTalkWorkflowMessageSender(DingTalkTenantService dingTalkTenantService)
    {
        _dingTalkTenantService = dingTalkTenantService;
    }
    public string Channel => "dingtalk";

    public Task SendAsync(WorkflowMessage message)
    {
        if (message.TenantId <= 0 || message.RecipientUserIds.Count == 0) return Task.CompletedTask;
        return _dingTalkTenantService.SendTextMessage(message.TenantId, message.RecipientUserIds,
            $"{message.Title}\n{message.Content}");
    }
}
