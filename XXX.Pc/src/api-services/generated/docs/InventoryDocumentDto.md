# InventoryDocumentDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**children** | [**Array&lt;InventoryDocumentItemDto&gt;**](InventoryDocumentItemDto.md) |  | [optional] [default to undefined]
**domainId** | **string** |  | [optional] [default to undefined]
**documentNo** | **string** |  | [optional] [default to undefined]
**documentType** | **number** |  | [optional] [default to undefined]
**fromWarehouseId** | **string** |  | [optional] [default to undefined]
**toWarehouseId** | **string** |  | [optional] [default to undefined]
**remark** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryDocumentDto } from './api';

const instance: InventoryDocumentDto = {
    id,
    name,
    children,
    domainId,
    documentNo,
    documentType,
    fromWarehouseId,
    toWarehouseId,
    remark,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
