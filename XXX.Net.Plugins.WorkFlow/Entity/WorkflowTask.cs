using System;
using System.Collections.Generic;
using System.Text;


namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 待办任务（MongoDB 存储），任务节点运行时创建，等待处理人完成
    /// </summary>
    public class WorkflowTask : WorkFlowMongoEntity
    {
        public string InstanceId { get; set; } = string.Empty;

        public string WorkflowId { get; set; } = string.Empty;

        public string NodeId { get; set; } = string.Empty;

        public string NodeName { get; set; } = string.Empty;

        /// <summary>
        /// 处理人用户 Id（SysUser.Id）
        /// </summary>
        public long AssigneeId { get; set; }

        /// <summary>
        /// 状态：pending / completed / skipped
        /// </summary>
        public string Status { get; set; } = "pending";

        /// <summary>
        /// 已填写的表单数据 JSON
        /// </summary>
        public string FormDataJson { get; set; } = "{}";

        public string Comment { get; set; } = string.Empty;
    }
}
