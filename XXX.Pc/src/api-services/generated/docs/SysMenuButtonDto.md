# SysMenuButtonDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**menuId** | **string** | 菜单Id | [optional] [default to undefined]
**label** | **string** | 按钮显示名 | [optional] [default to undefined]
**color** | **string** | 颜色 | [optional] [default to undefined]
**bgColor** | **string** | 背景色 | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**eventName** | **string** | 事件名称 | [optional] [default to undefined]
**buttonType** | **number** | 字段类型 | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**target** | **number** |  | [optional] [default to undefined]
**describe** | **string** | 说明 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuButtonDto } from './api';

const instance: SysMenuButtonDto = {
    id,
    name,
    tenantId,
    menuId,
    label,
    color,
    bgColor,
    icon,
    eventName,
    buttonType,
    sort,
    enabled,
    general,
    target,
    describe,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
