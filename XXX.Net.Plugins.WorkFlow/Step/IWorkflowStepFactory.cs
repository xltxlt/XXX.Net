using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.VueFlowModel;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    public interface IWorkflowStepFactory
    {
        string Type { get; }

        IStepBody Create(VfWorkflowNode node);
    }
}
