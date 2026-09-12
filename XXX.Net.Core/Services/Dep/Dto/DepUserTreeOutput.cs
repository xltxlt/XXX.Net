using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Services.Base.Dto;

namespace XXX.Net.Core.Services.Dep.Dto
{
    public class DepUserTreeOutput:IPagedTreeOutput<DepUserTreeOutput>
    {
        /// <summary>
        /// 部门ID / 用户ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 1=部门 2=用户
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<DepUserTreeOutput> Children { get; set; } = new();
    }
}
