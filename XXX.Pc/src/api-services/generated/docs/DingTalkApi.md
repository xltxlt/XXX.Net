# DingTalkApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiDingTalkCallBackTenantidSignatureTimestampNoncePost**](#apidingtalkcallbacktenantidsignaturetimestampnoncepost) | **POST** /api/ding-talk/call-back/{tenantid}/{signature}/{timestamp}/{nonce} | 获取企业内部应用的access_token|
|[**apiDingTalkDingTalkCreateAndDeliverTokenPost**](#apidingtalkdingtalkcreateanddelivertokenpost) | **POST** /api/ding-talk/ding-talk-create-and-deliver/{token} | 给指定用户发送钉钉消息卡片|
|[**apiDingTalkDingTalkCurrentEmployeesListAccessTokenPost**](#apidingtalkdingtalkcurrentemployeeslistaccesstokenpost) | **POST** /api/ding-talk/ding-talk-current-employees-list/{access_token} | 获取在职员工列表|
|[**apiDingTalkDingTalkCurrentEmployeesRosterListAccessTokenPost**](#apidingtalkdingtalkcurrentemployeesrosterlistaccesstokenpost) | **POST** /api/ding-talk/ding-talk-current-employees-roster-list/{access_token} | 获取员工花名册字段信息|
|[**apiDingTalkDingTalkSendInteractiveCardsTokenPost**](#apidingtalkdingtalksendinteractivecardstokenpost) | **POST** /api/ding-talk/ding-talk-send-interactive-cards/{token} | 给指定用户发送钉钉互动卡片|
|[**apiDingTalkDingTalkTokenGet**](#apidingtalkdingtalktokenget) | **GET** /api/ding-talk/ding-talk-token | 获取企业内部应用的access_token|
|[**apiDingTalkDingTalkWorkflowProcessInstancesTokenInputPost**](#apidingtalkdingtalkworkflowprocessinstancestokeninputpost) | **POST** /api/ding-talk/ding-talk-workflow-process-instances/{token}/{input} | 查询审批实例|
|[**apiDingTalkDingTalkWorkflowProcessInstancesTokenPost**](#apidingtalkdingtalkworkflowprocessinstancestokenpost) | **POST** /api/ding-talk/ding-talk-workflow-process-instances/{token} | 用于发起OA审批实例|
|[**apiDingTalkStartApprovalTenantidPost**](#apidingtalkstartapprovaltenantidpost) | **POST** /api/ding-talk/start-approval/{tenantid} | |
|[**apiDingTalkSyncOrganizationTenantidPost**](#apidingtalksyncorganizationtenantidpost) | **POST** /api/ding-talk/sync-organization/{tenantid} | |

# **apiDingTalkCallBackTenantidSignatureTimestampNoncePost**
> RESTfulResultDingTalkCallBackResultOutput apiDingTalkCallBackTenantidSignatureTimestampNoncePost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let tenantid: string; // (default to undefined)
let signature: string; // (default to undefined)
let timestamp: string; // (default to undefined)
let nonce: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkCallBackTenantidSignatureTimestampNoncePost(
    tenantid,
    signature,
    timestamp,
    nonce
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **tenantid** | [**string**] |  | defaults to undefined|
| **signature** | [**string**] |  | defaults to undefined|
| **timestamp** | [**string**] |  | defaults to undefined|
| **nonce** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkCallBackResultOutput**

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

# **apiDingTalkDingTalkCreateAndDeliverTokenPost**
> RESTfulResultDingTalkCreateAndDeliverOutput apiDingTalkDingTalkCreateAndDeliverTokenPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    DingTalkCreateAndDeliverInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let token: string; // (default to undefined)
let dingTalkCreateAndDeliverInput: DingTalkCreateAndDeliverInput; // (optional)

const { status, data } = await apiInstance.apiDingTalkDingTalkCreateAndDeliverTokenPost(
    token,
    dingTalkCreateAndDeliverInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkCreateAndDeliverInput** | **DingTalkCreateAndDeliverInput**|  | |
| **token** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkCreateAndDeliverOutput**

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

# **apiDingTalkDingTalkCurrentEmployeesListAccessTokenPost**
> RESTfulResultDingTalkBaseResponseGetDingTalkCurrentEmployeesListOutput apiDingTalkDingTalkCurrentEmployeesListAccessTokenPost(getDingTalkCurrentEmployeesListInput)


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    GetDingTalkCurrentEmployeesListInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let accessToken: string; // (default to undefined)
let getDingTalkCurrentEmployeesListInput: GetDingTalkCurrentEmployeesListInput; //

const { status, data } = await apiInstance.apiDingTalkDingTalkCurrentEmployeesListAccessTokenPost(
    accessToken,
    getDingTalkCurrentEmployeesListInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **getDingTalkCurrentEmployeesListInput** | **GetDingTalkCurrentEmployeesListInput**|  | |
| **accessToken** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkBaseResponseGetDingTalkCurrentEmployeesListOutput**

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

# **apiDingTalkDingTalkCurrentEmployeesRosterListAccessTokenPost**
> RESTfulResultDingTalkBaseResponseListDingTalkEmpRosterFieldVo apiDingTalkDingTalkCurrentEmployeesRosterListAccessTokenPost(getDingTalkCurrentEmployeesRosterListInput)


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    GetDingTalkCurrentEmployeesRosterListInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let accessToken: string; // (default to undefined)
let getDingTalkCurrentEmployeesRosterListInput: GetDingTalkCurrentEmployeesRosterListInput; //

const { status, data } = await apiInstance.apiDingTalkDingTalkCurrentEmployeesRosterListAccessTokenPost(
    accessToken,
    getDingTalkCurrentEmployeesRosterListInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **getDingTalkCurrentEmployeesRosterListInput** | **GetDingTalkCurrentEmployeesRosterListInput**|  | |
| **accessToken** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkBaseResponseListDingTalkEmpRosterFieldVo**

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

# **apiDingTalkDingTalkSendInteractiveCardsTokenPost**
> RESTfulResultDingTalkSendInteractiveCardsOutput apiDingTalkDingTalkSendInteractiveCardsTokenPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    DingTalkSendInteractiveCardsInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let token: string; // (default to undefined)
let dingTalkSendInteractiveCardsInput: DingTalkSendInteractiveCardsInput; // (optional)

const { status, data } = await apiInstance.apiDingTalkDingTalkSendInteractiveCardsTokenPost(
    token,
    dingTalkSendInteractiveCardsInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkSendInteractiveCardsInput** | **DingTalkSendInteractiveCardsInput**|  | |
| **token** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkSendInteractiveCardsOutput**

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

# **apiDingTalkDingTalkTokenGet**
> RESTfulResultGetDingTalkTokenOutput apiDingTalkDingTalkTokenGet()


### Example

```typescript
import {
    DingTalkApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

const { status, data } = await apiInstance.apiDingTalkDingTalkTokenGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**RESTfulResultGetDingTalkTokenOutput**

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

# **apiDingTalkDingTalkWorkflowProcessInstancesTokenInputPost**
> RESTfulResultDingTalkGetProcessInstancesOutput apiDingTalkDingTalkWorkflowProcessInstancesTokenInputPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let token: string; // (default to undefined)
let input: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkDingTalkWorkflowProcessInstancesTokenInputPost(
    token,
    input
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **token** | [**string**] |  | defaults to undefined|
| **input** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkGetProcessInstancesOutput**

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

# **apiDingTalkDingTalkWorkflowProcessInstancesTokenPost**
> RESTfulResultDingTalkWorkflowProcessInstancesOutput apiDingTalkDingTalkWorkflowProcessInstancesTokenPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    DingTalkWorkflowProcessInstancesInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let token: string; // (default to undefined)
let dingTalkWorkflowProcessInstancesInput: DingTalkWorkflowProcessInstancesInput; // (optional)

const { status, data } = await apiInstance.apiDingTalkDingTalkWorkflowProcessInstancesTokenPost(
    token,
    dingTalkWorkflowProcessInstancesInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkWorkflowProcessInstancesInput** | **DingTalkWorkflowProcessInstancesInput**|  | |
| **token** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkWorkflowProcessInstancesOutput**

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

# **apiDingTalkStartApprovalTenantidPost**
> RESTfulResultDingTalkWorkflowProcessInstancesOutput apiDingTalkStartApprovalTenantidPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration,
    DingTalkWorkflowProcessInstancesInput
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let tenantid: string; // (default to undefined)
let dingTalkWorkflowProcessInstancesInput: DingTalkWorkflowProcessInstancesInput; // (optional)

const { status, data } = await apiInstance.apiDingTalkStartApprovalTenantidPost(
    tenantid,
    dingTalkWorkflowProcessInstancesInput
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **dingTalkWorkflowProcessInstancesInput** | **DingTalkWorkflowProcessInstancesInput**|  | |
| **tenantid** | [**string**] |  | defaults to undefined|


### Return type

**RESTfulResultDingTalkWorkflowProcessInstancesOutput**

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

# **apiDingTalkSyncOrganizationTenantidPost**
> apiDingTalkSyncOrganizationTenantidPost()


### Example

```typescript
import {
    DingTalkApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new DingTalkApi(configuration);

let tenantid: string; // (default to undefined)

const { status, data } = await apiInstance.apiDingTalkSyncOrganizationTenantidPost(
    tenantid
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **tenantid** | [**string**] |  | defaults to undefined|


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

