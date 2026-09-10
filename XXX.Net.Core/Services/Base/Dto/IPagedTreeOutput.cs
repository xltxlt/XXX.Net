using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Base.Dto
{
    /// <summary>
    /// 页面树形返回限制
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedTreeOutput<T> where T : IPagedTreeOutput<T>
    {
        /// <summary>
        /// 子节点
        /// </summary>
        List<T> Children { get; set; }

    }
}
