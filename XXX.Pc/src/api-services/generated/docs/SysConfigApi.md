# SysConfigApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysConfigAddPost**](#apisysconfigaddpost) | **POST** /api/sys-config/add | 新增|
|[**apiSysConfigAddorupdatePost**](#apisysconfigaddorupdatepost) | **POST** /api/sys-config/addorupdate | 新增|
|[**apiSysConfigBatchaddPost**](#apisysconfigbatchaddpost) | **POST** /api/sys-config/batchadd | 新增|
|[**apiSysConfigBatchdeletePost**](#apisysconfigbatchdeletepost) | **POST** /api/sys-config/batchdelete | 删除|
|[**apiSysConfigBatchlogicdeletePost**](#apisysconfigbatchlogicdeletepost) | **POST** /api/sys-config/batchlogicdelete | 逻辑删除|
|[**apiSysConfigBatchupdatePost**](#apisysconfigbatchupdatepost) | **POST** /api/sys-config/batchupdate | 新增|
|[**apiSysConfigDeleteIdPost**](#apisysconfigdeleteidpost) | **POST** /api/sys-config/delete/{id} | 删除|
|[**apiSysConfigDetailIdGet**](#apisysconfigdetailidget) | **GET** /api/sys-config/detail/{id} | 获取详情|
|[**apiSysConfigDetailoptionGet**](#apisysconfigdetailoptionget) | **GET** /api/sys-config/detailoption | 获取详情|
|[**apiSysConfigListPost**](#apisysconfiglistpost) | **POST** /api/sys-config/list | 获取集合|
|[**apiSysConfigLogicdeleteIdPost**](#apisysconfiglogicdeleteidpost) | **POST** /api/sys-config/logicdelete/{id} | 逻辑删除|
|[**apiSysConfigOptionsPost**](#apisysconfigoptionspost) | **POST** /api/sys-config/options | 获取下拉搜索选项|
|[**apiSysConfigPagelistPost**](#apisysconfigpagelistpost) | **POST** /api/sys-config/pagelist | 获取分页集合|
|[**apiSysConfigPageoptionGet**](#apisysconfigpageoptionget) | **GET** /api/sys-config/pageoption | 获取新增修改页面选项|
|[**apiSysConfigToEntityPost**](#apisysconfigtoentitypost) | **POST** /api/sys-config/to-entity | 模型到实体的转换|
|[**apiSysConfigToListEntityPost**](#apisysconfigtolistentitypost) | **POST** /api/sys-config/to-list-entity | 模型到实体的批量转换|
|[**apiSysConfigUpdatePost**](#apisysconfigupdatepost) | **POST** /api/sys-config/update | 更新|

# **apiSysConfigAddPost**
> RESTfulResultSysConfig apiSysConfigAddPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    SysConfigDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: SysConfigDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigAddPost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **SysConfigDto**|  | |


### Return type

**RESTfulResultSysConfig**

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

# **apiSysConfigAddorupdatePost**
> RESTfulResultSysConfig apiSysConfigAddorupdatePost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    SysConfigDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: SysConfigDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigAddorupdatePost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **SysConfigDto**|  | |


### Return type

**RESTfulResultSysConfig**

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

# **apiSysConfigBatchaddPost**
> RESTfulResultInt32 apiSysConfigBatchaddPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: Array<SysConfigDto>; // (optional)

const { status, data } = await apiInstance.apiSysConfigBatchaddPost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **Array<SysConfigDto>**|  | |


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

# **apiSysConfigBatchdeletePost**
> apiSysConfigBatchdeletePost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysConfigBatchdeletePost(
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

# **apiSysConfigBatchlogicdeletePost**
> apiSysConfigBatchlogicdeletePost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysConfigBatchlogicdeletePost(
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

# **apiSysConfigBatchupdatePost**
> RESTfulResultInt32 apiSysConfigBatchupdatePost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: Array<SysConfigDto>; // (optional)

const { status, data } = await apiInstance.apiSysConfigBatchupdatePost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **Array<SysConfigDto>**|  | |


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

# **apiSysConfigDeleteIdPost**
> apiSysConfigDeleteIdPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysConfigDeleteIdPost(
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

# **apiSysConfigDetailIdGet**
> RESTfulResultSysConfig apiSysConfigDetailIdGet()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysConfigDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysConfig**

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

# **apiSysConfigDetailoptionGet**
> RESTfulResultPageDetailOptionSysConfigDto apiSysConfigDetailoptionGet()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysConfigDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysConfigDto**

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

# **apiSysConfigListPost**
> RESTfulResultListSysConfig apiSysConfigListPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysConfig**

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

# **apiSysConfigLogicdeleteIdPost**
> apiSysConfigLogicdeleteIdPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysConfigLogicdeleteIdPost(
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

# **apiSysConfigOptionsPost**
> RESTfulResultListPagedOptions apiSysConfigOptionsPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysConfigOptionsPost(
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

# **apiSysConfigPagelistPost**
> RESTfulResultPagedListSysConfig apiSysConfigPagelistPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysConfig**

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

# **apiSysConfigPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysConfigPageoptionGet()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysConfigPageoptionGet(
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

# **apiSysConfigToEntityPost**
> RESTfulResultSysConfig apiSysConfigToEntityPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    SysConfigDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: SysConfigDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigToEntityPost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **SysConfigDto**|  | |


### Return type

**RESTfulResultSysConfig**

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

# **apiSysConfigToListEntityPost**
> RESTfulResultListSysConfig apiSysConfigToListEntityPost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: Array<SysConfigDto>; // (optional)

const { status, data } = await apiInstance.apiSysConfigToListEntityPost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **Array<SysConfigDto>**|  | |


### Return type

**RESTfulResultListSysConfig**

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

# **apiSysConfigUpdatePost**
> RESTfulResultSysConfig apiSysConfigUpdatePost()


### Example

```typescript
import {
    SysConfigApi,
    Configuration,
    SysConfigDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysConfigApi(configuration);

let sysConfigDto: SysConfigDto; // (optional)

const { status, data } = await apiInstance.apiSysConfigUpdatePost(
    sysConfigDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysConfigDto** | **SysConfigDto**|  | |


### Return type

**RESTfulResultSysConfig**

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

