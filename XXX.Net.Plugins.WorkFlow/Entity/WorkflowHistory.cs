using System;
using System.Collections.Generic;
using System.Text;


namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 流程流转历史（MongoDB 存储）
    /// </summary>
    public class WorkflowHistory : WorkFlowMongoEntity
    {
        public string InstanceId { get; set; } = string.Empty;

        public string NodeId { get; set; } = string.Empty;

        public string NodeName { get; set; } = string.Empty;

        public long OperatorId { get; set; }

        public string OperatorName { get; set; } = string.Empty;

        /// <summary>
        /// 动作：start / save / complete / skip / auto
        /// </summary>
        public string Action { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;

        public DateTime OperatedTime { get; set; } = DateTime.Now;
    }
}
