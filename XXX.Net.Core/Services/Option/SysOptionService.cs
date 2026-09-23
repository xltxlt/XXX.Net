using Furion.HttpRemote;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Cache;
using XXX.Net.Core.Services.Option.Providers;

namespace XXX.Net.Core.Services.Option
{
    public class SysOptionService : IDynamicApiController
    {
        private readonly IEnumerable<IOptionProvider> _providers;
        private readonly IHttpRemoteService _httpRemoteService;
        private readonly ICacheService _cacheService;
        public SysOptionService(IEnumerable<IOptionProvider> providers, IHttpRemoteService httpRemoteService, ICacheService cacheService)
        {
            _providers = providers;
            _httpRemoteService = httpRemoteService;
            _cacheService = cacheService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<Dictionary<string, List<PagedOptions>>> GetOptions(List<BaseDataSource> dataSources)
        {
            var result = new Dictionary<string, List<PagedOptions>>();
            if (dataSources == null || dataSources.Count() == 0) return result;
            dataSources = dataSources.Where(w => w.DataSourceType != (int)DataSourceTypeEnum.Default).ToList();
            var _enumOptionProvider = _providers.OfType<EnumOptionProvider>().FirstOrDefault();
            var _entityOptionProvider = _providers.OfType<EntityOptionProvider>().FirstOrDefault();
            var _dictOptionProvider = _providers.OfType<DictOptionProvider>().FirstOrDefault();
            foreach (var item in dataSources)
            {
                List<PagedOptions> options = new List<PagedOptions>();
                switch (item.DataSourceType)
                {

                    case (int)DataSourceTypeEnum.FormEnum:
                        options = await _enumOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    case (int)DataSourceTypeEnum.FormEntity:
                        options = await _entityOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    case (int)DataSourceTypeEnum.FormDict:
                        options = await _dictOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    //case (int)DataSourceTypeEnum.FormApi:
                    //    object content = null;
                    //    if (item.HttpType == (int)HttpTypeEnum.HttpPost)
                    //    {

                    //        content = await _httpRemoteService.PostAsAsync<List<PagedOptions>>(requestUri: item.DataSourceValue,
                    //     builder => builder
                    //                .WithHeaders("Content-Type: application/json; charset=utf-8")
                    //                .WithHeaders(item.DataSourceHeaders)
                    //                .SetJsonContent(item.DataSourcePars));
                    //    }
                    //    else if (item.HttpType == (int)HttpTypeEnum.HttpGet)
                    //    {

                    //        content = await _httpRemoteService.GetAsAsync<List<PagedOptions>>(requestUri: item.DataSourceValue,
                    //     builder => builder
                    //                .WithHeaders("Content-Type: application/json; charset=utf-8")
                    //                .WithHeaders(item.DataSourceHeaders)
                    //                .WithQueryParameters(item.DataSourcePars));
                    //    }
                    //    options = content as List<PagedOptions> ?? new List<PagedOptions>();
                    //    break;

                    default: break;
                }
                result.Add(item.FieldName.ToFirstLowerInvariant(), options);
            }
            return result;
        }


        /// <summary>
        /// 获取所有可选的数据源
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<Dictionary<string, List<PagedOptions>>> OptionAll()
        {
            var sys_EnumData = await _cacheService.GetAsync<List<EnumCache>>("Sys_EnumData");
            var sys_DictData = await _cacheService.GetAsync<Dictionary<string, List<PagedOptions>>>("Sys_DictData");
            var mlDic = new Dictionary<string, List<PagedOptions>>();

            mlDic.Add(key: "Sys_EnumData", sys_EnumData.Select(s => new PagedOptions() { 
                Label= s.Name,
                Value=s.Name
            }).ToList());
            mlDic.Add(key: "Sys_DictData", sys_DictData.Select(s => new PagedOptions()
            {
                Label = s.Key,
                Value = s.Key
            }).ToList());
            return mlDic;
        }
    }
}
