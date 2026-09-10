# SysDictTypeApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysDictTypeAddPost**](#apisysdicttypeaddpost) | **POST** /api/sys-dict-type/add | 1. 新增父子|
|[**apiSysDictTypeAddorupdatePost**](#apisysdicttypeaddorupdatepost) | **POST** /api/sys-dict-type/addorupdate | 新增|
|[**apiSysDictTypeBatchaddPost**](#apisysdicttypebatchaddpost) | **POST** /api/sys-dict-type/batchadd | 新增|
|[**apiSysDictTypeBatchdeletePost**](#apisysdicttypebatchdeletepost) | **POST** /api/sys-dict-type/batchdelete | 删除|
|[**apiSysDictTypeBatchlogicdeletePost**](#apisysdicttypebatchlogicdeletepost) | **POST** /api/sys-dict-type/batchlogicdelete | 逻辑删除|
|[**apiSysDictTypeBatchupdatePost**](#apisysdicttypebatchupdatepost) | **POST** /api/sys-dict-type/batchupdate | 新增|
|[**apiSysDictTypeDeleteIdPost**](#apisysdicttypedeleteidpost) | **POST** /api/sys-dict-type/delete/{id} | 删除|
|[**apiSysDictTypeDetailParentidGet**](#apisysdicttypedetailparentidget) | **GET** /api/sys-dict-type/detail/{parentid} | 3. 查询详情（Include）|
|[**apiSysDictTypeDetailoptionGet**](#apisysdicttypedetailoptionget) | **GET** /api/sys-dict-type/detailoption | 获取详情|
|[**apiSysDictTypeListPost**](#apisysdicttypelistpost) | **POST** /api/sys-dict-type/list | 获取集合|
|[**apiSysDictTypeLogicdeleteIdPost**](#apisysdicttypelogicdeleteidpost) | **POST** /api/sys-dict-type/logicdelete/{id} | 逻辑删除|
|[**apiSysDictTypeOptionsPost**](#apisysdicttypeoptionspost) | **POST** /api/sys-dict-type/options | 获取下拉搜索选项|
|[**apiSysDictTypePagelistPost**](#apisysdicttypepagelistpost) | **POST** /api/sys-dict-type/pagelist | 获取分页集合|
|[**apiSysDictTypePageoptionGet**](#apisysdicttypepageoptionget) | **GET** /api/sys-dict-type/pageoption | 获取新增修改页面选项|
|[**apiSysDictTypeToEntityPost**](#apisysdicttypetoentitypost) | **POST** /api/sys-dict-type/to-entity | 模型到实体的转换|
|[**apiSysDictTypeToListEntityPost**](#apisysdicttypetolistentitypost) | **POST** /api/sys-dict-type/to-list-entity | 模型到实体的批量转换|
|[**apiSysDictTypeUpdatePost**](#apisysdicttypeupdatepost) | **POST** /api/sys-dict-type/update | 更新父子（Include 核心）|

# **apiSysDictTypeAddPost**
> RESTfulResultSysDictType apiSysDictTypeAddPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    SysDictTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: SysDictTypeDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeAddPost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **SysDictTypeDto**|  | |


### Return type

**RESTfulResultSysDictType**

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

# **apiSysDictTypeAddorupdatePost**
> RESTfulResultSysDictType apiSysDictTypeAddorupdatePost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    SysDictTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: SysDictTypeDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeAddorupdatePost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **SysDictTypeDto**|  | |


### Return type

**RESTfulResultSysDictType**

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

# **apiSysDictTypeBatchaddPost**
> RESTfulResultInt32 apiSysDictTypeBatchaddPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: Array<SysDictTypeDto>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeBatchaddPost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **Array<SysDictTypeDto>**|  | |


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

# **apiSysDictTypeBatchdeletePost**
> apiSysDictTypeBatchdeletePost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeBatchdeletePost(
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

# **apiSysDictTypeBatchlogicdeletePost**
> apiSysDictTypeBatchlogicdeletePost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeBatchlogicdeletePost(
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

# **apiSysDictTypeBatchupdatePost**
> RESTfulResultInt32 apiSysDictTypeBatchupdatePost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: Array<SysDictTypeDto>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeBatchupdatePost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **Array<SysDictTypeDto>**|  | |


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

# **apiSysDictTypeDeleteIdPost**
> apiSysDictTypeDeleteIdPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDictTypeDeleteIdPost(
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

# **apiSysDictTypeDetailParentidGet**
> RESTfulResultSysDictType apiSysDictTypeDetailParentidGet()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let parentid: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDictTypeDetailParentidGet(
    parentid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **parentid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysDictType**

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

# **apiSysDictTypeDetailoptionGet**
> RESTfulResultPageDetailOptionSysDictTypeDto apiSysDictTypeDetailoptionGet()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysDictTypeDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysDictTypeDto**

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

# **apiSysDictTypeListPost**
> RESTfulResultListSysDictType apiSysDictTypeListPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysDictType**

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

# **apiSysDictTypeLogicdeleteIdPost**
> apiSysDictTypeLogicdeleteIdPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDictTypeLogicdeleteIdPost(
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

# **apiSysDictTypeOptionsPost**
> RESTfulResultListPagedOptions apiSysDictTypeOptionsPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeOptionsPost(
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

# **apiSysDictTypePagelistPost**
> RESTfulResultPagedListSysDictType apiSysDictTypePagelistPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypePagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysDictType**

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

# **apiSysDictTypePageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysDictTypePageoptionGet()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysDictTypePageoptionGet(
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

# **apiSysDictTypeToEntityPost**
> RESTfulResultSysDictType apiSysDictTypeToEntityPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    SysDictTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: SysDictTypeDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeToEntityPost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **SysDictTypeDto**|  | |


### Return type

**RESTfulResultSysDictType**

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

# **apiSysDictTypeToListEntityPost**
> RESTfulResultListSysDictType apiSysDictTypeToListEntityPost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: Array<SysDictTypeDto>; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeToListEntityPost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **Array<SysDictTypeDto>**|  | |


### Return type

**RESTfulResultListSysDictType**

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

# **apiSysDictTypeUpdatePost**
> RESTfulResultSysDictType apiSysDictTypeUpdatePost()


### Example

```typescript
import {
    SysDictTypeApi,
    Configuration,
    SysDictTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDictTypeApi(configuration);

let sysDictTypeDto: SysDictTypeDto; // (optional)

const { status, data } = await apiInstance.apiSysDictTypeUpdatePost(
    sysDictTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDictTypeDto** | **SysDictTypeDto**|  | |


### Return type

**RESTfulResultSysDictType**

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

