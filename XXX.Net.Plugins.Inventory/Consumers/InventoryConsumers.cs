using DotNetCore.CAP;
using XXX.Net.Core.Cache;
using XXX.Net.Core.EventBus;
using XXX.Net.Plugins.Inventory.Constants;
using XXX.Net.Plugins.Inventory.Events;

namespace XXX.Net.Plugins.Inventory.Consumers;

public class InventoryStockChangedConsumer : ICapSubscribe
{
    private readonly ICacheService _cache;
    public InventoryStockChangedConsumer(ICacheService cache)=>_cache=cache;
    [CapSubscribe(InventoryTopics.StockChanged)]
    public async Task Handle(BaseEvent<InventoryStockChangedEvent> message)
    {
        var x=message.Data;
        await _cache.SetAsync($"Inventory:Stock:Event:{x.TenantId}:{x.DomainId}:{x.ItemId}:{x.WarehouseId}:{x.LocationId?.ToString()??"0"}",x,TimeSpan.FromMinutes(10));
        if(x.MinQuantity>0&&x.AvailableQuantity<x.MinQuantity)
            await _cache.SetAsync($"Inventory:Low:{x.TenantId}:{x.DomainId}:{x.ItemId}:{x.WarehouseId}",x,TimeSpan.FromMinutes(10));
    }
}

public class InventoryDocumentCompletedConsumer : ICapSubscribe
{
    [CapSubscribe(InventoryTopics.DocumentCompleted)]
    public Task Handle(BaseEvent<InventoryDocumentCompletedEvent> message) => Task.CompletedTask;
}
