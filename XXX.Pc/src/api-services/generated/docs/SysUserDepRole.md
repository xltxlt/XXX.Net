# SysUserDepRole

用户在租户组织机构中的角色关联。

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
**userId** | **string** | 用户 ID。 | [optional] [default to undefined]
**departmentId** | **string** | 部门 ID。 | [optional] [default to undefined]
**roleId** | **string** | 角色 ID。 | [optional] [default to undefined]

## Example

```typescript
import { SysUserDepRole } from './api';

const instance: SysUserDepRole = {
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
    userId,
    departmentId,
    roleId,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
