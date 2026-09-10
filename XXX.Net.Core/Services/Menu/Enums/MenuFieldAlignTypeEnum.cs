using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuFieldAlignType")]
    public enum MenuFieldAlignTypeEnum
    {
        [Description("默认")]
        Default=0,
        [Description("左对齐")]
        Left =1,
        [Description("右对齐")]
        Right =2,
        [Description("居中对齐")]
        Center = 3,
    }
}
