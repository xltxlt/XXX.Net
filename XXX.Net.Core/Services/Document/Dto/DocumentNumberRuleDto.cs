using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Document.Dto;

public class DocumentNumberRuleDto : BaseTenantUpdate
{
    /// <summary>
    /// 单据类型，用于区分同一租户下的不同单据规则。
    /// </summary>
    public int DocumentType { get; set; }

    /// <summary>
    /// 单据号规则编码，作为业务生成单据号时的查询标识。
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 单据号前缀。
    /// </summary>
    public string Prefix { get; set; } = string.Empty;

    /// <summary>
    /// 单据号中的日期格式；为空时不生成日期部分。
    /// </summary>
    public string DateFormat { get; set; } = string.Empty;

    /// <summary>
    /// 流水号补零后的最小长度。
    /// </summary>
    public int SequenceLength { get; set; } = 6;

    /// <summary>
    /// 流水号重置周期。
    /// </summary>
    [OptionEnum(typeof(DocumentNumberResetTypeEnum))]
    public DocumentNumberResetTypeEnum ResetType { get; set; } = DocumentNumberResetTypeEnum.Daily;

    /// <summary>
    /// 是否启用当前单据号规则。
    /// </summary>
    [OptionEnum(typeof(EnabledEnum))]
    public bool Enabled { get; set; } = true;
}
