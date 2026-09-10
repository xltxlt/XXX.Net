# SysMenuFieldApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysMenuFieldAddPost**](#apisysmenufieldaddpost) | **POST** /api/sys-menu-field/add | 新增|
|[**apiSysMenuFieldAddorupdatePost**](#apisysmenufieldaddorupdatepost) | **POST** /api/sys-menu-field/addorupdate | 新增|
|[**apiSysMenuFieldBatchaddPost**](#apisysmenufieldbatchaddpost) | **POST** /api/sys-menu-field/batchadd | 新增|
|[**apiSysMenuFieldBatchdeletePost**](#apisysmenufieldbatchdeletepost) | **POST** /api/sys-menu-field/batchdelete | 删除|
|[**apiSysMenuFieldBatchlogicdeletePost**](#apisysmenufieldbatchlogicdeletepost) | **POST** /api/sys-menu-field/batchlogicdelete | 逻辑删除|
|[**apiSysMenuFieldBatchupdatePost**](#apisysmenufieldbatchupdatepost) | **POST** /api/sys-menu-field/batchupdate | 新增|
|[**apiSysMenuFieldDeleteIdPost**](#apisysmenufielddeleteidpost) | **POST** /api/sys-menu-field/delete/{id} | 删除|
|[**apiSysMenuFieldDetailIdGet**](#apisysmenufielddetailidget) | **GET** /api/sys-menu-field/detail/{id} | 获取详情|
|[**apiSysMenuFieldDetailoptionGet**](#apisysmenufielddetailoptionget) | **GET** /api/sys-menu-field/detailoption | 获取详情|
|[**apiSysMenuFieldListPost**](#apisysmenufieldlistpost) | **POST** /api/sys-menu-field/list | 获取集合|
|[**apiSysMenuFieldLogicdeleteIdPost**](#apisysmenufieldlogicdeleteidpost) | **POST** /api/sys-menu-field/logicdelete/{id} | 逻辑删除|
|[**apiSysMenuFieldOptionsPost**](#apisysmenufieldoptionspost) | **POST** /api/sys-menu-field/options | 获取下拉搜索选项|
|[**apiSysMenuFieldPagelistPost**](#apisysmenufieldpagelistpost) | **POST** /api/sys-menu-field/pagelist | 获取分页集合|
|[**apiSysMenuFieldPageoptionGet**](#apisysmenufieldpageoptionget) | **GET** /api/sys-menu-field/pageoption | 获取新增修改页面选项|
|[**apiSysMenuFieldToEntityPost**](#apisysmenufieldtoentitypost) | **POST** /api/sys-menu-field/to-entity | 模型到实体的转换|
|[**apiSysMenuFieldToListEntityPost**](#apisysmenufieldtolistentitypost) | **POST** /api/sys-menu-field/to-list-entity | 模型到实体的批量转换|
|[**apiSysMenuFieldUpdatePost**](#apisysmenufieldupdatepost) | **POST** /api/sys-menu-field/update | 更新|

# **apiSysMenuFieldAddPost**
> RESTfulResultSysMenuField apiSysMenuFieldAddPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    SysMenuFieldDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: SysMenuFieldDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldAddPost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **SysMenuFieldDto**|  | |


### Return type

**RESTfulResultSysMenuField**

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

# **apiSysMenuFieldAddorupdatePost**
> RESTfulResultSysMenuField apiSysMenuFieldAddorupdatePost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    SysMenuFieldDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: SysMenuFieldDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldAddorupdatePost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **SysMenuFieldDto**|  | |


### Return type

**RESTfulResultSysMenuField**

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

# **apiSysMenuFieldBatchaddPost**
> RESTfulResultInt32 apiSysMenuFieldBatchaddPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: Array<SysMenuFieldDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldBatchaddPost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **Array<SysMenuFieldDto>**|  | |


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

# **apiSysMenuFieldBatchdeletePost**
> apiSysMenuFieldBatchdeletePost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldBatchdeletePost(
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

# **apiSysMenuFieldBatchlogicdeletePost**
> apiSysMenuFieldBatchlogicdeletePost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldBatchlogicdeletePost(
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

# **apiSysMenuFieldBatchupdatePost**
> RESTfulResultInt32 apiSysMenuFieldBatchupdatePost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: Array<SysMenuFieldDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldBatchupdatePost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **Array<SysMenuFieldDto>**|  | |


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

# **apiSysMenuFieldDeleteIdPost**
> apiSysMenuFieldDeleteIdPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuFieldDeleteIdPost(
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

# **apiSysMenuFieldDetailIdGet**
> RESTfulResultSysMenuField apiSysMenuFieldDetailIdGet()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuFieldDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysMenuField**

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

# **apiSysMenuFieldDetailoptionGet**
> RESTfulResultPageDetailOptionSysMenuFieldDto apiSysMenuFieldDetailoptionGet()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuFieldDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysMenuFieldDto**

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

# **apiSysMenuFieldListPost**
> RESTfulResultListSysMenuField apiSysMenuFieldListPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysMenuField**

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

# **apiSysMenuFieldLogicdeleteIdPost**
> apiSysMenuFieldLogicdeleteIdPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuFieldLogicdeleteIdPost(
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

# **apiSysMenuFieldOptionsPost**
> RESTfulResultListPagedOptions apiSysMenuFieldOptionsPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldOptionsPost(
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

# **apiSysMenuFieldPagelistPost**
> RESTfulResultPagedListSysMenuField apiSysMenuFieldPagelistPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysMenuField**

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

# **apiSysMenuFieldPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysMenuFieldPageoptionGet()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuFieldPageoptionGet(
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

# **apiSysMenuFieldToEntityPost**
> RESTfulResultSysMenuField apiSysMenuFieldToEntityPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    SysMenuFieldDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: SysMenuFieldDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldToEntityPost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **SysMenuFieldDto**|  | |


### Return type

**RESTfulResultSysMenuField**

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

# **apiSysMenuFieldToListEntityPost**
> RESTfulResultListSysMenuField apiSysMenuFieldToListEntityPost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: Array<SysMenuFieldDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldToListEntityPost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **Array<SysMenuFieldDto>**|  | |


### Return type

**RESTfulResultListSysMenuField**

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

# **apiSysMenuFieldUpdatePost**
> RESTfulResultSysMenuField apiSysMenuFieldUpdatePost()


### Example

```typescript
import {
    SysMenuFieldApi,
    Configuration,
    SysMenuFieldDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuFieldApi(configuration);

let sysMenuFieldDto: SysMenuFieldDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuFieldUpdatePost(
    sysMenuFieldDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuFieldDto** | **SysMenuFieldDto**|  | |


### Return type

**RESTfulResultSysMenuField**

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

