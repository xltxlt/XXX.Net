# SysDepTreeOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**name** | **string** | 菜单名称 | [optional] [default to undefined]
**shortName** | **string** |  | [optional] [default to undefined]
**tenantId** | **string** |  | [optional] [default to undefined]
**sort** | **number** |  | [optional] [default to undefined]
**enabled** | **number** |  | [optional] [default to undefined]
**children** | [**Array&lt;SysDepTreeOutput&gt;**](SysDepTreeOutput.md) | 子菜单 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]

## Example

```typescript
import { SysDepTreeOutput } from './api';

const instance: SysDepTreeOutput = {
    id,
    code,
    name,
    shortName,
    tenantId,
    sort,
    enabled,
    children,
    description,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
