using Furion.DatabaseAccessor;
using XXX.Net.Core.Cache;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Plugins.Inventory.Constants;
using XXX.Net.Plugins.Inventory.Dtos;
using XXX.Net.Plugins.Inventory.Entities;
using XXX.Net.Plugins.Inventory.Enums;
using XXX.Net.Plugins.Inventory.Events;
using Medallion.Threading;
using Microsoft.EntityFrameworkCore;

namespace XXX.Net.Plugins.Inventory.Services;

/// <summary>
/// 库存
/// </summary>

public class InventoryStockManageService : IInventoryStockManageService
{
    private readonly IMSRepository _repo;
    private readonly ICurrentUser _user;
    private readonly ICacheService _cache;
    private readonly IDistributedLockProvider _locks;
    private readonly IEventBus _eventBus;

    public InventoryStockManageService(IMSRepository msRepository, ICurrentUser currentUserser, ICacheService cache, IDistributedLockProvider locks, IEventBus eventBus)
    { _repo = msRepository; _user = currentUserser; _cache = cache; _locks = locks; _eventBus = eventBus; }

    private long Tenant(long requested) => requested > 0 ? requested : _user.TenantId;
    private static string LockKey(long tenant,long domain,long item,long warehouse,long? location) => $"inventory:stock:{tenant}:{domain}:{item}:{warehouse}:{location?.ToString() ?? "0"}";
    private static string CacheKey(long tenant,long domain,long item,long warehouse,long? location) => $"Inventory:Stock:{tenant}:{domain}:{item}:{warehouse}:{location?.ToString() ?? "0"}";

    public async Task<InventoryStockDto?> GetAsync(InventoryStockQueryDto q, CancellationToken ct = default)
    {
        var tenant = Tenant(q.TenantId ?? 0);
        if (q.DomainId.HasValue && q.ItemId.HasValue && q.WarehouseId.HasValue)
        {
            var cacheKey = CacheKey(tenant, q.DomainId.Value, q.ItemId.Value, q.WarehouseId.Value, q.LocationId);
            var cached = await _cache.GetAsync<InventoryStockDto>(cacheKey);
            if (cached != null) return cached;
        }
        var x = await _repo.Slave<InventoryStock>().AsQueryable().AsNoTracking()
            .FirstOrDefaultAsync(s => s.TenantId == tenant && (!q.DomainId.HasValue || s.DomainId == q.DomainId) && (!q.ItemId.HasValue || s.ItemId == q.ItemId) && (!q.WarehouseId.HasValue || s.WarehouseId == q.WarehouseId) && (!q.LocationId.HasValue || s.LocationId == q.LocationId), ct);
        if (x == null) return null;
        var dto = ToDto(x);
        if (q.DomainId.HasValue && q.ItemId.HasValue && q.WarehouseId.HasValue)
            await _cache.SetAsync(CacheKey(tenant, q.DomainId.Value, q.ItemId.Value, q.WarehouseId.Value, q.LocationId), dto, TimeSpan.FromMinutes(10));
        return dto;
    }

    public async Task<List<InventoryStockDto>> ListAsync(InventoryStockQueryDto q, CancellationToken ct = default)
    {
        var tenant = Tenant(q.TenantId ?? 0);
        var list = await _repo.Slave<InventoryStock>().AsQueryable().AsNoTracking()
            .Where(s => s.TenantId == tenant && (!q.DomainId.HasValue || s.DomainId == q.DomainId) && (!q.ItemId.HasValue || s.ItemId == q.ItemId) && (!q.WarehouseId.HasValue || s.WarehouseId == q.WarehouseId) && (!q.LocationId.HasValue || s.LocationId == q.LocationId))
            .OrderBy(s => s.ItemId).ThenBy(s => s.WarehouseId).ToListAsync(ct);
        return list.Select(ToDto).ToList();
    }

