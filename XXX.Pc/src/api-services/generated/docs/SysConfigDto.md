# SysConfigDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**tenantId** | **string** | 租户 | [optional] [default to undefined]
**key** | **string** | 配置键 | [optional] [default to undefined]
**value** | **string** | 配置值 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysConfigDto } from './api';

const instance: SysConfigDto = {
    id,
    name,
    tenantId,
    key,
    value,
    description,
    general,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
