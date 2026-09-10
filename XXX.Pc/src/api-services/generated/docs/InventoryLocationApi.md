# InventoryLocationApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryLocationAddPost**](#apiinventorylocationaddpost) | **POST** /api/inventory-location/add | 增加|
|[**apiInventoryLocationAddorupdatePost**](#apiinventorylocationaddorupdatepost) | **POST** /api/inventory-location/addorupdate | 新增|
|[**apiInventoryLocationAlltreePost**](#apiinventorylocationalltreepost) | **POST** /api/inventory-location/alltree | 获取所有数据树形|
|[**apiInventoryLocationBatchaddPost**](#apiinventorylocationbatchaddpost) | **POST** /api/inventory-location/batchadd | 新增|
|[**apiInventoryLocationBatchdeletePost**](#apiinventorylocationbatchdeletepost) | **POST** /api/inventory-location/batchdelete | 删除|
|[**apiInventoryLocationBatchlogicdeletePost**](#apiinventorylocationbatchlogicdeletepost) | **POST** /api/inventory-location/batchlogicdelete | 逻辑删除|
|[**apiInventoryLocationBatchupdatePost**](#apiinventorylocationbatchupdatepost) | **POST** /api/inventory-location/batchupdate | 新增|
|[**apiInventoryLocationDeleteIdPost**](#apiinventorylocationdeleteidpost) | **POST** /api/inventory-location/delete/{id} | 删除|
|[**apiInventoryLocationDetailIdGet**](#apiinventorylocationdetailidget) | **GET** /api/inventory-location/detail/{id} | 获取详情|
|[**apiInventoryLocationDetailoptionGet**](#apiinventorylocationdetailoptionget) | **GET** /api/inventory-location/detailoption | 获取详情|
|[**apiInventoryLocationHandlePathPost**](#apiinventorylocationhandlepathpost) | **POST** /api/inventory-location/handle-path | 处理树形层级|
|[**apiInventoryLocationListPost**](#apiinventorylocationlistpost) | **POST** /api/inventory-location/list | 获取集合|
|[**apiInventoryLocationLogicdeleteIdPost**](#apiinventorylocationlogicdeleteidpost) | **POST** /api/inventory-location/logicdelete/{id} | 逻辑删除|
|[**apiInventoryLocationOptionsPost**](#apiinventorylocationoptionspost) | **POST** /api/inventory-location/options | 获取下拉搜索选项|
|[**apiInventoryLocationPagelistPost**](#apiinventorylocationpagelistpost) | **POST** /api/inventory-location/pagelist | 获取分页集合|
|[**apiInventoryLocationPageoptionGet**](#apiinventorylocationpageoptionget) | **GET** /api/inventory-location/pageoption | 获取新增修改页面选项|
|[**apiInventoryLocationToEntityPost**](#apiinventorylocationtoentitypost) | **POST** /api/inventory-location/to-entity | |
|[**apiInventoryLocationToListEntityPost**](#apiinventorylocationtolistentitypost) | **POST** /api/inventory-location/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryLocationToTreeOutputPost**](#apiinventorylocationtotreeoutputpost) | **POST** /api/inventory-location/to-tree-output | 转换|
|[**apiInventoryLocationTreechildrenPost**](#apiinventorylocationtreechildrenpost) | **POST** /api/inventory-location/treechildren | 获取树形子节点|
|[**apiInventoryLocationTreelistPost**](#apiinventorylocationtreelistpost) | **POST** /api/inventory-location/treelist | 获取树形页面数据 带筛选|
|[**apiInventoryLocationTreeoptionsPost**](#apiinventorylocationtreeoptionspost) | **POST** /api/inventory-location/treeoptions | 获取树形下拉搜索选项|
|[**apiInventoryLocationUpdatePost**](#apiinventorylocationupdatepost) | **POST** /api/inventory-location/update | 更新|

# **apiInventoryLocationAddPost**
> RESTfulResultInventoryLocation apiInventoryLocationAddPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocationDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: InventoryLocationDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationAddPost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **InventoryLocationDto**|  | |


### Return type

**RESTfulResultInventoryLocation**

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

# **apiInventoryLocationAddorupdatePost**
> RESTfulResultInventoryLocation apiInventoryLocationAddorupdatePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocationDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: InventoryLocationDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationAddorupdatePost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **InventoryLocationDto**|  | |


### Return type

**RESTfulResultInventoryLocation**

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

# **apiInventoryLocationAlltreePost**
> RESTfulResultListPagedTreeOptions apiInventoryLocationAlltreePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

const { status, data } = await apiInstance.apiInventoryLocationAlltreePost();
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

# **apiInventoryLocationBatchaddPost**
> RESTfulResultInt32 apiInventoryLocationBatchaddPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: Array<InventoryLocationDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationBatchaddPost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **Array<InventoryLocationDto>**|  | |


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

# **apiInventoryLocationBatchdeletePost**
> apiInventoryLocationBatchdeletePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationBatchdeletePost(
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

# **apiInventoryLocationBatchlogicdeletePost**
> apiInventoryLocationBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationBatchlogicdeletePost(
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

# **apiInventoryLocationBatchupdatePost**
> RESTfulResultInt32 apiInventoryLocationBatchupdatePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: Array<InventoryLocationDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationBatchupdatePost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **Array<InventoryLocationDto>**|  | |


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

# **apiInventoryLocationDeleteIdPost**
> apiInventoryLocationDeleteIdPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryLocationDeleteIdPost(
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

# **apiInventoryLocationDetailIdGet**
> RESTfulResultInventoryLocation apiInventoryLocationDetailIdGet()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryLocationDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryLocation**

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

# **apiInventoryLocationDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryLocationDto apiInventoryLocationDetailoptionGet()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryLocationDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryLocationDto**

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

# **apiInventoryLocationHandlePathPost**
> RESTfulResultInventoryLocation apiInventoryLocationHandlePathPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocation
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocation: InventoryLocation; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationHandlePathPost(
    inventoryLocation
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocation** | **InventoryLocation**|  | |


### Return type

**RESTfulResultInventoryLocation**

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

# **apiInventoryLocationListPost**
> RESTfulResultListInventoryLocation apiInventoryLocationListPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryLocation**

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

# **apiInventoryLocationLogicdeleteIdPost**
> apiInventoryLocationLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryLocationLogicdeleteIdPost(
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

# **apiInventoryLocationOptionsPost**
> RESTfulResultListPagedOptions apiInventoryLocationOptionsPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationOptionsPost(
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

# **apiInventoryLocationPagelistPost**
> RESTfulResultPagedListInventoryLocation apiInventoryLocationPagelistPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryLocation**

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

# **apiInventoryLocationPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryLocationPageoptionGet()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

const { status, data } = await apiInstance.apiInventoryLocationPageoptionGet();
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

# **apiInventoryLocationToEntityPost**
> RESTfulResultInventoryLocation apiInventoryLocationToEntityPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocationDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: InventoryLocationDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationToEntityPost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **InventoryLocationDto**|  | |


### Return type

**RESTfulResultInventoryLocation**

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

# **apiInventoryLocationToListEntityPost**
> RESTfulResultListInventoryLocation apiInventoryLocationToListEntityPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: Array<InventoryLocationDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationToListEntityPost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **Array<InventoryLocationDto>**|  | |


### Return type

**RESTfulResultListInventoryLocation**

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

# **apiInventoryLocationToTreeOutputPost**
> RESTfulResultInventoryLocationTreeOutput apiInventoryLocationToTreeOutputPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocation
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocation: InventoryLocation; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationToTreeOutputPost(
    inventoryLocation
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocation** | **InventoryLocation**|  | |


### Return type

**RESTfulResultInventoryLocationTreeOutput**

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

# **apiInventoryLocationTreechildrenPost**
> RESTfulResultListInventoryLocation apiInventoryLocationTreechildrenPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    TreeChildrenDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let treeChildrenDto: TreeChildrenDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationTreechildrenPost(
    treeChildrenDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **treeChildrenDto** | **TreeChildrenDto**|  | |


### Return type

**RESTfulResultListInventoryLocation**

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

# **apiInventoryLocationTreelistPost**
> RESTfulResultListInventoryLocationTreeOutput apiInventoryLocationTreelistPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationTreelistPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryLocationTreeOutput**

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

# **apiInventoryLocationTreeoptionsPost**
> RESTfulResultListPagedTreeOptions apiInventoryLocationTreeoptionsPost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationTreeoptionsPost(
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

# **apiInventoryLocationUpdatePost**
> RESTfulResultInventoryLocation apiInventoryLocationUpdatePost()


### Example

```typescript
import {
    InventoryLocationApi,
    Configuration,
    InventoryLocationDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryLocationApi(configuration);

let inventoryLocationDto: InventoryLocationDto; // (optional)

const { status, data } = await apiInstance.apiInventoryLocationUpdatePost(
    inventoryLocationDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryLocationDto** | **InventoryLocationDto**|  | |


### Return type

**RESTfulResultInventoryLocation**

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

