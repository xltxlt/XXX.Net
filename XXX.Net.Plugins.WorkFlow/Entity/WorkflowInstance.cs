using System;
using System.Collections.Generic;
using System.Text;


namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 流程实例（MongoDB 存储）
    /// </summary>
    public class WorkflowInstance : WorkFlowMongoEntity
    {
        public string InstanceId { get; set; }

        public long TenantId { get; set; }

        public long PmFlowItemId { get; set; }
        public string TaskName { get; set; }

        public string WorkflowId { get; set; }

        public int Version { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// 当前节点
        /// </summary>
        public string CurrentNodeId { get; set; }

        /// <summary>
        /// 当前节点状态
        /// </summary>
        public string CurrentNodeStatus { get; set; }

        /// <summary>
        /// 流程数据
        /// </summary>
        public string DataJson { get; set; }

        /// <summary>
        /// 当前节点进入时间
        /// </summary>
        public DateTime? CurrentNodeStartedTime { get; set; }

        /// <summary>
        /// 最后处理时间
        /// </summary>
        public DateTime? LastOperateTime { get; set; }

        /// <summary>
        /// 版本号，用于并发控制
        /// </summary>
        public long RowVersion { get; set; }
    }
}
