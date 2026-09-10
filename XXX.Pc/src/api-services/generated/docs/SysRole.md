# SysRole


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
**code** | **string** | 编码 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**menus** | [**Array&lt;SysRoleMenu&gt;**](SysRoleMenu.md) | 菜单 | [optional] [default to undefined]
**menuButtons** | [**Array&lt;SysRoleMenuButton&gt;**](SysRoleMenuButton.md) | 按钮 | [optional] [default to undefined]
**menuFields** | [**Array&lt;SysRoleMenuField&gt;**](SysRoleMenuField.md) | 按钮 | [optional] [default to undefined]

## Example

```typescript
import { SysRole } from './api';

const instance: SysRole = {
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
    code,
    general,
    enabled,
    description,
    menus,
    menuButtons,
    menuFields,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
