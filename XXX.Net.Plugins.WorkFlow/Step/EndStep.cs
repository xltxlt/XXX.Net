using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;

namespace XXX.Net.Plugins.WorkFlow.Step
{
    /// <summary>
    /// 流程结束节点：同步业务流程实例状态为 completed。
    /// </summary>
    public class EndStep : StepBody
    {
        private readonly IWorkFlowRepository<WorkflowInstance> _instanceRepo;

        public EndStep(IWorkFlowRepository<WorkflowInstance> instanceRepo)
        {
            _instanceRepo = instanceRepo;
        }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            CompleteAsync(context).GetAwaiter().GetResult();
            return ExecutionResult.Next();
        }

        private async Task CompleteAsync(IStepExecutionContext context)
        {
            var instanceId = context.Workflow.Id;

            var instances = await _instanceRepo.GetListAsync(
                x => x.InstanceId == instanceId);

            var instance = instances.FirstOrDefault();
            if (instance == null)
                return;

            instance.Status = "completed";
            instance.CurrentNodeId = context.Step.ExternalId ?? string.Empty;

            await _instanceRepo.UpdateAsync(instance.Id, instance);
        }
    }
}
