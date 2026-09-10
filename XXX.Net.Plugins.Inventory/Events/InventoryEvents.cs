namespace XXX.Net.Plugins.Inventory.Events;
public class InventoryStockChangedEvent
{
    public long TenantId { get; set; }
    public long DomainId { get; set; }
    public long ItemId { get; set; }
    public long WarehouseId { get; set; }
    public long? LocationId { get; set; }
    public decimal Quantity { get; set; }
    public decimal AvailableQuantity { get; set; }
    public decimal MinQuantity { get; set; }
    public string BusinessKey { get; set; } = string.Empty;
}
public class InventoryDocumentCompletedEvent
{
    public long TenantId { get; set; }
    public long DocumentId { get; set; }
    public string DocumentNo { get; set; } = string.Empty;
}
