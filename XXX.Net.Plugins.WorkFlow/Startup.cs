using Furion;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using XXX.Net.Core.MongoDb;
using XXX.Net.Plugins.WorkFlow.Entity;
using XXX.Net.Plugins.WorkFlow.Notification;
using XXX.Net.Plugins.WorkFlow.Repository;
using XXX.Net.Plugins.WorkFlow.Service;

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
            services.AddScoped<WorkflowInstanceService>();

            // 自研工作流引擎
            services.AddScoped<WorkflowEngine>();
            services.AddScoped<
               WorkflowInstanceService>();

            services.AddScoped<
                WorkflowTaskService>();

            // 保留消息发送
            services.AddScoped<
                WorkflowTaskReminderService>();
            services.AddSingleton(sp =>
            {
                var mongoOptions = sp.GetRequiredService<IOptions<MongoOptions>>().Value;

                var mongoClient = new MongoClient(mongoOptions.ConnectionString);

                return mongoClient.GetDatabase(mongoOptions.DatabaseName);
            });

        }
    }
    public static class WorkflowMongoIndex
    {
        public static async Task EnsureIndexesAsync(IMongoDatabase database)
        {
            var collection = database.GetCollection<WorkflowTask>("WorkflowTask");

            var indexKeys = Builders<WorkflowTask>.IndexKeys
                .Ascending(x => x.TaskKey);

            var indexOptions = new CreateIndexOptions
            {
                Unique = true,
                Name = "UX_WorkflowTask_TaskKey"
            };

            await collection.Indexes.CreateOneAsync(
                new CreateIndexModel<WorkflowTask>(
                    indexKeys,
                    indexOptions));
        }
    }
}
