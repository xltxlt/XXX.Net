# InventoryStockDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**domainId** | **string** |  | [optional] [default to undefined]
**itemId** | **string** |  | [default to undefined]
**warehouseId** | **string** |  | [optional] [default to undefined]
**locationId** | **string** |  | [default to undefined]
**quantity** | **number** |  | [optional] [default to undefined]
**lockedQuantity** | **number** |  | [optional] [default to undefined]
**availableQuantity** | **number** |  | [optional] [default to undefined]
**minQuantity** | **number** |  | [optional] [default to undefined]
**maxQuantity** | **number** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryStockDto } from './api';

const instance: InventoryStockDto = {
    id,
    name,
    tenantId,
    domainId,
    itemId,
    warehouseId,
    locationId,
    quantity,
    lockedQuantity,
    availableQuantity,
    minQuantity,
    maxQuantity,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
