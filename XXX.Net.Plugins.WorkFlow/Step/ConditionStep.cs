using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 条件分支节点：根据流程数据选择走哪个分支。
    /// 第一版：默认走第一条出边；后续按 edge.Condition 表达式解析实现真正的分支。
    /// </summary>
    public class ConditionStep : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            // TODO: 后续根据 context.Workflow.Data + edge.Condition 解析分支值
            return ExecutionResult.Next();
        }
    }
}
