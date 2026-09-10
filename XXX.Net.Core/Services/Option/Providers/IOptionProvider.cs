using XXX.Net.Core.Services.Option.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace XXX.Net.Core.Services.Option.Providers
{
    public interface IOptionProvider
    {
        bool CanHandle( OptionAttribute attribute);
        Task<List<PagedOptions>>  GetOptions(PropertyInfo property,bool tree=false);
        Task<List<PagedOptions>> GetOptions(string name, string labelKey="", string valueKey="", bool tree = false);
        Task<List<PagedOptions>> GetOptions(string name, bool tree = false);


    }
}
