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
        /// <summary>
        /// WorkflowCore 实例 Id（StartWorkflow 返回值）
        /// </summary>
        public string InstanceId { get; set; } = string.Empty;

        public string WorkflowId { get; set; } = string.Empty;

        public int Version { get; set; } = 1;

        /// <summary>
        /// 状态：running / completed / terminated
        /// </summary>
        public string Status { get; set; } = "running";

        /// <summary>
        /// 流程业务数据 JSON（表单汇总）
        /// </summary>
        public string DataJson { get; set; } = "{}";

        public string CurrentNodeId { get; set; } = string.Empty;
    }
}
