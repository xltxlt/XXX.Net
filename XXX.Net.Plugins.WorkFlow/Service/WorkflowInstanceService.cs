using Furion.DynamicApiController;
using Furion.JsonSerialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TextTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Models;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 流程实例服务：启动流程、查询实例
    /// </summary>
    [ApiDescriptionSettings("Workflow")]
    public class WorkflowInstanceService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowInstance> _instanceRepo;
        private readonly IWorkFlowRepository<WorkflowDefinition> _defRepo;
        private readonly WorkflowEngine _engine;
        private readonly IJsonSerializerProvider _jsonSerializer;
        public WorkflowInstanceService(
            IWorkFlowRepository<WorkflowInstance> instanceRepo,
            IWorkFlowRepository<WorkflowDefinition> defRepo,
            WorkflowEngine engine,
            IJsonSerializerProvider jsonSerializer
           )
        {
            _instanceRepo = instanceRepo;
            _defRepo = defRepo;
            _engine = engine;
            _jsonSerializer = jsonSerializer;
        }


        /// <summary>
        /// 根据项目流程项启动工作流。
        /// PmFlowItem 创建成功后由 CAP 消费者调用，真正启动 WorkflowCore。
        /// </summary>
        public async Task<string> StartByPmFlowItem(
            PmFlowItem item,
            Dictionary<string, object> startFormData)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (!item.Enabled) throw new InvalidOperationException("项目流程项已禁用");
            if (item.Id <= 0) throw new InvalidOperationException("项目流程项 Id 无效");
            if (string.IsNullOrWhiteSpace(item.WorkflowId))
                throw new InvalidOperationException("项目流程项未绑定 WorkflowId");

            var exists = (await _instanceRepo.GetListAsync(x => x.PmFlowItemId == item.Id))
                .FirstOrDefault();
            if (exists != null)
                return exists.InstanceId;

            var def = (await _defRepo.GetListAsync(d =>
                    d.Id == item.WorkflowDefinitionId &&
                    d.WorkflowId == item.WorkflowId &&
                    d.Version == item.Version &&
                    d.Status == "published"))
                .FirstOrDefault()
                ?? throw new InvalidOperationException(
                    $"项目流程项绑定的流程定义不存在或未发布：{item.WorkflowId} v{item.Version}");

            if (def.TenantId != item.TenantId)
                throw new InvalidOperationException("流程定义与项目流程项不属于同一租户");

            var startNode = def.Nodes?.FirstOrDefault(x => x.Type == "start");
            if (startNode == null || string.IsNullOrWhiteSpace(startNode.Id))
                throw new InvalidOperationException("流程定义缺少开始节点");

            var nextEdge = def.Edges?
                .FirstOrDefault(x => x.Source == startNode.Id);

            if (nextEdge == null || string.IsNullOrWhiteSpace(nextEdge.Target))
                throw new InvalidOperationException("开始节点没有后续节点");

            var currentNode = def.Nodes?
                .FirstOrDefault(x => x.Id == nextEdge.Target);

            if (currentNode == null || string.IsNullOrWhiteSpace(currentNode.Id))
                throw new InvalidOperationException("开始节点的后续节点不存在");

            // 关键：HTTP JSON 进入 Dictionary<string, object> 后，
            // 表单字段里的对象/数组会变成 JsonElement。
            // 这里递归转换，避免 JsonElement 进入 WorkflowCore 的 FlowData.Variables。
            var startForm = _jsonSerializer.Serialize(startFormData);

            var variables = new Dictionary<string, object>
            {
                ["PmFlowItemId"] = item.Id,
                ["PmFlowTempId"] = item.PmFlowTempId,
                ["taskName"] = string.IsNullOrWhiteSpace(item.Name)
                    ? $"项目流程-{item.Id}"
                    : item.Name,
                ["Name"] = item.Name,
                ["Description"] = item.Description,
                ["PlanStartTime"] = item.PlanStartTime,
                ["PlanEndTime"] = item.PlanEndTime,
                ["StartNodeId"] = startNode.Id,
                ["StartFormData"] = startForm,
                [startNode.Id] = startForm,
            };

            var instanceId =await _engine.StartAsync(item.WorkflowId,def.Version,item.TenantId,variables["taskName"]?.ToString()?? $"项目流程-{item.Id}",variables);
            

            return instanceId;
        }

        /// <summary>
        /// 将 ASP.NET JSON 反序列化产生的 JsonElement 递归转换成
        /// MongoDB ObjectSerializer 可以直接处理的 CLR 类型。
        ///
        /// object:
        ///   JsonObject -> Dictionary<string, object>
        ///   JsonArray  -> List<object>
        ///   string/number/bool/null -> CLR 基础类型
        /// </summary>
        private static Dictionary<string, object> NormalizeDictionary(
            IDictionary<string, object>? source)
        {
            var result = new Dictionary<string, object>();

            if (source == null)
                return result;

            foreach (var item in source)
            {
                result[item.Key] = NormalizeValue(item.Value);
            }

            return result;
        }

        private static object NormalizeValue(object? value)
        {
            if (value == null)
                return null!;

            if (value is JsonElement jsonElement)
                return NormalizeJsonElement(jsonElement);

            if (value is IDictionary<string, object> dictionary)
                return NormalizeDictionary(dictionary);

            if (value is System.Collections.IDictionary dictionary2)
            {
                var result = new Dictionary<string, object>();

                foreach (System.Collections.DictionaryEntry item in dictionary2)
                {
                    var key = item.Key?.ToString();
                    if (!string.IsNullOrWhiteSpace(key))
                        result[key] = NormalizeValue(item.Value);
                }

                return result;
            }

            if (value is System.Collections.IEnumerable enumerable && value is not string)
            {
                var list = new List<object>();
                foreach (var item in enumerable)
                    list.Add(NormalizeValue(item));

                return list;
            }

            return value;
        }

        private static object NormalizeJsonElement(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                    return null!;

                case JsonValueKind.Object:
                    var dictionary = new Dictionary<string, object>();
                    foreach (var property in element.EnumerateObject())
                    {
                        dictionary[property.Name] = NormalizeJsonElement(property.Value);
                    }
                    return dictionary;

                case JsonValueKind.Array:
                    return element.EnumerateArray()
                        .Select(NormalizeJsonElement)
                        .ToList();

                case JsonValueKind.String:
                    if (element.TryGetDateTime(out var dateTime))
                        return dateTime;

                    return element.GetString() ?? string.Empty;

                case JsonValueKind.Number:
                    if (element.TryGetInt64(out var longValue))
                        return longValue;

                    if (element.TryGetDecimal(out var decimalValue))
                        return decimalValue;

                    return element.GetDouble();

                case JsonValueKind.True:
                    return true;

                case JsonValueKind.False:
                    return false;

                default:
                    return element.ToString();
            }
        }


        [HttpGet]
        public async Task<List<WorkflowInstance>> List()
        {
            return (await _instanceRepo.GetListAsync(_ => true))
                .OrderByDescending(x => x.CreatedTime)
                .ToList();
        }

        [HttpGet]
        public async Task<WorkflowInstance> Detail(string instanceId)
        {
            return (await _instanceRepo.GetListAsync(i => i.InstanceId == instanceId))
                .FirstOrDefault()
                ?? throw new InvalidOperationException("流程实例不存在");
        }
    }
}