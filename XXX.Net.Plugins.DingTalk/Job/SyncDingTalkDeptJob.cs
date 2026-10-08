
//

//


using XXX.NET.Plugin.DingTalk;
using Furion.Schedule;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Furion.DatabaseAccessor;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.Job;

/// <summary>
/// 同步钉钉角色job,自动同步触发器请在web页面按需求设置
/// </summary>
[JobDetail("SyncDingTalkDeptJob", Description = "同步钉钉部门", GroupName = "default", Concurrent = false)]
[Daily(TriggerId = "SyncDingTalkDeptTrigger", Description = "同步钉钉部门",RunOnStart =false)]
public class SyncDingTalkDeptJob : IJob
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IDingTalkApi _dingTalkApi;
    private readonly ILogger _logger;
    private readonly IMSRepository _mSRepository;

    public SyncDingTalkDeptJob(
        IServiceScopeFactory scopeFactory,
        IDingTalkApi dingTalkApi,
        IMSRepository mSRepository,
        ILoggerFactory loggerFactory)
    {
        _scopeFactory = scopeFactory;
        _dingTalkApi = dingTalkApi;
        _mSRepository = mSRepository;
        //_logger = loggerFactory.CreateLogger(CommonConst.SysLogCategoryName);
    }

    public async Task ExecuteAsync(JobExecutingContext context, CancellationToken stoppingToken)
    {
        using var serviceScope = _scopeFactory.CreateScope();
        var _dingTalkOptions = serviceScope.ServiceProvider.GetRequiredService<IOptions<DingTalkOptions>>();

        // 获取Token
        var tokenRes = await _dingTalkApi.GetDingTalkToken(_dingTalkOptions.Value.ClientId, _dingTalkOptions.Value.ClientSecret);
        if (tokenRes.ErrCode != 0)
            throw Oops.Oh(tokenRes.ErrMsg);

        var dingTalkDeptList = new List<DingTalkDept>();
        // 获取部门列表
        var deptIdsRes = await _dingTalkApi.GetDingTalkDept(tokenRes.AccessToken, new GetDingTalkDeptInput
        { dept_id = 1 });
        if (deptIdsRes.ErrCode != 0)
        {
            _logger.LogError(deptIdsRes.ErrMsg);
            throw Oops.Oh(deptIdsRes.ErrMsg);
        }
        dingTalkDeptList.AddRange(deptIdsRes.Result.Select(d => new DingTalkDept
        {
            DeptId = d.dept_id,
            Name = d.name,
            ParentId = d.parent_id
        }));
        foreach (var item in deptIdsRes.Result)
        {
            dingTalkDeptList.AddRange(await GetDingTalkDeptList(tokenRes.AccessToken, item.dept_id));
        }
        await _mSRepository.Master<DingTalkDept>().InsertNowAsync (dingTalkDeptList);
        var originColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("【" + DateTime.Now + "】同步钉钉部门");
        Console.ForegroundColor = originColor;
    }

    private async Task<List<DingTalkDept>> GetDingTalkDeptList(string token, long dept_id)
    {
        List<DingTalkDept> listTemp = new List<DingTalkDept>();
        var deptIdsRes = await _dingTalkApi.GetDingTalkDept(token, new GetDingTalkDeptInput
        { dept_id = dept_id });
        if (deptIdsRes.ErrCode != 0)
        {
            return null;
        }
        listTemp.AddRange(deptIdsRes.Result.Select(x => new DingTalkDept
        {
            DeptId = x.dept_id,
            Name = x.name,
            ParentId = x.parent_id
        }));
        foreach (var item in deptIdsRes.Result)
        {
            listTemp.AddRange(await GetDingTalkDeptList(token, item.dept_id));
        }
        return listTemp;
    }
}