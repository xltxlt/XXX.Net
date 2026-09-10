using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys
{
    [EnumCache("HttpType")]

    public enum HttpTypeEnum
    {
        [Description("Post")]
        HttpPost=0,
        [Description("Get")]
        HttpGet =1
    }
}
