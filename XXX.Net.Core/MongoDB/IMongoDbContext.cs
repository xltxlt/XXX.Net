using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.MongoDb
{
    /// <summary>
    /// MongoDB 数据库上下文接口
    /// </summary>
    public interface IMongoDbContext
    {
        /// <summary>
        /// 获取指定类型的 MongoDB 集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>MongoDB 集合</returns>
        IMongoCollection<T> GetCollection<T>() where T : class;
    }
}
