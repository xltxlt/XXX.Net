using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace XXX.Net.Core.Cache
{
    public class CacheWarmupRunner
    {
        private readonly IEnumerable<ICacheWarmup> _warmups;
        private readonly ILogger<CacheWarmupRunner> _logger;

        public CacheWarmupRunner(
            IEnumerable<ICacheWarmup> warmups,
            ILogger<CacheWarmupRunner> logger)
        {
            _warmups = warmups;
            _logger = logger;
        }

        public async Task RunAsync(
            CancellationToken cancellationToken = default)
        {
            var warmups = _warmups
                .OrderBy(x => x.Order)
                .ToList();

            foreach (var warmup in warmups)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var name = warmup.GetType().Name;

                var stopwatch = Stopwatch.StartNew();

                try
                {
                    _logger.LogInformation(
                        "开始执行缓存预热：{Name}",
                        name);

                    await warmup.ExecuteAsync(
                        cancellationToken);

                    stopwatch.Stop();

                    _logger.LogInformation(
                        "缓存预热完成：{Name}，耗时 {Elapsed} ms",
                        name,
                        stopwatch.ElapsedMilliseconds);
                }
                catch (Exception ex)
                {
                    stopwatch.Stop();

                    _logger.LogError(
                        ex,
                        "缓存预热失败：{Name}",
                        name);

                    throw;
                }
            }
        }
    }
}
