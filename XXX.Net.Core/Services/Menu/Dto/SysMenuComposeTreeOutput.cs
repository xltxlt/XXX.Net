using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base.Dto;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuCompose
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Label { get; set; }
        public long Id { get; set; }
    }
    public class SysMenuComposeTreeOutput:SysMenuTreeOutput, IPagedTreeOutput<SysMenuComposeTreeOutput>
    {
        public List<SysMenuCompose> MenuButtons { get; set; } = new List<SysMenuCompose>();
        public List<SysMenuCompose> MenuFields { get; set; } = new List<SysMenuCompose>();

        public new List<SysMenuComposeTreeOutput> Children { get; set; } = new List<SysMenuComposeTreeOutput>();
    }
   
}
