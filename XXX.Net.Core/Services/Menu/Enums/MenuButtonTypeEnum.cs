using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuButtonType")]
    public enum MenuButtonTypeEnum
    {
        [Description("操作按钮")]
        Button = 1,
        [Description("表格按钮")]
        TableButton = 2
    }
}
