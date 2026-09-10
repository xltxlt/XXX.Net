using Furion.Extensions;
using Furion.Extensitions;
using Furion.HttpRemote;
using Furion.HttpRemote.Extensions;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Services.Dict;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Core.Services.Option.Providers;
using System.Runtime.InteropServices;
namespace XXX.Net.Core.Services.Option
{
    public class OptionService
    {
        private readonly IEnumerable<IOptionProvider> _providers;
        private readonly IHttpRemoteService _httpRemoteService;
        public OptionService(IEnumerable<IOptionProvider> providers,IHttpRemoteService httpRemoteService )
        {
            _providers = providers;
            _httpRemoteService = httpRemoteService;
        }
        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <returns></returns>
        public async Task<Dictionary<string, List<PagedOptions>>> GetOptions<TDto>()
        {
            var result = new Dictionary<string, List<PagedOptions>>();

            var props = typeof(TDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var attr = prop
                    .GetCustomAttributes<OptionAttribute>()
                    .FirstOrDefault();

                if (attr == null)
                    continue;

                var provider = _providers
                    .FirstOrDefault(p => p.GetType() == attr.ProviderType);

                if (provider == null || !provider.CanHandle(attr))
                    continue;
                bool treeOption = prop.Name == "Path";
                var options = await provider.GetOptions(prop, treeOption);

                if (options?.Any() == true)
                {
                    result[prop.Name.ToFirstLowerInvariant()] = options;
                }
            }

            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherOptionSources"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, List<PagedOptions>>> GetOptions(
            List<OtherOptionSource> otherOptionSources,
            List<PagedCustomWhere> where = null)
        {
            var result = new Dictionary<string, List<PagedOptions>>();


            foreach (var prop in otherOptionSources)
            {
                var attr = prop.OptionAttr;

                if (attr == null)
                    continue;

                var provider = _providers
                    .FirstOrDefault(p => p.GetType() == attr.ProviderType);

                if (provider == null || !provider.CanHandle(attr))
                    continue;
               
                List<PagedOptions> options = new List<PagedOptions>();
                if (attr is OptionFunAttribute funAttr && provider is FunOptionProvider funProvider)
                {
                    options = await funProvider.GetOptions(
                        funAttr,
                        prop.Where ?? where ?? new List<PagedCustomWhere>());
                }
                else if (attr is OptionApiAttribute apiAttr && provider is ApiOptionProvider apiProvider)
                {
                    options = await apiProvider.GetOptions(apiAttr);
                }
                else if (attr is OptionEnumAttribute enumAttr)
                {
                    options = await provider.GetOptions(enumAttr.EnumType.Name, prop.TreeOption);
                }
                else
                {
                    bool treeOption = prop.FieldName == "Path";
                    var name = prop.FieldName;
                    if (attr is OptionEntityAttribute)
                    {
                        name = (attr as OptionEntityAttribute).TableName;
                    }
                    
                    options = await provider.GetOptions(name, prop.TreeOption);
                }

                if (options?.Any() == true)
                {
                    result[prop.FieldName.ToFirstLowerInvariant()] = options;
                }
            }

            return result;
        }
        /// <summary>
        /// 根据实体类attr 来获取搜索选项
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, List<PagedOptions>>> GetOptions<TDto>(List<SysMenuSerachFieldDto> searchFields)
        {
            var result = new Dictionary<string, List<PagedOptions>>();

            var props = typeof(TDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);


            var selectType = new List<int>() {
                (int)PageSearchTypeEnum.OneSelect,
                (int)PageSearchTypeEnum.MultSelect,
                (int)PageSearchTypeEnum.TreeSelect,
                (int)PageSearchTypeEnum.MultTreeSelect,
                (int)PageSearchTypeEnum.SelfTreeSelect,
                (int)PageSearchTypeEnum.MultSelfTreeSelect,
            };
            var fields = searchFields.Where(w => selectType.Contains(w.SearchType) && w.DataSourceType == (int)DataSourceTypeEnum.Default);

            var fieldProps= props.Where(w => fields.Select(s => s.FieldName).Contains(w.Name));
            foreach (var prop in fieldProps)
            {
                var attr = prop
                    .GetCustomAttributes<OptionAttribute>()
                    .FirstOrDefault();

                if (attr == null)
                    continue;

                var provider = _providers
                    .FirstOrDefault(p => p.GetType() == attr.ProviderType);

                if (provider == null || !provider.CanHandle( attr))
                    continue;

                var options = await provider.GetOptions(prop);
                result[prop.Name.ToFirstLowerInvariant()] = options;
            }
            var otherFieldProps = searchFields.Where(w => selectType.Contains(w.SearchType) && w.DataSourceType != (int)DataSourceTypeEnum.Default&&w.DataSourceType!=(int)DataSourceTypeEnum.FormOther);

            Dictionary<string, List<PagedOptions>> otehrResult= await GetOptions(otherFieldProps.Select(s=>s.Adapt<BaseDataSource>()).ToList());
            return result.Concat(otehrResult).ToDictionary();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, List<PagedOptions>>> GetOptions(List<BaseDataSource> dataSources)
        {
            var result = new Dictionary<string, List<PagedOptions>>();
            if (dataSources == null || dataSources.Count() == 0) return result;
            dataSources=dataSources.Where(w => w.DataSourceType != (int)DataSourceTypeEnum.Default).ToList();
            var _enumOptionProvider = _providers.OfType<EnumOptionProvider>().FirstOrDefault();
            var _entityOptionProvider = _providers.OfType<EntityOptionProvider>().FirstOrDefault();
            var _dictOptionProvider = _providers.OfType<DictOptionProvider>().FirstOrDefault();
            foreach (var item in dataSources)
            {
                List<PagedOptions> options = new List<PagedOptions>();
                switch (item.DataSourceType) {

                    case (int)DataSourceTypeEnum.FormEnum:
                        options = await _enumOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    case (int)DataSourceTypeEnum.FormEntity:
                        options = await _entityOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    case (int)DataSourceTypeEnum.FormDict:
                        options = await _dictOptionProvider.GetOptions(item.DataSourceValue);
                        break;
                    case (int)DataSourceTypeEnum.FormApi:
                        object content = null;
                        if (item.HttpType == (int)HttpTypeEnum.HttpPost)
                        {

                            content = await _httpRemoteService.PostAsAsync<List<PagedOptions>>(requestUri: item.DataSourceValue,
                         builder => builder
                                    .WithHeaders("Content-Type: application/json; charset=utf-8")
                                    .WithHeaders(item.DataSourceHeaders)
                                    .SetJsonContent(item.DataSourcePars));
                        }
                        else if (item.HttpType == (int)HttpTypeEnum.HttpGet)
                        {
                          
                            content = await _httpRemoteService.GetAsAsync<List<PagedOptions>>(requestUri: item.DataSourceValue,
                         builder => builder
                                    .WithHeaders("Content-Type: application/json; charset=utf-8")
                                    .WithHeaders (item.DataSourceHeaders)
                                    .WithQueryParameters(item.DataSourcePars));
                        }
                        options = content as List<PagedOptions> ?? new List<PagedOptions>();
                        break;
                    default:break;
                }
                result.Add(item.FieldName.ToFirstLowerInvariant(), options);
            }
            return result;
        }
    }
}
