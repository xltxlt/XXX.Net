# InventoryStockApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryStockAddPost**](#apiinventorystockaddpost) | **POST** /api/inventory-stock/add | 新增|
|[**apiInventoryStockAddorupdatePost**](#apiinventorystockaddorupdatepost) | **POST** /api/inventory-stock/addorupdate | 新增|
|[**apiInventoryStockBatchaddPost**](#apiinventorystockbatchaddpost) | **POST** /api/inventory-stock/batchadd | 新增|
|[**apiInventoryStockBatchdeletePost**](#apiinventorystockbatchdeletepost) | **POST** /api/inventory-stock/batchdelete | 删除|
|[**apiInventoryStockBatchlogicdeletePost**](#apiinventorystockbatchlogicdeletepost) | **POST** /api/inventory-stock/batchlogicdelete | 逻辑删除|
|[**apiInventoryStockBatchupdatePost**](#apiinventorystockbatchupdatepost) | **POST** /api/inventory-stock/batchupdate | 新增|
|[**apiInventoryStockDeleteIdPost**](#apiinventorystockdeleteidpost) | **POST** /api/inventory-stock/delete/{id} | 删除|
|[**apiInventoryStockDetailIdGet**](#apiinventorystockdetailidget) | **GET** /api/inventory-stock/detail/{id} | 获取详情|
|[**apiInventoryStockDetailoptionGet**](#apiinventorystockdetailoptionget) | **GET** /api/inventory-stock/detailoption | 获取详情|
|[**apiInventoryStockListPost**](#apiinventorystocklistpost) | **POST** /api/inventory-stock/list | 获取集合|
|[**apiInventoryStockLogicdeleteIdPost**](#apiinventorystocklogicdeleteidpost) | **POST** /api/inventory-stock/logicdelete/{id} | 逻辑删除|
|[**apiInventoryStockOptionsPost**](#apiinventorystockoptionspost) | **POST** /api/inventory-stock/options | 获取下拉搜索选项|
|[**apiInventoryStockPagelistPost**](#apiinventorystockpagelistpost) | **POST** /api/inventory-stock/pagelist | 获取分页集合|
|[**apiInventoryStockPageoptionGet**](#apiinventorystockpageoptionget) | **GET** /api/inventory-stock/pageoption | 获取新增修改页面选项|
|[**apiInventoryStockToEntityPost**](#apiinventorystocktoentitypost) | **POST** /api/inventory-stock/to-entity | |
|[**apiInventoryStockToListEntityPost**](#apiinventorystocktolistentitypost) | **POST** /api/inventory-stock/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryStockUpdatePost**](#apiinventorystockupdatepost) | **POST** /api/inventory-stock/update | 更新|

# **apiInventoryStockAddPost**
> RESTfulResultInventoryStock apiInventoryStockAddPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    InventoryStockDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: InventoryStockDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockAddPost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **InventoryStockDto**|  | |


### Return type

**RESTfulResultInventoryStock**

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

# **apiInventoryStockAddorupdatePost**
> RESTfulResultInventoryStock apiInventoryStockAddorupdatePost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    InventoryStockDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: InventoryStockDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockAddorupdatePost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **InventoryStockDto**|  | |


### Return type

**RESTfulResultInventoryStock**

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

# **apiInventoryStockBatchaddPost**
> RESTfulResultInt32 apiInventoryStockBatchaddPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: Array<InventoryStockDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockBatchaddPost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **Array<InventoryStockDto>**|  | |


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

# **apiInventoryStockBatchdeletePost**
> apiInventoryStockBatchdeletePost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockBatchdeletePost(
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

# **apiInventoryStockBatchlogicdeletePost**
> apiInventoryStockBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockBatchlogicdeletePost(
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

# **apiInventoryStockBatchupdatePost**
> RESTfulResultInt32 apiInventoryStockBatchupdatePost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: Array<InventoryStockDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockBatchupdatePost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **Array<InventoryStockDto>**|  | |


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

# **apiInventoryStockDeleteIdPost**
> apiInventoryStockDeleteIdPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryStockDeleteIdPost(
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

# **apiInventoryStockDetailIdGet**
> RESTfulResultInventoryStock apiInventoryStockDetailIdGet()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryStockDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryStock**

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

# **apiInventoryStockDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryStockDto apiInventoryStockDetailoptionGet()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryStockDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryStockDto**

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

# **apiInventoryStockListPost**
> RESTfulResultListInventoryStock apiInventoryStockListPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryStock**

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

# **apiInventoryStockLogicdeleteIdPost**
> apiInventoryStockLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryStockLogicdeleteIdPost(
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

# **apiInventoryStockOptionsPost**
> RESTfulResultListPagedOptions apiInventoryStockOptionsPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockOptionsPost(
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

# **apiInventoryStockPagelistPost**
> RESTfulResultPagedListInventoryStock apiInventoryStockPagelistPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryStock**

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

# **apiInventoryStockPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryStockPageoptionGet()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

const { status, data } = await apiInstance.apiInventoryStockPageoptionGet();
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

# **apiInventoryStockToEntityPost**
> RESTfulResultInventoryStock apiInventoryStockToEntityPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    InventoryStockDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: InventoryStockDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockToEntityPost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **InventoryStockDto**|  | |


### Return type

**RESTfulResultInventoryStock**

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

# **apiInventoryStockToListEntityPost**
> RESTfulResultListInventoryStock apiInventoryStockToListEntityPost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: Array<InventoryStockDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryStockToListEntityPost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **Array<InventoryStockDto>**|  | |


### Return type

**RESTfulResultListInventoryStock**

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

# **apiInventoryStockUpdatePost**
> RESTfulResultInventoryStock apiInventoryStockUpdatePost()


### Example

```typescript
import {
    InventoryStockApi,
    Configuration,
    InventoryStockDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryStockApi(configuration);

let inventoryStockDto: InventoryStockDto; // (optional)

const { status, data } = await apiInstance.apiInventoryStockUpdatePost(
    inventoryStockDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockDto** | **InventoryStockDto**|  | |


### Return type

**RESTfulResultInventoryStock**

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

