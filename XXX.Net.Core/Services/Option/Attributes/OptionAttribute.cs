using XXX.Net.Core.Services.Option.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Option.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class OptionAttribute : System.Attribute
    {
        public Type ProviderType { get; }

        protected OptionAttribute(Type providerType)
        {
            if (!typeof(IOptionProvider).IsAssignableFrom(providerType))
                throw new ArgumentException(
                    $"{providerType.Name} 必须实现 IOptionProvider", nameof(providerType));

            ProviderType = providerType;
        }
    }
}
