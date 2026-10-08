using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service.Dto;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    [ApiDescriptionSettings("Workflow")]
    public class WorkflowTaskService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowTask> _taskRepo;
        private readonly IWorkFlowRepository<WorkflowHistory> _wfHistoryRepo;
        private readonly WorkflowEngine _engine;
        private readonly ICurrentUser _currentUser;

        public WorkflowTaskService(
            IWorkFlowRepository<WorkflowTask> taskRepo,
            IWorkFlowRepository<WorkflowHistory> wfHistoryRepo,
        WorkflowEngine engine,
            ICurrentUser currentUser)
        {
            _wfHistoryRepo = wfHistoryRepo;
            _taskRepo = taskRepo;
            _engine = engine;
            _currentUser = currentUser;
        }
        [HttpGet]
        public async Task<WorkflowTask> Detail(string nodeId)
        {
            var data = await _taskRepo.GetOneAsync(
                x =>
                    x.NodeId == nodeId);
            return data??new WorkflowTask();
        }
        [HttpGet]
        public async Task<List<WorkflowTask>> TodoList()
        {
            var data= await _taskRepo.GetListAsync(
                x =>
                    x.AssigneeId == _currentUser.UserId &&
                    x.Status == "pending");
            return data;
        }

        [HttpGet]
        public async Task<List<WorkflowHistory>> WfHistorydList(string instanceId)
        {
            var data = await _wfHistoryRepo.GetListAsync(
                x =>
                x.InstanceId == instanceId 
                  );
            return data;
        }

        [HttpPost]
        public async Task Submit(TaskSubmitDto dto)
        {
            if (dto.Action is not
                ("save" or "complete" or "skip"))
            {
                throw new ArgumentException(
                    "不支持的任务操作");
            }

            if (dto.Action == "save")
            {
                await _engine.SaveTaskAsync(
                    dto.TaskId,
                    _currentUser.UserId,
                    dto.FormData,
                    dto.Comment);

                return;
            }

            if (dto.Action == "complete")
            {
                await _engine.CompleteTaskAsync(
                    dto.TaskId,
                    _currentUser.UserId,
                    _currentUser.RealName,
                    dto.FormData,
                    dto.Comment);

                return;
            }

            if (dto.Action == "skip")
            {
                await _engine.SkipTaskAsync(
                    dto.TaskId,
                    _currentUser.UserId,
                    _currentUser.RealName,
                    dto.Comment);
            }
        }
    }
}