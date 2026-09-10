using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 通知节点：占位，后续接入钉钉/微信/邮件通知
    /// </summary>
    public class NotificationStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            return ExecutionResult.Next();
        }
    }
}
