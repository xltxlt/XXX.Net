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
        public string Name { get; set; } = string.Empty;
        public string TempName { get; set; } = string.Empty;

        public string WorkflowId { get; set; } = string.Empty;

        public int Version { get; set; }

        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 当前节点。
        /// 单分支流程时等价于当前节点；存在并行分支时保留最后进入/处理的节点。
        /// </summary>
        public string CurrentNodeId { get; set; } = string.Empty;

        /// <summary>
        /// 当前活动节点集合。
        /// 用于支持一个节点分叉出多个并行分支。
        /// </summary>
        public List<string> ActiveNodeIds { get; set; } = new();

        /// <summary>
        /// 已完成节点集合。
        /// 用于支持汇聚节点等待多个前置节点全部完成。
        /// </summary>
        public List<string> CompletedNodeIds { get; set; } = new();

        /// <summary>
        /// 当前节点状态
        /// </summary>
        public string CurrentNodeStatus { get; set; } = string.Empty;

        /// <summary>
        /// 流程数据
        /// </summary>
        public string DataJson { get; set; } = string.Empty;

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
