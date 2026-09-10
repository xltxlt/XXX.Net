using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Models
{
    /// <summary>
    /// WorkflowCore 流程实例数据对象（承载表单数据、任务Id、定时时长等动态变量）
    /// </summary>
    public class FlowData
    {
        /// <summary>
        /// 流程实例业务Id（对应 WorkflowInstance.InstanceId）
        /// </summary>
        public string InstanceId { get; set; } = string.Empty;

        /// <summary>
        /// 流程定义业务Id（WorkflowDefinition.WorkflowId）
        /// </summary>
        public string WorkflowId { get; set; } = string.Empty;

        /// <summary>
        /// 动态变量：表单字段、当前任务Id、定时时长等
        /// </summary>
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();
    }
}
