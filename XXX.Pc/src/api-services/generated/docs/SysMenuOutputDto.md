# SysMenuOutputDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** | 菜单Id | [optional] [default to undefined]
**MenuName** | **string** | 菜单名称 | [optional] [default to undefined]
**alias** | **string** | 菜单别名 | [optional] [default to undefined]
**MenuCode** | **string** | 菜单编码 | [optional] [default to undefined]
**identify** | **string** | 权限标识 | [optional] [default to undefined]
**route** | **string** | 路由 | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**pageType** | **number** | 页面类型 | [optional] [default to undefined]
**maxTableButton** | **number** | 最大表格按钮数量 | [optional] [default to undefined]
**buttons** | [**Array&lt;SysMenuTableButtonDto&gt;**](SysMenuTableButtonDto.md) |  | [optional] [default to undefined]
**tableButtons** | [**Array&lt;SysMenuHandleButtonDto&gt;**](SysMenuHandleButtonDto.md) |  | [optional] [default to undefined]
**fields** | [**Array&lt;SysMenuTableFieldDto&gt;**](SysMenuTableFieldDto.md) |  | [optional] [default to undefined]

## Example

```typescript
import { SysMenuOutputDto } from './api';

const instance: SysMenuOutputDto = {
    id,
    MenuName,
    alias,
    MenuCode,
    identify,
    route,
    icon,
    general,
    enabled,
    pageType,
    maxTableButton,
    buttons,
    tableButtons,
    fields,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
