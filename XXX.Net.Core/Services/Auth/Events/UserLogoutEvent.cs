using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Auth.Events
{
    public class UserLogoutEvent
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    }
}
