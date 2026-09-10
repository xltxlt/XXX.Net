using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("MenuFieldType")]
    public enum MenuFieldTypeEnum
    {
        [Description("表格字段")]
        TableField = 1,
        [Description("搜索字段")]
        SearchField = 2
    }
}
