using DotNetCore.CAP.Dashboard;
using Furion.JsonSerialization;
using XXX.Net.Core.Cache;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services;
using XXX.Net.Core.Services.Config.Dto;
using XXX.Net.Core.Services.Dict.Dto;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;

namespace XXX.Net.Core.Cache

{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _db;
        private readonly CacheOptions _options;

        public RedisCacheService(IConnectionMultiplexer redis, CacheOptions options)
        {
            _db = redis.GetDatabase();
            _options = options;
        }




        private string Key(string key)
        {
            return $"{_options.InstanceName}{key}";
        }



        public async Task SetAsync<T>(string key, T value, TimeSpan? expire = null)
        {

            if (value != null)
            {
                if (value is string cacheValue)
                {
                    await _db.StringSetAsync(Key(key), cacheValue);
                }
                else
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    };

                    await _db.StringSetAsync(Key(key), JsonSerializer.Serialize(value, options));
                }
                if (expire.HasValue)
                {
                    await _db.KeyExpireAsync(Key(key), expire);
                }
            }

        }



        public async Task<T> GetAsync<T>(string key)
        {

            var value = await _db.StringGetAsync(Key(key));
            if (value.IsNullOrEmpty)
                return default(T);

            return JSON.Deserialize<T>(value!);
        }


        public async Task RemoveAsync(string key)
        {

            await _db.KeyDeleteAsync(Key(key));
        }


        public async Task<bool> ExistsAsync(string key)
        {
            return await _db.KeyExistsAsync(Key(key));
        }



        public async Task<long> IncrementAsync(string key, long value = 1)
        {
            return await _db.StringIncrementAsync(Key(key), value);
        }

        public async Task<List<PagedOptions>> GetEnumDataAsync(string key, string mianKey = "Sys_EnumData")
        {
            List<EnumCache> data = await GetAsync<List<EnumCache>>(mianKey);
            if (data == null) return new List<PagedOptions>();
            return data.Where(x => x.EnumType == key).SelectMany(x => x.Items)
                .Select(s => new PagedOptions()
                {
                    Label = s.Label,
                    Value = s.Value,
                    Disaebled = false

                })
                .ToList();
        }


        

        public async Task<string> GetSysConfigAsync(string key, string mianKey = "Sys_ConfigData")
        {
            var data = await GetAsync<Dictionary<string, string>>(mianKey);
            if (data == null) return null;
            return data.Where(x => x.Key == key).LastOrDefault().Value;
        }
      
        public async Task<List<PagedOptions>> GetDictDataAsync(string key, string mianKey = "Sys_DictData")
        {
            var data = await GetAsync<Dictionary<string, List<PagedOptions>>>(mianKey);
            if (data == null) return null;
            return data.Where(x => x.Key == key).LastOrDefault().Value;
        }
    }
}