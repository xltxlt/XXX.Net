# InventoryDocumentApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryDocumentAddPost**](#apiinventorydocumentaddpost) | **POST** /api/inventory-document/add | 1. 新增父子|
|[**apiInventoryDocumentAddorupdatePost**](#apiinventorydocumentaddorupdatepost) | **POST** /api/inventory-document/addorupdate | 新增|
|[**apiInventoryDocumentBatchaddPost**](#apiinventorydocumentbatchaddpost) | **POST** /api/inventory-document/batchadd | 新增|
|[**apiInventoryDocumentBatchdeletePost**](#apiinventorydocumentbatchdeletepost) | **POST** /api/inventory-document/batchdelete | 删除|
|[**apiInventoryDocumentBatchlogicdeletePost**](#apiinventorydocumentbatchlogicdeletepost) | **POST** /api/inventory-document/batchlogicdelete | 逻辑删除|
|[**apiInventoryDocumentBatchupdatePost**](#apiinventorydocumentbatchupdatepost) | **POST** /api/inventory-document/batchupdate | 新增|
|[**apiInventoryDocumentCancelIdPost**](#apiinventorydocumentcancelidpost) | **POST** /api/inventory-document/cancel/{id} | 取消库存单据|
|[**apiInventoryDocumentCompleteIdPost**](#apiinventorydocumentcompleteidpost) | **POST** /api/inventory-document/complete/{id} | 完成库存单据|
|[**apiInventoryDocumentCreatePost**](#apiinventorydocumentcreatepost) | **POST** /api/inventory-document/create | 创建库存单据|
|[**apiInventoryDocumentDeleteIdPost**](#apiinventorydocumentdeleteidpost) | **POST** /api/inventory-document/delete/{id} | 删除|
|[**apiInventoryDocumentDetailParentidGet**](#apiinventorydocumentdetailparentidget) | **GET** /api/inventory-document/detail/{parentid} | 3. 查询详情（Include）|
|[**apiInventoryDocumentDetailoptionGet**](#apiinventorydocumentdetailoptionget) | **GET** /api/inventory-document/detailoption | 获取详情|
|[**apiInventoryDocumentListPost**](#apiinventorydocumentlistpost) | **POST** /api/inventory-document/list | 获取集合|
|[**apiInventoryDocumentLogicdeleteIdPost**](#apiinventorydocumentlogicdeleteidpost) | **POST** /api/inventory-document/logicdelete/{id} | 逻辑删除|
|[**apiInventoryDocumentOptionsPost**](#apiinventorydocumentoptionspost) | **POST** /api/inventory-document/options | 获取下拉搜索选项|
|[**apiInventoryDocumentPagelistPost**](#apiinventorydocumentpagelistpost) | **POST** /api/inventory-document/pagelist | 获取分页集合|
|[**apiInventoryDocumentPageoptionGet**](#apiinventorydocumentpageoptionget) | **GET** /api/inventory-document/pageoption | 获取新增修改页面选项|
|[**apiInventoryDocumentToEntityPost**](#apiinventorydocumenttoentitypost) | **POST** /api/inventory-document/to-entity | 模型到实体的转换|
|[**apiInventoryDocumentToListEntityPost**](#apiinventorydocumenttolistentitypost) | **POST** /api/inventory-document/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryDocumentUpdatePost**](#apiinventorydocumentupdatepost) | **POST** /api/inventory-document/update | 更新父子（Include 核心）|

# **apiInventoryDocumentAddPost**
> RESTfulResultInventoryDocument apiInventoryDocumentAddPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    InventoryDocumentDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: InventoryDocumentDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentAddPost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **InventoryDocumentDto**|  | |


### Return type

**RESTfulResultInventoryDocument**

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

# **apiInventoryDocumentAddorupdatePost**
> RESTfulResultInventoryDocument apiInventoryDocumentAddorupdatePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    InventoryDocumentDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: InventoryDocumentDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentAddorupdatePost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **InventoryDocumentDto**|  | |


### Return type

**RESTfulResultInventoryDocument**

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

# **apiInventoryDocumentBatchaddPost**
> RESTfulResultInt32 apiInventoryDocumentBatchaddPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: Array<InventoryDocumentDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentBatchaddPost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **Array<InventoryDocumentDto>**|  | |


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

# **apiInventoryDocumentBatchdeletePost**
> apiInventoryDocumentBatchdeletePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentBatchdeletePost(
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

# **apiInventoryDocumentBatchlogicdeletePost**
> apiInventoryDocumentBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentBatchlogicdeletePost(
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

# **apiInventoryDocumentBatchupdatePost**
> RESTfulResultInt32 apiInventoryDocumentBatchupdatePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: Array<InventoryDocumentDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentBatchupdatePost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **Array<InventoryDocumentDto>**|  | |


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

# **apiInventoryDocumentCancelIdPost**
> apiInventoryDocumentCancelIdPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentCancelIdPost(
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

# **apiInventoryDocumentCompleteIdPost**
> apiInventoryDocumentCompleteIdPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentCompleteIdPost(
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

# **apiInventoryDocumentCreatePost**
> RESTfulResultInventoryDocument apiInventoryDocumentCreatePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    InventoryDocumentDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: InventoryDocumentDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentCreatePost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **InventoryDocumentDto**|  | |


### Return type

**RESTfulResultInventoryDocument**

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

# **apiInventoryDocumentDeleteIdPost**
> apiInventoryDocumentDeleteIdPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentDeleteIdPost(
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

# **apiInventoryDocumentDetailParentidGet**
> RESTfulResultInventoryDocument apiInventoryDocumentDetailParentidGet()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let parentid: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentDetailParentidGet(
    parentid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **parentid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryDocument**

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

# **apiInventoryDocumentDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryDocumentDto apiInventoryDocumentDetailoptionGet()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryDocumentDto**

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

# **apiInventoryDocumentListPost**
> RESTfulResultListInventoryDocument apiInventoryDocumentListPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryDocument**

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

# **apiInventoryDocumentLogicdeleteIdPost**
> apiInventoryDocumentLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryDocumentLogicdeleteIdPost(
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

# **apiInventoryDocumentOptionsPost**
> RESTfulResultListPagedOptions apiInventoryDocumentOptionsPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentOptionsPost(
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

# **apiInventoryDocumentPagelistPost**
> RESTfulResultPagedListInventoryDocument apiInventoryDocumentPagelistPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryDocument**

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

# **apiInventoryDocumentPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryDocumentPageoptionGet()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

const { status, data } = await apiInstance.apiInventoryDocumentPageoptionGet();
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

# **apiInventoryDocumentToEntityPost**
> RESTfulResultInventoryDocument apiInventoryDocumentToEntityPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    InventoryDocumentDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: InventoryDocumentDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentToEntityPost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **InventoryDocumentDto**|  | |


### Return type

**RESTfulResultInventoryDocument**

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

# **apiInventoryDocumentToListEntityPost**
> RESTfulResultListInventoryDocument apiInventoryDocumentToListEntityPost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: Array<InventoryDocumentDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentToListEntityPost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **Array<InventoryDocumentDto>**|  | |


### Return type

**RESTfulResultListInventoryDocument**

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

# **apiInventoryDocumentUpdatePost**
> RESTfulResultInventoryDocument apiInventoryDocumentUpdatePost()


### Example

```typescript
import {
    InventoryDocumentApi,
    Configuration,
    InventoryDocumentDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryDocumentApi(configuration);

let inventoryDocumentDto: InventoryDocumentDto; // (optional)

const { status, data } = await apiInstance.apiInventoryDocumentUpdatePost(
    inventoryDocumentDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryDocumentDto** | **InventoryDocumentDto**|  | |


### Return type

**RESTfulResultInventoryDocument**

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

