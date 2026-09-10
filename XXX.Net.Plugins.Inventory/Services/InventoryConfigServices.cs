using System.Security.Principal;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Base.Tree;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Plugins.Inventory.Dtos;
using XXX.Net.Plugins.Inventory.Entities;

namespace XXX.Net.Plugins.Inventory.Services;

/// <summary>
/// 库存域
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryDomainService : BaseService<InventoryDomain, InventoryDomainDto> {
    public InventoryDomainService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository,currentUser) { } 

}

/// <summary>
/// 库存类型
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryTypeService : BaseService<InventoryType, InventoryTypeDto> {
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
   
    public InventoryTypeService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository,currentUser) {
        _msRepository = msRepository;
         _currentUser=currentUser;
    }

    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="DomainId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvDomain"
            },
            TreeOption=false
        }

    };
    public override async Task<InventoryType> ToEntity(InventoryTypeDto dto, InventoryType oldEntity) {
        InventoryType? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else
        {
            entity = dto.Adapt<InventoryType>();
        }
        var mInventoryDomain= await _msRepository.Master<InventoryDomain>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.DomainId);
        if (mInventoryDomain == null) throw Oops.Oh("未找到对应库存域");
        entity.TenantId = mInventoryDomain.TenantId;
        entity.DomainId = mInventoryDomain.Id;
        return entity;
    }
    #endregion

}

/// <summary>
/// 动态属性定义
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryAttributeDefinitionService : BaseService<InventoryAttributeDefinition, InventoryAttributeDefinitionDto> {
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public InventoryAttributeDefinitionService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository, currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="DomainId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvDomain"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="InventoryTypeId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvType"
            },
            TreeOption=false
        }

    };
    public override async Task<InventoryAttributeDefinition> ToEntity(InventoryAttributeDefinitionDto dto, InventoryAttributeDefinition oldEntity)
    {
        InventoryAttributeDefinition? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else
        {
            entity = dto.Adapt<InventoryAttributeDefinition>();
        }
        var mInventoryType = await _msRepository.Master<InventoryType>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.InventoryTypeId);
        if (mInventoryType == null) throw Oops.Oh("未找到对应的物品类型");
        entity.TenantId = mInventoryType.TenantId;
        entity.InventoryTypeId= mInventoryType.Id;
        entity.DomainId= mInventoryType.Id;
        return entity;
    }
    #endregion
}

/// <summary>
/// 库存物品
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryItemService : BaseService<InventoryItem, InventoryItemDto> {
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public InventoryItemService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository, currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="DomainId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvDomain"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="InventoryTypeId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvType"
            },
            TreeOption=false
        }
    };
    public override async Task<InventoryItem> ToEntity(InventoryItemDto dto, InventoryItem oldEntity)
    {

        InventoryItem? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else
        {
            entity = dto.Adapt<InventoryItem>();
        }
        var mInventoryType = await _msRepository.Master<InventoryType>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.InventoryTypeId);
        if (mInventoryType == null) throw Oops.Oh("未找到对应的物品类型");
        entity.TenantId = mInventoryType.TenantId;
        entity.InventoryTypeId = mInventoryType.Id;
        entity.DomainId = mInventoryType.DomainId;
        return entity;
    }
    #endregion

}

/// <summary>
/// 仓库
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryWarehouseService : BaseService<InventoryWarehouse, InventoryWarehouseDto> {
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public InventoryWarehouseService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository, currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="DomainId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvDomain"
            },
            TreeOption=false
        }
     
    };
    public override async Task<InventoryWarehouse> ToEntity(InventoryWarehouseDto dto, InventoryWarehouse oldEntity)
    {
        InventoryWarehouse? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else
        {
            entity = dto.Adapt<InventoryWarehouse>();
        }
        var mInventoryDomain = await _msRepository.Master<InventoryDomain>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.DomainId);
        if (mInventoryDomain == null) throw Oops.Oh("未找到对应库存域");
        entity.TenantId = mInventoryDomain.TenantId;
        entity.DomainId = mInventoryDomain.Id;
        return entity;
    }
    #endregion
}

/// <summary>
/// 库位
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryLocationService : BaseTreeService<InventoryLocation, InventoryLocationDto, InventoryLocationTreeOutput> {
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public InventoryLocationService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository, currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="WarehouseId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvWarehouse"
            },
            TreeOption=false
        }

    };
    public override async Task<InventoryLocation> ToEntity(InventoryLocationDto dto, InventoryLocation oldEntity)
    {
        InventoryLocation? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else { 
            entity=dto.Adapt<InventoryLocation>();
        }
        var mInventoryWarehouse = await _msRepository.Master<InventoryWarehouse>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.WarehouseId);
        if (mInventoryWarehouse == null) throw Oops.Oh("未找到对应库存域");
        entity.TenantId = mInventoryWarehouse.TenantId;
        entity.WarehouseId = mInventoryWarehouse.Id;
        return entity;
    }
    #endregion




}


/// <summary>
/// 库位
/// </summary>
[ApiDescriptionSettings("Inventory")]
public class InventoryStockService : BaseService<InventoryStock, InventoryStockDto>
{
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public InventoryStockService(IMSRepository msRepository, ICurrentUser currentUser) : base(msRepository, currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 重写父类方法
    /// <summary>
    /// 其他来源参数
    /// </summary>
    protected override List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>() {
        new OtherOptionSource(){
            FieldName="TenantId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="SysTenant"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="WarehouseId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvWarehouse"
            },
            TreeOption=false
        },
         new OtherOptionSource(){
            FieldName="DomainId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvDomain"
            },
            TreeOption=false
        },
        new OtherOptionSource(){
            FieldName="InventoryTypeId",
            OptionAttr=new OptionEntityAttribute(){
                TableName="InvType"
            },
            TreeOption=false
        }

    };
    public override async Task<InventoryStock> ToEntity(InventoryStockDto dto, InventoryStock oldEntity)
    {
        InventoryStock? entity = null;

        if (oldEntity != null)
        {
            entity = dto.Adapt(oldEntity);
        }
        else
        {
            entity = dto.Adapt<InventoryStock>();
        }
        var mInventoryWarehouse = await _msRepository.Master<InventoryWarehouse>().AsQueryable().AsTracking().FirstOrDefaultAsync(x => x.Id == entity.WarehouseId);
        if (mInventoryWarehouse == null) throw Oops.Oh("未找到对应库存域");
        entity.TenantId = mInventoryWarehouse.TenantId;
        entity.WarehouseId = mInventoryWarehouse.Id;
        return entity;
    }
    #endregion




}
