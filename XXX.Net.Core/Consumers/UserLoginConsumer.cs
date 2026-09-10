using DotNetCore.CAP;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Logging;
using XXX.Net.Core.Services.Auth.Dto;
using Medallion.Threading;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Consumers
{
    public class UserLoginConsumer : ICapSubscribe
    {
        private readonly IDistributedLockProvider _distributedLockProvider;
        private readonly ILoggerService _loggerService;
        public UserLoginConsumer(IDistributedLockProvider distributedLockProvider, ILoggerService loggerService)
        {
            _distributedLockProvider = distributedLockProvider;
            _loggerService = loggerService;
        }
        [CapSubscribe("user.login")]
        public async Task Handle(BaseEvent<UserLoginEvent> message)
        {
            // 以商品 ID 为锁粒度

            var stockLock = _distributedLockProvider.CreateLock($"user:login:{message?.Data?.UserId}");
            // ✅ 阻塞式获取，最多等 10 秒，超时抛异常
            await using (await stockLock.AcquireAsync(TimeSpan.FromSeconds(10)))
            {
                // 临界区：扣减库存
                _loggerService.Info($"扣库存:{message.EventId}");
            }

            // 自动释放锁 非阻塞式
            //var userStockLock = _distributedLockProvider.CreateLock($"user:login:{message.Id}");
            //await using var handle = await stockLock.TryAcquireAsync();
            //if (handle == null)
            //    return; // 锁被占用，直接返回
        }
    }
}
