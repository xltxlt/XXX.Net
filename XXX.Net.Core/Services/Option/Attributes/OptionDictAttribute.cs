using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Core.Services.Option.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Option.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OptionDictAttribute : OptionAttribute
    {
        public string DictCode { get; }

        public OptionDictAttribute(string dictCode):base(typeof(DictOptionProvider))
        {
            DictCode = dictCode;
        }
    }
    
}
