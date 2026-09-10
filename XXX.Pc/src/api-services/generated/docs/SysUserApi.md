# SysUserApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysUserAddPost**](#apisysuseraddpost) | **POST** /api/sys-user/add | 添加用户|
|[**apiSysUserAddorupdatePost**](#apisysuseraddorupdatepost) | **POST** /api/sys-user/addorupdate | 新增|
|[**apiSysUserAllexportGet**](#apisysuserallexportget) | **GET** /api/sys-user/allexport | 导出数据|
|[**apiSysUserBatchaddPost**](#apisysuserbatchaddpost) | **POST** /api/sys-user/batchadd | 新增|
|[**apiSysUserBatchdeletePost**](#apisysuserbatchdeletepost) | **POST** /api/sys-user/batchdelete | 删除|
|[**apiSysUserBatchlogicdeletePost**](#apisysuserbatchlogicdeletepost) | **POST** /api/sys-user/batchlogicdelete | 逻辑删除|
|[**apiSysUserBatchupdatePost**](#apisysuserbatchupdatepost) | **POST** /api/sys-user/batchupdate | 新增|
|[**apiSysUserDeleteIdPost**](#apisysuserdeleteidpost) | **POST** /api/sys-user/delete/{id} | 删除|
|[**apiSysUserDetailIdGet**](#apisysuserdetailidget) | **GET** /api/sys-user/detail/{id} | 获取详情|
|[**apiSysUserDetailoptionGet**](#apisysuserdetailoptionget) | **GET** /api/sys-user/detailoption | 获取详情|
|[**apiSysUserDownloadtemplateGet**](#apisysuserdownloadtemplateget) | **GET** /api/sys-user/downloadtemplate | 下载导入模板|
|[**apiSysUserExportPost**](#apisysuserexportpost) | **POST** /api/sys-user/export | 导出数据|
|[**apiSysUserImportPost**](#apisysuserimportpost) | **POST** /api/sys-user/import | 导入数据|
|[**apiSysUserImportUpdatePost**](#apisysuserimportupdatepost) | **POST** /api/sys-user/import-update | |
|[**apiSysUserImportupdatePost**](#apisysuserimportupdatepost) | **POST** /api/sys-user/importupdate | 导入数据|
|[**apiSysUserListPost**](#apisysuserlistpost) | **POST** /api/sys-user/list | 获取集合|
|[**apiSysUserLogicdeleteIdPost**](#apisysuserlogicdeleteidpost) | **POST** /api/sys-user/logicdelete/{id} | 逻辑删除|
|[**apiSysUserOptionsPost**](#apisysuseroptionspost) | **POST** /api/sys-user/options | 获取下拉搜索选项|
|[**apiSysUserPagelistPost**](#apisysuserpagelistpost) | **POST** /api/sys-user/pagelist | 获取分页集合|
|[**apiSysUserPageoptionGet**](#apisysuserpageoptionget) | **GET** /api/sys-user/pageoption | 获取新增修改页面选项|
|[**apiSysUserToEntityPost**](#apisysusertoentitypost) | **POST** /api/sys-user/to-entity | 模型到实体的转换|
|[**apiSysUserToListEntityPost**](#apisysusertolistentitypost) | **POST** /api/sys-user/to-list-entity | 模型到实体的批量转换|
|[**apiSysUserUpdatePost**](#apisysuserupdatepost) | **POST** /api/sys-user/update | 更新|

# **apiSysUserAddPost**
> RESTfulResultSysUser apiSysUserAddPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    SysUserDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: SysUserDto; // (optional)

const { status, data } = await apiInstance.apiSysUserAddPost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **SysUserDto**|  | |


### Return type

**RESTfulResultSysUser**

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

# **apiSysUserAddorupdatePost**
> RESTfulResultSysUser apiSysUserAddorupdatePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    SysUserDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: SysUserDto; // (optional)

const { status, data } = await apiInstance.apiSysUserAddorupdatePost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **SysUserDto**|  | |


### Return type

**RESTfulResultSysUser**

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

# **apiSysUserAllexportGet**
> RESTfulResultFileStreamResult apiSysUserAllexportGet()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

const { status, data } = await apiInstance.apiSysUserAllexportGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultFileStreamResult**

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

# **apiSysUserBatchaddPost**
> RESTfulResultInt32 apiSysUserBatchaddPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: Array<SysUserDto>; // (optional)

const { status, data } = await apiInstance.apiSysUserBatchaddPost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **Array<SysUserDto>**|  | |


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

# **apiSysUserBatchdeletePost**
> apiSysUserBatchdeletePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysUserBatchdeletePost(
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

# **apiSysUserBatchlogicdeletePost**
> apiSysUserBatchlogicdeletePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let requestBody: Array<string>; // (optional)

const { status, data } = await apiInstance.apiSysUserBatchlogicdeletePost(
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

# **apiSysUserBatchupdatePost**
> RESTfulResultInt32 apiSysUserBatchupdatePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: Array<SysUserDto>; // (optional)

const { status, data } = await apiInstance.apiSysUserBatchupdatePost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **Array<SysUserDto>**|  | |


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

# **apiSysUserDeleteIdPost**
> apiSysUserDeleteIdPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysUserDeleteIdPost(
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

# **apiSysUserDetailIdGet**
> RESTfulResultSysUser apiSysUserDetailIdGet()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysUserDetailIdGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultSysUser**

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

# **apiSysUserDetailoptionGet**
> RESTfulResultPageDetailOptionSysUserDto apiSysUserDetailoptionGet()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let id: string; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysUserDetailoptionGet(
    id
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **id** | [**string**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPageDetailOptionSysUserDto**

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

# **apiSysUserDownloadtemplateGet**
> RESTfulResultIActionResult apiSysUserDownloadtemplateGet()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

const { status, data } = await apiInstance.apiSysUserDownloadtemplateGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultIActionResult**

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

# **apiSysUserExportPost**
> RESTfulResultIActionResult apiSysUserExportPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysUserExportPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultIActionResult**

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

# **apiSysUserImportPost**
> RESTfulResultPagedImportResult apiSysUserImportPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let file: File; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysUserImportPost(
    file
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **file** | [**File**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPagedImportResult**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSysUserImportUpdatePost**
> RESTfulResultPagedImportResult apiSysUserImportUpdatePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let file: File; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysUserImportUpdatePost(
    file
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **file** | [**File**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPagedImportResult**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSysUserImportupdatePost**
> RESTfulResultPagedImportResult apiSysUserImportupdatePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let file: File; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysUserImportupdatePost(
    file
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **file** | [**File**] |  | (optional) defaults to undefined|


### Return type

**RESTfulResultPagedImportResult**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSysUserListPost**
> RESTfulResultListSysUser apiSysUserListPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    PagedListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let pagedListDto: PagedListDto; // (optional)

const { status, data } = await apiInstance.apiSysUserListPost(
    pagedListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedListDto** | **PagedListDto**|  | |


### Return type

**RESTfulResultListSysUser**

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

# **apiSysUserLogicdeleteIdPost**
> apiSysUserLogicdeleteIdPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let id: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysUserLogicdeleteIdPost(
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

# **apiSysUserOptionsPost**
> RESTfulResultListPagedOptions apiSysUserOptionsPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let pagedCustomWhere: Array<PagedCustomWhere>; // (optional)

const { status, data } = await apiInstance.apiSysUserOptionsPost(
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

# **apiSysUserPagelistPost**
> RESTfulResultPagedListSysUser apiSysUserPagelistPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysUserPagelistPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultPagedListSysUser**

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

# **apiSysUserPageoptionGet**
> RESTfulResultDictionaryStringListPagedOptions apiSysUserPageoptionGet()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let where: Array<PagedCustomWhere>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysUserPageoptionGet(
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

# **apiSysUserToEntityPost**
> RESTfulResultSysUser apiSysUserToEntityPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    SysUserDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: SysUserDto; // (optional)

const { status, data } = await apiInstance.apiSysUserToEntityPost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **SysUserDto**|  | |


### Return type

**RESTfulResultSysUser**

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

# **apiSysUserToListEntityPost**
> RESTfulResultListSysUser apiSysUserToListEntityPost()


### Example

```typescript
import {
    SysUserApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: Array<SysUserDto>; // (optional)

const { status, data } = await apiInstance.apiSysUserToListEntityPost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **Array<SysUserDto>**|  | |


### Return type

**RESTfulResultListSysUser**

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

# **apiSysUserUpdatePost**
> RESTfulResultSysUser apiSysUserUpdatePost()


### Example

```typescript
import {
    SysUserApi,
    Configuration,
    SysUserDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserApi(configuration);

let sysUserDto: SysUserDto; // (optional)

const { status, data } = await apiInstance.apiSysUserUpdatePost(
    sysUserDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **sysUserDto** | **SysUserDto**|  | |


### Return type

**RESTfulResultSysUser**

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

