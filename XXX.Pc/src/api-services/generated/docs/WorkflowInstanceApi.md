# WorkflowInstanceApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowInstanceDetailInstanceidGet**](#apiworkflowinstancedetailinstanceidget) | **GET** /api/workflow-instance/detail/{instanceid} | |
|[**apiWorkflowInstanceListGet**](#apiworkflowinstancelistget) | **GET** /api/workflow-instance/list | |
|[**apiWorkflowInstanceStartWorkflowidPost**](#apiworkflowinstancestartworkflowidpost) | **POST** /api/workflow-instance/start/{workflowid} | |

# **apiWorkflowInstanceDetailInstanceidGet**
> RESTfulResultWorkflowInstance apiWorkflowInstanceDetailInstanceidGet()


### Example

```typescript
import {
    WorkflowInstanceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowInstanceApi(configuration);

let instanceid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowInstanceDetailInstanceidGet(
    instanceid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **instanceid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowInstance**

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

# **apiWorkflowInstanceListGet**
> RESTfulResultListWorkflowInstance apiWorkflowInstanceListGet()


### Example

```typescript
import {
    WorkflowInstanceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowInstanceApi(configuration);

const { status, data } = await apiInstance.apiWorkflowInstanceListGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListWorkflowInstance**

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

# **apiWorkflowInstanceStartWorkflowidPost**
> RESTfulResultString apiWorkflowInstanceStartWorkflowidPost()


### Example

```typescript
import {
    WorkflowInstanceApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowInstanceApi(configuration);

let workflowid: string; // (default to undefined)
let requestBody: { [key: string]: object; }; // (optional)

const { status, data } = await apiInstance.apiWorkflowInstanceStartWorkflowidPost(
    workflowid,
    requestBody
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **requestBody** | **{ [key: string]: object; }**|  | |
| **workflowid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultString**

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

