using Furion.EventBus;
using XXX.Net.Core.EventBus;
using Microsoft.Extensions.Logging;

namespace XXX.Net.Application;

public class SystemService : ISystemService, ITransient
{
    public string GetDescription()
    {

        
        return "让 .NET 开发更简单，更通用，更流行。";
    }
    [UnitOfWork]
    [IfException("1000", ErrorMessage = "我覆盖了默认的：{0} 不能小于 {1}")]
    public async Task<string>  PostRegister(IEventPublisher _publisher)
    {
        await _publisher.PublishAsync(SysUserEvents.UserRegister);
        //throw Oops.Oh("不能为空",99,110);
        return "注册成功";
    }


    /// <summary>
    /// 用户注册消费者
    /// </summary>
    public class RegisterSubcibe : IEventSubscriber,ISingleton {
        [EventSubscribe(SysUserEvents.UserRegister)]
        public async Task 发送短信(EventHandlerExecutedContext contenxt) {
            Console.WriteLine("发送短信");
        }
    }
}
