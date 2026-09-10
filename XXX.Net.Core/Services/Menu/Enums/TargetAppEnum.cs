using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuTarget")]
    public enum TargetAppEnum
    {
        [Description("PC")]
        PC=0,
        [Description("钉钉h5")]
        DingDing = 1,
        [Description("手机应用")]
        App =2,
        [Description("全部")]
        All = 99,
    }
}
