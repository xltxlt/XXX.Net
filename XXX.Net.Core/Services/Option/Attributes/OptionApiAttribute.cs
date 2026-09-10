using XXX.Net.Core.Services.Option.Providers;

namespace XXX.Net.Core.Services.Option.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionApiAttribute : OptionAttribute
    {
        public Type ApiType { get; }
        public string MethodName { get; }
        public string DataProperty { get; }
        public string ValueProperty { get; }
        public string LabelProperty { get; }

        public OptionApiAttribute(
            Type apiType,
            string methodName,
            string dataProperty = null,
            string valueProperty = "Id",
            string labelProperty = "Name") : base(typeof(ApiOptionProvider))
        {
            if (apiType == null)
                throw new ArgumentNullException(nameof(apiType));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentException("方法名不能为空", nameof(methodName));

            ApiType = apiType;
            MethodName = methodName;
            DataProperty = dataProperty;
            ValueProperty = valueProperty;
            LabelProperty = labelProperty;
        }
    }
}
