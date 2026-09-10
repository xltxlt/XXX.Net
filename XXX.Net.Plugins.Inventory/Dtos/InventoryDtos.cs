using System.ComponentModel.DataAnnotations;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Plugins.Inventory.Entities;
using XXX.Net.Plugins.Inventory.Enums;

namespace XXX.Net.Plugins.Inventory.Dtos;

public class InventoryDomainDto : BaseUpdate
{
    /// <summary>
    /// 所属租户
    /// </summary>
    [OptionEntity(typeof(SysTenant))]
    [Required(ErrorMessage = "所属租户不能为空")]
    public long TenantId { get; set; }
    /// <summary>
    /// 所属部门
    /// </summary>
    [OptionEntity(typeof(SysDepartment))]
    [Required(ErrorMessage = "所属部门不能为空")]
    public long DepartmentId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 状态
    /// </summary>

    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;
}
public class InventoryTypeDto : BaseUpdate
{

    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    [Required(ErrorMessage = "库存域不能为空")]
    public long DomainId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    [MinLength(4, ErrorMessage = "物品类型编码不能少于4位")]
    [Required(ErrorMessage = "物品类型编码不能为空")]
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 状态
    /// </summary>

    [OptionEnum(typeof(EnabledEnum))] 
    public bool Enabled { get; set; } = true;
}
public class InventoryAttributeDefinitionDto : BaseUpdate
{
  
    /// <summary>
    /// 物品类型
    /// </summary>
    [OptionEntity(typeof(InventoryType))]
    [Required(ErrorMessage = "物品类型不能为空")]
    public long InventoryTypeId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "属性编码不能为空")]
    [MinLength(4, ErrorMessage = "属性编码不能少于4位")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 属性类型
    /// </summary>
    
    [OptionEnum(typeof(PageFormTypeEnum))]
    public PageFormTypeEnum DataType { get; set; }
    /// <summary>
    /// 是否必填
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public bool Required { get; set; }
    /// <summary>
    /// 是否唯一
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public bool Unique { get; set; }
    /// <summary>
    /// 是否为键
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public bool IsKey { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }
    /// <summary>
    /// 选项
    /// </summary>
    public string? OptionsJson { get; set; }
}
public class InventoryItemDto : BaseUpdate
{
   
    /// <summary>
    /// 库存类型
    /// </summary>
    [OptionEntity(typeof(InventoryType))]
    [Required(ErrorMessage = "库存类型不能为空")]

    public long InventoryTypeId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "物品编码不能为空")]
    [MinLength(4, ErrorMessage = "物品编码不能少于4位")]
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 单位
    /// </summary>
    public string Unit { get; set; } = string.Empty;
    /// <summary>
    /// 库存物品状态
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public EnabledEnum Enabled { get; set; } = EnabledEnum.Enabled;
    /// <summary>
    /// 属性
    /// </summary>
    public string? AttributesJson { get; set; }
}
public class InventoryWarehouseDto : BaseUpdate
{
    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    [Required(ErrorMessage = "库存域不能为空")]
    public long DomainId { get; set; }
    /// <summary>
    /// 所属部门
    /// </summary>
    [OptionEntity(typeof(SysDepartment))]
    public long? DepartmentId { get; set; }
    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "仓库编码不能为空")]
    [MinLength(4, ErrorMessage = "仓库编码不能少于4位")]
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 状态
    /// </summary>

    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;
}
public class InventoryLocationDto : BaseUpdateTree<InventoryLocation>
{
    
    /// <summary>
    /// 所在仓库
    /// </summary>
    [OptionEntity(typeof(InventoryWarehouse))]
    [Required(ErrorMessage = "所在仓库不能为空")]

    public long WarehouseId { get; set; }

    /// <summary>
    /// 编码
    /// </summary>
    [Required(ErrorMessage = "仓位编码不能为空")]
    [MinLength(4, ErrorMessage = "仓位编码不能少于4位")]
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 状态
    /// </summary>

    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;
}
public class InventoryLocationTreeOutput :  Core.BaseEntitys.Entity.BasePrimaryKey, IPagedTreeOutput<InventoryLocationTreeOutput>
{
    /// <summary>
    /// 所属租户
    /// </summary>
    [OptionEntity(typeof(SysTenant))]
    public long TenantId { get; set; }
    /// <summary>
    /// 所在仓库
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long WarehouseId { get; set; }


    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>
    /// 状态
    /// </summary>

    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = string.Empty;
   
