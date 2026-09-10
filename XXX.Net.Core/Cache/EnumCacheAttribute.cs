

namespace XXX.Net.Core.Cache
{
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = false)]
    public class EnumCacheAttribute : Attribute
    {
        public string Name { get; }

        public EnumCacheAttribute(string name)
        {
            Name = name;
        }
    }
}
