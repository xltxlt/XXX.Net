# WorkflowNodeFormApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowNodeFormSavePost**](#apiworkflownodeformsavepost) | **POST** /api/workflow-node-form/save | |
|[**apiWorkflowNodeFormWorkflowdeginitionidNodeidGet**](#apiworkflownodeformworkflowdeginitionidnodeidget) | **GET** /api/workflow-node-form/{workflowdeginitionid}/{nodeid} | |

# **apiWorkflowNodeFormSavePost**
> RESTfulResultWorkflowNodeForm apiWorkflowNodeFormSavePost()


### Example

```typescript
import {
    WorkflowNodeFormApi,
    Configuration,
    WorkflowFormDto
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowNodeFormApi(configuration);

let workflowFormDto: WorkflowFormDto; // (optional)

const { status, data } = await apiInstance.apiWorkflowNodeFormSavePost(
    workflowFormDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowFormDto** | **WorkflowFormDto**|  | |


### Return type

**RESTfulResultWorkflowNodeForm**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json, text/plain
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiWorkflowNodeFormWorkflowdeginitionidNodeidGet**
> RESTfulResultWorkflowNodeForm apiWorkflowNodeFormWorkflowdeginitionidNodeidGet()


### Example

```typescript
import {
    WorkflowNodeFormApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowNodeFormApi(configuration);

let workflowdeginitionid: string; // (default to undefined)
let nodeid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
    workflowdeginitionid,
    nodeid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowdeginitionid** | [**string**] |  | defaults to undefined|
| **nodeid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowNodeForm**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

