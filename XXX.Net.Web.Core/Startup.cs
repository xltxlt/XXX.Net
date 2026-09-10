using Consul;
using Furion;
using Furion.HttpRemote;
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
using XXX.Net.Web.Core.Filters;
using IdGen;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using MiniExcelLibs;
using MongoDB.Bson.Serialization;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Threading.Tasks;
using XXX.Net.Plugins.Inventory.Extensions;
using XXX.Net.Core.Services.Org;
namespace XXX.Net.Web.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        //让CAP能扫描到XXX.Net.Core层
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
                options.HostName = rabbitMqOptions?.Host ?? "127.0.0.1";
                options.Port = rabbitMqOptions?.Port ?? 5672;
                options.UserName = rabbitMqOptions?.UserName ?? "admin";
                options.Password = rabbitMqOptions?.Password ?? "123456";
                options.VirtualHost = rabbitMqOptions?.VirtualHost ?? "/";
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
        });
        services.AddScoped<IEventBus, CapRabbitMqEventBus>();
        var capCoreType = typeof(XXX.Net.Core.Consumers.CapCoreMarker);
        var consumerTypes = capCoreType.Assembly.GetTypes()
            .Where(t => typeof(DotNetCore.CAP.ICapSubscribe).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract)
            .ToList();

        foreach (var consumerType in consumerTypes)
        {
            services.AddScoped(consumerType);
        }
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
