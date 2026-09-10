using MongoDB.Driver;

namespace XXX.Net.Core.MongoDb
{
    /// <summary>
    /// MongoDB 数据库上下文实现
    /// </summary>
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient client, MongoOptions options)
        {
            _database = client.GetDatabase(options.DatabaseName);
        }

        /// <summary>
        /// 获取指定类型的 MongoDB 集合，集合名称默认使用类名驼峰命名
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>MongoDB 集合</returns>
        public IMongoCollection<T> GetCollection<T>() where T : class
        {
            var collectionName = typeof(T).Name;
            // 首字母小写转换为驼峰命名
            if (collectionName.Length > 0)
            {
                collectionName = char.ToLowerInvariant(collectionName[0]) + collectionName.Substring(1);
            }
            return _database.GetCollection<T>(collectionName);
        }
    }
}
