using DotNetCore.CAP;
using Medallion.Threading;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Logging;
using XXX.Net.Core.Services.Auth.Dto;
using XXX.Net.Plugins.WorkFlow.Entity;\nusing XXX.Net.Plugins.WorkFlow.Service;

namespace XXX.Net.Plugins.WorkFlow.Event
{
    public class PmItemStartConsumer : ICapSubscribe
    {
        private readonly ILogger<PmItemStartConsumer> _logger;
        private readonly IDistributedLockProvider _distributedLockProvider;
        private readonly WorkflowInstanceService _workflowInstanceService;

        public PmItemStartConsumer(
            IDistributedLockProvider distributedLockProvider,
            WorkflowInstanceService workflowInstanceService,
            ILogger<PmItemStartConsumer> logger)
        {
            _distributedLockProvider = distributedLockProvider;
            _workflowInstanceService = workflowInstanceService;
            _logger = logger;
        }
        [CapSubscribe(PmEvents.PmItemStart)]
        public async Task Handle(BaseEvent<PmFlowItem> message)
        {
            var item = message.Data;
            if (item == null)
                throw new InvalidOperationException("流程启动事件数据为空");

            // CAP 可能因为重试重复消费，使用分布式锁 + PmFlowItemId 幂等。
            await using var handle = await _distributedLockProvider.AcquireLockAsync(
                $"workflow:pm-flow-item:start:{item.Id}");

            try
            {
                var instanceId = await _workflowInstanceService.StartByPmFlowItem(item);
                _logger.LogInformation(
                    "项目流程启动成功：PmFlowItemId={PmFlowItemId}, WorkflowId={WorkflowId}, InstanceId={InstanceId}",
                    item.Id, item.WorkflowId, instanceId);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "项目流程启动失败：PmFlowItemId={PmFlowItemId}, WorkflowId={WorkflowId}",
                    item.Id, item.WorkflowId);
                throw;
            }
        }
    }
}
