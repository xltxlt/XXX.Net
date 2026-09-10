using XXX.Net.Core.BaseEntitys.Entity;
using MongoDB.Driver;

using System.Linq.Expressions;

namespace XXX.Net.Core.MongoDb
{
    /// <summary>
    /// MongoDB 通用仓储实现
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class MongoBaseRepository<T> : IMongoBaseRepository<T> where T : BaseMongoEntity, new()
    {
        private readonly IMongoCollection<T> _collection;

        public MongoBaseRepository(IMongoDbContext context)
        {
            _collection = context.GetCollection<T>();
        }

        #region 查询

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 根据过滤条件获取实体列表
        /// </summary>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// 根据过滤定义获取实体列表
        /// </summary>
        public async Task<List<T>> GetListAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public async Task<(List<T> Items, long Total)> GetPagedListAsync(
            Expression<Func<T, bool>> filter,
            int pageIndex,
            int pageSize,
            Expression<Func<T, object>> sortBy = null,
            bool ascending = true)
        {
            var query = _collection.Find(filter);
            var total = await query.CountDocumentsAsync();

            if (sortBy != null)
            {
                var sort = ascending
                    ? Builders<T>.Sort.Ascending(sortBy)
                    : Builders<T>.Sort.Descending(sortBy);
                query = query.Sort(sort);
            }

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return (items, total);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        public async Task<T?> QuerySingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        /// <summary>
        /// 查询单个实体
        /// </summary>
        public async Task<T?> QuerySingleLastAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).SortByDescending(w=>w.Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).AnyAsync();
        }

        /// <summary>
        /// 统计数量
        /// </summary>
        public async Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.CountDocumentsAsync(filter);
        }

        #endregion

        #region 写入

        /// <summary>
        /// 插入单个实体
        /// </summary>
        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        /// <summary>
        /// 根据ID替换整个实体
        /// </summary>
        public async Task<bool> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.ReplaceOneAsync(filter, entity);
            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// 根据过滤条件部分更新
        /// </summary>
        public async Task<bool> UpdateAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update)
        {
            var result = await _collection.UpdateManyAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }

        /// <summary>
        /// 根据过滤条件删除
        /// </summary>
        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var result = await _collection.DeleteManyAsync(filter);
            return result.DeletedCount > 0;
        }

        #endregion
    }
}
