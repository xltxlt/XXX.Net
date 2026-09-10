using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.BaseEntitys.Enums
{
    /// <summary>
    /// 页面分组器
    /// </summary>
    [EnumCache("PageFromGroup")]
    public enum PageFromGroupEnum
    {
        /// <summary>
        /// 分组
        /// </summary>
        Group=0,

        /// <summary>
        /// 预览分组
        /// </summary>
        PrivewGroup=1,

        /// <summary>
        /// 表格
        /// </summary>
        Table=2,

        /// <summary>
        /// 列表
        /// </summary>
        List = 3,

    }
}
