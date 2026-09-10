# InventoryAttributeDefinitionDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**inventoryTypeId** | **string** |  | [default to undefined]
**code** | **string** |  | [default to undefined]
**dataType** | [**PageFormTypeEnum**](PageFormTypeEnum.md) |  | [optional] [default to undefined]
**required** | **boolean** |  | [optional] [default to undefined]
**unique** | **boolean** |  | [optional] [default to undefined]
**isKey** | **boolean** |  | [optional] [default to undefined]
**sort** | **number** |  | [optional] [default to undefined]
**optionsJson** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { InventoryAttributeDefinitionDto } from './api';

const instance: InventoryAttributeDefinitionDto = {
    id,
    name,
    inventoryTypeId,
    code,
    dataType,
    required,
    unique,
    isKey,
    sort,
    optionsJson,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
