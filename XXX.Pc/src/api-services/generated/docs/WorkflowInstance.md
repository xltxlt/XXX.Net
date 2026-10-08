# WorkflowInstance


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**createdTime** | **string** |  | [optional] [default to undefined]
**instanceId** | **string** |  | [optional] [default to undefined]
**tenantId** | **string** |  | [optional] [default to undefined]
**pmFlowItemId** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**tempName** | **string** |  | [optional] [default to undefined]
**workflowId** | **string** |  | [optional] [default to undefined]
**version** | **number** |  | [optional] [default to undefined]
**status** | **string** |  | [optional] [default to undefined]
**currentNodeId** | **string** |  | [optional] [default to undefined]
**activeNodeIds** | **Array&lt;string&gt;** |  | [optional] [default to undefined]
**completedNodeIds** | **Array&lt;string&gt;** |  | [optional] [default to undefined]
**currentNodeStatus** | **string** |  | [optional] [default to undefined]
**dataJson** | **string** |  | [optional] [default to undefined]
**currentNodeStartedTime** | **string** |  | [optional] [default to undefined]
**lastOperateTime** | **string** |  | [optional] [default to undefined]
**rowVersion** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { WorkflowInstance } from './api';

const instance: WorkflowInstance = {
    id,
    createdTime,
    instanceId,
    tenantId,
    pmFlowItemId,
    name,
    tempName,
    workflowId,
    version,
    status,
    currentNodeId,
    activeNodeIds,
    completedNodeIds,
    currentNodeStatus,
    dataJson,
    currentNodeStartedTime,
    lastOperateTime,
    rowVersion,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
