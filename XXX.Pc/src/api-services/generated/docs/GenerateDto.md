# GenerateDto



## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**sysMenuDto** | [**SysMenuDto**](SysMenuDto.md) |  | [optional] [default to undefined]
**dtoName** | **string** | 关联Dto | [default to undefined]
**namespaceName** | **string** | 命名空间 | [default to undefined]
**entityName** | **string** | 关联实体 | [default to undefined]
**serviceName** | **string** | 关联服务 | [default to undefined]
**menuName** | **string** | 文件名称 | [optional] [default to undefined]
**addBtn** | **boolean** | 新增功能 | [optional] [default to undefined]
**editBtn** | **boolean** | 修改功能 | [optional] [default to undefined]
**lockBtn** | **boolean** | 查看功能 | [optional] [default to undefined]
**delBtn** | **boolean** | 删除功能 | [optional] [default to undefined]
**importBtn** | **boolean** | 导入功能 | [optional] [default to undefined]
**exportBtn** | **boolean** | 导出功能 | [optional] [default to undefined]
**menuGenerate** | **boolean** | 菜单生成 | [optional] [default to undefined]

## Example

```typescript
import { GenerateDto } from './api';

const instance: GenerateDto = {
    sysMenuDto,
    dtoName,
    namespaceName,
    entityName,
    serviceName,
    menuName,
    addBtn,
    editBtn,
    lockBtn,
    delBtn,
    importBtn,
    exportBtn,
    menuGenerate,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
