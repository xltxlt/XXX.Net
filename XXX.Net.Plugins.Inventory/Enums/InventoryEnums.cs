using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.Cache;

namespace XXX.Net.Plugins.Inventory.Enums;

[EnumCache("InventoryDocumentType")]
public enum InventoryDocumentType
{
    [Description("入库")]
    Inbound = 1,
    [Description("出库")]
    Outbound = 2,
    [Description("调拨")]
    Transfer = 3,
    [Description("盘点")]
    Adjustment = 4,
    [Description("退回/归还")]
    Return = 5
}

[EnumCache("InventoryDocumentStatus")]

public enum InventoryDocumentStatus
{
    [Description("草稿")]
    Draft = 0,
    [Description("已完成")]

    Completed = 1,
    [Description("已取消")]

    Cancelled = 2
}
[EnumCache("InventoryTransactionType")]

public enum InventoryTransactionType
{
    [Description("入库")]
    Inbound = 1,
    [Description("出库")]
    Outbound = 2,
    [Description("调拨入库")]
    TransferIn = 3,
    [Description("调拨出库")]
    TransferOut = 4,
    [Description("盘盈")]
    AdjustmentIncrease = 5,
    [Description("盘亏")]
    AdjustmentDecrease = 6,
    [Description("锁定库存")]
    Lock = 7,
    [Description("解锁库存")]
    Unlock = 8,
    [Description("退回/归还")]
    Return = 9
}
