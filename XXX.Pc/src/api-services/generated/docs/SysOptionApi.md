# SysOptionApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysOptionOptionAllPost**](#apisysoptionoptionallpost) | **POST** /api/sys-option/option-all | 获取所有可选的数据源|
|[**apiSysOptionOptionsPost**](#apisysoptionoptionspost) | **POST** /api/sys-option/options | |

# **apiSysOptionOptionAllPost**
> RESTfulResultDictionaryStringListPagedOptions apiSysOptionOptionAllPost()


### Example

```typescript
import {
    SysOptionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOptionApi(configuration);

const { status, data } = await apiInstance.apiSysOptionOptionAllPost();
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

# **apiSysOptionOptionsPost**
> RESTfulResultDictionaryStringListPagedOptions apiSysOptionOptionsPost()


### Example

```typescript
import {
    SysOptionApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysOptionApi(configuration);

let baseDataSource: Array<BaseDataSource>; // (optional)

const { status, data } = await apiInstance.apiSysOptionOptionsPost(
    baseDataSource
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **baseDataSource** | **Array<BaseDataSource>**|  | |


### Return type

**RESTfulResultDictionaryStringListPagedOptions**

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

