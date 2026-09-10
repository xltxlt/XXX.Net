using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.EventBus
{
    public class SysUserEvents
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        public const string UserRegister = "user:register";

        /// <summary>
        /// 用户登录
        /// </summary>
        public const string UserLogin = "user:login";
        /// <summary>
        /// 登出
        /// </summary>
        public const string UserLogout = "user:logout";


    }
}
