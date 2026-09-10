using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XXX.Net.Core.Services.Auth.Dto
{
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "必填"), MinLength(3, ErrorMessage = "字符串长度不能少于3位")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填"), MinLength(3, ErrorMessage = "字符串长度不能少于3位")]
        public string PassWord { get; set; }
    }
}
