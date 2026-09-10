# DocumentNumberRuleDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**documentType** | **number** | 单据类型，用于区分同一租户下的不同单据规则。 | [optional] [default to undefined]
**code** | **string** | 单据号规则编码，作为业务生成单据号时的查询标识。 | [optional] [default to undefined]
**prefix** | **string** | 单据号前缀。 | [optional] [default to undefined]
**dateFormat** | **string** | 单据号中的日期格式；为空时不生成日期部分。 | [optional] [default to undefined]
**sequenceLength** | **number** | 流水号补零后的最小长度。 | [optional] [default to undefined]
**resetType** | [**DocumentNumberResetTypeEnum**](DocumentNumberResetTypeEnum.md) |  | [optional] [default to undefined]
**enabled** | **boolean** | 是否启用当前单据号规则。 | [optional] [default to undefined]

## Example

```typescript
import { DocumentNumberRuleDto } from './api';

const instance: DocumentNumberRuleDto = {
    id,
    name,
    tenantId,
    documentType,
    code,
    prefix,
    dateFormat,
    sequenceLength,
    resetType,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
