using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace XXX.Net.Core.Cache
{
    public interface ICacheWarmup
    {
        int Order { get; }

        Task ExecuteAsync(
            CancellationToken cancellationToken = default);
    }
}
