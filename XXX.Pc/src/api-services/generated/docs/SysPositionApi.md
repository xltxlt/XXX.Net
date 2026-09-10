# SysPositionApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysPositionAddPost**](#apisyspositionaddpost) | **POST** /api/sys-position/add | 新增|
|[**apiSysPositionAddorupdatePost**](#apisyspositionaddorupdatepost) | **POST** /api/sys-position/addorupdate | 新增|
|[**apiSysPositionBatchaddPost**](#apisyspositionbatchaddpost) | **POST** /api/sys-position/batchadd | 新增|
|[**apiSysPositionBatchdeletePost**](#apisyspositionbatchdeletepost) | **POST** /api/sys-position/batchdelete | 删除|
|[**apiSysPositionBatchlogicdeletePost**](#apisyspositionbatchlogicdeletepost) | **POST** /api/sys-position/batchlogicdelete | 逻辑删除|
|[**apiSysPositionBatchupdatePost**](#apisyspositionbatchupdatepost) | **POST** /api/sys-position/batchupdate | 新增|
|[**apiSysPositionDeleteIdPost**](#apisyspositiondeleteidpost) | **POST** /api/sys-position/delete/{id} | 删除|
|[**apiSysPositionDetailIdGet**](#apisyspositiondetailidget) | **GET** /api/sys-position/detail/{id} | 获取详情|
|[**apiSysPositionDetailoptionGet**](#apisyspositiondetailoptionget) | **GET** /api/sys-position/detailoption | 获取详情|
|[**apiSysPositionListPost**](#apisyspositionlistpost) | **POST** /api/sys-position/list | 获取集合|
|[**apiSysPositionLogicdeleteIdPost**](#apisyspositionlogicdeleteidpost) | **POST** /api/sys-position/logicdelete/{id} | 逻辑删除|
|[**apiSysPositionOptionsPost**](#apisyspositionoptionspost) | **POST** /api/sys-position/options | 获取下拉搜索选项|
|[**apiSysPositionPagelistPost**](#apisyspositionpagelistpost) | **POST** /api/sys-position/pagelist | 获取分页集合|
|[**apiSysPositionPageoptionGet**](#apisyspositionpageoptionget) | **GET** /api/sys-position/pageoption | 获取新增修改页面选项|
|[**apiSysPositionToEntityPost**](#apisyspositiontoentitypost) | **POST** /api/sys-position/to-entity | 模型到实体的转换|
|[**apiSysPositionToListEntityPost**](#apisyspositiontolistentitypost) | **POST** /api/sys-position/to-list-entity | 模型到实体的批量转换|
|[**apiSysPositionUpdatePost**](#apisyspositionupdatepost) | **POST** /api/sys-position/update | 更新|

# **apiSysPositionAddPost**
> RESTfulResultSysPosition apiSysPositionAddPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    SysPositionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: SysPositionDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionAddPost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **SysPositionDto**|  | |


### Return type

**RESTfulResultSysPosition**

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

# **apiSysPositionAddorupdatePost**
> RESTfulResultSysPosition apiSysPositionAddorupdatePost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    SysPositionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: SysPositionDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionAddorupdatePost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **SysPositionDto**|  | |


### Return type

**RESTfulResultSysPosition**

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

# **apiSysPositionBatchaddPost**
> RESTfulResultInt32 apiSysPositionBatchaddPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: Array<SysPositionDto>; // (optional)

const { status, data } = await apiInstance.apiSysPositionBatchaddPost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **Array<SysPositionDto>**|  | |


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

# **apiSysPositionBatchdeletePost**
> apiSysPositionBatchdeletePost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysPositionBatchdeletePost(
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

# **apiSysPositionBatchlogicdeletePost**
> apiSysPositionBatchlogicdeletePost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysPositionBatchlogicdeletePost(
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

# **apiSysPositionBatchupdatePost**
> RESTfulResultInt32 apiSysPositionBatchupdatePost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: Array<SysPositionDto>; // (optional)

const { status, data } = await apiInstance.apiSysPositionBatchupdatePost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **Array<SysPositionDto>**|  | |


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

# **apiSysPositionDeleteIdPost**
> apiSysPositionDeleteIdPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysPositionDeleteIdPost(
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

# **apiSysPositionDetailIdGet**
> RESTfulResultSysPosition apiSysPositionDetailIdGet()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysPositionDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysPosition**

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

# **apiSysPositionDetailoptionGet**
> RESTfulResultPageDetailOptionSysPositionDto apiSysPositionDetailoptionGet()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysPositionDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysPositionDto**

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

# **apiSysPositionListPost**
> RESTfulResultListSysPosition apiSysPositionListPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysPosition**

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

# **apiSysPositionLogicdeleteIdPost**
> apiSysPositionLogicdeleteIdPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysPositionLogicdeleteIdPost(
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

# **apiSysPositionOptionsPost**
> RESTfulResultListPagedOptions apiSysPositionOptionsPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysPositionOptionsPost(
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

# **apiSysPositionPagelistPost**
> RESTfulResultPagedListSysPosition apiSysPositionPagelistPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysPosition**

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

# **apiSysPositionPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysPositionPageoptionGet()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysPositionPageoptionGet(
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

# **apiSysPositionToEntityPost**
> RESTfulResultSysPosition apiSysPositionToEntityPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    SysPositionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: SysPositionDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionToEntityPost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **SysPositionDto**|  | |


### Return type

**RESTfulResultSysPosition**

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

# **apiSysPositionToListEntityPost**
> RESTfulResultListSysPosition apiSysPositionToListEntityPost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: Array<SysPositionDto>; // (optional)

const { status, data } = await apiInstance.apiSysPositionToListEntityPost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **Array<SysPositionDto>**|  | |


### Return type

**RESTfulResultListSysPosition**

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

# **apiSysPositionUpdatePost**
> RESTfulResultSysPosition apiSysPositionUpdatePost()


### Example

```typescript
import {
    SysPositionApi,
    Configuration,
    SysPositionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysPositionApi(configuration);

let sysPositionDto: SysPositionDto; // (optional)

const { status, data } = await apiInstance.apiSysPositionUpdatePost(
    sysPositionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysPositionDto** | **SysPositionDto**|  | |


### Return type

**RESTfulResultSysPosition**

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

