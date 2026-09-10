# SysMenuFieldDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**menuId** | **string** | 所属菜单ID | [optional] [default to undefined]
**label** | **string** | 字段显示名 | [optional] [default to undefined]
**eventName** | **string** | 事件名 | [optional] [default to undefined]
**fieldName** | **string** | 对应数据库字段名 | [optional] [default to undefined]
**width** | **string** | 宽度 | [optional] [default to undefined]
**fieldType** | **number** | 显示类型 | [optional] [default to undefined]
**searchType** | **number** | 搜索框类型（文本框/下拉/日期等） | [optional] [default to undefined]
**floatType** | **number** | 浮动类型 | [optional] [default to undefined]
**totalRow** | **boolean** | 合计行 | [optional] [default to undefined]
**totalRowText** | **string** | 合计行文本 | [optional] [default to undefined]
**initHide** | **boolean** | 初始隐藏 | [optional] [default to undefined]
**alignType** | **number** | 对齐方式 | [optional] [default to undefined]
**searchField** | **boolean** | 应用搜索 | [optional] [default to undefined]
**template** | **string** | 模板 | [optional] [default to undefined]
**style** | **string** | 样式 | [optional] [default to undefined]
**target** | **number** | 终端：1&#x3D;PC 2&#x3D;App | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**placeholder** | **string** | 提示文本 | [optional] [default to undefined]
**dataSourceType** | **number** |  | [optional] [default to undefined]
**dataSourceValue** | **string** | 数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址） | [optional] [default to undefined]
**dataSourcePars** | **string** | 数据源参数（JSON格式） | [optional] [default to undefined]

## Example

```typescript
import { SysMenuFieldDto } from './api';

const instance: SysMenuFieldDto = {
    id,
    name,
    menuId,
    label,
    eventName,
    fieldName,
    width,
    fieldType,
    searchType,
    floatType,
    totalRow,
    totalRowText,
    initHide,
    alignType,
    searchField,
    template,
    style,
    target,
    sort,
    enabled,
    general,
    description,
    placeholder,
    dataSourceType,
    dataSourceValue,
    dataSourcePars,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
