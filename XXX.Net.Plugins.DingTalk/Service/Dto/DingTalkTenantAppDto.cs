using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;

namespace XXX.Net.Plugins.DingTalk.Service.Dto
{
    public class DingTalkTenantAppDto:BaseTenantUpdate
    {
        public string CorpId { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string AgentId { get; set; } = string.Empty;
        public string CallbackToken { get; set; } = string.Empty;
        public string CallbackEncodingAesKey { get; set; } = string.Empty;
    }
}
