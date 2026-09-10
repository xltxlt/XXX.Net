using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 开始节点：直接进入下一步
    /// </summary>
    public class StartStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
