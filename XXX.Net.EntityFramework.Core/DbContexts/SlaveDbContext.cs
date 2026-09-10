using Furion.DatabaseAccessor;
using XXX.Net.Core.DbContextLocator;
using Microsoft.EntityFrameworkCore;

namespace Furion.EntityFramework.Core
{
    /// <summary>
    /// 从库数据库上下文
    /// </summary>
    [AppDbContext("SlaveConnectionString", DbProvider.SqlServer, typeof(SlaveDbContextLocator))]
    public class SlaveDbContext : AppDbContext<SlaveDbContext, SlaveDbContextLocator>
    {
        public SlaveDbContext(DbContextOptions<SlaveDbContext> options) : base(options)
        {
        }
    }
}