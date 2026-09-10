# SysOrganization


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**deleted** | **boolean** |  | [optional] [default to undefined]
**createdTime** | **string** |  | [optional] [default to undefined]
**createdBy** | **string** |  | [optional] [default to undefined]
**createByName** | **string** |  | [optional] [default to undefined]
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
**code** | **string** | 编码 | [optional] [default to undefined]
**shortName** | **string** | 简称 | [optional] [default to undefined]
**orgType** | **number** | 组织类型（字典表） | [optional] [default to undefined]
**isTopOrg** | **boolean** | 是否为顶级组织 | [optional] [default to undefined]
**domainName** | **string** | 域名 | [optional] [default to undefined]
**leaderUserId** | **string** | 部门主管ID | [optional] [default to undefined]
**businessAreaCode** | **string** | 业务大区编码 | [optional] [default to undefined]
**businessAreaId** | **string** | 业务大区ID | [optional] [default to undefined]
**dingTalkDeptId** | **string** | 钉钉部门ID | [optional] [default to undefined]
**companyCode** | **string** | 企业信用代码 | [optional] [default to undefined]
**contacts** | **string** | 联系人 | [optional] [default to undefined]
**contactsPhone** | **string** | 联系人手机 | [optional] [default to undefined]
**contactsAddress** | **string** | 地址 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysOrganization } from './api';

const instance: SysOrganization = {
    id,
    deleted,
    createdTime,
    createdBy,
    createByName,
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
    code,
    shortName,
    orgType,
    isTopOrg,
    domainName,
    leaderUserId,
    businessAreaCode,
    businessAreaId,
    dingTalkDeptId,
    companyCode,
    contacts,
    contactsPhone,
    contactsAddress,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
