# SysMenuTreeOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**name** | **string** | 菜单名称 | [optional] [default to undefined]
**alias** | **string** | 菜单别名 | [optional] [default to undefined]
**route** | **string** | 菜单路由 | [optional] [default to undefined]
**children** | [**Array&lt;SysMenuTreeOutput&gt;**](SysMenuTreeOutput.md) | 子菜单 | [optional] [default to undefined]
**description** | **string** | 菜单说明 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuTreeOutput } from './api';

const instance: SysMenuTreeOutput = {
    id,
    icon,
    code,
    name,
    alias,
    route,
    children,
    description,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
