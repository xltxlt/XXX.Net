using Consul;
using DotNetCore.CAP;
using Furion;
using Furion.HttpRemote;
using IdGen;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using MiniExcelLibs;
using MongoDB.Bson.Serialization;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using XXX.Net.Core.Cache;
using XXX.Net.Core.Converts;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.IdGenerator;
using XXX.Net.Core.Logging;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Dict;
using XXX.Net.Core.Services.Document;
using XXX.Net.Core.Services.Option;
using XXX.Net.Core.Services.Option.Providers;
using XXX.Net.Core.Services.Org;
using XXX.Net.Plugins.Inventory.Extensions;
using XXX.Net.Web.Core.Filters;
namespace XXX.Net.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //按项目程序集扫描 CAP Consumer
        var capProjectAssemblies = GetCapProjectAssemblies();
        services.AddFileLogging("logs/cap-{Date}.log");
        services.AddConsoleFormatter();
        services.AddSingleton<ILoggerService, LoggerService>();
        //services.AddJwt<JwtHandler>();
        services.AddJwt<JwtHandler>(enableGlobalAuthorize: true, jwtBearerConfigure: options =>
        {
            // 实现 JWT 身份验证过程控制
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var httpContext = context.HttpContext;
                    // 若请求 Url 包含 token 参数，则设置 Token 值
                    if (httpContext.Request.Query.ContainsKey("token"))
                        context.Token = httpContext.Request.Query["token"];
                    return Task.CompletedTask;
                }
            };
        });

        #region redis
        var redisOptions = App.GetConfig<CacheOptions>("Redis");
        services.AddSingleton(redisOptions ?? new CacheOptions());
        services.AddSingleton<IConnectionMultiplexer>(sp => ConnectionMultiplexer.Connect(redisOptions?.Connection ?? ""));
        services.AddSingleton<EnumScanner>();
        services.AddSingleton<ICacheService, RedisCacheService>();
        // 注册分布式锁 Provider
        services.AddSingleton<IDistributedLockProvider>(sp =>
        {
            var connection = sp.GetRequiredService<IConnectionMultiplexer>();
            return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
        });
        #endregion

        #region EventBus MabbitMq
        
        var rabbitMqOptions = App.GetConfig<MqOptions>("RabbitMQ");
        services.AddCap(x =>
        {
            // CAP 使用独立的 JSON 配置，需要与 Web API 的 long 序列化规则保持一致
            x.JsonSerializerOptions.Converters.Add(new BooleanJsonConverter());
            x.JsonSerializerOptions.Converters.Add(new LongJsonConverter());
            x.JsonSerializerOptions.Converters.Add(new NullableLongJsonConverter());

            // 数据库存储
            x.UseSqlServer(options =>
            {
                App.GetConfig<MqOptions>("RabbitMQ");
                var connectionString = App.Configuration["ConnectionStrings:MasterConnectionString"];
                options.ConnectionString = connectionString;
            });
            // RabbitMQ
            x.UseRabbitMQ(options =>
            {

                options.HostName = App.Configuration["CAP:RabbitMQ:HostName"];
                options.Port = App.Configuration.GetValue<int>("CAP:RabbitMQ:Port");
                options.UserName = App.Configuration["CAP:RabbitMQ:UserName"];
                options.Password = App.Configuration["CAP:RabbitMQ:Password"];
                options.VirtualHost = App.Configuration["CAP:RabbitMQ:VirtualHost"];
            });

            // 重试
            x.FailedRetryCount = 5;
            x.FailedRetryInterval = 60;

            // 死信处理：委托给 DeadLetterAlertService
            x.FailedThresholdCallback = failedInfo =>
            {
                var sp = failedInfo.ServiceProvider;
                var message = failedInfo.Message.Value as BaseEvent<object>;
                //var alertService = sp.GetRequiredService<IDeadLetterAlertService>();
                //alertService.Alert(
                //    message?.Id.ToString() ?? "unknown",
                //    message?.EventName ?? "unknown",
                //    x.FailedRetryCount
                //);
            };

            // 消息处理线程
            x.ConsumerThreadCount = 3;

            // Dashboard
            x.UseDashboard(cap => {
                cap.AllowAnonymousExplicit = true;
            });
        })
        .AddSubscriberAssembly(capProjectAssemblies);
       
        services.AddScoped<IEventBus, CapRabbitMqEventBus>();
    
        #endregion


        services.AddScoped<ICurrentUser, CurrentUser>();

        #region SnowflakeIdGenerator
        #endregion

        services.AddScoped(typeof(BaseService<,>),typeof(BaseService<,>));
        services.AddScoped<IDocumentNumberService, DocumentNumberService>();
        services.AddScoped(typeof(SysDepService),typeof(SysDepService));
        // 注册 OptionService
        services.AddScoped<OptionService>();
        // 注册所有 IOptionProvider
        services.AddScoped<IOptionProvider, EnumOptionProvider>();
        services.AddScoped<IOptionProvider, EntityOptionProvider>();
        services.AddScoped<IOptionProvider, DictOptionProvider>();
        services.AddScoped<IOptionProvider, FunOptionProvider>();
        services.AddScoped<IOptionProvider, ApiOptionProvider>();
        #region 预热数据
        services.AddScoped<ICacheWarmup, CacheDataWarmup>();
        services.AddScoped<CacheWarmupRunner>();
        services.AddHostedService<CacheWarmupHostedService>();
        #endregion
        services.AddCorsAccessor();
        //事件总线
        //services.AddEventBus();
        //远程请求
        services.AddHttpRemote(builder =>
        {
            builder.AddHttpDeclarative<XXX.NET.Plugin.DingTalk.IDingTalkApi>();
        });
        //任务调度
        services.AddSchedule();

        services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Encoder =
                        System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                    options.JsonSerializerOptions.Converters.Add(new BooleanJsonConverter());

                    options.JsonSerializerOptions.Converters.Add(new LongJsonConverter());

                    options.JsonSerializerOptions.Converters.Add(new NullableLongJsonConverter());

                    
                })
                .AddInjectWithUnifyResult();
        services.AddInventory();
        services.AddSwaggerGen(options =>
        {
            options.MapType<long>(() => new OpenApiSchema
            {
                Type = JsonSchemaType.String
            });
            options.MapType<long?>(() => new OpenApiSchema
            {
                Type = JsonSchemaType.String
            });
           

        });
        services.AddMvcFilter<RequestAuditFilter>();
    }

    private static Assembly[] GetCapProjectAssemblies()
    {
        var dependencyContext = DependencyContext.Default;
        if (dependencyContext is null)
            return [typeof(Startup).Assembly];

        return dependencyContext.RuntimeLibraries
            .Where(x => x.Type == "project" &&
                        x.Name.StartsWith("XXX.Net.", StringComparison.OrdinalIgnoreCase))
            .SelectMany(x => x.GetDefaultAssemblyNames(dependencyContext))
            .Select(Assembly.Load)
            .Distinct()
            .ToArray();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();
        app.UseInject(string.Empty);

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
   
}
