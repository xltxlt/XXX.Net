using Furion;
using Furion.EntityFramework.Core;
using XXX.Net.Core.DbContextLocator;
using XXX.Net.Core.IdGenerator;
using XXX.Net.EntityFramework.Core.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace XXX.Net.EntityFramework.Core;

[AppStartup(600)]
public class Startup : AppStartup
{
    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddDatabaseAccessor(options =>
    //    {
    //        options.AddDbPool<DefaultDbContext>();
    //    }, "XXX.Net.Database.Migrations");
    //}
    public void ConfigureServices(IServiceCollection services)
    {
       

        services.AddDatabaseAccessor(options =>
        {
            
            services.AddDbPool<MasterDbContext>();
            services.AddDbPool<SlaveDbContext, SlaveDbContextLocator>();
        }, "XXX.Net.Database.Migrations");
    }
}
