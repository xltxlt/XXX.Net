# SysRoleApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysRoleAddPost**](#apisysroleaddpost) | **POST** /api/sys-role/add | 新增|
|[**apiSysRoleAddorupdatePost**](#apisysroleaddorupdatepost) | **POST** /api/sys-role/addorupdate | 新增|
|[**apiSysRoleBatchaddPost**](#apisysrolebatchaddpost) | **POST** /api/sys-role/batchadd | 新增|
|[**apiSysRoleBatchdeletePost**](#apisysrolebatchdeletepost) | **POST** /api/sys-role/batchdelete | 删除|
|[**apiSysRoleBatchlogicdeletePost**](#apisysrolebatchlogicdeletepost) | **POST** /api/sys-role/batchlogicdelete | 逻辑删除|
|[**apiSysRoleBatchupdatePost**](#apisysrolebatchupdatepost) | **POST** /api/sys-role/batchupdate | 新增|
|[**apiSysRoleDeleteIdPost**](#apisysroledeleteidpost) | **POST** /api/sys-role/delete/{id} | 删除|
|[**apiSysRoleDetailIdGet**](#apisysroledetailidget) | **GET** /api/sys-role/detail/{id} | 获取详情|
|[**apiSysRoleDetailoptionGet**](#apisysroledetailoptionget) | **GET** /api/sys-role/detailoption | 获取详情|
|[**apiSysRoleListPost**](#apisysrolelistpost) | **POST** /api/sys-role/list | 获取集合|
|[**apiSysRoleLogicdeleteIdPost**](#apisysrolelogicdeleteidpost) | **POST** /api/sys-role/logicdelete/{id} | 逻辑删除|
|[**apiSysRoleOptionsPost**](#apisysroleoptionspost) | **POST** /api/sys-role/options | 获取下拉搜索选项|
|[**apiSysRolePagelistPost**](#apisysrolepagelistpost) | **POST** /api/sys-role/pagelist | 获取分页集合|
|[**apiSysRolePageoptionGet**](#apisysrolepageoptionget) | **GET** /api/sys-role/pageoption | 获取新增修改页面选项|
|[**apiSysRoleRolepermissionIdGet**](#apisysrolerolepermissionidget) | **GET** /api/sys-role/rolepermission/{id} | 获取角色权限|
|[**apiSysRoleSetrolepermissionPost**](#apisysrolesetrolepermissionpost) | **POST** /api/sys-role/setrolepermission | 设置角色权限|
|[**apiSysRoleToEntityPost**](#apisysroletoentitypost) | **POST** /api/sys-role/to-entity | 模型到实体的转换|
|[**apiSysRoleToListEntityPost**](#apisysroletolistentitypost) | **POST** /api/sys-role/to-list-entity | 模型到实体的批量转换|
|[**apiSysRoleUpdatePost**](#apisysroleupdatepost) | **POST** /api/sys-role/update | 更新|

# **apiSysRoleAddPost**
> RESTfulResultSysRole apiSysRoleAddPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    RoleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: RoleDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleAddPost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **RoleDto**|  | |


### Return type

**RESTfulResultSysRole**

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

# **apiSysRoleAddorupdatePost**
> RESTfulResultSysRole apiSysRoleAddorupdatePost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    RoleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: RoleDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleAddorupdatePost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **RoleDto**|  | |


### Return type

**RESTfulResultSysRole**

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

# **apiSysRoleBatchaddPost**
> RESTfulResultInt32 apiSysRoleBatchaddPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: Array<RoleDto>; // (optional)

const { status, data } = await apiInstance.apiSysRoleBatchaddPost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **Array<RoleDto>**|  | |


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

# **apiSysRoleBatchdeletePost**
> apiSysRoleBatchdeletePost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysRoleBatchdeletePost(
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

# **apiSysRoleBatchlogicdeletePost**
> apiSysRoleBatchlogicdeletePost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysRoleBatchlogicdeletePost(
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

# **apiSysRoleBatchupdatePost**
> RESTfulResultInt32 apiSysRoleBatchupdatePost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: Array<RoleDto>; // (optional)

const { status, data } = await apiInstance.apiSysRoleBatchupdatePost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **Array<RoleDto>**|  | |


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

# **apiSysRoleDeleteIdPost**
> apiSysRoleDeleteIdPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysRoleDeleteIdPost(
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

# **apiSysRoleDetailIdGet**
> RESTfulResultSysRole apiSysRoleDetailIdGet()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysRoleDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysRole**

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

# **apiSysRoleDetailoptionGet**
> RESTfulResultPageDetailOptionRoleDto apiSysRoleDetailoptionGet()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysRoleDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionRoleDto**

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

# **apiSysRoleListPost**
> RESTfulResultListSysRole apiSysRoleListPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysRole**

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

# **apiSysRoleLogicdeleteIdPost**
> apiSysRoleLogicdeleteIdPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysRoleLogicdeleteIdPost(
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

# **apiSysRoleOptionsPost**
> RESTfulResultListPagedOptions apiSysRoleOptionsPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysRoleOptionsPost(
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

# **apiSysRolePagelistPost**
> RESTfulResultPagedListSysRole apiSysRolePagelistPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysRolePagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysRole**

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

# **apiSysRolePageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysRolePageoptionGet()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysRolePageoptionGet(
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

# **apiSysRoleRolepermissionIdGet**
> RESTfulResultRolePermissionDto apiSysRoleRolepermissionIdGet()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysRoleRolepermissionIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultRolePermissionDto**

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

# **apiSysRoleSetrolepermissionPost**
> apiSysRoleSetrolepermissionPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    SetRolePermissionDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let setRolePermissionDto: SetRolePermissionDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleSetrolepermissionPost(
    setRolePermissionDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **setRolePermissionDto** | **SetRolePermissionDto**|  | |


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

# **apiSysRoleToEntityPost**
> RESTfulResultSysRole apiSysRoleToEntityPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    RoleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: RoleDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleToEntityPost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **RoleDto**|  | |


### Return type

**RESTfulResultSysRole**

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

# **apiSysRoleToListEntityPost**
> RESTfulResultListSysRole apiSysRoleToListEntityPost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: Array<RoleDto>; // (optional)

const { status, data } = await apiInstance.apiSysRoleToListEntityPost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **Array<RoleDto>**|  | |


### Return type

**RESTfulResultListSysRole**

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

# **apiSysRoleUpdatePost**
> RESTfulResultSysRole apiSysRoleUpdatePost()


### Example

```typescript
import {
    SysRoleApi,
    Configuration,
    RoleDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysRoleApi(configuration);

let roleDto: RoleDto; // (optional)

const { status, data } = await apiInstance.apiSysRoleUpdatePost(
    roleDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **roleDto** | **RoleDto**|  | |


### Return type

**RESTfulResultSysRole**

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

