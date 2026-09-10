using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Auth.Dto
{
    public class UserLoginEvent
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; } = string.Empty;

        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
    }
}
