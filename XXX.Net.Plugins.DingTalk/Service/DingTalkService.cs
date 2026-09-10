

using Furion.DatabaseAccessor;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using XXX.Net.Core.EventBus;
using XXX.Net.Plugins.DingTalk.Service.Dto;
using XXX.Net.Plugins.DingTalk.Utils;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace XXX.NET.Plugin.DingTalk.Service;

/// <summary>
/// 钉钉服务 🧩
/// </summary>
[ApiDescriptionSettings(DingTalkConst.GroupName, Order = 100)]
public class DingTalkService : IDynamicApiController, IScoped
{
    private readonly IDingTalkApi _dingTalkApi;
    private readonly DingTalkOptions _dingTalkOptions;
    private readonly IMSRepository _mSRepository;
    private readonly IEventBus _eventBus;
    private readonly DingTalkTenantService _tenantService;

    private readonly IHttpContextAccessor _httpContextAccessor;
    public DingTalkService(
        IDingTalkApi dingTalkApi,
        IOptions<DingTalkOptions> dingTalkOptions,
        IMSRepository mSRepository,
        IHttpContextAccessor httpContextAccessor,
        IEventBus eventBus,
        DingTalkTenantService tenantService
    )
    {
        _dingTalkApi = dingTalkApi;
        _dingTalkOptions = dingTalkOptions.Value;
        _mSRepository = mSRepository;
        _httpContextAccessor = httpContextAccessor;
        _eventBus = eventBus;
        _tenantService = tenantService;
    }
    /// <summary>
    /// 获取企业内部应用的access_token TODO 返回不包一层
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取企业内部应用的access_token")]
    public async Task<DingTalkCallBackResultOutput> PostCallBack(long tenantId, string signature, string timestamp, string nonce)
    {
        if (_httpContextAccessor.HttpContext == null) return new DingTalkCallBackResultOutput();
        string content = await _httpContextAccessor.HttpContext.Request.ReadBodyContentAsync();

        JToken json = JToken.Parse(content);
        string ever = json["encrypt"]?.ToString()??"";
        var tenantApp = await _mSRepository.Master<DingTalkTenantApp>().AsQueryable()
            .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.Enabled && !x.Deleted)
            ?? throw Oops.Oh("未配置当前租户的钉钉企业应用");
        DingTalkEncryptor dingTalkEncryptor = new DingTalkEncryptor(
            tenantApp.CallbackToken, tenantApp.CallbackEncodingAesKey, tenantApp.CorpId);

        //定义字符串接收解密后的值
        string returnData = dingTalkEncryptor.getDecryptMsg(signature, timestamp, nonce, ever);
        JToken jToken = JToken.Parse(returnData);
        string EventType = jToken["EventType"]?.ToString()??"";
        // 仅审批实例/审批任务事件进入审批事件总线，避免组织变更等回调误触发流程处理。
        if (EventType is "bpms_instance_change" or "bpms_task_change")
            await _eventBus.PublishAsync(EventType, new BaseEvent<object> { EventName = EventType, Data = returnData });
        var msg = dingTalkEncryptor.getEncryptedMap("success");
        return new DingTalkCallBackResultOutput()
        {
            msg_signature = msg["msg_signature"],
            encrypt = msg["encrypt"],
            timeStamp = msg["timeStamp"],
            nonce = msg["nonce"],
        };
    }

    /// <summary>同步指定租户的钉钉人员、部门、角色和岗位信息。</summary>
    [HttpPost]
    public Task SyncOrganization(long tenantId) => _tenantService.SyncOrganization(tenantId);

    /// <summary>发起指定租户的钉钉审批。</summary>
    [HttpPost]
    public Task<DingTalkWorkflowProcessInstancesOutput> StartApproval(long tenantId, DingTalkWorkflowProcessInstancesInput input)
        => _tenantService.StartApproval(tenantId, input);

    /// <summary>
    /// 获取企业内部应用的access_token
    /// </summary>
    /// <returns></returns>
    [DisplayName("获取企业内部应用的access_token")]
    public async Task<GetDingTalkTokenOutput> GetDingTalkToken()
    {
        var tokenRes = await _dingTalkApi.GetDingTalkToken(
            _dingTalkOptions.ClientId,
            _dingTalkOptions.ClientSecret
        );
        if (tokenRes.ErrCode != 0)
        {
            throw Oops.Oh(tokenRes.ErrMsg);
        }
        return tokenRes;
    }

    /// <summary>
    /// 获取在职员工列表 🔖
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost, DisplayName("获取在职员工列表")]
    public async Task<
        DingTalkBaseResponse<GetDingTalkCurrentEmployeesListOutput>
    > GetDingTalkCurrentEmployeesList(
        string access_token,
        [Required] GetDingTalkCurrentEmployeesListInput input
    )
    {
        return await _dingTalkApi.GetDingTalkCurrentEmployeesList(access_token, input);
    }

    /// <summary>
    /// 获取员工花名册字段信息 🔖
    /// </summary>
    /// <param name="access_token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost, DisplayName("获取员工花名册字段信息")]
    public async Task<
        DingTalkBaseResponse<List<DingTalkEmpRosterFieldVo>>
    > GetDingTalkCurrentEmployeesRosterList(
        string access_token,
        [Required] GetDingTalkCurrentEmployeesRosterListInput input
    )
    {
        return await _dingTalkApi.GetDingTalkCurrentEmployeesRosterList(access_token, input);
    }

    /// <summary>
    /// 发送钉钉互动卡片 🔖
    /// </summary>
    /// <param name="token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("给指定用户发送钉钉互动卡片")]
    [Obsolete]
    public async Task<DingTalkSendInteractiveCardsOutput> DingTalkSendInteractiveCards(
        string token,
        DingTalkSendInteractiveCardsInput input
    )
    {
        return await _dingTalkApi.DingTalkSendInteractiveCards(token, input);
    }

    /// <summary>
    /// 创建并投放钉钉消息卡片 🔖
    /// </summary>
    /// <param name="token"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    [DisplayName("给指定用户发送钉钉消息卡片")]
    public async Task<DingTalkCreateAndDeliverOutput> DingTalkCreateAndDeliver(
        string token,
        DingTalkCreateAndDeliverInput input
    )
    {
        return await _dingTalkApi.DingTalkCreateAndDeliver(token, input);
    }

    [DisplayName("用于发起OA审批实例")]
    public async Task<DingTalkWorkflowProcessInstancesOutput> DingTalkWorkflowProcessInstances(
        string token,
        DingTalkWorkflowProcessInstancesInput input
    )
    {
        var temp = await _dingTalkApi.DingTalkWorkflowProcessInstances(token, input);
        return temp;
    }

    [DisplayName("查询审批实例")]
    public async Task<DingTalkGetProcessInstancesOutput> DingTalkWorkflowProcessInstances(
        string token,
        string input
    )
    {
        var temp = await _dingTalkApi.GetProcessInstances(token, input);
        DingTalkWokerflowLog flow = await _mSRepository.Master<DingTalkWokerflowLog>().AsQueryable().FirstAsync(t => t.Status == "RUNNING" && t.instanceId == input);
        if ((flow != null) && (temp.Result.Status != flow.Status))
        {
            flow.Status = temp.Result.Status;
            flow.UpdateTime = DateTime.Now;
            flow.WorkflowId = temp.Result.BusinessId;
            flow.Result = temp.Result.Result;
            flow.taskId = temp.Result.Tasks.FirstOrDefault(t => t.Status == "RUNNING")?.TaskId;
            await _mSRepository.Master<DingTalkWokerflowLog>().UpdateNowAsync(flow);
        }
        return temp;
    }
}
