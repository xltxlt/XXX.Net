using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Auth.Dto
{
    /// <summary>
    /// 用户登录消息体
    /// </summary>
    public class UserLoginEo
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public long UserId { get; set; }
    }
}
