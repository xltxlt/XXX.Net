using System.Threading;

namespace XXX.Net.Core.Services.Document;

public interface IDocumentNumberService
{
    Task<string> GenerateAsync(
        string code,
        long? tenantId = null,
        CancellationToken cancellationToken = default);
}
