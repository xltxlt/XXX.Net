# ResultData


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**attachedProcessInstanceIds** | **Array&lt;string&gt;** |  | [optional] [default to undefined]
**businessId** | **string** |  | [optional] [default to undefined]
**title** | **string** |  | [optional] [default to undefined]
**originatorDeptId** | **string** |  | [optional] [default to undefined]
**operationRecords** | [**Array&lt;OperationRecord&gt;**](OperationRecord.md) |  | [optional] [default to undefined]
**formComponentValues** | [**Array&lt;FormComponentValue&gt;**](FormComponentValue.md) |  | [optional] [default to undefined]
**result** | **string** |  | [optional] [default to undefined]
**bizAction** | **string** |  | [optional] [default to undefined]
**createTime** | **string** |  | [optional] [default to undefined]
**originatorUserId** | **string** |  | [optional] [default to undefined]
**tasks** | [**Array&lt;TaskItem&gt;**](TaskItem.md) |  | [optional] [default to undefined]
**originatorDeptName** | **string** |  | [optional] [default to undefined]
**status** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { ResultData } from './api';

const instance: ResultData = {
    attachedProcessInstanceIds,
    businessId,
    title,
    originatorDeptId,
    operationRecords,
    formComponentValues,
    result,
    bizAction,
    createTime,
    originatorUserId,
    tasks,
    originatorDeptName,
    status,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
