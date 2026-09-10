using System.Runtime.CompilerServices;
using XXX.Net.Core;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Document;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Plugins.Inventory.Constants;
using XXX.Net.Plugins.Inventory.Dtos;
using XXX.Net.Plugins.Inventory.Entities;
using XXX.Net.Plugins.Inventory.Enums;
using XXX.Net.Plugins.Inventory.Events;
using static XXX.Net.Core.Extensions.MsRepositoryExtension;

namespace XXX.Net.Plugins.Inventory.Services;
/// <summary>
/// 单据
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryDocumentService : BaseFatherSonService<InventoryDocument, InventoryDocumentItem, InventoryDocumentDto, InventoryDocumentItemDto>, IDynamicApiController
{
    private readonly IMSRepository _repo;
    private readonly ICurrentUser _user;
    private readonly IInventoryStockManageService _stock;
    private readonly IDocumentNumberService _documentNumberService;
    private readonly IEventBus _eventBus;

    public InventoryDocumentService(IMSRepository msRepository, IDocumentNumberService documentNumberService, ICurrentUser currentUser, IInventoryStockManageService stock, IEventBus eventBus)
        : base(msRepository, currentUser)
    {
        _repo = msRepository;
        _user = currentUser;
        _stock = stock;
        _eventBus = eventBus;
        _documentNumberService = documentNumberService;
        OtherOptions = BuildOtherOptions();
    }

    private List<OtherOptionSource> BuildOtherOptions()
    {
        var tenantId = _user.TenantId.ToString();

        return new List<OtherOptionSource>
        {
            new OtherOptionSource{ 
                FieldName="Status",
                OptionAttr=new OptionEnumAttribute(typeof(InventoryDocumentStatus)),
                TreeOption=false
            },
             new OtherOptionSource{
                FieldName="TenantId",
                OptionAttr=new OptionEntityAttribute("SysTenant"),
                TreeOption=false
            },
            new OtherOptionSource{
                FieldName="WarehouseId",
                 OptionAttr = new OptionFunAttribute(
                    typeof(InventoryWarehouseService),
                    nameof(InventoryWarehouseService.Options)),
                Where = new List<PagedCustomWhere>
                {
                    new PagedCustomWhere
                    {
                        FiledName = "TenantId",
                        ConditionalType = (int)ConditionalType.Equal,
                        FiledValue = tenantId
                    },
                }
            },
            new OtherOptionSource
            {
                FieldName = "ItemId",
                OptionAttr = new OptionFunAttribute(
                    typeof(InventoryItemService),
                    nameof(InventoryItemService.Options)),
                Where = new List<PagedCustomWhere>
                {
                    new PagedCustomWhere
                    {
                        FiledName = "TenantId",
                        ConditionalType = (int)ConditionalType.Equal,
                        FiledValue = tenantId
                    },
                }
            },
            //new OtherOptionSource
            //{
            //    FieldName = "FromLocationId",
            //    OptionAttr = new OptionFunAttribute(
            //        typeof(InventoryLocationService),
            //        nameof(InventoryLocationService.TreeOptions)),
            //    Where = new List<PagedCustomWhere>
            //    {
            //        new PagedCustomWhere
            //        {
            //            FiledName = "TenantId",
            //            ConditionalType = (int)ConditionalType.Equal,
            //            FiledValue = tenantId
            //        }
            //    }
            //}
        };
    }

    #region 重写基类方法

    /// <summary>
    /// 其他选项
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new();

    public override async Task<Dictionary<string, List<PagedOptions>>> PageOption([FromServices] OptionService optionService, [FromQuery] List<PagedCustomWhere> where = null)
    {
        var options=await base.PageOption(optionService, where);
      

        //var mlInventoryLocation =await
        //    _repo.Slave<InventoryLocation>().AsQueryable().AsNoTracking()
        //    .Where(w =>w.TenantId==_user.TenantId&& w.Deleted == false ).ToListAsync();

        //var warehoseIds = mlInventoryLocation.Select(s => s.WarehouseId);

        //var mlInventoryWarehouse = await _repo.Slave<InventoryWarehouse>().AsQueryable().AsNoTracking()
        //  .Where(x => x.TenantId == _user.TenantId && x.Deleted == false && warehoseIds.Contains(x.Id))
        //  .ToListAsync();

        //foreach (var item in mlInventoryLocation.Where(w=>w.ClassLevel==1)) {
        //    item.ParentId = item.WarehouseId;
        //}
        //var items=  mlInventoryLocation.Adapt<List<BaseTreeEntity>>();
        //items.AddRange(mlInventoryWarehouse.Adapt<List<BaseTreeEntity>>());
        //var locationOption = TreeHelper.BuildTree<BaseTreeEntity, PagedOptions>(items, (BaseTreeEntity entity, List<PagedOptions> children) => {
        //    return new PagedOptions()
        //    {
        //        Value = entity.Id,
        //        Label = entity.Name,
        //        Children = children,
        //    };
        //})??new List<PagedOptions>();
        //options.Remove("toLocationId");
        //options.Add("toLocationId", locationOption);
        //options.Remove("formLocationId");
        //options.Add("formLocationId", locationOption);
        return options;
    }
    #endregion

    /// <summary>
    /// 打申请
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost, ApiDescriptionSettings(Name = "Inbound", Order = 100), DisplayName("创建出库存单据")]
    public async Task<InventoryDocument> Inbound(InventoryDocumentDto dto)
    {
        var tenant = _user.TenantId;
        if (dto.Children.Count == 0) throw Oops.Oh("单据明细不能为空");

        if (dto.FromWarehouseId != null)
        {
            throw Oops.Oh("来源仓库不能为空");
        }
        var mWarehouse = await _repo.Master<InventoryWarehouse>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == dto.ToWarehouseId);
        dto.DomainId = mWarehouse?.DomainId ?? 0;
        dto.DocumentNo =await _documentNumberService.GenerateAsync("Inbound");
        //if (string.IsNullOrWhiteSpace(dto.DocumentNo)) throw Oops.Oh("单据号不能为空");
        //if (await _repo.Slave<InventoryDocument>().Where(x => x.TenantId == tenant && x.DocumentNo == dto.DocumentNo).AnyAsync()) throw Oops.Oh("单据号已存在");
        var doc = dto.Adapt<InventoryDocument>();
        doc.TenantId = tenant;
        doc.Status = (int)InventoryDocumentStatus.Draft;
        doc.DocumentType = (int)InventoryDocumentType.Inbound;
        doc.CreatedTime = DateTime.Now;
        doc.CreatedBy = _user.UserId;
        doc.CreatedByName = _user.UserName;
        await _repo.Master<InventoryDocument>().InsertAsync(doc);
        return doc;
    }

    /// <summary>
    /// 打申请
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost, ApiDescriptionSettings(Name = "Create", Order = 100), DisplayName("创建库存单据")]
    public async Task<InventoryDocument> Create(InventoryDocumentDto dto)
    {
        var tenant = _user.TenantId;
        if (dto.Children.Count == 0) throw Oops.Oh("单据明细不能为空");

        if (dto.FromWarehouseId != null) {
            var mWarehouse = await _repo.Master<InventoryWarehouse>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == dto.FromWarehouseId);
            dto.DomainId = mWarehouse?.DomainId??0;
        }
        dto.DocumentNo =(dto.DocumentType) + DateTime.Now.ToString("yyyyMMddHHmm");
        //if (string.IsNullOrWhiteSpace(dto.DocumentNo)) throw Oops.Oh("单据号不能为空");
        //if (await _repo.Slave<InventoryDocument>().Where(x => x.TenantId == tenant && x.DocumentNo == dto.DocumentNo).AnyAsync()) throw Oops.Oh("单据号已存在");
        var doc = dto.Adapt<InventoryDocument>();
        doc.TenantId = tenant;
        doc.Status = (int)InventoryDocumentStatus.Draft;
        doc.CreatedTime = DateTime.Now;
        doc.CreatedBy = _user.UserId;
        doc.CreatedByName = _user.UserName;
        await _repo.Master<InventoryDocument>().InsertAsync(doc);
        return doc;
    }
    /// <summary>
    /// 确认
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [UnitOfWork]
    [HttpPost, ApiDescriptionSettings(Name = "Complete", Order = 120), DisplayName("完成库存单据")]
    public async Task Complete(long id)
    {
        var d = await _repo.Master<InventoryDocument>().FindOrDefaultAsync(id) ?? throw Oops.Oh("单据不存在");
        if (d.Status != (int)InventoryDocumentStatus.Draft) throw Oops.Oh("只有草稿单据可以完成");
        var items = await _repo.Master<InventoryDocumentItem>().Where(x => x.ParentId == id).ToListAsync();
        if (items.Count == 0) throw Oops.Oh("单据明细不能为空");
        var tenant = d.TenantId;
        for (var index = 0; index < items.Count; index++)
        {
            var i = items[index];
            var key = $"DOC:{tenant}:{d.DocumentNo}:{i.Id}:{index}";
            switch (d.DocumentType)
            {
                case (int)InventoryDocumentType.Inbound:
                case (int)InventoryDocumentType.Return:
                    await _stock.StockInAsync(new StockInRequest { TenantId = tenant, DomainId = d.DomainId, ItemId = i.ItemId, WarehouseId = d.ToWarehouseId ?? throw Oops.Oh("入库仓库不能为空"), LocationId = i.ToLocationId, Quantity = i.Quantity, BusinessKey = key, Remark = d.Remark });
                    break;
                case (int)InventoryDocumentType.Outbound:
                    await _stock.StockOutAsync(new StockOutRequest { TenantId = tenant, DomainId = d.DomainId, ItemId = i.ItemId, WarehouseId = d.FromWarehouseId ?? throw Oops.Oh("出库仓库不能为空"), LocationId = i.FromLocationId, Quantity = i.Quantity, BusinessKey = key, Remark = d.Remark });
                    break;
                case (int)InventoryDocumentType.Transfer:
                    await _stock.TransferAsync(new StockTransferRequest { TenantId = tenant, DomainId = d.DomainId, ItemId = i.ItemId, FromWarehouseId = d.FromWarehouseId ?? throw Oops.Oh("源仓库不能为空"), ToWarehouseId = d.ToWarehouseId ?? throw Oops.Oh("目标仓库不能为空"), FromLocationId = i.FromLocationId, ToLocationId = i.ToLocationId, Quantity = i.Quantity, BusinessKey = key, Remark = d.Remark });
                    break;
                default:
                    throw Oops.Oh("当前单据类型不支持直接完成");
            }
        }
        d.Status = (int)InventoryDocumentStatus.Completed; d.UpdatedTime = DateTime.Now; d.UpdatedBy = _user.UserId; d.UpdatedByName = _user.UserName;
        await _repo.Master<InventoryDocument>().UpdateNowAsync(d);
        await _eventBus.PublishAsync(InventoryTopics.DocumentCompleted, new BaseEvent<InventoryDocumentCompletedEvent> { EventName = InventoryTopics.DocumentCompleted, Data = new InventoryDocumentCompletedEvent { TenantId = tenant, DocumentId = d.Id, DocumentNo = d.DocumentNo } });
    }

    /// <summary>
    /// 取消
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost, ApiDescriptionSettings(Name = "Cancel", Order = 130), DisplayName("取消库存单据")]
    public async Task Cancel(long id)
    {
        var d = await _repo.Master<InventoryDocument>().FindOrDefaultAsync(id) ?? throw Oops.Oh("单据不存在");
        if (d.Status != (int)InventoryDocumentStatus.Draft) throw Oops.Oh("只有草稿单据可以取消");
        d.Status = (int)InventoryDocumentStatus.Cancelled; d.UpdatedTime = DateTime.Now; d.UpdatedBy = _user.UserId; d.UpdatedByName = _user.UserName;
        await _repo.Master<InventoryDocument>().UpdateNowAsync(d);
    }
}
