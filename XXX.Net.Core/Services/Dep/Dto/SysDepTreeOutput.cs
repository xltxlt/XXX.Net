using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Dto;

namespace XXX.Net.Core.Services.Org.Dto
{
    public class SysDepTreeOutput : BasePrimaryKey, IPagedTreeOutput<SysDepTreeOutput>
    {
   
        /// <summary>
        /// 编码
        /// </summary>

        public string Code { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>

        public string Name { get; set; }
        public string ShortName { get; set; }


        public long TenantId { get; set; }
        public int Sort{ get; set; }
        public int Enabled{ get; set; }




        /// <summary>
        /// 子菜单
        /// </summary>

        public List<SysDepTreeOutput> Children { get; set; } = new List<SysDepTreeOutput>();

        /// <summary>
        /// 说明
        /// </summary>

        public string Description { get; set; }
    }
}
