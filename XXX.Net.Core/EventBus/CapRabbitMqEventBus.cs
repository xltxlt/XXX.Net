using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.EventBus
{
    public class CapRabbitMqEventBus : IEventBus
    {
        protected readonly ICapPublisher _cap;
        public CapRabbitMqEventBus(ICapPublisher cap)
        {
            _cap = cap;
        }

        public async Task PublishAsync<T>(string name, BaseEvent<T> data)
        {
            await _cap.PublishAsync<BaseEvent<T>>(name, data);
            return;
        }

        public async Task PublishDelayAsync<T>(int seconds, string name, BaseEvent<T> data)
        {
            await _cap.PublishDelayAsync<BaseEvent<T>>(TimeSpan.FromSeconds(seconds), name, data);
            return;
        }
    }
}
