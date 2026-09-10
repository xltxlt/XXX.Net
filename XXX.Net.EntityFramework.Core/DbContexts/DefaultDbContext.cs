using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace XXX.Net.EntityFramework.Core;

[AppDbContext("Fyyy.Net", DbProvider.SqlServer)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
