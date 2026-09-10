# InventoryAttributeDefinitionApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventoryAttributeDefinitionAddPost**](#apiinventoryattributedefinitionaddpost) | **POST** /api/inventory-attribute-definition/add | 新增|
|[**apiInventoryAttributeDefinitionAddorupdatePost**](#apiinventoryattributedefinitionaddorupdatepost) | **POST** /api/inventory-attribute-definition/addorupdate | 新增|
|[**apiInventoryAttributeDefinitionBatchaddPost**](#apiinventoryattributedefinitionbatchaddpost) | **POST** /api/inventory-attribute-definition/batchadd | 新增|
|[**apiInventoryAttributeDefinitionBatchdeletePost**](#apiinventoryattributedefinitionbatchdeletepost) | **POST** /api/inventory-attribute-definition/batchdelete | 删除|
|[**apiInventoryAttributeDefinitionBatchlogicdeletePost**](#apiinventoryattributedefinitionbatchlogicdeletepost) | **POST** /api/inventory-attribute-definition/batchlogicdelete | 逻辑删除|
|[**apiInventoryAttributeDefinitionBatchupdatePost**](#apiinventoryattributedefinitionbatchupdatepost) | **POST** /api/inventory-attribute-definition/batchupdate | 新增|
|[**apiInventoryAttributeDefinitionDeleteIdPost**](#apiinventoryattributedefinitiondeleteidpost) | **POST** /api/inventory-attribute-definition/delete/{id} | 删除|
|[**apiInventoryAttributeDefinitionDetailIdGet**](#apiinventoryattributedefinitiondetailidget) | **GET** /api/inventory-attribute-definition/detail/{id} | 获取详情|
|[**apiInventoryAttributeDefinitionDetailoptionGet**](#apiinventoryattributedefinitiondetailoptionget) | **GET** /api/inventory-attribute-definition/detailoption | 获取详情|
|[**apiInventoryAttributeDefinitionListPost**](#apiinventoryattributedefinitionlistpost) | **POST** /api/inventory-attribute-definition/list | 获取集合|
|[**apiInventoryAttributeDefinitionLogicdeleteIdPost**](#apiinventoryattributedefinitionlogicdeleteidpost) | **POST** /api/inventory-attribute-definition/logicdelete/{id} | 逻辑删除|
|[**apiInventoryAttributeDefinitionOptionsPost**](#apiinventoryattributedefinitionoptionspost) | **POST** /api/inventory-attribute-definition/options | 获取下拉搜索选项|
|[**apiInventoryAttributeDefinitionPagelistPost**](#apiinventoryattributedefinitionpagelistpost) | **POST** /api/inventory-attribute-definition/pagelist | 获取分页集合|
|[**apiInventoryAttributeDefinitionPageoptionGet**](#apiinventoryattributedefinitionpageoptionget) | **GET** /api/inventory-attribute-definition/pageoption | 获取新增修改页面选项|
|[**apiInventoryAttributeDefinitionToEntityPost**](#apiinventoryattributedefinitiontoentitypost) | **POST** /api/inventory-attribute-definition/to-entity | |
|[**apiInventoryAttributeDefinitionToListEntityPost**](#apiinventoryattributedefinitiontolistentitypost) | **POST** /api/inventory-attribute-definition/to-list-entity | 模型到实体的批量转换|
|[**apiInventoryAttributeDefinitionUpdatePost**](#apiinventoryattributedefinitionupdatepost) | **POST** /api/inventory-attribute-definition/update | 更新|

# **apiInventoryAttributeDefinitionAddPost**
> RESTfulResultInventoryAttributeDefinition apiInventoryAttributeDefinitionAddPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    InventoryAttributeDefinitionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: InventoryAttributeDefinitionDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionAddPost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **InventoryAttributeDefinitionDto**|  | |


### Return type

**RESTfulResultInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionAddorupdatePost**
> RESTfulResultInventoryAttributeDefinition apiInventoryAttributeDefinitionAddorupdatePost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    InventoryAttributeDefinitionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: InventoryAttributeDefinitionDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionAddorupdatePost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **InventoryAttributeDefinitionDto**|  | |


### Return type

**RESTfulResultInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionBatchaddPost**
> RESTfulResultInt32 apiInventoryAttributeDefinitionBatchaddPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: Array<InventoryAttributeDefinitionDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionBatchaddPost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **Array<InventoryAttributeDefinitionDto>**|  | |


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

# **apiInventoryAttributeDefinitionBatchdeletePost**
> apiInventoryAttributeDefinitionBatchdeletePost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionBatchdeletePost(
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

# **apiInventoryAttributeDefinitionBatchlogicdeletePost**
> apiInventoryAttributeDefinitionBatchlogicdeletePost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionBatchlogicdeletePost(
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

# **apiInventoryAttributeDefinitionBatchupdatePost**
> RESTfulResultInt32 apiInventoryAttributeDefinitionBatchupdatePost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: Array<InventoryAttributeDefinitionDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionBatchupdatePost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **Array<InventoryAttributeDefinitionDto>**|  | |


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

# **apiInventoryAttributeDefinitionDeleteIdPost**
> apiInventoryAttributeDefinitionDeleteIdPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionDeleteIdPost(
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

# **apiInventoryAttributeDefinitionDetailIdGet**
> RESTfulResultInventoryAttributeDefinition apiInventoryAttributeDefinitionDetailIdGet()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionDetailoptionGet**
> RESTfulResultPageDetailOptionInventoryAttributeDefinitionDto apiInventoryAttributeDefinitionDetailoptionGet()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionInventoryAttributeDefinitionDto**

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

# **apiInventoryAttributeDefinitionListPost**
> RESTfulResultListInventoryAttributeDefinition apiInventoryAttributeDefinitionListPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionLogicdeleteIdPost**
> apiInventoryAttributeDefinitionLogicdeleteIdPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionLogicdeleteIdPost(
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

# **apiInventoryAttributeDefinitionOptionsPost**
> RESTfulResultListPagedOptions apiInventoryAttributeDefinitionOptionsPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionOptionsPost(
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

# **apiInventoryAttributeDefinitionPagelistPost**
> RESTfulResultPagedListInventoryAttributeDefinition apiInventoryAttributeDefinitionPagelistPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiInventoryAttributeDefinitionPageoptionGet()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionPageoptionGet();
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

# **apiInventoryAttributeDefinitionToEntityPost**
> RESTfulResultInventoryAttributeDefinition apiInventoryAttributeDefinitionToEntityPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    InventoryAttributeDefinitionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: InventoryAttributeDefinitionDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionToEntityPost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **InventoryAttributeDefinitionDto**|  | |


### Return type

**RESTfulResultInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionToListEntityPost**
> RESTfulResultListInventoryAttributeDefinition apiInventoryAttributeDefinitionToListEntityPost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: Array<InventoryAttributeDefinitionDto>; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionToListEntityPost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **Array<InventoryAttributeDefinitionDto>**|  | |


### Return type

**RESTfulResultListInventoryAttributeDefinition**

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

# **apiInventoryAttributeDefinitionUpdatePost**
> RESTfulResultInventoryAttributeDefinition apiInventoryAttributeDefinitionUpdatePost()


### Example

```typescript
import {
    InventoryAttributeDefinitionApi,
    Configuration,
    InventoryAttributeDefinitionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventoryAttributeDefinitionApi(configuration);

let inventoryAttributeDefinitionDto: InventoryAttributeDefinitionDto; // (optional)

const { status, data } = await apiInstance.apiInventoryAttributeDefinitionUpdatePost(
    inventoryAttributeDefinitionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryAttributeDefinitionDto** | **InventoryAttributeDefinitionDto**|  | |


### Return type

**RESTfulResultInventoryAttributeDefinition**

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

