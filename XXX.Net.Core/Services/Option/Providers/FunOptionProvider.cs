using System.Reflection;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;

namespace XXX.Net.Core.Services.Option.Providers
{
    public class FunOptionProvider : IOptionProvider
    {
        public bool CanHandle(OptionAttribute attribute) => attribute is OptionFunAttribute;

        private readonly IServiceProvider _serviceProvider;

        public FunOptionProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<List<PagedOptions>> GetOptions(PropertyInfo property, bool tree = false)
        {
            var attr = property.GetCustomAttribute<OptionFunAttribute>();
            if (attr == null)
                return new List<PagedOptions>();

            return await GetOptions(attr, new List<PagedCustomWhere>());
        }

        public async Task<List<PagedOptions>> GetOptions(
            OptionFunAttribute attr,
            List<PagedCustomWhere> where = null)
        {
            if (attr == null)
                return new List<PagedOptions>();

            var service = _serviceProvider.GetService(attr.ServiceType);
            if (service == null)
                throw new InvalidOperationException($"未注册选项服务：{attr.ServiceType.FullName}");

            var method = attr.ServiceType.GetMethod(
                attr.MethodName,
                BindingFlags.Public | BindingFlags.Instance);
            if (method == null)
                throw new MissingMethodException(attr.ServiceType.FullName, attr.MethodName);

            var parameters = method.GetParameters();
            object[] arguments = parameters.Length switch
            {
                0 => Array.Empty<object>(),
                1 when parameters[0].ParameterType == typeof(List<PagedCustomWhere>)
                    => new object[] { where ?? new List<PagedCustomWhere>() },
                _ => throw new InvalidOperationException(
                    $"选项方法 {attr.ServiceType.Name}.{attr.MethodName} 只支持无参数或 List<PagedCustomWhere> 参数")
            };

            var invocationResult = method.Invoke(service, arguments);
            return await ReadOptionsAsync(invocationResult);
        }

        private static async Task<List<PagedOptions>> ReadOptionsAsync(object invocationResult)
        {
            if (invocationResult is not Task task)
                throw new InvalidOperationException("选项方法必须返回 Task<List<PagedOptions>>");

            await task;
            var result = task.GetType().GetProperty("Result")?.GetValue(task);
            var options = result.Adapt<List<PagedOptions>>();
            return options;
        }

        public Task<List<PagedOptions>> GetOptions(string name, string valueKey = "Name", string labelKey = "Id", bool tree = false)
        {
            return Task.FromResult(new List<PagedOptions>());
        }
        public Task<List<PagedOptions>> GetOptions(string name, bool tree)
        {
            return GetOptions(name, "Id", "Name", tree);
        }
    }
}
