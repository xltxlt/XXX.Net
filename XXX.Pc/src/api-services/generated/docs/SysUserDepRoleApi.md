# SysUserDepRoleApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysUserDepRoleDepuserrolesPost**](#apisysuserdeproledepuserrolespost) | **POST** /api/sys-user-dep-role/depuserroles | 部门用户角色|
|[**apiSysUserDepRoleDepusersPost**](#apisysuserdeproledepuserspost) | **POST** /api/sys-user-dep-role/depusers | 部门用户|
|[**apiSysUserDepRoleSetdepuserrolesPost**](#apisysuserdeprolesetdepuserrolespost) | **POST** /api/sys-user-dep-role/setdepuserroles | 设置部门用户角色|

# **apiSysUserDepRoleDepuserrolesPost**
> RESTfulResultListUserDepRolesOutput apiSysUserDepRoleDepuserrolesPost()


### Example

```typescript
import {
    SysUserDepRoleApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserDepRoleApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysUserDepRoleDepuserrolesPost(
    pagedPaginationListDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **pagedPaginationListDto** | **PagedPaginationListDto**|  | |


### Return type

**RESTfulResultListUserDepRolesOutput**

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

# **apiSysUserDepRoleDepusersPost**
> RESTfulResultPagedListSysUser apiSysUserDepRoleDepusersPost()


### Example

```typescript
import {
    SysUserDepRoleApi,
    Configuration,
    PagedPaginationListDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserDepRoleApi(configuration);

let pagedPaginationListDto: PagedPaginationListDto; // (optional)

const { status, data } = await apiInstance.apiSysUserDepRoleDepusersPost(
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

# **apiSysUserDepRoleSetdepuserrolesPost**
> apiSysUserDepRoleSetdepuserrolesPost()


### Example

```typescript
import {
    SysUserDepRoleApi,
    Configuration,
    UserDepRolesDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysUserDepRoleApi(configuration);

let userDepRolesDto: UserDepRolesDto; // (optional)

const { status, data } = await apiInstance.apiSysUserDepRoleSetdepuserrolesPost(
    userDepRolesDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **userDepRolesDto** | **UserDepRolesDto**|  | |


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

