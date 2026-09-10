# SysDictTypeDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**children** | [**Array&lt;SysDictDataDto&gt;**](SysDictDataDto.md) |  | [optional] [default to undefined]
**code** | **string** | 类型编码 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysDictTypeDto } from './api';

const instance: SysDictTypeDto = {
    id,
    name,
    children,
    code,
    general,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
