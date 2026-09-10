# PagedListDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**menuId** | **string** | 页面Id | [optional] [default to undefined]
**menuCode** | **string** | 页面编码 | [optional] [default to undefined]
**tenantId** | **string** | 指定某租户下 | [optional] [default to undefined]
**where** | **{ [key: string]: string | null; }** | 查询(根据配置字段) | [optional] [default to undefined]
**customWhere** | [**Array&lt;PagedCustomWhere&gt;**](PagedCustomWhere.md) | 自定义高级查询 | [optional] [default to undefined]
**searchWhere** | [**Array&lt;PagedSearchWhere&gt;**](PagedSearchWhere.md) | 根据搜索类型 | [optional] [default to undefined]

## Example

```typescript
import { PagedListDto } from './api';

const instance: PagedListDto = {
    menuId,
    menuCode,
    tenantId,
    where,
    customWhere,
    searchWhere,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
