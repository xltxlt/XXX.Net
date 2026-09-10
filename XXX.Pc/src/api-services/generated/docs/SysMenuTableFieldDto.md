# SysMenuTableFieldDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**fieldName** | **string** |  | [optional] [default to undefined]
**dataSourceType** | **number** | 数据源类型 | [optional] [default to undefined]
**dataSourceValue** | **string** | 数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址） | [optional] [default to undefined]
**httpType** | **number** |  | [optional] [default to undefined]
**dataSourcePars** | **string** | 数据源参数（JSON格式） | [optional] [default to undefined]
**dataSourceHeaders** | **string** | headers | [optional] [default to undefined]
**label** | **string** | 字段显示名 | [optional] [default to undefined]
**eventName** | **string** | 事件名 | [optional] [default to undefined]
**fieldType** | **number** | 显示类型 | [optional] [default to undefined]
**searchType** | **number** | 搜索框类型（文本框/下拉/日期等） | [optional] [default to undefined]
**width** | **string** | 列宽 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**totalRow** | **boolean** | 合计行 | [optional] [default to undefined]
**totalRowText** | **string** | 合计行文本 | [optional] [default to undefined]
**initHide** | **boolean** | 初始隐藏 | [optional] [default to undefined]
**alignType** | **number** | 对齐方式 | [optional] [default to undefined]
**floatType** | **number** | 浮动类型 | [optional] [default to undefined]
**searchField** | **boolean** | 应用搜索 | [optional] [default to undefined]
**template** | **string** | 自定义模板 | [optional] [default to undefined]
**style** | **string** | 样式 | [optional] [default to undefined]
**placeholder** | **string** | 提示文本 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuTableFieldDto } from './api';

const instance: SysMenuTableFieldDto = {
    fieldName,
    dataSourceType,
    dataSourceValue,
    httpType,
    dataSourcePars,
    dataSourceHeaders,
    label,
    eventName,
    fieldType,
    searchType,
    width,
    description,
    totalRow,
    totalRowText,
    initHide,
    alignType,
    floatType,
    searchField,
    template,
    style,
    placeholder,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
