using DotNetCore.CAP;
using Medallion.Threading;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using XXX.Net.Core.EventBus;
using XXX.Net.Plugins.WorkFlow.Service;

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

        /// <summary>
        /// 启动对应工作流，同时把发起时填写的开始节点表单传入流程实例。
        /// </summary>
        [CapSubscribe(PmEvents.PmItemStart)]
        public async Task Handle(BaseEvent<PmItemStartEvent> message)
        {
            var data = message.Data ?? throw new InvalidOperationException("流程启动事件数据为空");
            var item = data.Item ?? throw new InvalidOperationException("流程启动事件中的项目流程项为空");

            var flowItemLock = _distributedLockProvider.CreateLock(
                $"workflow:pm-flow-item:start:{item.Id}");

            try
            {
                await using (await flowItemLock.AcquireAsync(TimeSpan.FromSeconds(30)))
                {
                    var instanceId = await _workflowInstanceService.StartByPmFlowItem(
                        item,
                        data.StartFormData);

                    _logger.LogInformation(
                        "项目流程启动成功：PmFlowItemId={PmFlowItemId}, WorkflowId={WorkflowId}, InstanceId={InstanceId}",
                        item.Id, item.WorkflowId, instanceId);
                }
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