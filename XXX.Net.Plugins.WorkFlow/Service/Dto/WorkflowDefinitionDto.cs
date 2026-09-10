using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Plugins.WorkFlow.Entity;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    public class WorkflowDefinitionDto
    {
        public long PmFlowTempId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public VueFlowModel.VfWorkflowDefinition WorkflowDefinition { get; set; } = new VueFlowModel.VfWorkflowDefinition();
        /// <summary>
        /// 
        /// </summary>
        public List<WorkflowNodeForm> WorkflowNodeForm { get; set; } = new List<WorkflowNodeForm>();
    }
}
