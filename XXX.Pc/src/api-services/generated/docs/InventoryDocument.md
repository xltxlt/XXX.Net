# InventoryDocument


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**deleted** | **boolean** |  | [optional] [default to undefined]
**createdTime** | **string** |  | [optional] [default to undefined]
**createdBy** | **string** |  | [optional] [default to undefined]
**createByName** | **string** |  | [optional] [default to undefined]
**updatedTime** | **string** |  | [optional] [default to undefined]
**updatedBy** | **string** |  | [optional] [default to undefined]
**updatedByName** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**children** | [**Array&lt;InventoryDocumentItem&gt;**](InventoryDocumentItem.md) | 子级集合 | [optional] [default to undefined]
**items** | [**Array&lt;InventoryDocumentItem&gt;**](InventoryDocumentItem.md) | 子级集合 | [optional] [default to undefined]
**tenantId** | **string** |  | [optional] [default to undefined]
**domainId** | **string** |  | [optional] [default to undefined]
**documentNo** | **string** |  | [optional] [default to undefined]
**documentType** | [**InventoryDocumentType**](InventoryDocumentType.md) |  | [optional] [default to undefined]
**status** | [**InventoryDocumentStatus**](InventoryDocumentStatus.md) |  | [optional] [default to undefined]
**fromWarehouseId** | **string** |  | [optional] [default to undefined]
**toWarehouseId** | **string** |  | [optional] [default to undefined]
**remark** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryDocument } from './api';

const instance: InventoryDocument = {
    id,
    deleted,
    createdTime,
    createdBy,
    createByName,
    updatedTime,
    updatedBy,
    updatedByName,
    name,
    children,
    items,
    tenantId,
    domainId,
    documentNo,
    documentType,
    status,
    fromWarehouseId,
    toWarehouseId,
    remark,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
