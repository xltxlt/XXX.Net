# InventoryWarehouseApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryWarehouseAddPost**](#apiinventorywarehouseaddpost) | **POST** /api/inventory-warehouse/add | 新增|
|[**apiInventoryWarehouseAddorupdatePost**](#apiinventorywarehouseaddorupdatepost) | **POST** /api/inventory-warehouse/addorupdate | 新增|
|[**apiInventoryWarehouseBatchaddPost**](#apiinventorywarehousebatchaddpost) | **POST** /api/inventory-warehouse/batchadd | 新增|
|[**apiInventoryWarehouseBatchdeletePost**](#apiinventorywarehousebatchdeletepost) | **POST** /api/inventory-warehouse/batchdelete | 删除|
|[**apiInventoryWarehouseBatchlogicdeletePost**](#apiinventorywarehousebatchlogicdeletepost) | **POST** /api/inventory-warehouse/batchlogicdelete | 逻辑删除|
|[**apiInventoryWarehouseBatchupdatePost**](#apiinventorywarehousebatchupdatepost) | **POST** /api/inventory-warehouse/batchupdate | 新增|
|[**apiInventoryWarehouseDeleteIdPost**](#apiinventorywarehousedeleteidpost) | **POST** /api/inventory-warehouse/delete/{id} | 删除|
|[**apiInventoryWarehouseDetailIdGet**](#apiinventorywarehousedetailidget) | **GET** /api/inventory-warehouse/detail/{id} | 获取详情|
|[**apiInventoryWarehouseDetailoptionGet**](#apiinventorywarehousedetailoptionget) | **GET** /api/inventory-warehouse/detailoption | 获取详情|
|[**apiInventoryWarehouseListPost**](#apiinventorywarehouselistpost) | **POST** /api/inventory-warehouse/list | 获取集合|
|[**apiInventoryWarehouseLogicdeleteIdPost**](#apiinventorywarehouselogicdeleteidpost) | **POST** /api/inventory-warehouse/logicdelete/{id} | 逻辑删除|
|[**apiInventoryWarehouseOptionsPost**](#apiinventorywarehouseoptionspost) | **POST** /api/inventory-warehouse/options | 获取下拉搜索选项|
|[**apiInventoryWarehousePagelistPost**](#apiinventorywarehousepagelistpost) | **POST** /api/inventory-warehouse/pagelist | 获取分页集合|
|[**apiInventoryWarehousePageoptionGet**](#apiinventorywarehousepageoptionget) | **GET** /api/inventory-warehouse/pageoption | 获取新增修改页面选项|
|[**apiInventoryWarehouseToEntityPost**](#apiinventorywarehousetoentitypost) | **POST** /api/inventory-warehouse/to-entity | |
|[**apiInventoryWarehouseToListEntityPost**](#apiinventorywarehousetolistentitypost) | **POST** /api/inventory-warehouse/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryWarehouseUpdatePost**](#apiinventorywarehouseupdatepost) | **POST** /api/inventory-warehouse/update | 更新|

# **apiInventoryWarehouseAddPost**
> RESTfulResultInventoryWarehouse apiInventoryWarehouseAddPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    InventoryWarehouseDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: InventoryWarehouseDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseAddPost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **InventoryWarehouseDto**|  | |


### Return type

**RESTfulResultInventoryWarehouse**

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

# **apiInventoryWarehouseAddorupdatePost**
> RESTfulResultInventoryWarehouse apiInventoryWarehouseAddorupdatePost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    InventoryWarehouseDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: InventoryWarehouseDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseAddorupdatePost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **InventoryWarehouseDto**|  | |


### Return type

**RESTfulResultInventoryWarehouse**

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

# **apiInventoryWarehouseBatchaddPost**
> RESTfulResultInt32 apiInventoryWarehouseBatchaddPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: Array<InventoryWarehouseDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseBatchaddPost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **Array<InventoryWarehouseDto>**|  | |


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

# **apiInventoryWarehouseBatchdeletePost**
> apiInventoryWarehouseBatchdeletePost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseBatchdeletePost(
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

# **apiInventoryWarehouseBatchlogicdeletePost**
> apiInventoryWarehouseBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseBatchlogicdeletePost(
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

# **apiInventoryWarehouseBatchupdatePost**
> RESTfulResultInt32 apiInventoryWarehouseBatchupdatePost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: Array<InventoryWarehouseDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseBatchupdatePost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **Array<InventoryWarehouseDto>**|  | |


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

# **apiInventoryWarehouseDeleteIdPost**
> apiInventoryWarehouseDeleteIdPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryWarehouseDeleteIdPost(
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

# **apiInventoryWarehouseDetailIdGet**
> RESTfulResultInventoryWarehouse apiInventoryWarehouseDetailIdGet()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryWarehouseDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryWarehouse**

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

# **apiInventoryWarehouseDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryWarehouseDto apiInventoryWarehouseDetailoptionGet()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryWarehouseDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryWarehouseDto**

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

# **apiInventoryWarehouseListPost**
> RESTfulResultListInventoryWarehouse apiInventoryWarehouseListPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryWarehouse**

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

# **apiInventoryWarehouseLogicdeleteIdPost**
> apiInventoryWarehouseLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryWarehouseLogicdeleteIdPost(
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

# **apiInventoryWarehouseOptionsPost**
> RESTfulResultListPagedOptions apiInventoryWarehouseOptionsPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseOptionsPost(
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

# **apiInventoryWarehousePagelistPost**
> RESTfulResultPagedListInventoryWarehouse apiInventoryWarehousePagelistPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehousePagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryWarehouse**

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

# **apiInventoryWarehousePageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryWarehousePageoptionGet()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

const { status, data } = await apiInstance.apiInventoryWarehousePageoptionGet();
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

# **apiInventoryWarehouseToEntityPost**
> RESTfulResultInventoryWarehouse apiInventoryWarehouseToEntityPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    InventoryWarehouseDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: InventoryWarehouseDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseToEntityPost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **InventoryWarehouseDto**|  | |


### Return type

**RESTfulResultInventoryWarehouse**

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

# **apiInventoryWarehouseToListEntityPost**
> RESTfulResultListInventoryWarehouse apiInventoryWarehouseToListEntityPost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: Array<InventoryWarehouseDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseToListEntityPost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **Array<InventoryWarehouseDto>**|  | |


### Return type

**RESTfulResultListInventoryWarehouse**

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

# **apiInventoryWarehouseUpdatePost**
> RESTfulResultInventoryWarehouse apiInventoryWarehouseUpdatePost()


### Example

```typescript
import {
    InventoryWarehouseApi,
    Configuration,
    InventoryWarehouseDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryWarehouseApi(configuration);

let inventoryWarehouseDto: InventoryWarehouseDto; // (optional)

const { status, data } = await apiInstance.apiInventoryWarehouseUpdatePost(
    inventoryWarehouseDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryWarehouseDto** | **InventoryWarehouseDto**|  | |


### Return type

**RESTfulResultInventoryWarehouse**

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

