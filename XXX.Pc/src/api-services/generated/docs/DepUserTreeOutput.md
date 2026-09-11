# DepUserTreeOutput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** | 部门ID / 用户ID | [optional] [default to undefined]
**type** | **number** | 1&#x3D;部门 2&#x3D;用户 | [optional] [default to undefined]
**name** | **string** | 名称 | [optional] [default to undefined]
**code** | **string** | 部门编码 | [optional] [default to undefined]
**parentId** | **string** | 父部门ID | [optional] [default to undefined]
**children** | [**Array&lt;DepUserTreeOutput&gt;**](DepUserTreeOutput.md) | 子节点 | [optional] [default to undefined]

## Example

```typescript
import { DepUserTreeOutput } from './api';

const instance: DepUserTreeOutput = {
    id,
    type,
    name,
    code,
    parentId,
    children,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
