using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuFieldFloatType")]
    public enum MenuFieldFloatTypeEnum
    {
        [Description("无浮动")]
        None=0,
        [Description("左浮动")]
        Left =1,
        [Description("右浮动")]
        Right =2,
    }
}
