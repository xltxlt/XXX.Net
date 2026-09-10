using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    /// <summary>
    /// 组件项
    /// </summary>
    public class ComponentItem
    {
        public string Title { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsIndependent { get; set; } = false;
        public bool IsPreview { get; set; } = false;
        public bool IsAddGroup { get; set; } = false;
        public bool IsButton { get; set; } = false;
        public List<ComponentAttr> Attr { get; set; } = new List<ComponentAttr>();
    }
}
