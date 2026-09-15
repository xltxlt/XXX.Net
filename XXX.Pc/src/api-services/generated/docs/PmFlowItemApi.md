# PmFlowItemApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiPmFlowItemAddPost**](#apipmflowitemaddpost) | **POST** /api/pm-flow-item/add | 新增|
|[**apiPmFlowItemAddorupdatePost**](#apipmflowitemaddorupdatepost) | **POST** /api/pm-flow-item/addorupdate | 新增|
|[**apiPmFlowItemBatchaddPost**](#apipmflowitembatchaddpost) | **POST** /api/pm-flow-item/batchadd | 新增|
|[**apiPmFlowItemBatchdeletePost**](#apipmflowitembatchdeletepost) | **POST** /api/pm-flow-item/batchdelete | 删除|
|[**apiPmFlowItemBatchlogicdeletePost**](#apipmflowitembatchlogicdeletepost) | **POST** /api/pm-flow-item/batchlogicdelete | 逻辑删除|
|[**apiPmFlowItemBatchupdatePost**](#apipmflowitembatchupdatepost) | **POST** /api/pm-flow-item/batchupdate | 新增|
|[**apiPmFlowItemDeleteIdPost**](#apipmflowitemdeleteidpost) | **POST** /api/pm-flow-item/delete/{id} | 删除|
|[**apiPmFlowItemDetailIdGet**](#apipmflowitemdetailidget) | **GET** /api/pm-flow-item/detail/{id} | 获取详情|
|[**apiPmFlowItemDetailoptionGet**](#apipmflowitemdetailoptionget) | **GET** /api/pm-flow-item/detailoption | 获取详情|
|[**apiPmFlowItemListPost**](#apipmflowitemlistpost) | **POST** /api/pm-flow-item/list | 获取集合|
|[**apiPmFlowItemLogicdeleteIdPost**](#apipmflowitemlogicdeleteidpost) | **POST** /api/pm-flow-item/logicdelete/{id} | 逻辑删除|
|[**apiPmFlowItemOptionsPost**](#apipmflowitemoptionspost) | **POST** /api/pm-flow-item/options | 获取下拉搜索选项|
|[**apiPmFlowItemPagelistPost**](#apipmflowitempagelistpost) | **POST** /api/pm-flow-item/pagelist | 获取分页集合|
|[**apiPmFlowItemPageoptionGet**](#apipmflowitempageoptionget) | **GET** /api/pm-flow-item/pageoption | 获取新增修改页面选项|
|[**apiPmFlowItemToEntityPost**](#apipmflowitemtoentitypost) | **POST** /api/pm-flow-item/to-entity | 模型到实体的转换|
|[**apiPmFlowItemToListEntityPost**](#apipmflowitemtolistentitypost) | **POST** /api/pm-flow-item/to-list-entity | 模型到实体的批量转换|
|[**apiPmFlowItemUpdatePost**](#apipmflowitemupdatepost) | **POST** /api/pm-flow-item/update | 更新|

# **apiPmFlowItemAddPost**
> RESTfulResultPmFlowItem apiPmFlowItemAddPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PmFlowItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: PmFlowItemDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemAddPost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **PmFlowItemDto**|  | |


### Return type

**RESTfulResultPmFlowItem**

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

# **apiPmFlowItemAddorupdatePost**
> RESTfulResultPmFlowItem apiPmFlowItemAddorupdatePost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PmFlowItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: PmFlowItemDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemAddorupdatePost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **PmFlowItemDto**|  | |


### Return type

**RESTfulResultPmFlowItem**

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

# **apiPmFlowItemBatchaddPost**
> RESTfulResultInt32 apiPmFlowItemBatchaddPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: Array<PmFlowItemDto>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemBatchaddPost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **Array<PmFlowItemDto>**|  | |


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

# **apiPmFlowItemBatchdeletePost**
> apiPmFlowItemBatchdeletePost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemBatchdeletePost(
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

# **apiPmFlowItemBatchlogicdeletePost**
> apiPmFlowItemBatchlogicdeletePost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemBatchlogicdeletePost(
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

# **apiPmFlowItemBatchupdatePost**
> RESTfulResultInt32 apiPmFlowItemBatchupdatePost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: Array<PmFlowItemDto>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemBatchupdatePost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **Array<PmFlowItemDto>**|  | |


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

# **apiPmFlowItemDeleteIdPost**
> apiPmFlowItemDeleteIdPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowItemDeleteIdPost(
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

# **apiPmFlowItemDetailIdGet**
> RESTfulResultPmFlowItem apiPmFlowItemDetailIdGet()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowItemDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultPmFlowItem**

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

# **apiPmFlowItemDetailoptionGet**
> RESTfulResultPageDetailOptionPmFlowItemDto apiPmFlowItemDetailoptionGet()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiPmFlowItemDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionPmFlowItemDto**

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

# **apiPmFlowItemListPost**
> RESTfulResultListPmFlowItem apiPmFlowItemListPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListPmFlowItem**

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

# **apiPmFlowItemLogicdeleteIdPost**
> apiPmFlowItemLogicdeleteIdPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiPmFlowItemLogicdeleteIdPost(
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

# **apiPmFlowItemOptionsPost**
> RESTfulResultListPagedOptions apiPmFlowItemOptionsPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemOptionsPost(
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

# **apiPmFlowItemPagelistPost**
> RESTfulResultPagedListPmFlowItem apiPmFlowItemPagelistPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListPmFlowItem**

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

# **apiPmFlowItemPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiPmFlowItemPageoptionGet()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiPmFlowItemPageoptionGet(
    where
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **where** | **Array&lt;PagedCustomWhere&gt;** |  | (optional) defaults to undefined|


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

# **apiPmFlowItemToEntityPost**
> RESTfulResultPmFlowItem apiPmFlowItemToEntityPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PmFlowItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: PmFlowItemDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemToEntityPost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **PmFlowItemDto**|  | |


### Return type

**RESTfulResultPmFlowItem**

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

# **apiPmFlowItemToListEntityPost**
> RESTfulResultListPmFlowItem apiPmFlowItemToListEntityPost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: Array<PmFlowItemDto>; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemToListEntityPost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **Array<PmFlowItemDto>**|  | |


### Return type

**RESTfulResultListPmFlowItem**

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

# **apiPmFlowItemUpdatePost**
> RESTfulResultPmFlowItem apiPmFlowItemUpdatePost()


### Example

```typescript
import {
    PmFlowItemApi,
    Configuration,
    PmFlowItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new PmFlowItemApi(configuration);

let pmFlowItemDto: PmFlowItemDto; // (optional)

const { status, data } = await apiInstance.apiPmFlowItemUpdatePost(
    pmFlowItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pmFlowItemDto** | **PmFlowItemDto**|  | |


### Return type

**RESTfulResultPmFlowItem**

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

