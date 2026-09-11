using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using XXX.Net.Core.BaseEntitys.Entity;

namespace XXX.Net.Core.Services.Dep.Dto
{
    public class DepUserSummaryDto: BaseTreeEntity
    {


        public string ShortName { get; set; }

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

        /// <summary>
        /// 当前部门以及所有子部门的用户ID
        /// 只用于内部计算，不返回前端
        /// </summary>
        [JsonIgnore]
        public HashSet<long> UserIds { get; set; } = new();
    }
}
