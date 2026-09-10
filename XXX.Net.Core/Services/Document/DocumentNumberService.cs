using XXX.Net.Core.Cache;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Enums;
using System.Threading;

namespace XXX.Net.Core.Services.Document;

public sealed class DocumentNumberService : IDocumentNumberService
{
    private readonly IMSRepository _repository;
    private readonly ICacheService _cache;
    private readonly ICurrentUser _currentUser;

    public DocumentNumberService(
        IMSRepository repository,
        ICacheService cache,
        ICurrentUser currentUser)
    {
        _repository = repository;
        _cache = cache;
        _currentUser = currentUser;
    }

    public async Task<string> GenerateAsync(
        string code,
        long? tenantId = null,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw Oops.Oh("单据号规则编码不能为空");
        }

        var actualTenantId = tenantId ?? _currentUser.TenantId;
        if (actualTenantId <= 0)
        {
            throw Oops.Oh("租户不能为空");
        }

        var normalizedCode = code.Trim();
        var rule = await _repository.Master<SysDocumentRule>()
            .AsQueryable()
            .Where(x => x.TenantId == actualTenantId
                && x.Code == normalizedCode
                && x.Enabled)
            .SingleOrDefaultAsync(cancellationToken);

        if (rule == null)
        {
            throw Oops.Oh($"未找到启用的单据号规则：{normalizedCode}");
        }

        if (rule.SequenceLength is < 1 or > 18)
        {
            throw Oops.Oh("单据号流水长度必须在 1 到 18 之间");
        }

        var now = DateTime.Now;
        var period = GetPeriod(rule.ResetType, now);
        var redisKey = $"DocumentNumber:{actualTenantId}:{normalizedCode}:{period}";
        var sequence = await _cache.IncrementAsync(redisKey);
        var sequenceText = sequence.ToString($"D{rule.SequenceLength}");
        var dateText = string.IsNullOrWhiteSpace(rule.DateFormat)
            ? string.Empty
            : FormatDate(now, rule.DateFormat);

        return $"{rule.Prefix}{dateText}{sequenceText}";
    }

    private static string GetPeriod(DocumentNumberResetTypeEnum resetType, DateTime now)
    {
        return resetType switch
        {
            DocumentNumberResetTypeEnum.Daily => now.ToString("yyyyMMdd"),
            DocumentNumberResetTypeEnum.Monthly => now.ToString("yyyyMM"),
            DocumentNumberResetTypeEnum.Yearly => now.ToString("yyyy"),
            DocumentNumberResetTypeEnum.Never => "all",
            _ => throw Oops.Oh("单据号规则重置周期无效")
        };
    }

    private static string FormatDate(DateTime value, string format)
    {
        try
        {
            return value.ToString(format);
        }
        catch (FormatException)
        {
            throw Oops.Oh($"单据号日期格式无效：{format}");
        }
    }
}
