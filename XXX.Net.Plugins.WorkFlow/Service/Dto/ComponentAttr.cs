using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    /// <summary>
    /// 组件属性
    /// </summary>
    public class ComponentAttr
    {
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int Type { get; set; } 
        public bool Required { get; set; } = false;
        public bool Show { get; set; } = false;
        public bool Readonly { get; set; } = false;
        public List<PagedOptions> Data { get; set; } = new List<PagedOptions>();
    }
}
