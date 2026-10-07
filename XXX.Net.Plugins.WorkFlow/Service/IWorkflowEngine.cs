using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    public interface IWorkflowEngine
    {
        Task<string> StartAsync(
            long pmFlowItemId,
            string workflowId,
            int version,
            Dictionary<string, object> data);

        Task CompleteTaskAsync(
            string taskId,
            long userId,
            Dictionary<string, object> formData,
            string comment);

        Task SkipTaskAsync(
            string taskId,
            long userId,
            string comment);

        Task RollbackAsync(
            string taskId,
            long userId,
            string targetNodeId,
            string comment);

        Task CancelAsync(
            string instanceId,
            long userId,
            string comment);
    }
}
