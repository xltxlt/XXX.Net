# SysMenuComposeTreeOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**name** | **string** | 菜单名称 | [optional] [default to undefined]
**alias** | **string** | 菜单别名 | [optional] [default to undefined]
**route** | **string** | 菜单路由 | [optional] [default to undefined]
**children** | [**Array&lt;SysMenuComposeTreeOutput&gt;**](SysMenuComposeTreeOutput.md) |  | [optional] [default to undefined]
**description** | **string** | 菜单说明 | [optional] [default to undefined]
**menuButtons** | [**Array&lt;SysMenuCompose&gt;**](SysMenuCompose.md) |  | [optional] [default to undefined]
**menuFields** | [**Array&lt;SysMenuCompose&gt;**](SysMenuCompose.md) |  | [optional] [default to undefined]

## Example

```typescript
import { SysMenuComposeTreeOutput } from './api';

const instance: SysMenuComposeTreeOutput = {
    id,
    icon,
    code,
    name,
    alias,
    route,
    children,
    description,
    menuButtons,
    menuFields,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
