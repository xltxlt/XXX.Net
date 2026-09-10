using MiniExcelLibs.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.User.Dto
{
    public class SysUserExportVo
    {
        [ExcelColumnName("用户名")]

        public string UserName { get; set; }

        [ExcelColumnName("真实姓名")]
        public string RealName { get; set; }

        [ExcelColumnName("用户密码")]
        public string PassWord { get; set; }


        [ExcelColumnName("手机号")]
        public string Mobile { get; set; }

        [ExcelColumnName("创建时间")]
        public DateTime CreatedTime { get; set; }

    }
}
