using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 服务调用节点：占位，后续调用配置的 HTTP 服务
    /// </summary>
    public class ServiceStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
