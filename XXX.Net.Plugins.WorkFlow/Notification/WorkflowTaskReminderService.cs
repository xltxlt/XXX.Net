using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;

namespace XXX.Net.Plugins.WorkFlow.Notification
{
    /// <summary>
    /// 扫描已到提醒时间的待办，并通过已注册的消息渠道发送一次到期提醒。
    /// </summary>
    public sealed class WorkflowTaskReminderService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public WorkflowTaskReminderService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendDueRemindersAsync(stoppingToken);
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private async Task SendDueRemindersAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var taskRepo = scope.ServiceProvider.GetRequiredService<IWorkFlowRepository<WorkflowTask>>();
            var senders = scope.ServiceProvider.GetServices<IWorkflowMessageSender>();
            var now = DateTime.Now;
            var tasks = await taskRepo.GetListAsync(task => task.Status == "pending"
                && !task.ReminderSent
                && task.ReminderTime != null
                && task.ReminderTime <= now);

            foreach (var task in tasks)
            {
                var message = new WorkflowMessage
                {
                    Title = $"任务即将到期：{task.NodeName}",
                    TenantId = task.TenantId,
                    Content = $"任务「{task.NodeName}」将于 {task.DueTime:yyyy-MM-dd HH:mm} 到期，请及时处理。",
                    InstanceId = task.InstanceId,
                    TaskId = task.Id,
                    RecipientUserIds = task.ResponsibleUserIds.Concat(task.CcUserIds).Append(task.AssigneeId).Distinct().ToList(),
                };
                foreach (var sender in senders)
                    await sender.SendAsync(message);

                task.ReminderSent = true;
                await taskRepo.UpdateAsync(task.Id, task);
            }
        }
    }
}
