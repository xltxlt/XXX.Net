# PmFlowTempApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiPmFlowTempAddPost**](#apipmflowtempaddpost) | **POST** /api/pm-flow-temp/add | 新增|
|[**apiPmFlowTempAddorupdatePost**](#apipmflowtempaddorupdatepost) | **POST** /api/pm-flow-temp/addorupdate | 新增|
|[**apiPmFlowTempBatchaddPost**](#apipmflowtempbatchaddpost) | **POST** /api/pm-flow-temp/batchadd | 新增|
|[**apiPmFlowTempBatchdeletePost**](#apipmflowtempbatchdeletepost) | **POST** /api/pm-flow-temp/batchdelete | 删除|
|[**apiPmFlowTempBatchlogicdeletePost**](#apipmflowtempbatchlogicdeletepost) | **POST** /api/pm-flow-temp/batchlogicdelete | 逻辑删除|
|[**apiPmFlowTempBatchupdatePost**](#apipmflowtempbatchupdatepost) | **POST** /api/pm-flow-temp/batchupdate | 新增|
|[**apiPmFlowTempDeleteIdPost**](#apipmflowtempdeleteidpost) | **POST** /api/pm-flow-temp/delete/{id} | 删除|
|[**apiPmFlowTempDetailIdGet**](#apipmflowtempdetailidget) | **GET** /api/pm-flow-temp/detail/{id} | 获取详情|
|[**apiPmFlowTempDetailoptionGet**](#apipmflowtempdetailoptionget) | **GET** /api/pm-flow-temp/detailoption | 获取详情|
|[**apiPmFlowTempListPost**](#apipmflowtemplistpost) | **POST** /api/pm-flow-temp/list | 获取集合|
|[**apiPmFlowTempLogicdeleteIdPost**](#apipmflowtemplogicdeleteidpost) | **POST** /api/pm-flow-temp/logicdelete/{id} | 逻辑删除|
|[**apiPmFlowTempOptionsPost**](#apipmflowtempoptionspost) | **POST** /api/pm-flow-temp/options | 获取下拉搜索选项|
|[**apiPmFlowTempPagelistPost**](#apipmflowtemppagelistpost) | **POST** /api/pm-flow-temp/pagelist | 获取分页集合|
|[**apiPmFlowTempPageoptionGet**](#apipmflowtemppageoptionget) | **GET** /api/pm-flow-temp/pageoption | 获取新增修改页面选项|
|[**apiPmFlowTempUpdatePost**](#apipmflowtempupdatepost) | **POST** /api/pm-flow-temp/update | 更新|

# **apiPmFlowTempAddPost**
> RESTfulResultPmFlowTemp apiPmFlowTempAddPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration,
    PmFlowTempDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pmFlowTempDto: PmFlowTempDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempAddPost(
    pmFlowTempDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowTempDto** | **PmFlowTempDto**|  | |


### Return type

**RESTfulResultPmFlowTemp**

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

# **apiPmFlowTempAddorupdatePost**
> RESTfulResultPmFlowTemp apiPmFlowTempAddorupdatePost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration,
    PmFlowTempDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pmFlowTempDto: PmFlowTempDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempAddorupdatePost(
    pmFlowTempDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowTempDto** | **PmFlowTempDto**|  | |


### Return type

**RESTfulResultPmFlowTemp**

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

# **apiPmFlowTempBatchaddPost**
> RESTfulResultInt32 apiPmFlowTempBatchaddPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pmFlowTempDto: Array<PmFlowTempDto>; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempBatchaddPost(
    pmFlowTempDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowTempDto** | **Array<PmFlowTempDto>**|  | |


### Return type

**RESTfulResultInt32**

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

# **apiPmFlowTempBatchdeletePost**
> apiPmFlowTempBatchdeletePost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempBatchdeletePost(
    requestBody
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **requestBody** | **Array<string>**|  | |


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

# **apiPmFlowTempBatchlogicdeletePost**
> apiPmFlowTempBatchlogicdeletePost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempBatchlogicdeletePost(
    requestBody
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **requestBody** | **Array<string>**|  | |


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

# **apiPmFlowTempBatchupdatePost**
> RESTfulResultInt32 apiPmFlowTempBatchupdatePost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pmFlowTempDto: Array<PmFlowTempDto>; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempBatchupdatePost(
    pmFlowTempDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowTempDto** | **Array<PmFlowTempDto>**|  | |


### Return type

**RESTfulResultInt32**

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

# **apiPmFlowTempDeleteIdPost**
> apiPmFlowTempDeleteIdPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowTempDeleteIdPost(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPmFlowTempDetailIdGet**
> RESTfulResultPmFlowTemp apiPmFlowTempDetailIdGet()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowTempDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultPmFlowTemp**

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

# **apiPmFlowTempDetailoptionGet**
> RESTfulResultPageDetailOptionPmFlowTempDto apiPmFlowTempDetailoptionGet()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiPmFlowTempDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionPmFlowTempDto**

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

# **apiPmFlowTempListPost**
> RESTfulResultListPmFlowTemp apiPmFlowTempListPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListPmFlowTemp**

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

# **apiPmFlowTempLogicdeleteIdPost**
> apiPmFlowTempLogicdeleteIdPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowTempLogicdeleteIdPost(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiPmFlowTempOptionsPost**
> RESTfulResultListPagedOptions apiPmFlowTempOptionsPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempOptionsPost(
    pagedCustomWhere
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedCustomWhere** | **Array<PagedCustomWhere>**|  | |


### Return type

**RESTfulResultListPagedOptions**

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

# **apiPmFlowTempPagelistPost**
> RESTfulResultPagedListPmFlowTemp apiPmFlowTempPagelistPost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListPmFlowTemp**

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

# **apiPmFlowTempPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiPmFlowTempPageoptionGet()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

const { status, data } = await apiInstance.apiPmFlowTempPageoptionGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultDictionaryStringListPagedOptions**

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

# **apiPmFlowTempUpdatePost**
> RESTfulResultPmFlowTemp apiPmFlowTempUpdatePost()


### Example

```typescript
import {
    PmFlowTempApi,
    Configuration,
    PmFlowTempDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowTempApi(configuration);

let pmFlowTempDto: PmFlowTempDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowTempUpdatePost(
    pmFlowTempDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowTempDto** | **PmFlowTempDto**|  | |


### Return type

**RESTfulResultPmFlowTemp**

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

