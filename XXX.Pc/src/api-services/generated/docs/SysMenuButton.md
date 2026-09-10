# SysMenuButton


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**deleted** | **boolean** |  | [optional] [default to undefined]
**createdTime** | **string** |  | [optional] [default to undefined]
**createdBy** | **string** |  | [optional] [default to undefined]
**createdByName** | **string** |  | [optional] [default to undefined]
**updatedTime** | **string** |  | [optional] [default to undefined]
**updatedBy** | **string** |  | [optional] [default to undefined]
**updatedByName** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**tenantId** | **string** |  | [optional] [default to undefined]
**tenant** | [**SysTenant**](SysTenant.md) |  | [optional] [default to undefined]
**menuId** | **string** | 所属菜单ID | [optional] [default to undefined]
**label** | **string** | 字段显示名 | [optional] [default to undefined]
**eventName** | **string** | 事件名称 | [optional] [default to undefined]
**buttonType** | **number** | 字段类型：1&#x3D;按钮 2&#x3D;表格按钮 | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**color** | **string** | 颜色 | [optional] [default to undefined]
**bgColor** | **string** | 背景色 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**target** | **number** | 终端：1&#x3D;PC 2&#x3D;App | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuButton } from './api';

const instance: SysMenuButton = {
    id,
    deleted,
    createdTime,
    createdBy,
    createdByName,
    updatedTime,
    updatedBy,
    updatedByName,
    name,
    tenantId,
    tenant,
    menuId,
    label,
    eventName,
    buttonType,
    icon,
    color,
    bgColor,
    description,
    target,
    sort,
    general,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
