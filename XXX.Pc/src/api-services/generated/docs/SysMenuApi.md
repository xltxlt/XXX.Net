# SysMenuApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysMenuAddPost**](#apisysmenuaddpost) | **POST** /api/sys-menu/add | 增加|
|[**apiSysMenuAddorupdatePost**](#apisysmenuaddorupdatepost) | **POST** /api/sys-menu/addorupdate | 新增|
|[**apiSysMenuAllmenucomposePost**](#apisysmenuallmenucomposepost) | **POST** /api/sys-menu/allmenucompose | 获取所有菜单、按钮、表头|
|[**apiSysMenuAlltreePost**](#apisysmenualltreepost) | **POST** /api/sys-menu/alltree | 获取所有数据树形|
|[**apiSysMenuBatchaddPost**](#apisysmenubatchaddpost) | **POST** /api/sys-menu/batchadd | 新增|
|[**apiSysMenuBatchdeletePost**](#apisysmenubatchdeletepost) | **POST** /api/sys-menu/batchdelete | 删除|
|[**apiSysMenuBatchlogicdeletePost**](#apisysmenubatchlogicdeletepost) | **POST** /api/sys-menu/batchlogicdelete | 逻辑删除|
|[**apiSysMenuBatchupdatePost**](#apisysmenubatchupdatepost) | **POST** /api/sys-menu/batchupdate | 新增|
|[**apiSysMenuDeleteIdPost**](#apisysmenudeleteidpost) | **POST** /api/sys-menu/delete/{id} | 删除|
|[**apiSysMenuDetailIdGet**](#apisysmenudetailidget) | **GET** /api/sys-menu/detail/{id} | 获取详情|
|[**apiSysMenuDetailoptionGet**](#apisysmenudetailoptionget) | **GET** /api/sys-menu/detailoption | 获取详情|
|[**apiSysMenuHandlePathPost**](#apisysmenuhandlepathpost) | **POST** /api/sys-menu/handle-path | 处理树形层级|
|[**apiSysMenuLeftmenuPost**](#apisysmenuleftmenupost) | **POST** /api/sys-menu/leftmenu | 获取当前用户左侧菜单|
|[**apiSysMenuListPost**](#apisysmenulistpost) | **POST** /api/sys-menu/list | 获取集合|
|[**apiSysMenuLogicdeleteIdPost**](#apisysmenulogicdeleteidpost) | **POST** /api/sys-menu/logicdelete/{id} | 逻辑删除|
|[**apiSysMenuMenurenderPost**](#apisysmenumenurenderpost) | **POST** /api/sys-menu/menurender | 获取菜单渲染数据|
|[**apiSysMenuOptionsPost**](#apisysmenuoptionspost) | **POST** /api/sys-menu/options | 获取下拉搜索选项|
|[**apiSysMenuPagelistPost**](#apisysmenupagelistpost) | **POST** /api/sys-menu/pagelist | 获取分页集合|
|[**apiSysMenuPageoptionGet**](#apisysmenupageoptionget) | **GET** /api/sys-menu/pageoption | 获取新增修改页面选项|
|[**apiSysMenuSysManagerMenuTenantidGet**](#apisysmenusysmanagermenutenantidget) | **GET** /api/sys-menu/sys-manager-menu/{tenantid} | |
|[**apiSysMenuToEntityPost**](#apisysmenutoentitypost) | **POST** /api/sys-menu/to-entity | 模型到实体的转换|
|[**apiSysMenuToListEntityPost**](#apisysmenutolistentitypost) | **POST** /api/sys-menu/to-list-entity | 模型到实体的批量转换|
|[**apiSysMenuToTreeOutputPost**](#apisysmenutotreeoutputpost) | **POST** /api/sys-menu/to-tree-output | 转换|
|[**apiSysMenuTreechildrenPost**](#apisysmenutreechildrenpost) | **POST** /api/sys-menu/treechildren | 获取树形子节点|
|[**apiSysMenuTreelistPost**](#apisysmenutreelistpost) | **POST** /api/sys-menu/treelist | 获取树形页面数据 带筛选|
|[**apiSysMenuTreeoptionsPost**](#apisysmenutreeoptionspost) | **POST** /api/sys-menu/treeoptions | 获取树形下拉搜索选项|
|[**apiSysMenuUpdatePost**](#apisysmenuupdatepost) | **POST** /api/sys-menu/update | 更新|
|[**apiSysMenuUserMenuUseridTenantidGet**](#apisysmenuusermenuuseridtenantidget) | **GET** /api/sys-menu/user-menu/{userid}/{tenantid} | |

# **apiSysMenuAddPost**
> RESTfulResultSysMenu apiSysMenuAddPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenuDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: SysMenuDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuAddPost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **SysMenuDto**|  | |


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuAddorupdatePost**
> RESTfulResultSysMenu apiSysMenuAddorupdatePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenuDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: SysMenuDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuAddorupdatePost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **SysMenuDto**|  | |


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuAllmenucomposePost**
> RESTfulResultListSysMenuComposeTreeOutput apiSysMenuAllmenucomposePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

const { status, data } = await apiInstance.apiSysMenuAllmenucomposePost();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListSysMenuComposeTreeOutput**

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

# **apiSysMenuAlltreePost**
> RESTfulResultListPagedTreeOptions apiSysMenuAlltreePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

const { status, data } = await apiInstance.apiSysMenuAlltreePost();
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

# **apiSysMenuBatchaddPost**
> RESTfulResultInt32 apiSysMenuBatchaddPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: Array<SysMenuDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuBatchaddPost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **Array<SysMenuDto>**|  | |


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

# **apiSysMenuBatchdeletePost**
> apiSysMenuBatchdeletePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuBatchdeletePost(
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

# **apiSysMenuBatchlogicdeletePost**
> apiSysMenuBatchlogicdeletePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysMenuBatchlogicdeletePost(
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

# **apiSysMenuBatchupdatePost**
> RESTfulResultInt32 apiSysMenuBatchupdatePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: Array<SysMenuDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuBatchupdatePost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **Array<SysMenuDto>**|  | |


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

# **apiSysMenuDeleteIdPost**
> apiSysMenuDeleteIdPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuDeleteIdPost(
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

# **apiSysMenuDetailIdGet**
> RESTfulResultSysMenu apiSysMenuDetailIdGet()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuDetailoptionGet**
> RESTfulResultPageDetailOptionSysMenuDto apiSysMenuDetailoptionGet()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysMenuDto**

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

# **apiSysMenuHandlePathPost**
> RESTfulResultSysMenu apiSysMenuHandlePathPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenu
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenu: SysMenu; // (optional)

const { status, data } = await apiInstance.apiSysMenuHandlePathPost(
    sysMenu
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenu** | **SysMenu**|  | |


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuLeftmenuPost**
> RESTfulResultListSysMenuTreeOutput apiSysMenuLeftmenuPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

const { status, data } = await apiInstance.apiSysMenuLeftmenuPost();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultListSysMenuTreeOutput**

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

# **apiSysMenuListPost**
> RESTfulResultListSysMenu apiSysMenuListPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysMenu**

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

# **apiSysMenuLogicdeleteIdPost**
> apiSysMenuLogicdeleteIdPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuLogicdeleteIdPost(
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

# **apiSysMenuMenurenderPost**
> RESTfulResultSysMenuOutputDto apiSysMenuMenurenderPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenuRenderDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuRenderDto: SysMenuRenderDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuMenurenderPost(
    sysMenuRenderDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuRenderDto** | **SysMenuRenderDto**|  | |


### Return type

**RESTfulResultSysMenuOutputDto**

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

# **apiSysMenuOptionsPost**
> RESTfulResultListPagedOptions apiSysMenuOptionsPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysMenuOptionsPost(
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

# **apiSysMenuPagelistPost**
> RESTfulResultPagedListSysMenu apiSysMenuPagelistPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysMenu**

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

# **apiSysMenuPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysMenuPageoptionGet()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysMenuPageoptionGet(
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

# **apiSysMenuSysManagerMenuTenantidGet**
> RESTfulResultListSysMenu apiSysMenuSysManagerMenuTenantidGet()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let tenantid: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuSysManagerMenuTenantidGet(
    tenantid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **tenantid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultListSysMenu**

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

# **apiSysMenuToEntityPost**
> RESTfulResultSysMenu apiSysMenuToEntityPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenuDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: SysMenuDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuToEntityPost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **SysMenuDto**|  | |


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuToListEntityPost**
> RESTfulResultListSysMenu apiSysMenuToListEntityPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: Array<SysMenuDto>; // (optional)

const { status, data } = await apiInstance.apiSysMenuToListEntityPost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **Array<SysMenuDto>**|  | |


### Return type

**RESTfulResultListSysMenu**

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

# **apiSysMenuToTreeOutputPost**
> RESTfulResultSysMenuTreeOutput apiSysMenuToTreeOutputPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenu
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenu: SysMenu; // (optional)

const { status, data } = await apiInstance.apiSysMenuToTreeOutputPost(
    sysMenu
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenu** | **SysMenu**|  | |


### Return type

**RESTfulResultSysMenuTreeOutput**

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

# **apiSysMenuTreechildrenPost**
> RESTfulResultListSysMenu apiSysMenuTreechildrenPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    TreeChildrenDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let treeChildrenDto: TreeChildrenDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuTreechildrenPost(
    treeChildrenDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **treeChildrenDto** | **TreeChildrenDto**|  | |


### Return type

**RESTfulResultListSysMenu**

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

# **apiSysMenuTreelistPost**
> RESTfulResultListSysMenuTreeOutput apiSysMenuTreelistPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuTreelistPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysMenuTreeOutput**

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

# **apiSysMenuTreeoptionsPost**
> RESTfulResultListPagedTreeOptions apiSysMenuTreeoptionsPost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysMenuTreeoptionsPost(
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

# **apiSysMenuUpdatePost**
> RESTfulResultSysMenu apiSysMenuUpdatePost()


### Example

```typescript
import {
    SysMenuApi,
    Configuration,
    SysMenuDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let sysMenuDto: SysMenuDto; // (optional)

const { status, data } = await apiInstance.apiSysMenuUpdatePost(
    sysMenuDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysMenuDto** | **SysMenuDto**|  | |


### Return type

**RESTfulResultSysMenu**

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

# **apiSysMenuUserMenuUseridTenantidGet**
> RESTfulResultListSysMenu apiSysMenuUserMenuUseridTenantidGet()


### Example

```typescript
import {
    SysMenuApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysMenuApi(configuration);

let userid: string; // (default to undefined)
let tenantid: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysMenuUserMenuUseridTenantidGet(
    userid,
    tenantid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **userid** | [**string**] |  | defaults to undefined|
| **tenantid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultListSysMenu**

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

