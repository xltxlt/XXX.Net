

namespace XXX.Net.Core.Cache
{
    public class EnumCache
    {

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; } = string.Empty;


        /// <summary>
        /// 类型
        /// </summary>
        public string EnumType { get; set; } = string.Empty;


        /// <summary>
        /// 数据
        /// </summary>
        public List<EnumItem> Items { get; set; } = new List<EnumItem>();

    }


    public class EnumItem
    {

        public int Value { get; set; }


        public string Label { get; set; } = string.Empty;

    }
}
