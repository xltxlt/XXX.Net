
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XXX.Net.Core.EventBus
{

    /// <summary>
    /// 通用领域事件消息
    /// </summary>
    /// <typeparam name="T">事件数据类型</typeparam>
    public sealed class BaseEvent<T>
    {
        public BaseEvent() { 
            EventId = Guid.NewGuid();
            OccurredOn = DateTime.Now;
        }
        public BaseEvent(string eventName, T data)
        {
            EventId = Guid.NewGuid();
            EventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
            OccurredOn = DateTime.Now;
            Data = data;
        }
        public BaseEvent(long tenantId,string eventName, T data)
        {
            EventId = Guid.NewGuid();
            EventName = eventName ?? throw new ArgumentNullException(nameof(eventName));
            OccurredOn = DateTime.Now;
            Data = data;
            TenantId = tenantId;
        }
        /// <summary>
        /// 事件唯一标识
        /// 用于幂等处理
        /// </summary>
        public Guid EventId { get; init; }

        /// <summary>
        /// 租户Id
        /// </summary>
        public long TenantId { get; set; }

        /// <summary>
        /// 事件名称
        /// 例如：UserCreated、InventoryCreated
        /// </summary>
        public string EventName { get; init; }

        /// <summary>
        /// 事件版本
        /// 用于事件结构升级
        /// </summary>
        public int EventVersion { get; init; } = 1;

        /// <summary>
        /// 事件发生时间
        /// </summary>
        public DateTime OccurredOn { get; init; }

        /// <summary>
        /// 链路追踪ID
        /// </summary>
        public string TraceId { get; init; }

        /// <summary>
        /// 事件来源
        /// 例如：Inventory、User、Order
        /// </summary>
        public string Source { get; init; }

        /// <summary>
        /// 事件数据
        /// </summary>
        public T Data { get; init; }
    }

}
