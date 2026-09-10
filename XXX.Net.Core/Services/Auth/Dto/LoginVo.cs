using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Auth.Dto
{
    public class LoginVo
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string RefreshToken { get; set; }
        /// <summary>
        /// 首页
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public LoginUserInfo UserInfo { get; set; }
    }
    public class LoginUserInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public long TenantId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        public bool IsAdmin { get; set; }
        //public List<long> orgIds { get; set; }
        //public List<long> roleIds { get; set; }
    }
}
