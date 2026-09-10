using XXX.Net.Core.Cache;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Dict;
using XXX.Net.Core.Services.Dict.Dto;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XXX.Net.Core.Services.Option.Providers
{
    /// <summary>
    /// TODO 待提升效率从缓存中读
    /// </summary>
    public class DictOptionProvider : IOptionProvider
    {
        private readonly ICacheService _cacheService;
        public bool CanHandle(OptionAttribute attribute)=> attribute is OptionDictAttribute ;

        public DictOptionProvider(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public  async Task<List<PagedOptions>> GetOptions(PropertyInfo property, bool tree = false)
        {
            var attr = property.GetCustomAttribute<OptionDictAttribute>();
            if (attr == null) return new List<PagedOptions>();

            var list =await _cacheService.GetDictDataAsync(attr.DictCode);
            return list;
        }
        public async Task<List<PagedOptions>> GetOptions(string name,string labelKey = "", string valueKey="",bool tree=false)
        {

            var list = await _cacheService.GetDictDataAsync(name);
            return list;
        }
        public async Task<List<PagedOptions>> GetOptions(string name,  bool tree)
        {
            return await GetOptions(name, "", "", tree);
        }
    }
}
