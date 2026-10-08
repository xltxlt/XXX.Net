# DingTalkWorkflowProcessInstancesInput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**originatorUserId** | **string** |  | [optional] [default to undefined]
**processCode** | **string** |  | [optional] [default to undefined]
**deptId** | **string** |  | [optional] [default to undefined]
**microappAgentId** | **string** |  | [optional] [default to undefined]
**approvers** | [**Array&lt;Approver&gt;**](Approver.md) |  | [optional] [default to undefined]
**ccList** | **Array&lt;string&gt;** |  | [optional] [default to undefined]
**ccPosition** | **string** |  | [optional] [default to undefined]
**targetSelectActioners** | [**Array&lt;TargetSelectActioner&gt;**](TargetSelectActioner.md) |  | [optional] [default to undefined]
**formComponentValues** | [**Array&lt;FormComponentValue&gt;**](FormComponentValue.md) |  | [optional] [default to undefined]
**requestId** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { DingTalkWorkflowProcessInstancesInput } from './api';

const instance: DingTalkWorkflowProcessInstancesInput = {
    originatorUserId,
    processCode,
    deptId,
    microappAgentId,
    approvers,
    ccList,
    ccPosition,
    targetSelectActioners,
    formComponentValues,
    requestId,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
