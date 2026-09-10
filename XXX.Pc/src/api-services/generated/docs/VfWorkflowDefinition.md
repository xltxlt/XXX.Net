# VfWorkflowDefinition


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**pmFlowTempId** | **string** |  | [optional] [default to undefined]
**workflowId** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**version** | **number** |  | [optional] [default to undefined]
**nodes** | [**Array&lt;VfWorkflowNode&gt;**](VfWorkflowNode.md) |  | [optional] [default to undefined]
**edges** | [**Array&lt;VfWorkflowEdge&gt;**](VfWorkflowEdge.md) |  | [optional] [default to undefined]
**form** | **{ [key: string]: string; }** |  | [optional] [default to undefined]
**attrData** | **{ [key: string]: string; }** |  | [optional] [default to undefined]
**buttonList** | **{ [key: string]: string; }** |  | [optional] [default to undefined]

## Example

```typescript
import { VfWorkflowDefinition } from './api';

const instance: VfWorkflowDefinition = {
    pmFlowTempId,
    workflowId,
    name,
    version,
    nodes,
    edges,
    form,
    attrData,
    buttonList,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
