# WorkflowDefinitionApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiWorkflowDefinitionDetailWorkflowdefinitionidGet**](#apiworkflowdefinitiondetailworkflowdefinitionidget) | **GET** /api/workflow-definition/detail/{workflowdefinitionid} | |
|[**apiWorkflowDefinitionListGet**](#apiworkflowdefinitionlistget) | **GET** /api/workflow-definition/list | |
|[**apiWorkflowDefinitionPublishWorkflowidPost**](#apiworkflowdefinitionpublishworkflowidpost) | **POST** /api/workflow-definition/publish/{workflowid} | |
|[**apiWorkflowDefinitionSavePost**](#apiworkflowdefinitionsavepost) | **POST** /api/workflow-definition/save | |

# **apiWorkflowDefinitionDetailWorkflowdefinitionidGet**
> RESTfulResultWorkflowDefinition apiWorkflowDefinitionDetailWorkflowdefinitionidGet()


### Example

```typescript
import {
    WorkflowDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowDefinitionApi(configuration);

let workflowdefinitionid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(
    workflowdefinitionid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowdefinitionid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowDefinition**

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

# **apiWorkflowDefinitionListGet**
> RESTfulResultListWorkflowDefinition apiWorkflowDefinitionListGet()


### Example

```typescript
import {
    WorkflowDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowDefinitionApi(configuration);

const { status, data } = await apiInstance.apiWorkflowDefinitionListGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListWorkflowDefinition**

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

# **apiWorkflowDefinitionPublishWorkflowidPost**
> RESTfulResultWorkflowDefinition apiWorkflowDefinitionPublishWorkflowidPost()


### Example

```typescript
import {
    WorkflowDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowDefinitionApi(configuration);

let workflowid: string; // (default to undefined)

const { status, data } = await apiInstance.apiWorkflowDefinitionPublishWorkflowidPost(
    workflowid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultWorkflowDefinition**

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

# **apiWorkflowDefinitionSavePost**
> RESTfulResultWorkflowDefinition apiWorkflowDefinitionSavePost()


### Example

```typescript
import {
    WorkflowDefinitionApi,
    Configuration,
    WorkflowDefinitionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new WorkflowDefinitionApi(configuration);

let workflowDefinitionDto: WorkflowDefinitionDto; // (optional)

const { status, data } = await apiInstance.apiWorkflowDefinitionSavePost(
    workflowDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **workflowDefinitionDto** | **WorkflowDefinitionDto**|  | |


### Return type

**RESTfulResultWorkflowDefinition**

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

