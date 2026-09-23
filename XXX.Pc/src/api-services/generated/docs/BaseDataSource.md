# BaseDataSource


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**fieldName** | **string** |  | [optional] [default to undefined]
**dataSourceType** | **number** | 数据源类型 | [optional] [default to undefined]
**dataSourceValue** | **string** | 数据源配置值（1字典类型编码/ 2枚举 / 3数据表  ） | [optional] [default to undefined]
**httpType** | **number** |  | [optional] [default to undefined]
**dataSourcePars** | **string** | 数据源参数（JSON格式） | [optional] [default to undefined]
**dataSourceHeaders** | **string** | headers | [optional] [default to undefined]

## Example

```typescript
import { BaseDataSource } from './api';

const instance: BaseDataSource = {
    fieldName,
    dataSourceType,
    dataSourceValue,
    httpType,
    dataSourcePars,
    dataSourceHeaders,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
