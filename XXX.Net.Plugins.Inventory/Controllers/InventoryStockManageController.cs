using XXX.Net.Plugins.Inventory.Dtos;
using XXX.Net.Plugins.Inventory.Services;
namespace XXX.Net.Plugins.Inventory.Controllers;

[ApiDescriptionSettings("Inventory", Name="InventoryStockManage",Order=100)]

public class InventoryStockManageController : IDynamicApiController
{
    private readonly IInventoryStockManageService _service;
    public InventoryStockManageController(IInventoryStockManageService service)=>_service=service;


    [HttpPost,ApiDescriptionSettings(Name="Get",Order=100),DisplayName("获取库存")]
    public Task<InventoryStockDto?> Get(InventoryStockQueryDto request)=>_service.GetAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="List",Order=110),DisplayName("库存列表")]
    public Task<List<InventoryStockDto>> List(InventoryStockQueryDto request)=>_service.ListAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="StockIn",Order=200),DisplayName("入库")]
    public Task StockIn(StockInRequest request)=>_service.StockInAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="StockOut",Order=210),DisplayName("出库")]
    public Task StockOut(StockOutRequest request)=>_service.StockOutAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="Transfer",Order=220),DisplayName("调拨")]
    public Task Transfer(StockTransferRequest request)=>_service.TransferAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="Adjust",Order=230),DisplayName("库存调整")]
    public Task Adjust(StockAdjustRequest request)=>_service.AdjustAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="Lock",Order=240),DisplayName("锁定库存")]
    public Task Lock(StockLockRequest request)=>_service.LockAsync(request);


    [HttpPost,ApiDescriptionSettings(Name="Unlock",Order=250),DisplayName("解锁库存")]
    public Task Unlock(StockLockRequest request)=>_service.UnlockAsync(request);
}
