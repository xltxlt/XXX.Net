using XXX.Net.Plugins.Inventory.Dtos;
namespace XXX.Net.Plugins.Inventory.Services;
public interface IInventoryStockManageService
{
    Task<InventoryStockDto?> GetAsync(InventoryStockQueryDto query, CancellationToken ct = default);
    Task<List<InventoryStockDto>> ListAsync(InventoryStockQueryDto query, CancellationToken ct = default);
    Task StockInAsync(StockInRequest request, CancellationToken ct = default);
    Task StockOutAsync(StockOutRequest request, CancellationToken ct = default);
    Task TransferAsync(StockTransferRequest request, CancellationToken ct = default);
    Task AdjustAsync(StockAdjustRequest request, CancellationToken ct = default);
    Task LockAsync(StockLockRequest request, CancellationToken ct = default);
    Task UnlockAsync(StockLockRequest request, CancellationToken ct = default);
}
