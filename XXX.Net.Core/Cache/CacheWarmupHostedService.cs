using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace XXX.Net.Core.Cache
{
    public class CacheWarmupHostedService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<CacheWarmupHostedService> _logger;

        public CacheWarmupHostedService(
            IServiceScopeFactory scopeFactory,
            ILogger<CacheWarmupHostedService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(
            CancellationToken cancellationToken)
        {
            try
            {
                using var scope =
                    _scopeFactory.CreateScope();

                var runner =
                    scope.ServiceProvider
                        .GetRequiredService<CacheWarmupRunner>();

                await runner.RunAsync(
                    cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "缓存预热执行失败");

                throw;
            }
        }

        public Task StopAsync(
            CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
