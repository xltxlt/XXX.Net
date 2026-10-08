# WorkflowTaskApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowTaskDetailNodeidGet**](#apiworkflowtaskdetailnodeidget) | **GET** /api/workflow-task/detail/{nodeid} | |
|[**apiWorkflowTaskPost**](#apiworkflowtaskpost) | **POST** /api/workflow-task | |
|[**apiWorkflowTaskTodoListGet**](#apiworkflowtasktodolistget) | **GET** /api/workflow-task/todo-list | |
|[**apiWorkflowTaskWfHistorydListInstanceidGet**](#apiworkflowtaskwfhistorydlistinstanceidget) | **GET** /api/workflow-task/wf-historyd-list/{instanceid} | |

# **apiWorkflowTaskDetailNodeidGet**
> RESTfulResultWorkflowTask apiWorkflowTaskDetailNodeidGet()


### Example

```typescript
import {
    WorkflowTaskApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowTaskApi(configuration);

let nodeid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowTaskDetailNodeidGet(
    nodeid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **nodeid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowTask**

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

# **apiWorkflowTaskPost**
> apiWorkflowTaskPost()


### Example

```typescript
import {
    WorkflowTaskApi,
    Configuration,
    TaskSubmitDto
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowTaskApi(configuration);

let taskSubmitDto: TaskSubmitDto; // (optional)

const { status, data } = await apiInstance.apiWorkflowTaskPost(
    taskSubmitDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **taskSubmitDto** | **TaskSubmitDto**|  | |


### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json, text/plain
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiWorkflowTaskTodoListGet**
> RESTfulResultListWorkflowTask apiWorkflowTaskTodoListGet()


### Example

```typescript
import {
    WorkflowTaskApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowTaskApi(configuration);

const { status, data } = await apiInstance.apiWorkflowTaskTodoListGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListWorkflowTask**

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

# **apiWorkflowTaskWfHistorydListInstanceidGet**
> RESTfulResultListWorkflowHistory apiWorkflowTaskWfHistorydListInstanceidGet()


### Example

```typescript
import {
    WorkflowTaskApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowTaskApi(configuration);

let instanceid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowTaskWfHistorydListInstanceidGet(
    instanceid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **instanceid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultListWorkflowHistory**

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

