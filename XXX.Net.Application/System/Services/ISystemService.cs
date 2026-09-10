using Furion.EventBus;

namespace XXX.Net.Application;

public interface ISystemService
{
    string GetDescription();
    Task<string> PostRegister(IEventPublisher _publisher);
}
