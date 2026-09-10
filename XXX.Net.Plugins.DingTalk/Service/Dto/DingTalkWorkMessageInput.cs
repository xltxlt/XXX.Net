namespace XXX.NET.Plugin.DingTalk;

/// <summary>钉钉工作通知请求。</summary>
public class DingTalkWorkMessageInput
{
    [Newtonsoft.Json.JsonProperty("agent_id")]
    public long AgentId { get; set; }

    [Newtonsoft.Json.JsonProperty("userid_list")]
    public string UserIdList { get; set; } = string.Empty;

    [Newtonsoft.Json.JsonProperty("msg")]
    public DingTalkTextMessage Message { get; set; } = new();
}

public class DingTalkTextMessage
{
    [Newtonsoft.Json.JsonProperty("msgtype")]
    public string MessageType { get; set; } = "text";

    [Newtonsoft.Json.JsonProperty("text")]
    public DingTalkTextMessageContent Text { get; set; } = new();
}

public class DingTalkTextMessageContent
{
    [Newtonsoft.Json.JsonProperty("content")]
    public string Content { get; set; } = string.Empty;
}

public class DingTalkWorkMessageOutput
{
    [Newtonsoft.Json.JsonProperty("errcode")]
    public int ErrorCode { get; set; }

    [Newtonsoft.Json.JsonProperty("errmsg")]
    public string ErrorMessage { get; set; } = string.Empty;
}
