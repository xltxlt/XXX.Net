using DotNetCore.CAP;
using Medallion.Threading;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Logging;
using XXX.Net.Core.Services.Auth.Dto;
using XXX.Net.Plugins.WorkFlow.Entity;

namespace XXX.Net.Plugins.WorkFlow.Event
{
    public class PmItemStartConsumer : ICapSubscribe
    {
        private readonly ILogger<PmItemStartConsumer> _logger;
        private readonly IDistributedLockProvider _distributedLockProvider;
        public PmItemStartConsumer(IDistributedLockProvider distributedLockProvider, ILogger<PmItemStartConsumer> logger)
        {
            _distributedLockProvider = distributedLockProvider;
            _logger = logger;
        }
        [CapSubscribe(PmEvents.PmItemStart)]
        public async Task Handle(BaseEvent<PmFlowItem> message)
        {
            _logger.LogInformation($"流程创建:{message.EventId}");

        }
    }
}
