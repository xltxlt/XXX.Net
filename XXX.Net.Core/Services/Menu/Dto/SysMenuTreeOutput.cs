using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuTreeOutput : BasePrimaryKey, IPagedTreeOutput<SysMenuTreeOutput>
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 编码
        /// </summary>

        public string Code { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>

        public string Name { get; set; }
        /// <summary>
        /// 菜单别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 菜单路由
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// 子菜单
        /// </summary>

        public List<SysMenuTreeOutput> Children { get; set; } = new List<SysMenuTreeOutput>();

        /// <summary>
        /// 菜单说明
        /// </summary>

        public string Description { get; set; }
    }
}
