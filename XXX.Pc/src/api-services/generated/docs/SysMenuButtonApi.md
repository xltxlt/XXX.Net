# SysMenuButtonApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysMenuButtonAddPost**](#apisysmenubuttonaddpost) | **POST** /api/sys-menu-button/add | 新增|
|[**apiSysMenuButtonAddorupdatePost**](#apisysmenubuttonaddorupdatepost) | **POST** /api/sys-menu-button/addorupdate | 新增|
|[**apiSysMenuButtonBatchaddPost**](#apisysmenubuttonbatchaddpost) | **POST** /api/sys-menu-button/batchadd | 新增|
|[**apiSysMenuButtonBatchdeletePost**](#apisysmenubuttonbatchdeletepost) | **POST** /api/sys-menu-button/batchdelete | 删除|
|[**apiSysMenuButtonBatchlogicdeletePost**](#apisysmenubuttonbatchlogicdeletepost) | **POST** /api/sys-menu-button/batchlogicdelete | 逻辑删除|
|[**apiSysMenuButtonBatchupdatePost**](#apisysmenubuttonbatchupdatepost) | **POST** /api/sys-menu-button/batchupdate | 新增|
|[**apiSysMenuButtonDeleteIdPost**](#apisysmenubuttondeleteidpost) | **POST** /api/sys-menu-button/delete/{id} | 删除|
|[**apiSysMenuButtonDetailIdGet**](#apisysmenubuttondetailidget) | **GET** /api/sys-menu-button/detail/{id} | 获取详情|
|[**apiSysMenuButtonDetailoptionGet**](#apisysmenubuttondetailoptionget) | **GET** /api/sys-menu-button/detailoption | 获取详情|
|[**apiSysMenuButtonListPost**](#apisysmenubuttonlistpost) | **POST** /api/sys-menu-button/list | 获取集合|
|[**apiSysMenuButtonLogicdeleteIdPost**](#apisysmenubuttonlogicdeleteidpost) | **POST** /api/sys-menu-button/logicdelete/{id} | 逻辑删除|
|[**apiSysMenuButtonOptionsPost**](#apisysmenubuttonoptionspost) | **POST** /api/sys-menu-button/options | 获取下拉搜索选项|
|[**apiSysMenuButtonPagelistPost**](#apisysmenubuttonpagelistpost) | **POST** /api/sys-menu-button/pagelist | 获取分页集合|
|[**apiSysMenuButtonPageoptionGet**](#apisysmenubuttonpageoptionget) | **GET** /api/sys-menu-button/pageoption | 获取新增修改页面选项|
|[**apiSysMenuButtonToEntityPost**](#apisysmenubuttontoentitypost) | **POST** /api/sys-menu-button/to-entity | 模型到实体的转换|
|[**apiSysMenuButtonToListEntityPost**](#apisysmenubuttontolistentitypost) | **POST** /api/sys-menu-button/to-list-entity | 模型到实体的批量转换|
|[**apiSysMenuButtonUpdatePost**](#apisysmenubuttonupdatepost) | **POST** /api/sys-menu-button/update | 更新|

# **apiSysMenuButtonAddPost**
> RESTfulResultSysMenuButton apiSysMenuButtonAddPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    SysMenuButtonDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: SysMenuButtonDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonAddPost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **SysMenuButtonDto**|  | |


### Return type

**RESTfulResultSysMenuButton**

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

# **apiSysMenuButtonAddorupdatePost**
> RESTfulResultSysMenuButton apiSysMenuButtonAddorupdatePost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    SysMenuButtonDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: SysMenuButtonDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonAddorupdatePost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **SysMenuButtonDto**|  | |


### Return type

**RESTfulResultSysMenuButton**

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

# **apiSysMenuButtonBatchaddPost**
> RESTfulResultInt32 apiSysMenuButtonBatchaddPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: Array<SysMenuButtonDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonBatchaddPost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **Array<SysMenuButtonDto>**|  | |


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

# **apiSysMenuButtonBatchdeletePost**
> apiSysMenuButtonBatchdeletePost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonBatchdeletePost(
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

# **apiSysMenuButtonBatchlogicdeletePost**
> apiSysMenuButtonBatchlogicdeletePost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonBatchlogicdeletePost(
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

# **apiSysMenuButtonBatchupdatePost**
> RESTfulResultInt32 apiSysMenuButtonBatchupdatePost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: Array<SysMenuButtonDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonBatchupdatePost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **Array<SysMenuButtonDto>**|  | |


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

# **apiSysMenuButtonDeleteIdPost**
> apiSysMenuButtonDeleteIdPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuButtonDeleteIdPost(
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

# **apiSysMenuButtonDetailIdGet**
> RESTfulResultSysMenuButton apiSysMenuButtonDetailIdGet()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuButtonDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysMenuButton**

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

# **apiSysMenuButtonDetailoptionGet**
> RESTfulResultPageDetailOptionSysMenuButtonDto apiSysMenuButtonDetailoptionGet()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuButtonDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysMenuButtonDto**

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

# **apiSysMenuButtonListPost**
> RESTfulResultListSysMenuButton apiSysMenuButtonListPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysMenuButton**

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

# **apiSysMenuButtonLogicdeleteIdPost**
> apiSysMenuButtonLogicdeleteIdPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuButtonLogicdeleteIdPost(
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

# **apiSysMenuButtonOptionsPost**
> RESTfulResultListPagedOptions apiSysMenuButtonOptionsPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonOptionsPost(
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

# **apiSysMenuButtonPagelistPost**
> RESTfulResultPagedListSysMenuButton apiSysMenuButtonPagelistPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysMenuButton**

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

# **apiSysMenuButtonPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysMenuButtonPageoptionGet()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuButtonPageoptionGet(
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

# **apiSysMenuButtonToEntityPost**
> RESTfulResultSysMenuButton apiSysMenuButtonToEntityPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    SysMenuButtonDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: SysMenuButtonDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonToEntityPost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **SysMenuButtonDto**|  | |


### Return type

**RESTfulResultSysMenuButton**

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

# **apiSysMenuButtonToListEntityPost**
> RESTfulResultListSysMenuButton apiSysMenuButtonToListEntityPost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: Array<SysMenuButtonDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonToListEntityPost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **Array<SysMenuButtonDto>**|  | |


### Return type

**RESTfulResultListSysMenuButton**

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

# **apiSysMenuButtonUpdatePost**
> RESTfulResultSysMenuButton apiSysMenuButtonUpdatePost()


### Example

```typescript
import {
    SysMenuButtonApi,
    Configuration,
    SysMenuButtonDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuButtonApi(configuration);

let sysMenuButtonDto: SysMenuButtonDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuButtonUpdatePost(
    sysMenuButtonDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuButtonDto** | **SysMenuButtonDto**|  | |


### Return type

**RESTfulResultSysMenuButton**

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

