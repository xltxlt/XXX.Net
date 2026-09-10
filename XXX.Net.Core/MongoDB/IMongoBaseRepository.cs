using XXX.Net.Core.BaseEntitys.Entity;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace XXX.Net.Core.MongoDb { 
    /// <summary>
    /// MongoDB 通用仓储接口
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public interface IMongoBaseRepository<T> where T : BaseMongoEntity, new()
    {
        #region 查询

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// 根据过滤条件获取实体列表
        /// </summary>
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 根据过滤定义获取实体列表
        /// </summary>
        Task<List<T>> GetListAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="pageIndex">页码，从1开始</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="sortBy">排序字段</param>
        /// <param name="ascending">是否升序</param>
        /// <returns>分页数据和总记录数</returns>
        Task<(List<T> Items, long Total)> GetPagedListAsync(
            Expression<Func<T, bool>> filter,
            int pageIndex,
            int pageSize,
            Expression<Func<T, object>> sortBy = null,
            bool ascending = true);

        /// <summary>
        /// 查询单个实体
        /// </summary>
        Task<T> QuerySingleAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> QuerySingleLastAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 统计数量
        /// </summary>
        Task<long> CountAsync(Expression<Func<T, bool>> filter);

        #endregion

        #region 写入

        /// <summary>
        /// 插入单个实体
        /// </summary>
        Task InsertAsync(T entity);

        /// <summary>
        /// 批量插入
        /// </summary>
        Task InsertManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// 根据ID替换整个实体
        /// </summary>
        Task<bool> UpdateAsync(string id, T entity);

        /// <summary>
        /// 根据过滤条件部分更新
        /// </summary>
        Task<bool> UpdateAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update);

        /// <summary>
        /// 根据ID删除
        /// </summary>
        Task<bool> DeleteAsync(string id);

        /// <summary>
        /// 根据过滤条件删除
        /// </summary>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> filter);

        #endregion
    }
}
