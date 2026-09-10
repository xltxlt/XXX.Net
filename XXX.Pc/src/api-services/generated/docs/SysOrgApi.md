# SysOrgApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysOrgAddPost**](#apisysorgaddpost) | **POST** /api/sys-org/add | 增加|
|[**apiSysOrgAddorupdatePost**](#apisysorgaddorupdatepost) | **POST** /api/sys-org/addorupdate | 新增|
|[**apiSysOrgAlltreePost**](#apisysorgalltreepost) | **POST** /api/sys-org/alltree | 获取所有数据树形|
|[**apiSysOrgBatchaddPost**](#apisysorgbatchaddpost) | **POST** /api/sys-org/batchadd | 新增|
|[**apiSysOrgBatchdeletePost**](#apisysorgbatchdeletepost) | **POST** /api/sys-org/batchdelete | 删除|
|[**apiSysOrgBatchlogicdeletePost**](#apisysorgbatchlogicdeletepost) | **POST** /api/sys-org/batchlogicdelete | 逻辑删除|
|[**apiSysOrgBatchupdatePost**](#apisysorgbatchupdatepost) | **POST** /api/sys-org/batchupdate | 新增|
|[**apiSysOrgDeleteIdPost**](#apisysorgdeleteidpost) | **POST** /api/sys-org/delete/{id} | 删除|
|[**apiSysOrgDetailIdGet**](#apisysorgdetailidget) | **GET** /api/sys-org/detail/{id} | 获取详情|
|[**apiSysOrgDetailoptionGet**](#apisysorgdetailoptionget) | **GET** /api/sys-org/detailoption | 获取详情|
|[**apiSysOrgListPost**](#apisysorglistpost) | **POST** /api/sys-org/list | 获取集合|
|[**apiSysOrgLogicdeleteIdPost**](#apisysorglogicdeleteidpost) | **POST** /api/sys-org/logicdelete/{id} | 逻辑删除|
|[**apiSysOrgOptionsPost**](#apisysorgoptionspost) | **POST** /api/sys-org/options | 获取下拉搜索选项|
|[**apiSysOrgPagelistPost**](#apisysorgpagelistpost) | **POST** /api/sys-org/pagelist | 获取分页集合|
|[**apiSysOrgPageoptionGet**](#apisysorgpageoptionget) | **GET** /api/sys-org/pageoption | 获取新增修改页面选项|
|[**apiSysOrgToTreeOutputPost**](#apisysorgtotreeoutputpost) | **POST** /api/sys-org/to-tree-output | 转换|
|[**apiSysOrgTreechildrenPost**](#apisysorgtreechildrenpost) | **POST** /api/sys-org/treechildren | 获取树形子节点|
|[**apiSysOrgTreelistPost**](#apisysorgtreelistpost) | **POST** /api/sys-org/treelist | 获取树形页面数据 带筛选|
|[**apiSysOrgTreeoptionsPost**](#apisysorgtreeoptionspost) | **POST** /api/sys-org/treeoptions | 获取树形下拉搜索选项|
|[**apiSysOrgUpdatePost**](#apisysorgupdatepost) | **POST** /api/sys-org/update | 更新|

# **apiSysOrgAddPost**
> RESTfulResultSysOrganization apiSysOrgAddPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    SysOrgDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrgDto: SysOrgDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgAddPost(
    sysOrgDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrgDto** | **SysOrgDto**|  | |


### Return type

**RESTfulResultSysOrganization**

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

# **apiSysOrgAddorupdatePost**
> RESTfulResultSysOrganization apiSysOrgAddorupdatePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    SysOrgDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrgDto: SysOrgDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgAddorupdatePost(
    sysOrgDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrgDto** | **SysOrgDto**|  | |


### Return type

**RESTfulResultSysOrganization**

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

# **apiSysOrgAlltreePost**
> RESTfulResultListPagedTreeOptions apiSysOrgAlltreePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

const { status, data } = await apiInstance.apiSysOrgAlltreePost();
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

# **apiSysOrgBatchaddPost**
> RESTfulResultInt32 apiSysOrgBatchaddPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrgDto: Array<SysOrgDto>; // (optional)

const { status, data } = await apiInstance.apiSysOrgBatchaddPost(
    sysOrgDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrgDto** | **Array<SysOrgDto>**|  | |


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

# **apiSysOrgBatchdeletePost**
> apiSysOrgBatchdeletePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysOrgBatchdeletePost(
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

# **apiSysOrgBatchlogicdeletePost**
> apiSysOrgBatchlogicdeletePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysOrgBatchlogicdeletePost(
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

# **apiSysOrgBatchupdatePost**
> RESTfulResultInt32 apiSysOrgBatchupdatePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrgDto: Array<SysOrgDto>; // (optional)

const { status, data } = await apiInstance.apiSysOrgBatchupdatePost(
    sysOrgDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrgDto** | **Array<SysOrgDto>**|  | |


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

# **apiSysOrgDeleteIdPost**
> apiSysOrgDeleteIdPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysOrgDeleteIdPost(
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

# **apiSysOrgDetailIdGet**
> RESTfulResultSysOrganization apiSysOrgDetailIdGet()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysOrgDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysOrganization**

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

# **apiSysOrgDetailoptionGet**
> RESTfulResultPageDetailOptionSysOrgDto apiSysOrgDetailoptionGet()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysOrgDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysOrgDto**

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

# **apiSysOrgListPost**
> RESTfulResultListSysOrganization apiSysOrgListPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysOrganization**

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

# **apiSysOrgLogicdeleteIdPost**
> apiSysOrgLogicdeleteIdPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysOrgLogicdeleteIdPost(
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

# **apiSysOrgOptionsPost**
> RESTfulResultListPagedOptions apiSysOrgOptionsPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysOrgOptionsPost(
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

# **apiSysOrgPagelistPost**
> RESTfulResultPagedListSysOrganization apiSysOrgPagelistPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysOrganization**

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

# **apiSysOrgPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysOrgPageoptionGet()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

const { status, data } = await apiInstance.apiSysOrgPageoptionGet();
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

# **apiSysOrgToTreeOutputPost**
> RESTfulResultSysOrgTreeOutput apiSysOrgToTreeOutputPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    SysOrganization
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrganization: SysOrganization; // (optional)

const { status, data } = await apiInstance.apiSysOrgToTreeOutputPost(
    sysOrganization
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrganization** | **SysOrganization**|  | |


### Return type

**RESTfulResultSysOrgTreeOutput**

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

# **apiSysOrgTreechildrenPost**
> RESTfulResultListSysOrganization apiSysOrgTreechildrenPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    TreeChildrenDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let treeChildrenDto: TreeChildrenDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgTreechildrenPost(
    treeChildrenDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **treeChildrenDto** | **TreeChildrenDto**|  | |


### Return type

**RESTfulResultListSysOrganization**

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

# **apiSysOrgTreelistPost**
> RESTfulResultListSysOrgTreeOutput apiSysOrgTreelistPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgTreelistPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysOrgTreeOutput**

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

# **apiSysOrgTreeoptionsPost**
> RESTfulResultListPagedTreeOptions apiSysOrgTreeoptionsPost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysOrgTreeoptionsPost(
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

# **apiSysOrgUpdatePost**
> RESTfulResultSysOrganization apiSysOrgUpdatePost()


### Example

```typescript
import {
    SysOrgApi,
    Configuration,
    SysOrgDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOrgApi(configuration);

let sysOrgDto: SysOrgDto; // (optional)

const { status, data } = await apiInstance.apiSysOrgUpdatePost(
    sysOrgDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysOrgDto** | **SysOrgDto**|  | |


### Return type

**RESTfulResultSysOrganization**

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

