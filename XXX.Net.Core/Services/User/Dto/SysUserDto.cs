using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.User.Dto
{
    public class SysUserDto:BaseUpdate
    {

        /// <summary>
        /// 租户Id
        /// </summary>
        public long TenantId { get; set; }

        [Description("真实姓名")]
        public string RealName { get; set; }

        [Description("用户名")]
        [Required]
        public string UserName { get; set; }

        [Description("手机号")]
        public string Mobile { get; set; }

        [Description("邮箱")]
        public string Email { get; set; }

        [Description("头像")]
        public string Avater { get; set; }

    }
}
