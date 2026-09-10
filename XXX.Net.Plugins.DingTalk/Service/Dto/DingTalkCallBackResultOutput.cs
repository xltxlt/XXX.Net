using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.DingTalk.Service.Dto
{
    public class DingTalkCallBackResultOutput
    {
        /// <summary>
        /// 消息签名
        /// </summary>
        public string msg_signature { get; set; } = string.Empty;
        /// <summary>
        /// encrypt
        /// </summary>
        public string encrypt { get; set; } = string.Empty;
        /// <summary>
        /// 时间戳
        /// </summary>
        public string timeStamp { get; set; } = string.Empty;
        /// <summary>
        /// 随机数
        /// </summary>
        public string nonce { get; set; } = string.Empty;

    }
}
