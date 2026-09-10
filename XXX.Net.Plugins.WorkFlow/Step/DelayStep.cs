using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Models;
using WorkflowDefinitionEntity = XXX.Net.Plugins.WorkFlow.Entity.WorkflowDefinition;
using WorkflowNodeModel = XXX.Net.Plugins.WorkFlow.VueFlowModel.VfWorkflowNode;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 定时节点：延迟指定时长后继续。时长取自节点配置 duration+unit，
    /// 或配置 delayFrom 指定从前面步骤输出参数（FlowData.Variables）中取。
    /// </summary>
    public class DelayStep : StepBody
    {
        private readonly IWorkFlowRepository<WorkflowDefinitionEntity> _definitionRepo;

        public DelayStep(IWorkFlowRepository<WorkflowDefinitionEntity> definitionRepo)
        {
            _definitionRepo = definitionRepo;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            var nodeId = context.Step.ExternalId ?? context.Step.Id.ToString();
            var flowData = (context.Workflow.Data as FlowData) ?? new FlowData();
            var period = ResolvePeriodAsync(flowData.WorkflowId, nodeId, flowData).GetAwaiter().GetResult();
            return ExecutionResult.Sleep(period, null);
        }

        private async Task<TimeSpan> ResolvePeriodAsync(string workflowId, string nodeId, FlowData flowData)
        {
            var defs = await _definitionRepo.GetListAsync(d => d.WorkflowId == workflowId);
            var node = defs.SelectMany(d => d.Nodes).FirstOrDefault(n => n.Id == nodeId);

            if (node == null || string.IsNullOrEmpty(node.Config)) return TimeSpan.Zero;
            try
            {
                using var doc = JsonDocument.Parse(node.Config);
                var root = doc.RootElement;
                if (root.ValueKind != JsonValueKind.Object) return TimeSpan.Zero;

                // 优先从前面步骤输出参数取
                if (root.TryGetProperty("delayFrom", out var fromEl)
                    && fromEl.ValueKind == JsonValueKind.String
                    && !string.IsNullOrEmpty(fromEl.GetString()))
                {
                    var fromField = fromEl.GetString()!;
                    if (flowData.Variables.TryGetValue(fromField, out var val))
                    {
                        if (val is TimeSpan ts) return ts;
                        if (TryToDouble(val, out var d)) return TimeSpan.FromMinutes(d);
                    }
                }

                // 其次从节点配置取固定时长
                double duration = 0;
                string unit = "minute";
                if (root.TryGetProperty("duration", out var dEl) && dEl.ValueKind != JsonValueKind.Null) TryToDouble(dEl, out duration);
                if (root.TryGetProperty("unit", out var uEl) && uEl.ValueKind == JsonValueKind.String) unit = uEl.GetString()!;
                return unit switch
                {
                    "second" => TimeSpan.FromSeconds(duration),
                    "hour" => TimeSpan.FromHours(duration),
                    _ => TimeSpan.FromMinutes(duration),
                };
            }
            catch
            {
                return TimeSpan.Zero;
            }
        }

        private static bool TryToDouble(object? val, out double result)
        {
            result = 0;
            if (val == null) return false;
            if (val is JsonElement je && je.ValueKind == JsonValueKind.Number) return je.TryGetDouble(out result);
            if (val is JsonElement je2 && je2.ValueKind == JsonValueKind.String) return double.TryParse(je2.GetString(), out result);
            try
            {
                return double.TryParse(val.ToString(), out result);
            }
            catch { return false; }
        }
    }
}
