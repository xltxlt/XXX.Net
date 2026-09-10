using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    /// <summary>
    /// 待办提交 DTO（保存/完成/跳过）
    /// </summary>
    public class TaskSubmitDto
    {
        public string TaskId { get; set; } = string.Empty;

        /// <summary>
        /// 动作：save / complete / skip
        /// </summary>
        public string Action { get; set; } = string.Empty;

        public Dictionary<string, object> FormData { get; set; } = new Dictionary<string, object>();

        public string Comment { get; set; } = string.Empty;
    }
}