    [UnitOfWork]
    public async Task StockInAsync(StockInRequest request, CancellationToken ct = default)
    {
        Validate(request.Quantity, request.BusinessKey);
        request.TenantId = Tenant(request.TenantId);
        await using var handle = await _locks.CreateLock(LockKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId)).AcquireAsync(TimeSpan.FromSeconds(15));
        if (await IsProcessed(request.TenantId, request.BusinessKey, ct)) return;
        var stock = await FindStock(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,ct);
        var before = stock?.Quantity ?? 0m;
        if (stock == null) { stock = NewStock(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId); stock.Quantity=request.Quantity; stock.AvailableQuantity=request.Quantity; await _repo.Master<InventoryStock>().InsertNowAsync(stock); }
        else { stock.Quantity += request.Quantity; stock.AvailableQuantity += request.Quantity; await _repo.Master<InventoryStock>().UpdateNowAsync(stock); }
        await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,InventoryTransactionType.Inbound,request.Quantity,before,stock.Quantity,null,request.BusinessKey,request.Remark,ct);
        await PublishChanged(stock, request.BusinessKey);
        await _cache.RemoveAsync(CacheKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId));
    }

    [UnitOfWork]
    public async Task StockOutAsync(StockOutRequest request, CancellationToken ct = default)
    {
        Validate(request.Quantity, request.BusinessKey); 
        request.TenantId = Tenant(request.TenantId);
        await using var handle = await _locks.CreateLock(LockKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId)).AcquireAsync(TimeSpan.FromSeconds(15));
        if (await IsProcessed(request.TenantId, request.BusinessKey, ct)) return;
        var stock = await FindStock(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,ct) ?? throw Oops.Oh("库存不存在");
        if (stock.AvailableQuantity < request.Quantity) throw Oops.Oh("库存不足");
        var before=stock.Quantity; stock.Quantity -= request.Quantity; stock.AvailableQuantity -= request.Quantity;
        await _repo.Master<InventoryStock>().UpdateNowAsync(stock);
        await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,InventoryTransactionType.Outbound,request.Quantity,before,stock.Quantity,null,request.BusinessKey,request.Remark,ct);
        await PublishChanged(stock, request.BusinessKey);
        await _cache.RemoveAsync(CacheKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId));
    }

    [UnitOfWork]
    public async Task TransferAsync(StockTransferRequest request, CancellationToken ct = default)
    {
        Validate(request.Quantity, request.BusinessKey); request.TenantId=Tenant(request.TenantId);
        if(request.FromWarehouseId==request.ToWarehouseId && request.FromLocationId==request.ToLocationId) throw Oops.Oh("源和目标库存位置不能相同");
        var first = LockKey(request.TenantId,request.DomainId,request.ItemId,request.FromWarehouseId,request.FromLocationId);
        var second = LockKey(request.TenantId,request.DomainId,request.ItemId,request.ToWarehouseId,request.ToLocationId);
        if (string.CompareOrdinal(first,second)>0) (first,second)=(second,first);
        await using var h1=await _locks.CreateLock(first).AcquireAsync(TimeSpan.FromSeconds(15));
        await using var h2=await _locks.CreateLock(second).AcquireAsync(TimeSpan.FromSeconds(15));
        if(await IsProcessed(request.TenantId,request.BusinessKey,ct)) return;
        var source=await FindStock(request.TenantId,request.DomainId,request.ItemId,request.FromWarehouseId,request.FromLocationId,ct) ?? throw Oops.Oh("源库存不存在");
        if(source.AvailableQuantity<request.Quantity) throw Oops.Oh("源库存不足");
        var target=await FindStock(request.TenantId,request.DomainId,request.ItemId,request.ToWarehouseId,request.ToLocationId,ct);
        var sourceBefore=source.Quantity; source.Quantity-=request.Quantity; source.AvailableQuantity-=request.Quantity;
        await _repo.Master<InventoryStock>().UpdateNowAsync(source);
        if(target==null){ target=NewStock(request.TenantId,request.DomainId,request.ItemId,request.ToWarehouseId,request.ToLocationId); target.Quantity=request.Quantity; target.AvailableQuantity=request.Quantity; await _repo.Master<InventoryStock>().InsertNowAsync(target); }
        else { var before=target.Quantity; target.Quantity+=request.Quantity; target.AvailableQuantity+=request.Quantity; await _repo.Master<InventoryStock>().UpdateNowAsync(target); }
        await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.FromWarehouseId,request.FromLocationId,InventoryTransactionType.TransferOut,request.Quantity,sourceBefore,source.Quantity,null,request.BusinessKey+":OUT",request.Remark,ct);
        await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.ToWarehouseId,request.ToLocationId,InventoryTransactionType.TransferIn,request.Quantity,target.Quantity-request.Quantity,target.Quantity,null,request.BusinessKey+":IN",request.Remark,ct);
        await PublishChanged(source,request.BusinessKey+":OUT"); await PublishChanged(target,request.BusinessKey+":IN");
        await _cache.RemoveAsync(CacheKey(request.TenantId,request.DomainId,request.ItemId,request.FromWarehouseId,request.FromLocationId)); await _cache.RemoveAsync(CacheKey(request.TenantId,request.DomainId,request.ItemId,request.ToWarehouseId,request.ToLocationId));
    }

    [UnitOfWork]
    public async Task AdjustAsync(StockAdjustRequest request, CancellationToken ct = default)
    {
        request.TenantId=Tenant(request.TenantId); ValidateBusinessKey(request.BusinessKey);
        await using var handle=await _locks.CreateLock(LockKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId)).AcquireAsync(TimeSpan.FromSeconds(15));
        if(await IsProcessed(request.TenantId,request.BusinessKey,ct)) return;
        var stock=await FindStock(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,ct);
        if(stock==null){ if(request.TargetQuantity<0) throw Oops.Oh("目标库存不能小于0"); stock=NewStock(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId); stock.Quantity=stock.AvailableQuantity=request.TargetQuantity; await _repo.Master<InventoryStock>().InsertNowAsync(stock); await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,InventoryTransactionType.AdjustmentIncrease,request.TargetQuantity,0,stock.Quantity,null,request.BusinessKey,request.Remark,ct); }
        else { if(request.TargetQuantity<0) throw Oops.Oh("目标库存不能小于0"); var before=stock.Quantity; var delta=request.TargetQuantity-before; stock.Quantity=request.TargetQuantity; stock.AvailableQuantity=Math.Max(0,stock.AvailableQuantity+delta); await _repo.Master<InventoryStock>().UpdateNowAsync(stock); var type=delta>=0?InventoryTransactionType.AdjustmentIncrease:InventoryTransactionType.AdjustmentDecrease; await AddTransaction(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId,type,Math.Abs(delta),before,stock.Quantity,null,request.BusinessKey,request.Remark,ct); }
        await PublishChanged(stock,request.BusinessKey); await _cache.RemoveAsync(CacheKey(request.TenantId,request.DomainId,request.ItemId,request.WarehouseId,request.LocationId));
    }

    [UnitOfWork]
    public async Task LockAsync(StockLockRequest request, CancellationToken ct = default)=>await ChangeLockedAsync(request,true,ct);
    [UnitOfWork]
    public async Task UnlockAsync(StockLockRequest request, CancellationToken ct = default)=>await ChangeLockedAsync(request,false,ct);

    private async Task ChangeLockedAsync(StockLockRequest r,bool isLock,CancellationToken ct){ Validate(r.Quantity,r.BusinessKey); r.TenantId=Tenant(r.TenantId); await using var handle=await _locks.CreateLock(LockKey(r.TenantId,r.DomainId,r.ItemId,r.WarehouseId,r.LocationId)).AcquireAsync(TimeSpan.FromSeconds(15)); if(await IsProcessed(r.TenantId,r.BusinessKey,ct))return; var s=await FindStock(r.TenantId,r.DomainId,r.ItemId,r.WarehouseId,r.LocationId,ct)??throw Oops.Oh("库存不存在"); if(isLock){if(s.AvailableQuantity<r.Quantity)throw Oops.Oh("可用库存不足");s.LockedQuantity+=r.Quantity;s.AvailableQuantity-=r.Quantity;}else{if(s.LockedQuantity<r.Quantity)throw Oops.Oh("锁定库存不足");s.LockedQuantity-=r.Quantity;s.AvailableQuantity+=r.Quantity;} await _repo.Master<InventoryStock>().UpdateNowAsync(s); await AddTransaction(r.TenantId,r.DomainId,r.ItemId,r.WarehouseId,r.LocationId,isLock?InventoryTransactionType.Lock:InventoryTransactionType.Unlock,r.Quantity,s.Quantity,s.Quantity,null,r.BusinessKey,r.Remark,ct); await PublishChanged(s,r.BusinessKey); await _cache.RemoveAsync(CacheKey(r.TenantId,r.DomainId,r.ItemId,r.WarehouseId,r.LocationId)); }

    private async Task<InventoryStock?> FindStock(long tenant,long domain,long item,long warehouse,long? location,CancellationToken ct)=>await _repo.Master<InventoryStock>().Where(x=>x.TenantId==tenant&&x.DomainId==domain&&x.ItemId==item&&x.WarehouseId==warehouse&&x.LocationId==location).FirstOrDefaultAsync(ct);
    private static InventoryStock NewStock(long tenant,long domain,long item,long warehouse,long? location)=>new(){TenantId=tenant,DomainId=domain,ItemId=item,WarehouseId=warehouse,LocationId=location,Name="库存"};
    private async Task<bool> IsProcessed(long tenant,string key,CancellationToken ct)=>await _repo.Slave<InventoryStockTransaction>().AsQueryable().AnyAsync(x=>x.TenantId==tenant&&x.BusinessKey==key,ct);
    private async Task AddTransaction(long tenant,long domain,long item,long warehouse,long? location,InventoryTransactionType type,decimal qty,decimal before,decimal after,long? doc,string key,string? remark,CancellationToken ct){ if(await _repo.Master<InventoryStockTransaction>().Where(x=>x.TenantId==tenant&&x.BusinessKey==key).AnyAsync(ct))return; var e=new InventoryStockTransaction{TenantId=tenant,DomainId=domain,ItemId=item,WarehouseId=warehouse,LocationId=location,DocumentId=doc,TransactionType=type,Quantity=qty,BeforeQuantity=before,AfterQuantity=after,BusinessKey=key,Remark=remark,Name=type.ToString(),CreatedTime=DateTime.Now,CreatedBy=_user.UserId,CreatedByName=_user.UserName}; await _repo.Master<InventoryStockTransaction>().InsertNowAsync(e); }
    private async Task PublishChanged(InventoryStock s,string key)=>await _eventBus.PublishAsync(InventoryTopics.StockChanged,new XXX.Net.Core.EventBus.BaseEvent<InventoryStockChangedEvent>{EventName=InventoryTopics.StockChanged,Data=new InventoryStockChangedEvent{TenantId=s.TenantId,DomainId=s.DomainId,ItemId=s.ItemId,WarehouseId=s.WarehouseId,LocationId=s.LocationId,Quantity=s.Quantity,AvailableQuantity=s.AvailableQuantity,MinQuantity=s.MinQuantity,BusinessKey=key}});
    private static InventoryStockDto ToDto(InventoryStock x)=>new(){Id=x.Id,TenantId=x.TenantId,DomainId=x.DomainId,ItemId=x.ItemId,WarehouseId=x.WarehouseId,LocationId=x.LocationId,Quantity=x.Quantity,LockedQuantity=x.LockedQuantity,AvailableQuantity=x.AvailableQuantity,MinQuantity=x.MinQuantity,MaxQuantity=x.MaxQuantity};
    private static void Validate(decimal q,string key){if(q<=0)throw Oops.Oh("数量必须大于0");ValidateBusinessKey(key);} private static void ValidateBusinessKey(string key){if(string.IsNullOrWhiteSpace(key))throw Oops.Oh("BusinessKey不能为空");}
}
