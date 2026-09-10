using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.EventBus
{
    public interface IEventBus
    {
        /// <summary>
        /// 立即发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task PublishAsync<T>(string name, BaseEvent<T> data);
        /// <summary>
        /// 延迟发布
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="seconds"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>

        Task PublishDelayAsync<T>(int seconds, string name, BaseEvent<T> data);
    }
}
