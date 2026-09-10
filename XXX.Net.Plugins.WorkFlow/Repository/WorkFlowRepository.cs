using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using XXX.Net.Core.MongoDb;
using XXX.Net.Plugins.WorkFlow.Entity;

namespace XXX.Net.Plugins.WorkFlow.Repository
{
    public interface IWorkFlowRepository<T> where T : WorkFlowMongoEntity, new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetOneAsync(Expression<Func<T, bool>> filter);
        Task InsertAsync(T entity);
        Task InsertManyAsync(List<T> entitys);
        Task<bool> UpdateAsync(string id, T entity);
        Task<bool> DeleteAsync(string id);
    }

    /// <summary>
    /// WorkFlow 专用 Mongo 仓储（基于 IMongoDbContext，实体继承 WorkFlowMongoEntity）
    /// </summary>
    public class WorkFlowRepository<T> : IWorkFlowRepository<T> where T : WorkFlowMongoEntity, new()
    {
        private readonly IMongoCollection<T> _collection;

        public WorkFlowRepository(IMongoDbContext context)
        {
            _collection = context.GetCollection<T>();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);

        }
        public async Task InsertManyAsync(List<T> entitys)
        {
            await _collection.InsertManyAsync(entitys);

        }
        public async Task<bool> UpdateAsync(string id, T entity)
        {
            var result = await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
            return result.DeletedCount > 0;
        }
    }
}
