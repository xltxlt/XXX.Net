using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Enums
{
    [EnumCache("Enabled")]
    public enum EnabledEnum
    {
        
        [Description("禁用")]
        Enabled=0,

        [Description("启用")]
        Enable = 1,
    }
}
