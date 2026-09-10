# SysDepApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysDepAddPost**](#apisysdepaddpost) | **POST** /api/sys-dep/add | 增加|
|[**apiSysDepAddorupdatePost**](#apisysdepaddorupdatepost) | **POST** /api/sys-dep/addorupdate | 新增|
|[**apiSysDepAlltreePost**](#apisysdepalltreepost) | **POST** /api/sys-dep/alltree | 获取所有数据树形|
|[**apiSysDepBatchaddPost**](#apisysdepbatchaddpost) | **POST** /api/sys-dep/batchadd | 新增|
|[**apiSysDepBatchdeletePost**](#apisysdepbatchdeletepost) | **POST** /api/sys-dep/batchdelete | 删除|
|[**apiSysDepBatchlogicdeletePost**](#apisysdepbatchlogicdeletepost) | **POST** /api/sys-dep/batchlogicdelete | 逻辑删除|
|[**apiSysDepBatchupdatePost**](#apisysdepbatchupdatepost) | **POST** /api/sys-dep/batchupdate | 新增|
|[**apiSysDepDeleteIdPost**](#apisysdepdeleteidpost) | **POST** /api/sys-dep/delete/{id} | 删除|
|[**apiSysDepDetailIdGet**](#apisysdepdetailidget) | **GET** /api/sys-dep/detail/{id} | 获取详情|
|[**apiSysDepDetailoptionGet**](#apisysdepdetailoptionget) | **GET** /api/sys-dep/detailoption | 获取详情|
|[**apiSysDepHandlePathPost**](#apisysdephandlepathpost) | **POST** /api/sys-dep/handle-path | 处理树形层级|
|[**apiSysDepListPost**](#apisysdeplistpost) | **POST** /api/sys-dep/list | 获取集合|
|[**apiSysDepLogicdeleteIdPost**](#apisysdeplogicdeleteidpost) | **POST** /api/sys-dep/logicdelete/{id} | 逻辑删除|
|[**apiSysDepOptionsPost**](#apisysdepoptionspost) | **POST** /api/sys-dep/options | 获取下拉搜索选项|
|[**apiSysDepPagelistPost**](#apisysdeppagelistpost) | **POST** /api/sys-dep/pagelist | 获取分页集合|
|[**apiSysDepPageoptionGet**](#apisysdeppageoptionget) | **GET** /api/sys-dep/pageoption | 获取新增修改页面选项|
|[**apiSysDepToEntityPost**](#apisysdeptoentitypost) | **POST** /api/sys-dep/to-entity | 模型到实体的转换|
|[**apiSysDepToListEntityPost**](#apisysdeptolistentitypost) | **POST** /api/sys-dep/to-list-entity | 模型到实体的批量转换|
|[**apiSysDepToTreeOutputPost**](#apisysdeptotreeoutputpost) | **POST** /api/sys-dep/to-tree-output | 转换|
|[**apiSysDepTreechildrenPost**](#apisysdeptreechildrenpost) | **POST** /api/sys-dep/treechildren | 获取树形子节点|
|[**apiSysDepTreelistPost**](#apisysdeptreelistpost) | **POST** /api/sys-dep/treelist | 获取树形页面数据 带筛选|
|[**apiSysDepTreeoptionsPost**](#apisysdeptreeoptionspost) | **POST** /api/sys-dep/treeoptions | 获取树形下拉搜索选项|
|[**apiSysDepUpdatePost**](#apisysdepupdatepost) | **POST** /api/sys-dep/update | 更新|

# **apiSysDepAddPost**
> RESTfulResultSysDepartment apiSysDepAddPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: SysDepDto; // (optional)

const { status, data } = await apiInstance.apiSysDepAddPost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **SysDepDto**|  | |


### Return type

**RESTfulResultSysDepartment**

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

# **apiSysDepAddorupdatePost**
> RESTfulResultSysDepartment apiSysDepAddorupdatePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: SysDepDto; // (optional)

const { status, data } = await apiInstance.apiSysDepAddorupdatePost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **SysDepDto**|  | |


### Return type

**RESTfulResultSysDepartment**

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

# **apiSysDepAlltreePost**
> RESTfulResultListPagedTreeOptions apiSysDepAlltreePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

const { status, data } = await apiInstance.apiSysDepAlltreePost();
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

# **apiSysDepBatchaddPost**
> RESTfulResultInt32 apiSysDepBatchaddPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: Array<SysDepDto>; // (optional)

const { status, data } = await apiInstance.apiSysDepBatchaddPost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **Array<SysDepDto>**|  | |


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

# **apiSysDepBatchdeletePost**
> apiSysDepBatchdeletePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysDepBatchdeletePost(
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

# **apiSysDepBatchlogicdeletePost**
> apiSysDepBatchlogicdeletePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysDepBatchlogicdeletePost(
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

# **apiSysDepBatchupdatePost**
> RESTfulResultInt32 apiSysDepBatchupdatePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: Array<SysDepDto>; // (optional)

const { status, data } = await apiInstance.apiSysDepBatchupdatePost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **Array<SysDepDto>**|  | |


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

# **apiSysDepDeleteIdPost**
> apiSysDepDeleteIdPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDepDeleteIdPost(
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

# **apiSysDepDetailIdGet**
> RESTfulResultSysDepartment apiSysDepDetailIdGet()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDepDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysDepartment**

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

# **apiSysDepDetailoptionGet**
> RESTfulResultPageDetailOptionSysDepDto apiSysDepDetailoptionGet()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysDepDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysDepDto**

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

# **apiSysDepHandlePathPost**
> RESTfulResultSysDepartment apiSysDepHandlePathPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepartment
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepartment: SysDepartment; // (optional)

const { status, data } = await apiInstance.apiSysDepHandlePathPost(
    sysDepartment
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepartment** | **SysDepartment**|  | |


### Return type

**RESTfulResultSysDepartment**

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

# **apiSysDepListPost**
> RESTfulResultListSysDepartment apiSysDepListPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysDepListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysDepartment**

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

# **apiSysDepLogicdeleteIdPost**
> apiSysDepLogicdeleteIdPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysDepLogicdeleteIdPost(
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

# **apiSysDepOptionsPost**
> RESTfulResultListPagedOptions apiSysDepOptionsPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysDepOptionsPost(
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

# **apiSysDepPagelistPost**
> RESTfulResultPagedListSysDepartment apiSysDepPagelistPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysDepPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysDepartment**

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

# **apiSysDepPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysDepPageoptionGet()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysDepPageoptionGet(
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

# **apiSysDepToEntityPost**
> RESTfulResultSysDepartment apiSysDepToEntityPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: SysDepDto; // (optional)

const { status, data } = await apiInstance.apiSysDepToEntityPost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **SysDepDto**|  | |


### Return type

**RESTfulResultSysDepartment**

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

# **apiSysDepToListEntityPost**
> RESTfulResultListSysDepartment apiSysDepToListEntityPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: Array<SysDepDto>; // (optional)

const { status, data } = await apiInstance.apiSysDepToListEntityPost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **Array<SysDepDto>**|  | |


### Return type

**RESTfulResultListSysDepartment**

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

# **apiSysDepToTreeOutputPost**
> RESTfulResultSysDepTreeOutput apiSysDepToTreeOutputPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepartment
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepartment: SysDepartment; // (optional)

const { status, data } = await apiInstance.apiSysDepToTreeOutputPost(
    sysDepartment
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepartment** | **SysDepartment**|  | |


### Return type

**RESTfulResultSysDepTreeOutput**

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

# **apiSysDepTreechildrenPost**
> RESTfulResultListSysDepartment apiSysDepTreechildrenPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    TreeChildrenDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let treeChildrenDto: TreeChildrenDto; // (optional)

const { status, data } = await apiInstance.apiSysDepTreechildrenPost(
    treeChildrenDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **treeChildrenDto** | **TreeChildrenDto**|  | |


### Return type

**RESTfulResultListSysDepartment**

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

# **apiSysDepTreelistPost**
> RESTfulResultListSysDepTreeOutput apiSysDepTreelistPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysDepTreelistPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysDepTreeOutput**

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

# **apiSysDepTreeoptionsPost**
> RESTfulResultListPagedTreeOptions apiSysDepTreeoptionsPost()


### Example

```typescript
import {
    SysDepApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysDepTreeoptionsPost(
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

# **apiSysDepUpdatePost**
> RESTfulResultSysDepartment apiSysDepUpdatePost()


### Example

```typescript
import {
    SysDepApi,
    Configuration,
    SysDepDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysDepApi(configuration);

let sysDepDto: SysDepDto; // (optional)

const { status, data } = await apiInstance.apiSysDepUpdatePost(
    sysDepDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysDepDto** | **SysDepDto**|  | |


### Return type

**RESTfulResultSysDepartment**

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

