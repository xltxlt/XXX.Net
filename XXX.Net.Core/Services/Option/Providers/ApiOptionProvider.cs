using System.Collections;
using System.Reflection;
using XXX.Net.Core.Services.Option.Attributes;

namespace XXX.Net.Core.Services.Option.Providers
{
    public class ApiOptionProvider : IOptionProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiOptionProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool CanHandle(OptionAttribute attribute) => attribute is OptionApiAttribute;

        public async Task<List<PagedOptions>> GetOptions(PropertyInfo property, bool tree = false)
        {
            var attr = property.GetCustomAttribute<OptionApiAttribute>();
            if (attr == null)
                return new List<PagedOptions>();

            return await GetOptions(attr);
        }

        public async Task<List<PagedOptions>> GetOptions(OptionApiAttribute attr)
        {
            if (attr == null)
                return new List<PagedOptions>();

            var api = _serviceProvider.GetService(attr.ApiType);
            if (api == null)
                throw new InvalidOperationException($"未注册 Furion API 接口：{attr.ApiType.FullName}");

            var method = attr.ApiType.GetMethod(
                attr.MethodName,
                BindingFlags.Public | BindingFlags.Instance);
            if (method == null)
                throw new MissingMethodException(attr.ApiType.FullName, attr.MethodName);
            if (method.GetParameters().Length != 0)
                throw new InvalidOperationException(
                    $"选项 API {attr.ApiType.Name}.{attr.MethodName} 必须是无参数方法；需要参数时请通过服务方法封装后再使用 OptionApiAttribute");

            var invocationResult = method.Invoke(api, Array.Empty<object>());
            var response = await ReadAsync(invocationResult);
            var data = GetData(response, attr.DataProperty);

            if (data is IEnumerable<PagedOptions> options)
                return options.ToList();

            if (data is not IEnumerable items)
                return new List<PagedOptions>();

            var result = new List<PagedOptions>();
            foreach (var item in items)
            {
                if (item == null)
                    continue;

                if (item is PagedOptions option)
                {
                    result.Add(option);
                    continue;
                }

                result.Add(new PagedOptions
                {
                    Value = GetPropertyValue(item, attr.ValueProperty),
                    Label = Convert.ToString(GetPropertyValue(item, attr.LabelProperty)) ?? string.Empty
                });
            }

            return result;
        }

        private static async Task<object> ReadAsync(object invocationResult)
        {
            if (invocationResult is not Task task)
                throw new InvalidOperationException("Furion API 方法必须返回 Task 类型");

            await task;
            return task.GetType().GetProperty("Result")?.GetValue(task);
        }

        private static object GetData(object response, string dataProperty)
        {
            if (response == null || string.IsNullOrWhiteSpace(dataProperty))
                return response;

            var current = response;
            foreach (var name in dataProperty.Split('.', StringSplitOptions.RemoveEmptyEntries))
            {
                current = GetPropertyValue(current, name);
                if (current == null)
                    return null;
            }

            return current;
        }

        private static object GetPropertyValue(object value, string propertyName)
        {
            if (value == null || string.IsNullOrWhiteSpace(propertyName))
                return null;

            return value.GetType()
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                ?.GetValue(value);
        }

        public Task<List<PagedOptions>> GetOptions(
            string name,
            string labelKey = "",
            string valueKey = "",
            bool tree = false)
        {
            return Task.FromResult(new List<PagedOptions>());
        }

        public Task<List<PagedOptions>> GetOptions(string name, bool tree = false)
        {
            return Task.FromResult(new List<PagedOptions>());
        }
    }
}