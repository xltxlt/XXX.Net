# SysOrgTreeOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**name** | **string** | 菜单名称 | [optional] [default to undefined]
**children** | [**Array&lt;SysOrgTreeOutput&gt;**](SysOrgTreeOutput.md) | 子菜单 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]

## Example

```typescript
import { SysOrgTreeOutput } from './api';

const instance: SysOrgTreeOutput = {
    id,
    code,
    name,
    children,
    description,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
