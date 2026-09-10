
using System.Threading;

namespace XXX.Net.Core.Cache
{
    public interface ICacheService
    {
        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        Task SetAsync<T>(string key,T value,TimeSpan? expire = null);

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);

     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mianKey"></param>
        /// <returns></returns>
        Task<List<PagedOptions>> GetEnumDataAsync(string key, string mianKey = "Sys_EnumData");


        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mianKey"></param>
        /// <returns></returns>
        Task<List<PagedOptions>> GetDictDataAsync(string key, string mianKey = "Sys_DictData");

        /// <summary>
        /// 获取系统配置数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mianKey"></param>
        /// <returns></returns>
        Task<string> GetSysConfigAsync(string key, string mianKey = "Sys_ConfigData");

      

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveAsync(string key);


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string key);

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<long> IncrementAsync(string key,long value = 1);
      
    }
}
