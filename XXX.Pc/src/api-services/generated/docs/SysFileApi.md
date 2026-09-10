# SysFileApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiSysFileDownloadFileidFilenameGet**](#apisysfiledownloadfileidfilenameget) | **GET** /api/sys-file/download/{fileid}/{filename} | |
|[**apiSysFileUploadPost**](#apisysfileuploadpost) | **POST** /api/sys-file/upload | |
|[**apiSysFileUploadSinglePost**](#apisysfileuploadsinglepost) | **POST** /api/sys-file/upload-single | |

# **apiSysFileDownloadFileidFilenameGet**
> apiSysFileDownloadFileidFilenameGet()


### Example

```typescript
import {
    SysFileApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysFileApi(configuration);

let fileid: string; // (default to undefined)
let filename: string; // (default to undefined)

const { status, data } = await apiInstance.apiSysFileDownloadFileidFilenameGet(
    fileid,
    filename
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **fileid** | [**string**] |  | defaults to undefined|
| **filename** | [**string**] |  | defaults to undefined|


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

# **apiSysFileUploadPost**
> apiSysFileUploadPost()


### Example

```typescript
import {
    SysFileApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysFileApi(configuration);

let files: Array<File>; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysFileUploadPost(
    files
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **files** | **Array&lt;File&gt;** |  | (optional) defaults to undefined|


### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **apiSysFileUploadSinglePost**
> SysFileOutput apiSysFileUploadSinglePost()


### Example

```typescript
import {
    SysFileApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new SysFileApi(configuration);

let file: File; // (optional) (default to undefined)

const { status, data } = await apiInstance.apiSysFileUploadSinglePost(
    file
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **file** | [**File**] |  | (optional) defaults to undefined|


### Return type

**SysFileOutput**

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

