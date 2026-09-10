# InventoryItemDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**inventoryTypeId** | **string** |  | [default to undefined]
**code** | **string** |  | [default to undefined]
**unit** | **string** |  | [optional] [default to undefined]
**enabled** | [**EnabledEnum**](EnabledEnum.md) |  | [optional] [default to undefined]
**attributesJson** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryItemDto } from './api';

const instance: InventoryItemDto = {
    id,
    name,
    inventoryTypeId,
    code,
    unit,
    enabled,
    attributesJson,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
