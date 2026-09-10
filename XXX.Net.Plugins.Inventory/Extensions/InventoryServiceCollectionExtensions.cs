using DotNetCore.CAP;
using XXX.Net.Plugins.Inventory.Consumers;
using XXX.Net.Plugins.Inventory.Services;
using Microsoft.Extensions.DependencyInjection;

namespace XXX.Net.Plugins.Inventory.Extensions;
public static class InventoryServiceCollectionExtensions
{
    public static IServiceCollection AddInventory(this IServiceCollection services)
    {
        services.AddScoped<IInventoryStockManageService, InventoryStockManageService>();
        services.AddScoped<InventoryDomainService>();
        services.AddScoped<InventoryTypeService>();
        services.AddScoped<InventoryAttributeDefinitionService>();
        services.AddScoped<InventoryItemService>();
        services.AddScoped<InventoryWarehouseService>();
        services.AddScoped<InventoryLocationService>();
        services.AddScoped<InventoryDocumentService>();
        services.AddScoped<InventoryStockChangedConsumer>();
        services.AddScoped<InventoryDocumentCompletedConsumer>();
        return services;
    }
}
