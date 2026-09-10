using Furion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using WorkflowCore.Interface;
using XXX.Net.Core.MongoDb;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Step;

namespace XXX.Net.Plugins.WorkFlow
{
    /// <summary>
    /// WorkFlow 插件启动配置：注册 MongoDB 仓储 + WorkflowCore 引擎（不改动其它层）
    /// </summary>
    [AppStartup(700)]
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ===== MongoDB（复用 appsettings 的 MongoDB 配置节） =====
            var mongoOptions = App.GetConfig<MongoOptions>("MongoDB")
                ?? new MongoOptions { ConnectionString = "mongodb://localhost:27017", DatabaseName = "XXX.Workflow" };

            services.AddSingleton(mongoOptions);
            services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoOptions.ConnectionString));
            services.AddSingleton<IMongoDbContext, MongoDbContext>();
            services.AddScoped(typeof(IWorkFlowRepository<>), typeof(WorkFlowRepository<>));

            // ===== WorkflowCore =====
            services.AddWorkflow(cfg => cfg.UseMongoDB(mongoOptions.ConnectionString, mongoOptions.DatabaseName));

            // StepBody 注册到 DI，支持构造函数注入
            services.AddTransient<StartStep>();
            services.AddTransient<TaskStep>();
            services.AddTransient<DelayStep>();
            services.AddTransient<ConditionStep>();
            services.AddTransient<NotificationStep>();
            services.AddTransient<ServiceStep>();

            // 启动 WorkflowHost（后台运行流程）
            services.AddHostedService(sp => sp.GetRequiredService<IWorkflowHost>());
        }
    }
}
