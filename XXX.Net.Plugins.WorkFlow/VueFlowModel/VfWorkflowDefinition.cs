using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.VueFlowModel
{
    public class VfWorkflowDefinition
    {
        public long PmFlowTempId { get; set; }

        public string WorkflowId { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }

        public List<VfWorkflowNode> Nodes { get; set; } = new List<VfWorkflowNode>();

        public List<VfWorkflowEdge> Edges { get; set; } = new List<VfWorkflowEdge>();

        /// <summary>
        /// 表单模板
        /// </summary>
        public Dictionary<string, string> Form { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 表单模板属性
        /// </summary>
        public Dictionary<string, string> AttrData { get; set; }=new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> ButtonList { get; set; } = new Dictionary<string, string>();

    }
}
