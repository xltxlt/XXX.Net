# SysMenuDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**path** | **Array&lt;string&gt;** | /1/2/3/ TODO 待排除自动映射 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**menuId** | **string** | 所属菜单ID | [optional] [default to undefined]
**alias** | **string** | 别名 | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**identify** | **string** | 权限标识（如 user:list、user:add） | [optional] [default to undefined]
**menuType** | **number** | 菜单类型：1&#x3D;目录 2&#x3D;页面 3&#x3D;按钮 | [optional] [default to undefined]
**target** | **number** | 终端：1&#x3D;PC 2&#x3D;小程序 3&#x3D;App | [optional] [default to undefined]
**route** | **string** | 路由地址 | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**pageType** | **number** | 页面类型 | [optional] [default to undefined]
**maxTableButton** | **number** | 最大表格按钮数量 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuDto } from './api';

const instance: SysMenuDto = {
    id,
    name,
    sort,
    path,
    tenantId,
    menuId,
    alias,
    code,
    identify,
    menuType,
    target,
    route,
    icon,
    description,
    general,
    enabled,
    pageType,
    maxTableButton,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
