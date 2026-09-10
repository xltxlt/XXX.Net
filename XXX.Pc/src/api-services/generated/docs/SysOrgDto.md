# SysOrgDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**path** | **Array&lt;string&gt;** | /1/2/3/ TODO 待排除自动映射 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**code** | **string** | 编码 | [optional] [default to undefined]
**shortName** | **string** | 简称 | [optional] [default to undefined]
**isTopOrg** | **boolean** | 顶级组织 | [optional] [default to undefined]
**domainName** | **string** | 域名 | [optional] [default to undefined]
**companyCode** | **string** | 企业信用代码 | [optional] [default to undefined]
**contacts** | **string** | 联系人 | [optional] [default to undefined]
**contactsPhone** | **string** | 联系人手机 | [optional] [default to undefined]
**contactsAddress** | **string** | 地址 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysOrgDto } from './api';

const instance: SysOrgDto = {
    id,
    name,
    sort,
    path,
    tenantId,
    code,
    shortName,
    isTopOrg,
    domainName,
    companyCode,
    contacts,
    contactsPhone,
    contactsAddress,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
