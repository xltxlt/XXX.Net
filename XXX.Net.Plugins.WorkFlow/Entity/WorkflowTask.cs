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
        /// <summary>流程所属租户。</summary>
        public long TenantId { get; set; }
        public string InstanceId { get; set; } = string.Empty;

        public string WorkflowId { get; set; } = string.Empty;

        /// <summary>Definition snapshot used to load the exact version of the node form.</summary>
        public string WorkflowDefinitionId { get; set; } = string.Empty;

        public string NodeId { get; set; } = string.Empty;

        public string NodeName { get; set; } = string.Empty;

        /// <summary>
        /// 处理人用户 Id（SysUser.Id）
        /// </summary>
        public long AssigneeId { get; set; }

        /// <summary>节点指定的负责人。</summary>
        public List<long> ResponsibleUserIds { get; set; } = new List<long>();

        /// <summary>节点指定的负责部门。</summary>
        public List<long> ResponsibleDepartmentIds { get; set; } = new List<long>();

        /// <summary>节点抄送人。</summary>
        public List<long> CcUserIds { get; set; } = new List<long>();

        /// <summary>预计工期（天）。</summary>
        public int EstimatedDurationDays { get; set; }

        /// <summary>到期前提醒天数。</summary>
        public int ReminderBeforeDays { get; set; }

        public DateTime? DueTime { get; set; }

        public DateTime? ReminderTime { get; set; }

        /// <summary>是否已发送到期提醒。</summary>
        public bool ReminderSent { get; set; }

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
