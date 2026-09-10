using Furion;
using System.Reflection;

namespace XXX.Net.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "XXX.Net.Plugins.Inventory",
            "XXX.Net.Plugins.WorkFlow",
            "XXX.Net.Application",
            "XXX.Net.Core",
            "XXX.Net.EntityFramework.Core",
            "XXX.Net.Web.Core"
        };
    }
}