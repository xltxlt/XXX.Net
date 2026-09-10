# WorkflowTaskApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowTaskPost**](#apiworkflowtaskpost) | **POST** /api/workflow-task | |
|[**apiWorkflowTaskTodoListGet**](#apiworkflowtasktodolistget) | **GET** /api/workflow-task/todo-list | |

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

