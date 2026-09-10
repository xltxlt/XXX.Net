# WorkflowDefinition


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**createdTime** | **string** |  | [optional] [default to undefined]
**pmFlowTempId** | **string** |  | [optional] [default to undefined]
**workflowId** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**version** | **number** |  | [optional] [default to undefined]
**status** | **string** |  | [optional] [default to undefined]
**nodes** | [**Array&lt;VfWorkflowNode&gt;**](VfWorkflowNode.md) |  | [optional] [default to undefined]
**edges** | [**Array&lt;VfWorkflowEdge&gt;**](VfWorkflowEdge.md) |  | [optional] [default to undefined]

## Example

```typescript
import { WorkflowDefinition } from './api';

const instance: WorkflowDefinition = {
    id,
    createdTime,
    pmFlowTempId,
    workflowId,
    name,
    version,
    status,
    nodes,
    edges,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