    public List<InventoryLocationTreeOutput> Children { get; set; } = new List<InventoryLocationTreeOutput>();
}
public class InventoryStockDto:BaseTenantUpdate
{
    //public long Id { get; set; }
    ///// <summary>
    ///// 所属租户
    ///// </summary>
    //[OptionEntity(typeof(SysTenant))]
    //public long TenantId { get; set; }
    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long DomainId { get; set; }

    /// <summary>
    /// 库存物品
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    [Required(ErrorMessage = "库存物品不能为空")]
    public long ItemId { get; set; }
    /// <summary>
    /// 所在仓库
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long WarehouseId { get; set; }
    /// <summary>
    /// 所在库位
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    [Required(ErrorMessage = "所在库位不能为空")]
    public long? LocationId { get; set; }
    /// <summary>
    /// 数量
    /// </summary>
    public decimal Quantity { get; set; }
    /// <summary>
    /// 锁定数量
    /// </summary>
    public decimal LockedQuantity { get; set; }
    /// <summary>
    /// 可用数量
    /// </summary>
    public decimal AvailableQuantity { get; set; }
    /// <summary>
    /// 最小数量
    /// </summary>
    public decimal MinQuantity { get; set; }
    /// <summary>
    /// 最大数量
    /// </summary>
    public decimal MaxQuantity { get; set; }
}
public class InventoryStockQueryDto
{
    /// <summary>
    /// 所属租户
    /// </summary>
    [OptionEntity(typeof(SysTenant))]
    public long? TenantId { get; set; }
    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long? DomainId { get; set; }
    /// <summary>
    /// 库存物品
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]

    public long? ItemId { get; set; }
    /// <summary>
    /// 所在仓库
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long? WarehouseId { get; set; }
    /// <summary>
    /// 所在库位
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long? LocationId { get; set; }
}
public class StockInRequest
{
    /// <summary>
    /// 所属租户
    /// </summary>
    public long TenantId { get; set; }
    /// <summary>
    /// 库存域
    /// </summary>
    public long DomainId { get; set; }
    public long ItemId { get; set; }
    public long WarehouseId { get; set; }
    public long? LocationId { get; set; }
    public decimal Quantity { get; set; }
    public string BusinessKey { get; set; } = string.Empty;
    public string? Remark { get; set; }
}
public class StockOutRequest : StockInRequest { }
public class StockLockRequest : StockInRequest { }
public class StockTransferRequest
{
    /// <summary>
    /// 所属租户
    /// </summary>
    public long TenantId { get; set; }
    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long DomainId { get; set; }
    public long ItemId { get; set; }
    public long FromWarehouseId { get; set; }
    public long ToWarehouseId { get; set; }
    public long? FromLocationId { get; set; }
    public long? ToLocationId { get; set; }
    public decimal Quantity { get; set; }
    public string BusinessKey { get; set; } = string.Empty;
    public string? Remark { get; set; }
}
public class StockAdjustRequest : StockInRequest
{
    public decimal TargetQuantity { get; set; }
}
public class InventoryDocumentDto : BaseParentUpdate<InventoryDocumentItemDto>
{
    
    /// <summary>
    /// 库存域
    /// </summary>
    [OptionEntity(typeof(InventoryDomain))]
    public long DomainId { get; set; }

    /// <summary>
    /// 单据号
    /// </summary>
    public string DocumentNo { get; set; } = string.Empty;
    /// <summary>
    /// 单据类型
    /// </summary>

    [OptionEnum(typeof(InventoryDocumentType))]

    public int DocumentType { get; set; }
    /// <summary>
    /// 来源仓库
    /// </summary>
    [OptionEntity(typeof(InventoryWarehouse))]

    public long? FromWarehouseId { get; set; }
    /// <summary>
    /// 调往仓库
    /// </summary>
    [OptionEntity(typeof(InventoryWarehouse))]
    public long? ToWarehouseId { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}
public class InventoryDocumentItemDto : BaseUpdate
{
    public long ItemId { get; set; }
    public decimal Quantity { get; set; }

    [OptionEntity(typeof(InventoryLocation))]
    public long? FromLocationId { get; set; }

    [OptionEntity(typeof(InventoryLocation))]
    public long? ToLocationId { get; set; }
    public string? Remark { get; set; }
}
