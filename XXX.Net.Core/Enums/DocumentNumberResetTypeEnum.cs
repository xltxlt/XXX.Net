using XXX.Net.Core.Cache;

namespace XXX.Net.Core.Enums;

[EnumCache("DocumentNumberResetType")]
public enum DocumentNumberResetTypeEnum
{
    [Description("每日重置")]
    Daily = 0,

    [Description("每月重置")]
    Monthly = 1,

    [Description("每年重置")]
    Yearly = 2,

    [Description("永不重置")]
    Never = 3
}
