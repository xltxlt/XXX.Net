# InventoryTypeApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryTypeAddPost**](#apiinventorytypeaddpost) | **POST** /api/inventory-type/add | 新增|
|[**apiInventoryTypeAddorupdatePost**](#apiinventorytypeaddorupdatepost) | **POST** /api/inventory-type/addorupdate | 新增|
|[**apiInventoryTypeBatchaddPost**](#apiinventorytypebatchaddpost) | **POST** /api/inventory-type/batchadd | 新增|
|[**apiInventoryTypeBatchdeletePost**](#apiinventorytypebatchdeletepost) | **POST** /api/inventory-type/batchdelete | 删除|
|[**apiInventoryTypeBatchlogicdeletePost**](#apiinventorytypebatchlogicdeletepost) | **POST** /api/inventory-type/batchlogicdelete | 逻辑删除|
|[**apiInventoryTypeBatchupdatePost**](#apiinventorytypebatchupdatepost) | **POST** /api/inventory-type/batchupdate | 新增|
|[**apiInventoryTypeDeleteIdPost**](#apiinventorytypedeleteidpost) | **POST** /api/inventory-type/delete/{id} | 删除|
|[**apiInventoryTypeDetailIdGet**](#apiinventorytypedetailidget) | **GET** /api/inventory-type/detail/{id} | 获取详情|
|[**apiInventoryTypeDetailoptionGet**](#apiinventorytypedetailoptionget) | **GET** /api/inventory-type/detailoption | 获取详情|
|[**apiInventoryTypeListPost**](#apiinventorytypelistpost) | **POST** /api/inventory-type/list | 获取集合|
|[**apiInventoryTypeLogicdeleteIdPost**](#apiinventorytypelogicdeleteidpost) | **POST** /api/inventory-type/logicdelete/{id} | 逻辑删除|
|[**apiInventoryTypeOptionsPost**](#apiinventorytypeoptionspost) | **POST** /api/inventory-type/options | 获取下拉搜索选项|
|[**apiInventoryTypePagelistPost**](#apiinventorytypepagelistpost) | **POST** /api/inventory-type/pagelist | 获取分页集合|
|[**apiInventoryTypePageoptionGet**](#apiinventorytypepageoptionget) | **GET** /api/inventory-type/pageoption | 获取新增修改页面选项|
|[**apiInventoryTypeToEntityPost**](#apiinventorytypetoentitypost) | **POST** /api/inventory-type/to-entity | |
|[**apiInventoryTypeToListEntityPost**](#apiinventorytypetolistentitypost) | **POST** /api/inventory-type/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryTypeUpdatePost**](#apiinventorytypeupdatepost) | **POST** /api/inventory-type/update | 更新|

# **apiInventoryTypeAddPost**
> RESTfulResultInventoryType apiInventoryTypeAddPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    InventoryTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: InventoryTypeDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeAddPost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **InventoryTypeDto**|  | |


### Return type

**RESTfulResultInventoryType**

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

# **apiInventoryTypeAddorupdatePost**
> RESTfulResultInventoryType apiInventoryTypeAddorupdatePost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    InventoryTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: InventoryTypeDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeAddorupdatePost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **InventoryTypeDto**|  | |


### Return type

**RESTfulResultInventoryType**

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

# **apiInventoryTypeBatchaddPost**
> RESTfulResultInt32 apiInventoryTypeBatchaddPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: Array<InventoryTypeDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeBatchaddPost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **Array<InventoryTypeDto>**|  | |


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

# **apiInventoryTypeBatchdeletePost**
> apiInventoryTypeBatchdeletePost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeBatchdeletePost(
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

# **apiInventoryTypeBatchlogicdeletePost**
> apiInventoryTypeBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeBatchlogicdeletePost(
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

# **apiInventoryTypeBatchupdatePost**
> RESTfulResultInt32 apiInventoryTypeBatchupdatePost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: Array<InventoryTypeDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeBatchupdatePost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **Array<InventoryTypeDto>**|  | |


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

# **apiInventoryTypeDeleteIdPost**
> apiInventoryTypeDeleteIdPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryTypeDeleteIdPost(
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

# **apiInventoryTypeDetailIdGet**
> RESTfulResultInventoryType apiInventoryTypeDetailIdGet()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryTypeDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryType**

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

# **apiInventoryTypeDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryTypeDto apiInventoryTypeDetailoptionGet()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryTypeDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryTypeDto**

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

# **apiInventoryTypeListPost**
> RESTfulResultListInventoryType apiInventoryTypeListPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryType**

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

# **apiInventoryTypeLogicdeleteIdPost**
> apiInventoryTypeLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryTypeLogicdeleteIdPost(
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

# **apiInventoryTypeOptionsPost**
> RESTfulResultListPagedOptions apiInventoryTypeOptionsPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeOptionsPost(
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

# **apiInventoryTypePagelistPost**
> RESTfulResultPagedListInventoryType apiInventoryTypePagelistPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypePagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryType**

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

# **apiInventoryTypePageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryTypePageoptionGet()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

const { status, data } = await apiInstance.apiInventoryTypePageoptionGet();
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

# **apiInventoryTypeToEntityPost**
> RESTfulResultInventoryType apiInventoryTypeToEntityPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    InventoryTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: InventoryTypeDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeToEntityPost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **InventoryTypeDto**|  | |


### Return type

**RESTfulResultInventoryType**

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

# **apiInventoryTypeToListEntityPost**
> RESTfulResultListInventoryType apiInventoryTypeToListEntityPost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: Array<InventoryTypeDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeToListEntityPost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **Array<InventoryTypeDto>**|  | |


### Return type

**RESTfulResultListInventoryType**

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

# **apiInventoryTypeUpdatePost**
> RESTfulResultInventoryType apiInventoryTypeUpdatePost()


### Example

```typescript
import {
    InventoryTypeApi,
    Configuration,
    InventoryTypeDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryTypeApi(configuration);

let inventoryTypeDto: InventoryTypeDto; // (optional)

const { status, data } = await apiInstance.apiInventoryTypeUpdatePost(
    inventoryTypeDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryTypeDto** | **InventoryTypeDto**|  | |


### Return type

**RESTfulResultInventoryType**

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

