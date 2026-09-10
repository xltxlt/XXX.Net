using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;


namespace XXX.Net.Core.Cache
{
    public class EnumScanner
    {
        public List<EnumCache> Scan()
        {
            var result = new List<EnumCache>();
            var assemblies =AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(t =>t.IsEnum &&t.GetCustomAttribute<EnumCacheAttribute>() != null);
                foreach (var type in types)
                {

                    var attr =type.GetCustomAttribute<EnumCacheAttribute>();

                    var items = Enum.GetValues(type)
                        .Cast<object>()
                        .Select(x =>
                        {

                            var field =type.GetField(x.ToString());
                            var desc =field?.GetCustomAttribute<DescriptionAttribute>()?.Description?? x.ToString();

                            return new EnumItem
                            {
                                Value = Convert.ToInt32(x),
                                Label = desc??""
                            };
                        }).ToList();

                    result.Add(new EnumCache
                    {
                        Name = attr?.Name??"",
                        EnumType = type.Name,
                        Items = items
                    });
                }
            }
            return result;
        }
    }
}
