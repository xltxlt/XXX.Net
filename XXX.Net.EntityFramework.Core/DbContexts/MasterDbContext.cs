using Furion.DatabaseAccessor;
using XXX.Net.Core.BaseEntitys;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using IdGen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace XXX.Net.EntityFramework.Core.DbContexts
{
    /// <summary>
    /// 主库数据库上下文
    /// </summary>
    [AppDbContext("MasterConnectionString", DbProvider.SqlServer, typeof(SlaveDbContextLocator))]
    public class MasterDbContext : AppDbContext<MasterDbContext>, IModelBuilderFilter
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }

        public void OnCreating(ModelBuilder modelBuilder, EntityTypeBuilder entityBuilder, DbContext dbContext, Type dbContextLocator)
        {
            // Furion 框架在 OnCreating 中自动调用和管理模型构建
            // 不要在这里调用 base.OnModelCreating()，避免递归
        }
        
    }
}
