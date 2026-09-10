# DocumentApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiDocumentAddPost**](#apidocumentaddpost) | **POST** /api/document/add | 新增|
|[**apiDocumentAddorupdatePost**](#apidocumentaddorupdatepost) | **POST** /api/document/addorupdate | 新增|
|[**apiDocumentBatchaddPost**](#apidocumentbatchaddpost) | **POST** /api/document/batchadd | 新增|
|[**apiDocumentBatchdeletePost**](#apidocumentbatchdeletepost) | **POST** /api/document/batchdelete | 删除|
|[**apiDocumentBatchlogicdeletePost**](#apidocumentbatchlogicdeletepost) | **POST** /api/document/batchlogicdelete | 逻辑删除|
|[**apiDocumentBatchupdatePost**](#apidocumentbatchupdatepost) | **POST** /api/document/batchupdate | 新增|
|[**apiDocumentDeleteIdPost**](#apidocumentdeleteidpost) | **POST** /api/document/delete/{id} | 删除|
|[**apiDocumentDetailIdGet**](#apidocumentdetailidget) | **GET** /api/document/detail/{id} | 获取详情|
|[**apiDocumentDetailoptionGet**](#apidocumentdetailoptionget) | **GET** /api/document/detailoption | 获取详情|
|[**apiDocumentListPost**](#apidocumentlistpost) | **POST** /api/document/list | 获取集合|
|[**apiDocumentLogicdeleteIdPost**](#apidocumentlogicdeleteidpost) | **POST** /api/document/logicdelete/{id} | 逻辑删除|
|[**apiDocumentOptionsPost**](#apidocumentoptionspost) | **POST** /api/document/options | 获取下拉搜索选项|
|[**apiDocumentPagelistPost**](#apidocumentpagelistpost) | **POST** /api/document/pagelist | 获取分页集合|
|[**apiDocumentPageoptionGet**](#apidocumentpageoptionget) | **GET** /api/document/pageoption | 获取新增修改页面选项|
|[**apiDocumentToEntityPost**](#apidocumenttoentitypost) | **POST** /api/document/to-entity | 模型到实体的转换|
|[**apiDocumentToListEntityPost**](#apidocumenttolistentitypost) | **POST** /api/document/to-list-entity | 模型到实体的批量转换|
|[**apiDocumentUpdatePost**](#apidocumentupdatepost) | **POST** /api/document/update | 更新|

# **apiDocumentAddPost**
> RESTfulResultSysDocumentRule apiDocumentAddPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    DocumentNumberRuleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: DocumentNumberRuleDto; // (optional)

const { status, data } = await apiInstance.apiDocumentAddPost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **DocumentNumberRuleDto**|  | |


### Return type

**RESTfulResultSysDocumentRule**

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

# **apiDocumentAddorupdatePost**
> RESTfulResultSysDocumentRule apiDocumentAddorupdatePost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    DocumentNumberRuleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: DocumentNumberRuleDto; // (optional)

const { status, data } = await apiInstance.apiDocumentAddorupdatePost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **DocumentNumberRuleDto**|  | |


### Return type

**RESTfulResultSysDocumentRule**

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

# **apiDocumentBatchaddPost**
> RESTfulResultInt32 apiDocumentBatchaddPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: Array<DocumentNumberRuleDto>; // (optional)

const { status, data } = await apiInstance.apiDocumentBatchaddPost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **Array<DocumentNumberRuleDto>**|  | |


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

# **apiDocumentBatchdeletePost**
> apiDocumentBatchdeletePost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiDocumentBatchdeletePost(
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

# **apiDocumentBatchlogicdeletePost**
> apiDocumentBatchlogicdeletePost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiDocumentBatchlogicdeletePost(
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

# **apiDocumentBatchupdatePost**
> RESTfulResultInt32 apiDocumentBatchupdatePost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: Array<DocumentNumberRuleDto>; // (optional)

const { status, data } = await apiInstance.apiDocumentBatchupdatePost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **Array<DocumentNumberRuleDto>**|  | |


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

# **apiDocumentDeleteIdPost**
> apiDocumentDeleteIdPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDocumentDeleteIdPost(
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

# **apiDocumentDetailIdGet**
> RESTfulResultSysDocumentRule apiDocumentDetailIdGet()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDocumentDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysDocumentRule**

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

# **apiDocumentDetailoptionGet**
> RESTfulResultPageDetailOptionDocumentNumberRuleDto apiDocumentDetailoptionGet()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiDocumentDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionDocumentNumberRuleDto**

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

# **apiDocumentListPost**
> RESTfulResultListSysDocumentRule apiDocumentListPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiDocumentListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysDocumentRule**

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

# **apiDocumentLogicdeleteIdPost**
> apiDocumentLogicdeleteIdPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDocumentLogicdeleteIdPost(
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

# **apiDocumentOptionsPost**
> RESTfulResultListPagedOptions apiDocumentOptionsPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiDocumentOptionsPost(
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

# **apiDocumentPagelistPost**
> RESTfulResultPagedListSysDocumentRule apiDocumentPagelistPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiDocumentPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysDocumentRule**

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

# **apiDocumentPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiDocumentPageoptionGet()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiDocumentPageoptionGet(
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

# **apiDocumentToEntityPost**
> RESTfulResultSysDocumentRule apiDocumentToEntityPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    DocumentNumberRuleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: DocumentNumberRuleDto; // (optional)

const { status, data } = await apiInstance.apiDocumentToEntityPost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **DocumentNumberRuleDto**|  | |


### Return type

**RESTfulResultSysDocumentRule**

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

# **apiDocumentToListEntityPost**
> RESTfulResultListSysDocumentRule apiDocumentToListEntityPost()


### Example

```typescript
import {
    DocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: Array<DocumentNumberRuleDto>; // (optional)

const { status, data } = await apiInstance.apiDocumentToListEntityPost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **Array<DocumentNumberRuleDto>**|  | |


### Return type

**RESTfulResultListSysDocumentRule**

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

# **apiDocumentUpdatePost**
> RESTfulResultSysDocumentRule apiDocumentUpdatePost()


### Example

```typescript
import {
    DocumentApi,
    Configuration,
    DocumentNumberRuleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DocumentApi(configuration);

let documentNumberRuleDto: DocumentNumberRuleDto; // (optional)

const { status, data } = await apiInstance.apiDocumentUpdatePost(
    documentNumberRuleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **documentNumberRuleDto** | **DocumentNumberRuleDto**|  | |


### Return type

**RESTfulResultSysDocumentRule**

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

