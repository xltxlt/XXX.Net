using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuType")]
    public enum MenuTypeEnum
    {
        [Description("页面")]
        Menu=2,
        [Description("目录")]
        Directory = 1,
    }
}
