# RoleMenuPermissionOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** | 菜单ID | [optional] [default to undefined]
**name** | **string** | 菜单名称 | [optional] [default to undefined]
**checked** | **boolean** | 是否拥有菜单权限 | [optional] [default to undefined]
**menuButtons** | [**Array&lt;SysMenuCompose&gt;**](SysMenuCompose.md) | 按钮 | [optional] [default to undefined]
**menuFields** | [**Array&lt;SysMenuCompose&gt;**](SysMenuCompose.md) | 字段 | [optional] [default to undefined]

## Example

```typescript
import { RoleMenuPermissionOutput } from './api';

const instance: RoleMenuPermissionOutput = {
    id,
    name,
    checked,
    menuButtons,
    menuFields,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
