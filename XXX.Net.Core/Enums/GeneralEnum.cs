using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Enums
{
    [EnumCache("General")]
    public enum GeneralEnum
    {
        [Description("租户")]
        Tenant = 0,
        [Description("全局")]
        Global = 1
    }
}
