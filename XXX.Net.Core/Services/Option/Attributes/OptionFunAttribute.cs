using XXX.Net.Core.Services.Option.Providers;

namespace XXX.Net.Core.Services.Option.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionFunAttribute : OptionAttribute
    {
        public Type ServiceType { get; }
        public string MethodName { get; }

        public OptionFunAttribute(Type serviceType, string methodName) : base(typeof(FunOptionProvider))
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("方法名不能为空", nameof(methodName));

            ServiceType = serviceType;
            MethodName = methodName;
        }
    }
}
