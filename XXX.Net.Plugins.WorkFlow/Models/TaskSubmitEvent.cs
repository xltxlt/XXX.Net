using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Models
{
    /// <summary>
    /// 任务提交事件（用户点击 保存/完成/跳过 时通过 PublishEvent 唤醒 WorkflowCore 的 WaitForEvent）
    /// </summary>
    public class TaskSubmitEvent
    {
        /// <summary>
        /// 待办任务业务 Id（对应 WorkflowTask 主键 / WaitForEvent 的 eventKey）
        /// </summary>
        public string TaskId { get; set; } = string.Empty;

        /// <summary>
        /// 动作：save / complete / skip
        /// </summary>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// 表单数据
        /// </summary>
        public Dictionary<string, object> FormData { get; set; } = new Dictionary<string, object>();

        public long OperatorId { get; set; }

        public string OperatorName { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
    }
}
