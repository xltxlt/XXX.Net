using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Models;
using XXX.Net.Plugins.WorkFlow.Notification;
using XXX.Net.Plugins.WorkFlow.Service.Dto;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 待办任务服务：查询待办、提交（保存/完成/跳过）
    /// </summary>
    [ApiDescriptionSettings("Workflow")]

    public class WorkflowTaskService : IDynamicApiController
    {
        private readonly IWorkFlowRepository<WorkflowTask> _taskRepo;
        private readonly IWorkflowHost _host;
        private readonly ICurrentUser _currentUser;
        private readonly IEnumerable<IWorkflowMessageSender> _messageSenders;

        public WorkflowTaskService(
            IWorkFlowRepository<WorkflowTask> taskRepo,
            IWorkflowHost host,
            ICurrentUser currentUser,
            IEnumerable<IWorkflowMessageSender> messageSenders)
        {
            _taskRepo = taskRepo;
            _host = host;
            _currentUser = currentUser;
            _messageSenders = messageSenders;
        }

        /// <summary>
        /// 当前用户的待办列表
        /// </summary>
        [HttpGet]
        public async Task<List<WorkflowTask>> TodoList()
        {
            var userId = _currentUser.UserId;
            return await _taskRepo.GetListAsync(t => t.AssigneeId == userId && t.Status == "pending");
        }

        /// <summary>
        /// 提交待办：save=仅保存；complete=完成并流转；skip=跳过并流转
        /// </summary>
        [HttpPost]
        public async Task Submit(TaskSubmitDto dto)
        {
            if (dto.Action is not ("save" or "complete" or "skip"))
                throw new ArgumentException("不支持的任务操作");
            var task = await _taskRepo.GetOneAsync(t => t.Id == dto.TaskId)
                ?? throw new InvalidOperationException("待办不存在");
            if (task.AssigneeId != _currentUser.UserId)
                throw new UnauthorizedAccessException("只能处理分配给自己的待办");
            if (task.Status != "pending" && dto.Action != "save")
                throw new InvalidOperationException("待办已经处理");

            task.FormDataJson = JsonSerializer.Serialize(dto.FormData ?? new Dictionary<string, object>());
            task.Comment = dto.Comment ?? string.Empty;
            if (dto.Action == "complete") task.Status = "completed";
            else if (dto.Action == "skip") task.Status = "skipped";
            // save 保持 pending
            await _taskRepo.UpdateAsync(task.Id, task);

            if (dto.Action is "complete" or "skip")
            {
                var message = new WorkflowMessage
                {
                    Title = $"任务已{(dto.Action == "complete" ? "完成" : "跳过")}：{task.NodeName}",
                    TenantId = task.TenantId,
                    Content = $"任务「{task.NodeName}」已由 {_currentUser.RealName}处理。",
                    InstanceId = task.InstanceId,
                    TaskId = task.Id,
                    RecipientUserIds = task.ResponsibleUserIds.Concat(task.CcUserIds).Append(task.AssigneeId).Distinct().ToList(),
                };
                foreach (var sender in _messageSenders)
                    await sender.SendAsync(message);
            }

            // 完成/跳过：发布事件唤醒 WorkflowCore 流转
            if (dto.Action == "complete" || dto.Action == "skip")
            {
                var evt = new TaskSubmitEvent
                {
                    TaskId = dto.TaskId,
                    Action = dto.Action,
                    FormData = dto.FormData ?? new Dictionary<string, object>(),
                    OperatorId = _currentUser.UserId,
                    OperatorName = _currentUser.RealName,
                    Comment = dto.Comment ?? string.Empty,
                };
                await _host.PublishEvent(TaskStep.EventName, dto.TaskId, evt);
            }
        }
    }
}
