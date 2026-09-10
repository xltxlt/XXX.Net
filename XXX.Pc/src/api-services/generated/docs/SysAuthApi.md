# SysAuthApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysAuthLoginPost**](#apisysauthloginpost) | **POST** /api/sys-auth/login | 账号密码登录|
|[**apiSysAuthLogoutPost**](#apisysauthlogoutpost) | **POST** /api/sys-auth/logout | 退出登录|

# **apiSysAuthLoginPost**
> RESTfulResultLoginVo apiSysAuthLoginPost()

用户名/密码：superadmin/123456

### Example

```typescript
import {
    SysAuthApi,
    Configuration,
    LoginDto
} from './api';

const configuration = new Configuration();
const apiInstance = new SysAuthApi(configuration);

let loginDto: LoginDto; // (optional)

const { status, data } = await apiInstance.apiSysAuthLoginPost(
    loginDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **loginDto** | **LoginDto**|  | |


### Return type

**RESTfulResultLoginVo**

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

# **apiSysAuthLogoutPost**
> apiSysAuthLogoutPost()


### Example

```typescript
import {
    SysAuthApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysAuthApi(configuration);

const { status, data } = await apiInstance.apiSysAuthLogoutPost();
```

### Parameters
This endpoint does not have any parameters.


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

