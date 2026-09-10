# InventoryDomainApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryDomainAddPost**](#apiinventorydomainaddpost) | **POST** /api/inventory-domain/add | 新增|
|[**apiInventoryDomainAddorupdatePost**](#apiinventorydomainaddorupdatepost) | **POST** /api/inventory-domain/addorupdate | 新增|
|[**apiInventoryDomainBatchaddPost**](#apiinventorydomainbatchaddpost) | **POST** /api/inventory-domain/batchadd | 新增|
|[**apiInventoryDomainBatchdeletePost**](#apiinventorydomainbatchdeletepost) | **POST** /api/inventory-domain/batchdelete | 删除|
|[**apiInventoryDomainBatchlogicdeletePost**](#apiinventorydomainbatchlogicdeletepost) | **POST** /api/inventory-domain/batchlogicdelete | 逻辑删除|
|[**apiInventoryDomainBatchupdatePost**](#apiinventorydomainbatchupdatepost) | **POST** /api/inventory-domain/batchupdate | 新增|
|[**apiInventoryDomainDeleteIdPost**](#apiinventorydomaindeleteidpost) | **POST** /api/inventory-domain/delete/{id} | 删除|
|[**apiInventoryDomainDetailIdGet**](#apiinventorydomaindetailidget) | **GET** /api/inventory-domain/detail/{id} | 获取详情|
|[**apiInventoryDomainDetailoptionGet**](#apiinventorydomaindetailoptionget) | **GET** /api/inventory-domain/detailoption | 获取详情|
|[**apiInventoryDomainListPost**](#apiinventorydomainlistpost) | **POST** /api/inventory-domain/list | 获取集合|
|[**apiInventoryDomainLogicdeleteIdPost**](#apiinventorydomainlogicdeleteidpost) | **POST** /api/inventory-domain/logicdelete/{id} | 逻辑删除|
|[**apiInventoryDomainOptionsPost**](#apiinventorydomainoptionspost) | **POST** /api/inventory-domain/options | 获取下拉搜索选项|
|[**apiInventoryDomainPagelistPost**](#apiinventorydomainpagelistpost) | **POST** /api/inventory-domain/pagelist | 获取分页集合|
|[**apiInventoryDomainPageoptionGet**](#apiinventorydomainpageoptionget) | **GET** /api/inventory-domain/pageoption | 获取新增修改页面选项|
|[**apiInventoryDomainToEntityPost**](#apiinventorydomaintoentitypost) | **POST** /api/inventory-domain/to-entity | 模型到实体的转换|
|[**apiInventoryDomainToListEntityPost**](#apiinventorydomaintolistentitypost) | **POST** /api/inventory-domain/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryDomainUpdatePost**](#apiinventorydomainupdatepost) | **POST** /api/inventory-domain/update | 更新|

# **apiInventoryDomainAddPost**
> RESTfulResultInventoryDomain apiInventoryDomainAddPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    InventoryDomainDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: InventoryDomainDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainAddPost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **InventoryDomainDto**|  | |


### Return type

**RESTfulResultInventoryDomain**

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

# **apiInventoryDomainAddorupdatePost**
> RESTfulResultInventoryDomain apiInventoryDomainAddorupdatePost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    InventoryDomainDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: InventoryDomainDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainAddorupdatePost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **InventoryDomainDto**|  | |


### Return type

**RESTfulResultInventoryDomain**

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

# **apiInventoryDomainBatchaddPost**
> RESTfulResultInt32 apiInventoryDomainBatchaddPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: Array<InventoryDomainDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainBatchaddPost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **Array<InventoryDomainDto>**|  | |


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

# **apiInventoryDomainBatchdeletePost**
> apiInventoryDomainBatchdeletePost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainBatchdeletePost(
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

# **apiInventoryDomainBatchlogicdeletePost**
> apiInventoryDomainBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainBatchlogicdeletePost(
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

# **apiInventoryDomainBatchupdatePost**
> RESTfulResultInt32 apiInventoryDomainBatchupdatePost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: Array<InventoryDomainDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainBatchupdatePost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **Array<InventoryDomainDto>**|  | |


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

# **apiInventoryDomainDeleteIdPost**
> apiInventoryDomainDeleteIdPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDomainDeleteIdPost(
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

# **apiInventoryDomainDetailIdGet**
> RESTfulResultInventoryDomain apiInventoryDomainDetailIdGet()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDomainDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryDomain**

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

# **apiInventoryDomainDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryDomainDto apiInventoryDomainDetailoptionGet()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryDomainDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryDomainDto**

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

# **apiInventoryDomainListPost**
> RESTfulResultListInventoryDomain apiInventoryDomainListPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryDomain**

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

# **apiInventoryDomainLogicdeleteIdPost**
> apiInventoryDomainLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDomainLogicdeleteIdPost(
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

# **apiInventoryDomainOptionsPost**
> RESTfulResultListPagedOptions apiInventoryDomainOptionsPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainOptionsPost(
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

# **apiInventoryDomainPagelistPost**
> RESTfulResultPagedListInventoryDomain apiInventoryDomainPagelistPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryDomain**

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

# **apiInventoryDomainPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryDomainPageoptionGet()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

const { status, data } = await apiInstance.apiInventoryDomainPageoptionGet();
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

# **apiInventoryDomainToEntityPost**
> RESTfulResultInventoryDomain apiInventoryDomainToEntityPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    InventoryDomainDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: InventoryDomainDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainToEntityPost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **InventoryDomainDto**|  | |


### Return type

**RESTfulResultInventoryDomain**

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

# **apiInventoryDomainToListEntityPost**
> RESTfulResultListInventoryDomain apiInventoryDomainToListEntityPost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: Array<InventoryDomainDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainToListEntityPost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **Array<InventoryDomainDto>**|  | |


### Return type

**RESTfulResultListInventoryDomain**

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

# **apiInventoryDomainUpdatePost**
> RESTfulResultInventoryDomain apiInventoryDomainUpdatePost()


### Example

```typescript
import {
    InventoryDomainApi,
    Configuration,
    InventoryDomainDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDomainApi(configuration);

let inventoryDomainDto: InventoryDomainDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDomainUpdatePost(
    inventoryDomainDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDomainDto** | **InventoryDomainDto**|  | |


### Return type

**RESTfulResultInventoryDomain**

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

