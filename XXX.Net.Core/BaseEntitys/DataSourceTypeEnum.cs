using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys
{
    [EnumCache("DataSourceType")]
    public enum DataSourceTypeEnum
    {
        [Description("默认")]
        Default=0,
        [Description("枚举")]
        FormEnum = 1,
        [Description("字典")]
        FormDict = 2,
        [Description("实体类")]
        FormEntity = 3,
        [Description("Api")]
        FormApi = 4,
        [Description("其他")]
        FormOther = 99,
    }
}
