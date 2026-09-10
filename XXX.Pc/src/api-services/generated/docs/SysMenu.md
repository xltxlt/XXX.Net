# SysMenu


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
**path** | **string** | /1/2/3/ | [optional] [default to undefined]
**parentId** | **string** |  | [optional] [default to undefined]
**classLevel** | **number** |  | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**tenantId** | **string** |  | [optional] [default to undefined]
**tenant** | [**SysTenant**](SysTenant.md) |  | [optional] [default to undefined]
**alias** | **string** | 别名 | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**identify** | **string** | 权限标识（如 user:list、user:add） | [optional] [default to undefined]
**menuType** | **number** | 菜单类型：1&#x3D;目录 2&#x3D;页面 3&#x3D;按钮 | [optional] [default to undefined]
**target** | **number** | 终端：1&#x3D;PC 2&#x3D;小程序 3&#x3D;App 4&#x3D;全部 | [optional] [default to undefined]
**route** | **string** | 路由地址 | [optional] [default to undefined]
**eventName** | **string** | 事件名称 | [optional] [default to undefined]
**icon** | **string** | 图标 | [optional] [default to undefined]
**workbenchIcon** | **string** | 工作台 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**pageType** | **number** | 页面类型 | [optional] [default to undefined]
**maxTableButton** | **number** | 最大表格按钮数量 | [optional] [default to undefined]
**menuButtons** | [**Array&lt;SysMenuButton&gt;**](SysMenuButton.md) | 所有按钮（真实导航，EF 用） | [optional] [default to undefined]
**menuFields** | [**Array&lt;SysMenuField&gt;**](SysMenuField.md) | 菜单字段列表 | [optional] [default to undefined]

## Example

```typescript
import { SysMenu } from './api';

const instance: SysMenu = {
    id,
    deleted,
    createdTime,
    createdBy,
    createdByName,
    updatedTime,
    updatedBy,
    updatedByName,
    name,
    path,
    parentId,
    classLevel,
    sort,
    tenantId,
    tenant,
    alias,
    code,
    identify,
    menuType,
    target,
    route,
    eventName,
    icon,
    workbenchIcon,
    description,
    general,
    enabled,
    pageType,
    maxTableButton,
    menuButtons,
    menuFields,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
