using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Enums
{
    [EnumCache("PageType")]
    public enum PageTypeEum
    {
        [Description("列表页")]
        List=1,

        [Description("分页列表页")]
        PaginationList = 2,


        [Description("树形列表页")]
        TreeList = 3,


        [Description("树形分页列表页")]
        PaginationTreeList = 4,

        [Description("异步树形列表页")]
        AsycnTreeList = 5,

        [Description("异步分页树形列表页")]
        AsycnPaginationTreeList = 6,


        [Description("父子列表页")]
        PatherSonList = 7,


        [Description("自定义")]
        Custom = 99,

    }
}
