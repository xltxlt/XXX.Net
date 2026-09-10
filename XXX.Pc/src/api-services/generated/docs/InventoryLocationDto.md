# InventoryLocationDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**path** | **Array&lt;string&gt;** | /1/2/3/ TODO 待排除自动映射 | [optional] [default to undefined]
**warehouseId** | **string** |  | [default to undefined]
**code** | **string** |  | [default to undefined]
**enabled** | **boolean** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryLocationDto } from './api';

const instance: InventoryLocationDto = {
    id,
    name,
    sort,
    path,
    warehouseId,
    code,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
