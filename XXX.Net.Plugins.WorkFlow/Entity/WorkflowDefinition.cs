using System;
using System.Collections.Generic;
using System.Text;

using XXX.Net.Plugins.WorkFlow.VueFlowModel;

namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 流程定义（MongoDB 存储），含节点与边（对齐前端 WorkflowDefinitionDto）
    /// </summary>
    public class WorkflowDefinition : WorkFlowMongoEntity
    {
        /// <summary>流程模板所属租户。</summary>
        public long TenantId { get; set; }
        /// <summary>
        /// 项目流程Id
        /// </summary>
        public long PmFlowTempId { get; set; }

        /// <summary>
        /// 业务键（流程唯一标识）
        /// </summary>
        public string WorkflowId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Version { get; set; } = 1;

        /// <summary>
        /// 状态：draft / published
        /// </summary>
        public string Status { get; set; } = "draft";

        public List<VfWorkflowNode> Nodes { get; set; } = new List<VfWorkflowNode>();

        public List<VfWorkflowEdge> Edges { get; set; } = new List<VfWorkflowEdge>();
    }
}
