using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkflowCore.Interface;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow.Service
{
    /// <summary>
    /// 应用启动时把 MongoDB 中已发布的 WorkflowDefinition 恢复到 WorkflowCore Registry。
    /// </summary>
    public sealed class WorkflowDefinitionRegistry : IHostedService
    {
        private readonly IWorkflowHost _host;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<WorkflowDefinitionRegistry> _logger;

        public WorkflowDefinitionRegistry(
            IWorkflowHost host,
            IServiceScopeFactory scopeFactory,
            ILogger<WorkflowDefinitionRegistry> logger)
        {
            _host = host;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var repository = scope.ServiceProvider
                .GetRequiredService<IWorkFlowRepository<WorkflowDefinition>>();

            var definitions = await repository.GetListAsync(x => x.Status == "published");
            var count = 0;

            foreach (var definition in definitions
                .GroupBy(x => $"{x.WorkflowId}:{x.Version}")
                .Select(x => x.First()))
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    var workflowDefinition =
                        WorkflowDefinitionConverter.Convert(definition);

                    _host.Registry.RegisterWorkflow(workflowDefinition);
                    count++;

                    _logger.LogInformation(
                        "WorkflowCore 流程注册成功：{WorkflowId} v{Version}",
                        definition.WorkflowId,
                        definition.Version);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "WorkflowCore 流程注册失败：{WorkflowId} v{Version}",
                        definition.WorkflowId,
                        definition.Version);
                }
            }

            _logger.LogInformation(
                "WorkflowCore 已恢复 {Count} 个已发布流程版本。",
                count);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
