using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 流程定义服务：保存/查询/发布流程定义（MongoDB 存储，发布时转换为 WorkflowCore 并注册）
    /// </summary>
    [ApiDescriptionSettings("Workflow")]
    public class WorkflowDefinitionService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowDefinition> _repo;
        private readonly IWorkFlowRepository<WorkflowNodeForm> _nodeFormRepo;
        private readonly IWorkflowHost _host;
        private readonly IMSRepository _msRepository;

        public WorkflowDefinitionService(IWorkFlowRepository<WorkflowDefinition> repo, IWorkFlowRepository<WorkflowNodeForm> nodeFormRepo, IWorkflowHost host, IMSRepository msRepository)
        {
            _repo = repo;
            _host = host;
            _msRepository = msRepository;
            _nodeFormRepo = nodeFormRepo;
        }

        /// <summary>
        /// 保存流程定义（新增或更新）
        /// </summary>
        [HttpPost]
        [UnitOfWork]
        public async Task<WorkflowDefinition> Save(WorkflowDefinitionDto workflowDefinitionDto)
        {
            if (workflowDefinitionDto.PmFlowTempId <= 0)
                throw Oops.Oh("请选择要保存的流程模板");

            var dto = workflowDefinitionDto.WorkflowDefinition ?? throw Oops.Oh("流程定义不能为空");
            var workflowNodeForms = workflowDefinitionDto.WorkflowNodeForm ?? new List<WorkflowNodeForm>();
            Validate(dto);
            if (string.IsNullOrEmpty(dto.WorkflowId))
            {
                dto.WorkflowId = Guid.NewGuid().ToString("N");
            }
            var existing = await _repo.GetListAsync(d => d.WorkflowId == dto.WorkflowId);
            var oldEntity = existing.OrderByDescending(d => d.Version).FirstOrDefault();
            var version = oldEntity != null ? (oldEntity.Version + 1) : 1;
            var mPmFlowTemp= await _msRepository.Master<PmFlowTemp>().AsQueryable().Where(w=>w.Id== workflowDefinitionDto.PmFlowTempId).FirstOrDefaultAsync();
            if (mPmFlowTemp == null) {
                throw Oops.Oh("未找到对应的实体类");
            }
            
            
            var entity = new WorkflowDefinition
            {
                PmFlowTempId = workflowDefinitionDto.PmFlowTempId,
                WorkflowId = dto.WorkflowId,
                Name = dto.Name ?? mPmFlowTemp.Name,
                Nodes = dto.Nodes ?? new List<VueFlowModel.VfWorkflowNode>(),
                Edges = dto.Edges ?? new List<VueFlowModel.VfWorkflowEdge>(),
                Status = "draft",
                Version = version,
            };
            await _repo.InsertAsync(entity);
            var mlAddNodeFormTemp = new List<WorkflowNodeForm>();
            foreach (var nodeFormTemp in workflowNodeForms.GroupBy(x => x.NodeId).Select(x => x.Last())) {
                if (!entity.Nodes.Any(n => n.Id == nodeFormTemp.NodeId))
                    throw Oops.Oh($"表单节点 {nodeFormTemp.NodeId} 不存在于流程定义中");
                nodeFormTemp.WorkflowDeginitionId = entity.Id;
                nodeFormTemp.WorkflowId = entity.WorkflowId;
                nodeFormTemp.Version = entity.Version;
                mlAddNodeFormTemp.Add(nodeFormTemp);
            }
           
            await _nodeFormRepo.InsertManyAsync(mlAddNodeFormTemp);

            mPmFlowTemp.WorkflowId = dto.WorkflowId;
            mPmFlowTemp.LastVersion = version;
            mPmFlowTemp.WorkflowDefinitionId = entity.Id;
            await _msRepository.Master<PmFlowTemp>().UpdateAsync(mPmFlowTemp);
            return entity;
        }

        /// <summary>
        /// 发布流程：转换为 WorkflowCore 定义并注册
        /// </summary>
        [HttpPost]
        public async Task<WorkflowDefinition> Publish(string workflowId)
        {
            var entity = (await _repo.GetListAsync(d => d.WorkflowId == workflowId)).OrderByDescending(d => d.Version).FirstOrDefault()
                ?? throw new InvalidOperationException("流程定义不存在");

            var wcDef = WorkflowDefinitionConverter.Convert(entity);
            _host.Registry.RegisterWorkflow(wcDef);

            entity.Status = "published";
            await _repo.UpdateAsync(entity.Id, entity);
            return entity;
        }

        /// <summary>
        /// 流程定义列表
        /// </summary>
        [HttpGet]
        public async Task<List<WorkflowDefinition>> List()
        {
            return (await _repo.GetListAsync(_ => true)).OrderByDescending(x => x.CreatedTime).ToList();
        }

        private static void Validate(VueFlowModel.VfWorkflowDefinition definition)
        {
            var nodes = definition.Nodes ?? new List<VueFlowModel.VfWorkflowNode>();
            var edges = definition.Edges ?? new List<VueFlowModel.VfWorkflowEdge>();
            if (nodes.Count == 0) throw Oops.Oh("流程至少需要一个节点");
            if (nodes.Count(n => n.Type == "start") != 1) throw Oops.Oh("流程必须且只能有一个开始节点");
            if (!nodes.Any(n => n.Type == "end")) throw Oops.Oh("流程必须包含结束节点");
            if (nodes.Any(n => string.IsNullOrWhiteSpace(n.Id)) || nodes.Select(n => n.Id).Distinct().Count() != nodes.Count)
                throw Oops.Oh("节点标识不能为空且不能重复");
            if (edges.Any(e => !nodes.Any(n => n.Id == e.Source) || !nodes.Any(n => n.Id == e.Target)))
                throw Oops.Oh("连线引用了不存在的节点");
            foreach (var taskNode in nodes.Where(n => n.Type == "task"))
            {
                try
                {
                    using var config = System.Text.Json.JsonDocument.Parse(taskNode.Config ?? "{}");
                    var root = config.RootElement;
                    var hasUser = root.TryGetProperty("responsibleUserIds", out var users) && users.ValueKind == System.Text.Json.JsonValueKind.Array && users.GetArrayLength() > 0;
                    var hasDepartment = root.TryGetProperty("responsibleDepartmentIds", out var departments) && departments.ValueKind == System.Text.Json.JsonValueKind.Array && departments.GetArrayLength() > 0;
                    var durationDays = root.TryGetProperty("estimatedDurationDays", out var duration) && duration.TryGetInt32(out var durationValue) ? durationValue : 0;
                    var reminderDays = root.TryGetProperty("reminderBeforeDays", out var reminder) && reminder.TryGetInt32(out var reminderValue) ? reminderValue : -1;
                    var durationValid = durationDays > 0;
                    var reminderValid = reminderDays >= 0 && reminderDays <= durationDays;
                    if (!hasUser && !hasDepartment) throw Oops.Oh($"任务节点 {taskNode.Name} 必须指定负责人或负责部门");
                    if (!durationValid || !reminderValid) throw Oops.Oh($"任务节点 {taskNode.Name} 的预计工期或提醒天数不正确");
                }
                catch (System.Text.Json.JsonException)
                {
                    throw Oops.Oh($"任务节点 {taskNode.Name} 的配置格式不正确");
                }
            }
        }

        /// <summary>
        /// 流程定义详情
        /// </summary>
        [HttpGet]
        public async Task<WorkflowDefinition> Detail(string workflowDefinitionId)
        {
            return (await _repo.GetListAsync(d => d.Id == workflowDefinitionId)).LastOrDefault()
                ?? throw new InvalidOperationException("流程定义不存在");
        }
    }
}
