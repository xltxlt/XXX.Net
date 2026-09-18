using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Event;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    [ApiDescriptionSettings("Workflow")]
    public class PmFlowItemService : BaseTenantService<PmFlowItem, PmFlowItemDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        private readonly IWorkFlowRepository<WorkflowDefinition> _definitionRepo;
        private readonly IWorkFlowRepository<WorkflowNodeForm> _nodeFormRepo;
        private readonly IEventBus _eventBus;

        public PmFlowItemService(
            IEventBus eventBus,
            IMSRepository msRepository,
            IWorkFlowRepository<WorkflowDefinition> definitionRepo,
            IWorkFlowRepository<WorkflowNodeForm> nodeFormRepo,
            ICurrentUser currentUser,
            IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
            _definitionRepo = definitionRepo;
            _nodeFormRepo = nodeFormRepo;
            _eventBus = eventBus;
        }

        #region 重写父类 基础方法
        public override async Task<PmFlowItem> ToEntity(PmFlowItemDto dto, PmFlowItem oldEntity = null)
        {
            var entity = await base.ToEntity(dto, oldEntity);
            var flowTemp = await _msRepository.Master<PmFlowTemp>()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == dto.PmFlowTempId);

            if (flowTemp == null)
                throw new InvalidOperationException("流程模板不存在");

            if (!flowTemp.Enabled)
                throw new InvalidOperationException("流程模板已禁用");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowId))
                throw new InvalidOperationException("流程模板尚未绑定流程定义，请先设计并发布流程");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowDefinitionId) || flowTemp.LastVersion <= 0)
                throw new InvalidOperationException("流程模板尚未发布流程定义，请先发布流程");

            entity.WorkflowId = flowTemp.WorkflowId;
            entity.WorkflowDefinitionId = flowTemp.WorkflowDefinitionId;
            entity.Version = flowTemp.LastVersion;
            return entity;
        }

        /// <summary>
        /// 新增项目流程项并发起流程。
        /// 基础业务参数与开始节点表单一次提交；CAP 事件携带完整发起数据后异步启动 WorkflowCore。
        /// </summary>
        [ApiDescriptionSettings(Name = "Add", Order = 400), HttpPost]
        [DisplayName("新增")]
        [UnitOfWork]
        public override async Task<PmFlowItem> Add(PmFlowItemDto dto)
        {
            if (dto.PmFlowTempId <= 0)
                throw new InvalidOperationException("请选择流程模板");

            var flowTemp = await _msRepository.Master<PmFlowTemp>()
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == dto.PmFlowTempId);

            if (flowTemp == null)
                throw new InvalidOperationException("流程模板不存在");

            if (!flowTemp.Enabled)
                throw new InvalidOperationException("流程模板已禁用");

            if (string.IsNullOrWhiteSpace(flowTemp.WorkflowId) ||
                string.IsNullOrWhiteSpace(flowTemp.WorkflowDefinitionId) ||
                flowTemp.LastVersion <= 0)
                throw new InvalidOperationException("流程模板尚未发布流程定义，请先发布流程");

            var definition = await _definitionRepo.GetOneAsync(x =>
                    x.Id == flowTemp.WorkflowDefinitionId &&
                    x.WorkflowId == flowTemp.WorkflowId &&
                    x.Version == flowTemp.LastVersion)
                ?? throw new InvalidOperationException("流程模板关联的流程定义不存在，请重新发布流程");

            if (!string.Equals(definition.Status, "published", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("当前流程版本尚未发布，请重新发布流程");

            if (definition.TenantId != flowTemp.TenantId)
                throw new InvalidOperationException("流程定义与流程模板不属于同一租户");

            var startNode = definition.Nodes?.FirstOrDefault(x => x.Type == "start");
            if (startNode == null || string.IsNullOrWhiteSpace(startNode.Id))
                throw new InvalidOperationException("流程定义缺少开始节点");

            var startForm = (await _nodeFormRepo.GetListAsync(x =>
                    x.WorkflowDeginitionId == definition.Id && x.NodeId == startNode.Id))
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefault();

            if (!IsFormDesigned(startForm))
                throw new InvalidOperationException("开始节点尚未设计表单，无法发起流程");

            ValidateRequiredFields(startForm.FormJson, dto.StartFormData);

            var entity = await base.Add(dto);

            await _msRepository.Master<PmFlowItem>().UpdateAsync(entity);

            await _eventBus.PublishAsync(
                PmEvents.PmItemStart,
                new BaseEvent<PmItemStartEvent>(
                    PmEvents.PmItemStart,
                    new PmItemStartEvent
                    {
                        Item = entity,
                        StartFormData = dto.StartFormData ?? new Dictionary<string, object>()
                    }));

            return entity;
        }

        /// <summary>
        /// 更新。更新项目流程项不应再次创建一个新的流程实例。
        /// </summary>
        [ApiDescriptionSettings(Name = "Update", Order = 400), HttpPost]
        [DisplayName("更新")]
        [UnitOfWork]
        public override async Task<PmFlowItem> Update(PmFlowItemDto dto)
        {
            return await base.Update(dto);
        }

        private static bool IsFormDesigned(WorkflowNodeForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.FormJson))
                return false;

            try
            {
                using var doc = JsonDocument.Parse(form.FormJson);
                return doc.RootElement.ValueKind == JsonValueKind.Array &&
                       doc.RootElement.GetArrayLength() > 0;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static void ValidateRequiredFields(string formJson, Dictionary<string, object> values)
        {
            using var doc = JsonDocument.Parse(formJson);
            var valueMap = values ?? new Dictionary<string, object>();

            foreach (var field in EnumerateFields(doc.RootElement))
            {
                if (!field.TryGetProperty("must", out var must) || must.ValueKind != JsonValueKind.True)
                    continue;

                if (!field.TryGetProperty("fieldName", out var fieldNameElement))
                    continue;

                var fieldName = fieldNameElement.GetString();
                if (string.IsNullOrWhiteSpace(fieldName))
                    continue;

                if (!valueMap.TryGetValue(fieldName, out var value) || IsEmptyValue(value))
                    throw new InvalidOperationException($"开始节点表单字段“{fieldName}”不能为空");
            }
        }

        private static IEnumerable<JsonElement> EnumerateFields(JsonElement element)
        {
            if (element.ValueKind != JsonValueKind.Array)
                yield break;

            foreach (var item in element.EnumerateArray())
            {
                if (item.ValueKind != JsonValueKind.Object)
                    continue;

                if (item.TryGetProperty("fieldName", out _) && item.TryGetProperty("formType", out _))
                    yield return item;

                if (item.TryGetProperty("child", out var children))
                {
                    foreach (var child in EnumerateFields(children))
                        yield return child;
                }
            }
        }

        private static bool IsEmptyValue(object value)
        {
            if (value == null) return true;
            if (value is JsonElement json)
            {
                if (json.ValueKind == JsonValueKind.Null || json.ValueKind == JsonValueKind.Undefined)
                    return true;
                if (json.ValueKind == JsonValueKind.String)
                    return string.IsNullOrWhiteSpace(json.GetString());
                if (json.ValueKind == JsonValueKind.Array)
                    return json.GetArrayLength() == 0;
                return false;
            }

            if (value is string text)
                return string.IsNullOrWhiteSpace(text);
            if (value is System.Collections.IEnumerable enumerable && !(value is string))
                return !enumerable.GetEnumerator().MoveNext();
            return false;
        }
        #endregion
    }
}