# SysMenuField


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
**menuId** | **string** | 所属菜单ID | [optional] [default to undefined]
**label** | **string** | 字段显示名 | [optional] [default to undefined]
**eventName** | **string** | 事件名 | [optional] [default to undefined]
**fieldName** | **string** | 对应数据库字段名 | [optional] [default to undefined]
**fieldType** | **number** | 显示类型 | [optional] [default to undefined]
**searchType** | **number** | 搜索框类型（文本框/下拉/日期等） | [optional] [default to undefined]
**totalRow** | **boolean** | 合计行 | [optional] [default to undefined]
**totalRowText** | **string** | 合计行文本 | [optional] [default to undefined]
**initHide** | **boolean** | 初始隐藏 | [optional] [default to undefined]
**alignType** | **number** | 对齐方式 | [optional] [default to undefined]
**floatType** | **number** | 浮动类型 | [optional] [default to undefined]
**searchField** | **boolean** | 应用搜索 | [optional] [default to undefined]
**template** | **string** | 自定义模板 | [optional] [default to undefined]
**style** | **string** | 样式 | [optional] [default to undefined]
**width** | **string** | 列宽 | [optional] [default to undefined]
**target** | **number** | 终端：1&#x3D;PC 2&#x3D;App | [optional] [default to undefined]
**sort** | **number** | 排序 | [optional] [default to undefined]
**description** | **string** | 说明 | [optional] [default to undefined]
**placeholder** | **string** | 提示文本 | [optional] [default to undefined]
**dataSourceType** | **number** | 数据源类型：0&#x3D;无 1&#x3D;字典 2&#x3D;数据表 3&#x3D;枚举 4&#x3D;API | [optional] [default to undefined]
**dataSourceValue** | **string** | 数据源配置值（字典类型编码 / 数据表 / 枚举 / API地址） | [optional] [default to undefined]
**dataSourcePars** | **string** | 数据源参数（JSON格式） | [optional] [default to undefined]
**isCustom** | **boolean** | 是否为自定义 | [optional] [default to undefined]
**general** | **boolean** | 全局通用 | [optional] [default to undefined]
**enabled** | **boolean** | 状态 | [optional] [default to undefined]

## Example

```typescript
import { SysMenuField } from './api';

const instance: SysMenuField = {
    id,
    deleted,
    createdTime,
    createdBy,
    createdByName,
    updatedTime,
    updatedBy,
    updatedByName,
    name,
    menuId,
    label,
    eventName,
    fieldName,
    fieldType,
    searchType,
    totalRow,
    totalRowText,
    initHide,
    alignType,
    floatType,
    searchField,
    template,
    style,
    width,
    target,
    sort,
    description,
    placeholder,
    dataSourceType,
    dataSourceValue,
    dataSourcePars,
    isCustom,
    general,
    enabled,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
