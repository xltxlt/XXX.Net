using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Services.Base.Dto;

namespace XXX.Net.Core.Services.Dep.Dto
{
    public class DepUserSummaryOutput : IPagedTreeOutput<DepUserSummaryOutput>
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }


        public long? LeaderUserId { get; set; }


        /// <summary>
        /// 当前部门用户数
        /// </summary>
        public int UserCount { get; set; }

        /// <summary>
        /// 子部门数量
        /// </summary>
        public int DepCount { get; set; }
        public List<DepUserSummaryOutput> Children { get; set; }=new List<DepUserSummaryOutput>();
    }
}
