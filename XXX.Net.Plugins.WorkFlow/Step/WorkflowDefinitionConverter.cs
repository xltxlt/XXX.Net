using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Models;
using WorkflowDefinitionEntity = XXX.Net.Plugins.WorkFlow.Entity.WorkflowDefinition;
using WcWorkflowDefinition = WorkflowCore.Models.WorkflowDefinition;
using WcWorkflowStep = WorkflowCore.Models.WorkflowStep;
using WcWorkflowStepCollection = WorkflowCore.Models.WorkflowStepCollection;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 把前端设计的流程定义（Nodes+Edges）转换为 WorkflowCore 的 WorkflowDefinition（Steps）
    /// </summary>
    public static class WorkflowDefinitionConverter
    {
        public static WcWorkflowDefinition Convert(WorkflowDefinitionEntity def)
        {
            if (def == null) throw new ArgumentNullException(nameof(def));
            if (def.Nodes == null || def.Nodes.Count == 0) throw new InvalidOperationException("流程定义缺少节点");

            // 分配 StepId（int）
            var stepIds = new Dictionary<string, int>();
            var id = 0;
            foreach (var node in def.Nodes)
            {
                stepIds[node.Id] = id++;
            }

            var steps = new WcWorkflowStepCollection();
            foreach (var node in def.Nodes)
            {
                var step = CreateStep(GetBodyType(node.Type));
                step.Id = stepIds[node.Id];
                step.Name = node.Name ?? node.Id;
                step.ExternalId = node.Id;
                step.Outcomes = new List<IStepOutcome>();

                if (node.Type != "end")
                {
                    var outEdges = def.Edges.Where(e => e.Source == node.Id).ToList();
                    if (outEdges.Count > 0)
                    {
                        foreach (var edge in outEdges)
                        {
                            var targetStepId = stepIds.TryGetValue(edge.Target, out var t) ? t : -1;
                            step.Outcomes.Add(new WorkflowCore.Models.ValueOutcome
                            {
                                NextStep = targetStepId,
                                Label = edge.Condition,
                                ExternalNextStepId = edge.Target,
                                Value = outEdges.Count > 1 && edge != outEdges[0]
                                    ? Expression.Lambda(Expression.Constant(edge.Target))
                                    : null,
                            });
                        }
                    }
                }

                steps.Add(step);
            }

            return new WcWorkflowDefinition
            {
                Id = def.WorkflowId,
                Version = def.Version,
                DataType = typeof(FlowData),
                Steps = steps,
            };
        }

        /// <summary>
        /// 通过泛型 WorkflowStep&lt;TStepBody&gt; 创建 step，从而设置只读的 BodyType
        /// </summary>
        private static WcWorkflowStep CreateStep(Type bodyType)
        {
            var stepType = typeof(WorkflowCore.Models.WorkflowStep<>).MakeGenericType(bodyType);
            return (WcWorkflowStep)Activator.CreateInstance(stepType)!;
        }

        private static Type GetBodyType(string type)
        {
            return type switch
            {
                "start" => typeof(StartStep),
                "task" => typeof(TaskStep),
                "approval" => typeof(TaskStep),
                "condition" => typeof(ConditionStep),
                "delay" => typeof(DelayStep),
                "notification" => typeof(NotificationStep),
                "service" => typeof(ServiceStep),
                "end" => typeof(StartStep),
                _ => throw new InvalidOperationException($"不支持的节点类型：{type}"),
            };
        }
    }
}
