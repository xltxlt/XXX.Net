using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Core.Services.Option.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Option.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionEnumAttribute : OptionAttribute
    {
        public Type EnumType { get; }

        public OptionEnumAttribute(Type enumType) : base(typeof(EnumOptionProvider))
    {
            if (!enumType.IsEnum)
                throw new ArgumentException("必须是枚举类型");

            EnumType = enumType;
        }
    }
}
