# GenerateApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiGenerateDetailPost**](#apigeneratedetailpost) | **POST** /api/generate/detail | 生成页面|
|[**apiGeneratePageoptionGet**](#apigeneratepageoptionget) | **GET** /api/generate/pageoption | 获取新增修改页面选项|

# **apiGenerateDetailPost**
> apiGenerateDetailPost()


### Example

```typescript
import {
    GenerateApi,
    Configuration,
    GenerateDto
} from './api';

const configuration = new Configuration();
const apiInstance = new GenerateApi(configuration);

let generateDto: GenerateDto; // (optional)

const { status, data } = await apiInstance.apiGenerateDetailPost(
    generateDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **generateDto** | **GenerateDto**|  | |


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

# **apiGeneratePageoptionGet**
> RESTfulResultObject apiGeneratePageoptionGet()


### Example

```typescript
import {
    GenerateApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new GenerateApi(configuration);

const { status, data } = await apiInstance.apiGeneratePageoptionGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultObject**

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

