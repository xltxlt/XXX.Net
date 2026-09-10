# InventoryItemApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryItemAddPost**](#apiinventoryitemaddpost) | **POST** /api/inventory-item/add | 新增|
|[**apiInventoryItemAddorupdatePost**](#apiinventoryitemaddorupdatepost) | **POST** /api/inventory-item/addorupdate | 新增|
|[**apiInventoryItemBatchaddPost**](#apiinventoryitembatchaddpost) | **POST** /api/inventory-item/batchadd | 新增|
|[**apiInventoryItemBatchdeletePost**](#apiinventoryitembatchdeletepost) | **POST** /api/inventory-item/batchdelete | 删除|
|[**apiInventoryItemBatchlogicdeletePost**](#apiinventoryitembatchlogicdeletepost) | **POST** /api/inventory-item/batchlogicdelete | 逻辑删除|
|[**apiInventoryItemBatchupdatePost**](#apiinventoryitembatchupdatepost) | **POST** /api/inventory-item/batchupdate | 新增|
|[**apiInventoryItemDeleteIdPost**](#apiinventoryitemdeleteidpost) | **POST** /api/inventory-item/delete/{id} | 删除|
|[**apiInventoryItemDetailIdGet**](#apiinventoryitemdetailidget) | **GET** /api/inventory-item/detail/{id} | 获取详情|
|[**apiInventoryItemDetailoptionGet**](#apiinventoryitemdetailoptionget) | **GET** /api/inventory-item/detailoption | 获取详情|
|[**apiInventoryItemListPost**](#apiinventoryitemlistpost) | **POST** /api/inventory-item/list | 获取集合|
|[**apiInventoryItemLogicdeleteIdPost**](#apiinventoryitemlogicdeleteidpost) | **POST** /api/inventory-item/logicdelete/{id} | 逻辑删除|
|[**apiInventoryItemOptionsPost**](#apiinventoryitemoptionspost) | **POST** /api/inventory-item/options | 获取下拉搜索选项|
|[**apiInventoryItemPagelistPost**](#apiinventoryitempagelistpost) | **POST** /api/inventory-item/pagelist | 获取分页集合|
|[**apiInventoryItemPageoptionGet**](#apiinventoryitempageoptionget) | **GET** /api/inventory-item/pageoption | 获取新增修改页面选项|
|[**apiInventoryItemToEntityPost**](#apiinventoryitemtoentitypost) | **POST** /api/inventory-item/to-entity | |
|[**apiInventoryItemToListEntityPost**](#apiinventoryitemtolistentitypost) | **POST** /api/inventory-item/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryItemUpdatePost**](#apiinventoryitemupdatepost) | **POST** /api/inventory-item/update | 更新|

# **apiInventoryItemAddPost**
> RESTfulResultInventoryItem apiInventoryItemAddPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    InventoryItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: InventoryItemDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemAddPost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **InventoryItemDto**|  | |


### Return type

**RESTfulResultInventoryItem**

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

# **apiInventoryItemAddorupdatePost**
> RESTfulResultInventoryItem apiInventoryItemAddorupdatePost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    InventoryItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: InventoryItemDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemAddorupdatePost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **InventoryItemDto**|  | |


### Return type

**RESTfulResultInventoryItem**

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

# **apiInventoryItemBatchaddPost**
> RESTfulResultInt32 apiInventoryItemBatchaddPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: Array<InventoryItemDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemBatchaddPost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **Array<InventoryItemDto>**|  | |


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

# **apiInventoryItemBatchdeletePost**
> apiInventoryItemBatchdeletePost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemBatchdeletePost(
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

# **apiInventoryItemBatchlogicdeletePost**
> apiInventoryItemBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemBatchlogicdeletePost(
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

# **apiInventoryItemBatchupdatePost**
> RESTfulResultInt32 apiInventoryItemBatchupdatePost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: Array<InventoryItemDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemBatchupdatePost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **Array<InventoryItemDto>**|  | |


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

# **apiInventoryItemDeleteIdPost**
> apiInventoryItemDeleteIdPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryItemDeleteIdPost(
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

# **apiInventoryItemDetailIdGet**
> RESTfulResultInventoryItem apiInventoryItemDetailIdGet()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryItemDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryItem**

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

# **apiInventoryItemDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryItemDto apiInventoryItemDetailoptionGet()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryItemDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryItemDto**

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

# **apiInventoryItemListPost**
> RESTfulResultListInventoryItem apiInventoryItemListPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryItem**

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

# **apiInventoryItemLogicdeleteIdPost**
> apiInventoryItemLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryItemLogicdeleteIdPost(
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

# **apiInventoryItemOptionsPost**
> RESTfulResultListPagedOptions apiInventoryItemOptionsPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemOptionsPost(
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

# **apiInventoryItemPagelistPost**
> RESTfulResultPagedListInventoryItem apiInventoryItemPagelistPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryItem**

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

# **apiInventoryItemPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryItemPageoptionGet()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

const { status, data } = await apiInstance.apiInventoryItemPageoptionGet();
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

# **apiInventoryItemToEntityPost**
> RESTfulResultInventoryItem apiInventoryItemToEntityPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    InventoryItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: InventoryItemDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemToEntityPost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **InventoryItemDto**|  | |


### Return type

**RESTfulResultInventoryItem**

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

# **apiInventoryItemToListEntityPost**
> RESTfulResultListInventoryItem apiInventoryItemToListEntityPost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: Array<InventoryItemDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryItemToListEntityPost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **Array<InventoryItemDto>**|  | |


### Return type

**RESTfulResultListInventoryItem**

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

# **apiInventoryItemUpdatePost**
> RESTfulResultInventoryItem apiInventoryItemUpdatePost()


### Example

```typescript
import {
    InventoryItemApi,
    Configuration,
    InventoryItemDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryItemApi(configuration);

let inventoryItemDto: InventoryItemDto; // (optional)

const { status, data } = await apiInstance.apiInventoryItemUpdatePost(
    inventoryItemDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryItemDto** | **InventoryItemDto**|  | |


### Return type

**RESTfulResultInventoryItem**

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

