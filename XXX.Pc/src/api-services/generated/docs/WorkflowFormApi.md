# WorkflowFormApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowFormSavePost**](#apiworkflowformsavepost) | **POST** /api/workflow-form/save | |
|[**apiWorkflowFormWorkflowidNodeidGet**](#apiworkflowformworkflowidnodeidget) | **GET** /api/workflow-form/{workflowid}/{nodeid} | |

# **apiWorkflowFormSavePost**
> RESTfulResultWorkflowForm apiWorkflowFormSavePost()


### Example

```typescript
import {
    WorkflowFormApi,
    Configuration,
    WorkflowFormDto
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowFormApi(configuration);

let workflowFormDto: WorkflowFormDto; // (optional)

const { status, data } = await apiInstance.apiWorkflowFormSavePost(
    workflowFormDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowFormDto** | **WorkflowFormDto**|  | |


### Return type

**RESTfulResultWorkflowForm**

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

# **apiWorkflowFormWorkflowidNodeidGet**
> RESTfulResultWorkflowForm apiWorkflowFormWorkflowidNodeidGet()


### Example

```typescript
import {
    WorkflowFormApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowFormApi(configuration);

let workflowid: string; // (default to undefined)
let nodeid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowFormWorkflowidNodeidGet(
    workflowid,
    nodeid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowid** | [**string**] |  | defaults to undefined|
| **nodeid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowForm**

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

