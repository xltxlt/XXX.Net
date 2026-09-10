namespace XXX.Net.Core.MongoDb
{
    /// <summary>
    /// MongoDB 配置选项
    /// </summary>
    public class MongoOptions
    {
        /// <summary>
        /// MongoDB 连接字符串
        /// </summary>
        public string ConnectionString { get; set; } = "mongodb://localhost:27017";

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DatabaseName { get; set; } = "CoreHistory";
    }
}
