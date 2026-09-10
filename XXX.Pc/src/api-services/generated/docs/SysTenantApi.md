# SysTenantApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysTenantAddPost**](#apisystenantaddpost) | **POST** /api/sys-tenant/add | 增加|
|[**apiSysTenantAddorupdatePost**](#apisystenantaddorupdatepost) | **POST** /api/sys-tenant/addorupdate | 新增|
|[**apiSysTenantAlltreePost**](#apisystenantalltreepost) | **POST** /api/sys-tenant/alltree | 获取所有数据树形|
|[**apiSysTenantBatchaddPost**](#apisystenantbatchaddpost) | **POST** /api/sys-tenant/batchadd | 新增|
|[**apiSysTenantBatchdeletePost**](#apisystenantbatchdeletepost) | **POST** /api/sys-tenant/batchdelete | 删除|
|[**apiSysTenantBatchlogicdeletePost**](#apisystenantbatchlogicdeletepost) | **POST** /api/sys-tenant/batchlogicdelete | 逻辑删除|
|[**apiSysTenantBatchupdatePost**](#apisystenantbatchupdatepost) | **POST** /api/sys-tenant/batchupdate | 新增|
|[**apiSysTenantDeleteIdPost**](#apisystenantdeleteidpost) | **POST** /api/sys-tenant/delete/{id} | 删除|
|[**apiSysTenantDetailIdGet**](#apisystenantdetailidget) | **GET** /api/sys-tenant/detail/{id} | 获取详情|
|[**apiSysTenantDetailoptionGet**](#apisystenantdetailoptionget) | **GET** /api/sys-tenant/detailoption | 获取详情|
|[**apiSysTenantHandlePathPost**](#apisystenanthandlepathpost) | **POST** /api/sys-tenant/handle-path | 处理树形层级|
|[**apiSysTenantListPost**](#apisystenantlistpost) | **POST** /api/sys-tenant/list | 获取集合|
|[**apiSysTenantLogicdeleteIdPost**](#apisystenantlogicdeleteidpost) | **POST** /api/sys-tenant/logicdelete/{id} | 逻辑删除|
|[**apiSysTenantOptionsPost**](#apisystenantoptionspost) | **POST** /api/sys-tenant/options | 获取下拉搜索选项|
|[**apiSysTenantPagelistPost**](#apisystenantpagelistpost) | **POST** /api/sys-tenant/pagelist | 获取分页集合|
|[**apiSysTenantPageoptionGet**](#apisystenantpageoptionget) | **GET** /api/sys-tenant/pageoption | 获取新增修改页面选项|
|[**apiSysTenantToEntityPost**](#apisystenanttoentitypost) | **POST** /api/sys-tenant/to-entity | 模型到实体的转换|
|[**apiSysTenantToListEntityPost**](#apisystenanttolistentitypost) | **POST** /api/sys-tenant/to-list-entity | 模型到实体的批量转换|
|[**apiSysTenantToTreeOutputPost**](#apisystenanttotreeoutputpost) | **POST** /api/sys-tenant/to-tree-output | 转换|
|[**apiSysTenantTreechildrenPost**](#apisystenanttreechildrenpost) | **POST** /api/sys-tenant/treechildren | 获取树形子节点|
|[**apiSysTenantTreelistPost**](#apisystenanttreelistpost) | **POST** /api/sys-tenant/treelist | 获取树形页面数据 带筛选|
|[**apiSysTenantTreeoptionsPost**](#apisystenanttreeoptionspost) | **POST** /api/sys-tenant/treeoptions | 获取树形下拉搜索选项|
|[**apiSysTenantUpdatePost**](#apisystenantupdatepost) | **POST** /api/sys-tenant/update | 更新|

# **apiSysTenantAddPost**
> RESTfulResultSysTenant apiSysTenantAddPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenantDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: SysTenantDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantAddPost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **SysTenantDto**|  | |


### Return type

**RESTfulResultSysTenant**

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

# **apiSysTenantAddorupdatePost**
> RESTfulResultSysTenant apiSysTenantAddorupdatePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenantDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: SysTenantDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantAddorupdatePost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **SysTenantDto**|  | |


### Return type

**RESTfulResultSysTenant**

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

# **apiSysTenantAlltreePost**
> RESTfulResultListPagedTreeOptions apiSysTenantAlltreePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

const { status, data } = await apiInstance.apiSysTenantAlltreePost();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListPagedTreeOptions**

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

# **apiSysTenantBatchaddPost**
> RESTfulResultInt32 apiSysTenantBatchaddPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: Array<SysTenantDto>; // (optional)

const { status, data } = await apiInstance.apiSysTenantBatchaddPost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **Array<SysTenantDto>**|  | |


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

# **apiSysTenantBatchdeletePost**
> apiSysTenantBatchdeletePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysTenantBatchdeletePost(
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

# **apiSysTenantBatchlogicdeletePost**
> apiSysTenantBatchlogicdeletePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysTenantBatchlogicdeletePost(
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

# **apiSysTenantBatchupdatePost**
> RESTfulResultInt32 apiSysTenantBatchupdatePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: Array<SysTenantDto>; // (optional)

const { status, data } = await apiInstance.apiSysTenantBatchupdatePost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **Array<SysTenantDto>**|  | |


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

# **apiSysTenantDeleteIdPost**
> apiSysTenantDeleteIdPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysTenantDeleteIdPost(
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

# **apiSysTenantDetailIdGet**
> RESTfulResultSysTenant apiSysTenantDetailIdGet()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysTenantDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysTenant**

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

# **apiSysTenantDetailoptionGet**
> RESTfulResultPageDetailOptionSysTenantDto apiSysTenantDetailoptionGet()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysTenantDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysTenantDto**

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

# **apiSysTenantHandlePathPost**
> RESTfulResultSysTenant apiSysTenantHandlePathPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenant
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenant: SysTenant; // (optional)

const { status, data } = await apiInstance.apiSysTenantHandlePathPost(
    sysTenant
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenant** | **SysTenant**|  | |


### Return type

**RESTfulResultSysTenant**

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

# **apiSysTenantListPost**
> RESTfulResultListSysTenant apiSysTenantListPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysTenant**

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

# **apiSysTenantLogicdeleteIdPost**
> apiSysTenantLogicdeleteIdPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysTenantLogicdeleteIdPost(
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

# **apiSysTenantOptionsPost**
> RESTfulResultListPagedOptions apiSysTenantOptionsPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysTenantOptionsPost(
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

# **apiSysTenantPagelistPost**
> RESTfulResultPagedListSysTenant apiSysTenantPagelistPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysTenant**

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

# **apiSysTenantPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysTenantPageoptionGet()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysTenantPageoptionGet(
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

# **apiSysTenantToEntityPost**
> RESTfulResultSysTenant apiSysTenantToEntityPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenantDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: SysTenantDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantToEntityPost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **SysTenantDto**|  | |


### Return type

**RESTfulResultSysTenant**

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

# **apiSysTenantToListEntityPost**
> RESTfulResultListSysTenant apiSysTenantToListEntityPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: Array<SysTenantDto>; // (optional)

const { status, data } = await apiInstance.apiSysTenantToListEntityPost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **Array<SysTenantDto>**|  | |


### Return type

**RESTfulResultListSysTenant**

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

# **apiSysTenantToTreeOutputPost**
> RESTfulResultSysTenantTreeOutput apiSysTenantToTreeOutputPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenant
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenant: SysTenant; // (optional)

const { status, data } = await apiInstance.apiSysTenantToTreeOutputPost(
    sysTenant
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenant** | **SysTenant**|  | |


### Return type

**RESTfulResultSysTenantTreeOutput**

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

# **apiSysTenantTreechildrenPost**
> RESTfulResultListSysTenant apiSysTenantTreechildrenPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    TreeChildrenDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let treeChildrenDto: TreeChildrenDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantTreechildrenPost(
    treeChildrenDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **treeChildrenDto** | **TreeChildrenDto**|  | |


### Return type

**RESTfulResultListSysTenant**

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

# **apiSysTenantTreelistPost**
> RESTfulResultListSysTenantTreeOutput apiSysTenantTreelistPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantTreelistPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysTenantTreeOutput**

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

# **apiSysTenantTreeoptionsPost**
> RESTfulResultListPagedTreeOptions apiSysTenantTreeoptionsPost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysTenantTreeoptionsPost(
    pagedCustomWhere
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedCustomWhere** | **Array<PagedCustomWhere>**|  | |


### Return type

**RESTfulResultListPagedTreeOptions**

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

# **apiSysTenantUpdatePost**
> RESTfulResultSysTenant apiSysTenantUpdatePost()


### Example

```typescript
import {
    SysTenantApi,
    Configuration,
    SysTenantDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysTenantApi(configuration);

let sysTenantDto: SysTenantDto; // (optional)

const { status, data } = await apiInstance.apiSysTenantUpdatePost(
    sysTenantDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysTenantDto** | **SysTenantDto**|  | |


### Return type

**RESTfulResultSysTenant**

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

