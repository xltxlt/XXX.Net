# DingTalkTenantApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiDingTalkTenantAddPost**](#apidingtalktenantaddpost) | **POST** /api/ding-talk-tenant/add | 新增|
|[**apiDingTalkTenantAddorupdatePost**](#apidingtalktenantaddorupdatepost) | **POST** /api/ding-talk-tenant/addorupdate | 新增|
|[**apiDingTalkTenantBatchaddPost**](#apidingtalktenantbatchaddpost) | **POST** /api/ding-talk-tenant/batchadd | 新增|
|[**apiDingTalkTenantBatchdeletePost**](#apidingtalktenantbatchdeletepost) | **POST** /api/ding-talk-tenant/batchdelete | 删除|
|[**apiDingTalkTenantBatchlogicdeletePost**](#apidingtalktenantbatchlogicdeletepost) | **POST** /api/ding-talk-tenant/batchlogicdelete | 逻辑删除|
|[**apiDingTalkTenantBatchupdatePost**](#apidingtalktenantbatchupdatepost) | **POST** /api/ding-talk-tenant/batchupdate | 新增|
|[**apiDingTalkTenantDeleteIdPost**](#apidingtalktenantdeleteidpost) | **POST** /api/ding-talk-tenant/delete/{id} | 删除|
|[**apiDingTalkTenantDetailIdGet**](#apidingtalktenantdetailidget) | **GET** /api/ding-talk-tenant/detail/{id} | 获取详情|
|[**apiDingTalkTenantDetailbytenantTenantidGet**](#apidingtalktenantdetailbytenanttenantidget) | **GET** /api/ding-talk-tenant/detailbytenant/{tenantid} | 获取详情|
|[**apiDingTalkTenantDetailoptionGet**](#apidingtalktenantdetailoptionget) | **GET** /api/ding-talk-tenant/detailoption | 获取详情|
|[**apiDingTalkTenantListPost**](#apidingtalktenantlistpost) | **POST** /api/ding-talk-tenant/list | 获取集合|
|[**apiDingTalkTenantLogicdeleteIdPost**](#apidingtalktenantlogicdeleteidpost) | **POST** /api/ding-talk-tenant/logicdelete/{id} | 逻辑删除|
|[**apiDingTalkTenantOptionsPost**](#apidingtalktenantoptionspost) | **POST** /api/ding-talk-tenant/options | 获取下拉搜索选项|
|[**apiDingTalkTenantPagelistPost**](#apidingtalktenantpagelistpost) | **POST** /api/ding-talk-tenant/pagelist | 获取分页集合|
|[**apiDingTalkTenantPageoptionGet**](#apidingtalktenantpageoptionget) | **GET** /api/ding-talk-tenant/pageoption | 获取新增修改页面选项|
|[**apiDingTalkTenantToEntityPost**](#apidingtalktenanttoentitypost) | **POST** /api/ding-talk-tenant/to-entity | 模型到实体的转换|
|[**apiDingTalkTenantToListEntityPost**](#apidingtalktenanttolistentitypost) | **POST** /api/ding-talk-tenant/to-list-entity | 模型到实体的批量转换|
|[**apiDingTalkTenantUpdatePost**](#apidingtalktenantupdatepost) | **POST** /api/ding-talk-tenant/update | 更新|

# **apiDingTalkTenantAddPost**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantAddPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    DingTalkTenantAppDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: DingTalkTenantAppDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantAddPost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **DingTalkTenantAppDto**|  | |


### Return type

**RESTfulResultDingTalkTenantApp**

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

# **apiDingTalkTenantAddorupdatePost**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantAddorupdatePost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    DingTalkTenantAppDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: DingTalkTenantAppDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantAddorupdatePost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **DingTalkTenantAppDto**|  | |


### Return type

**RESTfulResultDingTalkTenantApp**

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

# **apiDingTalkTenantBatchaddPost**
> RESTfulResultInt32 apiDingTalkTenantBatchaddPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: Array<DingTalkTenantAppDto>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantBatchaddPost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **Array<DingTalkTenantAppDto>**|  | |


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

# **apiDingTalkTenantBatchdeletePost**
> apiDingTalkTenantBatchdeletePost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantBatchdeletePost(
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

# **apiDingTalkTenantBatchlogicdeletePost**
> apiDingTalkTenantBatchlogicdeletePost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantBatchlogicdeletePost(
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

# **apiDingTalkTenantBatchupdatePost**
> RESTfulResultInt32 apiDingTalkTenantBatchupdatePost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: Array<DingTalkTenantAppDto>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantBatchupdatePost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **Array<DingTalkTenantAppDto>**|  | |


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

# **apiDingTalkTenantDeleteIdPost**
> apiDingTalkTenantDeleteIdPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantDeleteIdPost(
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

# **apiDingTalkTenantDetailIdGet**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantDetailIdGet()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkTenantApp**

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

# **apiDingTalkTenantDetailbytenantTenantidGet**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantDetailbytenantTenantidGet()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let tenantid: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantDetailbytenantTenantidGet(
    tenantid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **tenantid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkTenantApp**

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

# **apiDingTalkTenantDetailoptionGet**
> RESTfulResultPageDetailOptionDingTalkTenantAppDto apiDingTalkTenantDetailoptionGet()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionDingTalkTenantAppDto**

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

# **apiDingTalkTenantListPost**
> RESTfulResultListDingTalkTenantApp apiDingTalkTenantListPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListDingTalkTenantApp**

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

# **apiDingTalkTenantLogicdeleteIdPost**
> apiDingTalkTenantLogicdeleteIdPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantLogicdeleteIdPost(
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

# **apiDingTalkTenantOptionsPost**
> RESTfulResultListPagedOptions apiDingTalkTenantOptionsPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantOptionsPost(
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

# **apiDingTalkTenantPagelistPost**
> RESTfulResultPagedListDingTalkTenantApp apiDingTalkTenantPagelistPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListDingTalkTenantApp**

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

# **apiDingTalkTenantPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiDingTalkTenantPageoptionGet()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiDingTalkTenantPageoptionGet(
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

# **apiDingTalkTenantToEntityPost**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantToEntityPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    DingTalkTenantAppDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: DingTalkTenantAppDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantToEntityPost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **DingTalkTenantAppDto**|  | |


### Return type

**RESTfulResultDingTalkTenantApp**

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

# **apiDingTalkTenantToListEntityPost**
> RESTfulResultListDingTalkTenantApp apiDingTalkTenantToListEntityPost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: Array<DingTalkTenantAppDto>; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantToListEntityPost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **Array<DingTalkTenantAppDto>**|  | |


### Return type

**RESTfulResultListDingTalkTenantApp**

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

# **apiDingTalkTenantUpdatePost**
> RESTfulResultDingTalkTenantApp apiDingTalkTenantUpdatePost()


### Example

```typescript
import {
    DingTalkTenantApi,
    Configuration,
    DingTalkTenantAppDto
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkTenantApi(configuration);

let dingTalkTenantAppDto: DingTalkTenantAppDto; // (optional)

const { status, data } = await apiInstance.apiDingTalkTenantUpdatePost(
    dingTalkTenantAppDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkTenantAppDto** | **DingTalkTenantAppDto**|  | |


### Return type

**RESTfulResultDingTalkTenantApp**

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

