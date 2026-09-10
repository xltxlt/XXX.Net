using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.VueFlowModel
{
    /// <summary>
    /// 流程节点（对齐前端 FlowDesigner 的 node，Type 存前端小写类型字符串）
    /// </summary>
    public class VfWorkflowNode
    {
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// 节点类型（小写）：start/task/approval/condition/parallel/delay/notification/service/end/parent
        /// </summary>
        public string Type { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 节点配置 JSON 字符串（assigneeIds、审批人、条件、时长等）
        /// </summary>
        public string Config { get; set; } = "{}";

        public string NodeJson { get; set; } = string.Empty;
    }
}
