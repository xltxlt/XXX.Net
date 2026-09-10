using XXX.Net.Core.Cache;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using Microsoft.OpenApi;
using System.ComponentModel;
using System.Reflection;

namespace XXX.Net.Core.Services.Option.Providers
{
    /// <summary>
    /// TODO 待提升效率从缓存中读
    /// </summary>
    public class EnumOptionProvider : IOptionProvider
    {
        //public  async Task<List<PagedOptions>>  GetOptions(System.Reflection.PropertyInfo property)
        //{
        //    var attr = property.GetCustomAttribute<OptionEnumAttribute>();
        //    if (attr == null) return null;

        //    return Enum.GetValues(attr.EnumType)
        //        .Cast<Enum>()
        //        .Select(e => new PagedOptions
        //        {
        //            Value = Convert.ToInt64(e),
        //            Label = e.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description ?? e.ToString()
        //        })
        //        .ToList();
        //}

        //public async Task<List<PagedOptions>> GetOptions(string name, string labelKey = "", string valueKey = "")
        //{
        //    var enumType = Type.GetType(name);
        //    if (enumType == null || !enumType.IsEnum)
        //        return Task.FromResult(new List<PagedOptions>());

        //    var list = Enum.GetValues(enumType)
        //        .Cast<Enum>()
        //        .Select(e => new PagedOptions
        //        {
        //            Value = Convert.ToInt64(e),
        //            Label = e.GetType().GetCustomAttribute<DescriptionAttribute>()?.Description ?? e.ToString()
        //        })
        //        .ToList();

        //    return Task.FromResult(list);
        //}
        private readonly ICacheService _cacheService;
        public bool CanHandle(OptionAttribute attribute) => attribute is OptionEnumAttribute ;


        public EnumOptionProvider(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }
        public async Task<List<PagedOptions>> GetOptions(System.Reflection.PropertyInfo property, bool tree = false)
        {
            var attr = property.GetCustomAttribute<OptionEnumAttribute>();
            if (attr == null) return null;

            return await _cacheService.GetEnumDataAsync(attr.EnumType.Name) ;
            
        }

        public async Task<List<PagedOptions>> GetOptions(string name, string labelKey = "", string valueKey = "", bool tree = false)
        {
            return await _cacheService.GetEnumDataAsync(name);

        }
        public async Task<List<PagedOptions>> GetOptions(string name,bool tree)
        {
            return await _cacheService.GetEnumDataAsync(name);

        }
    }
}
