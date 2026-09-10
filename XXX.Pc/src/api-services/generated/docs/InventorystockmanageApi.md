# InventorystockmanageApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventorystockmanageAdjustPost**](#apiinventorystockmanageadjustpost) | **POST** /api/inventorystockmanage/adjust | 库存调整|
|[**apiInventorystockmanageGetPost**](#apiinventorystockmanagegetpost) | **POST** /api/inventorystockmanage/get | 获取库存|
|[**apiInventorystockmanageListPost**](#apiinventorystockmanagelistpost) | **POST** /api/inventorystockmanage/list | 库存列表|
|[**apiInventorystockmanageLockPost**](#apiinventorystockmanagelockpost) | **POST** /api/inventorystockmanage/lock | 锁定库存|
|[**apiInventorystockmanageStockinPost**](#apiinventorystockmanagestockinpost) | **POST** /api/inventorystockmanage/stockin | 入库|
|[**apiInventorystockmanageStockoutPost**](#apiinventorystockmanagestockoutpost) | **POST** /api/inventorystockmanage/stockout | 出库|
|[**apiInventorystockmanageTransferPost**](#apiinventorystockmanagetransferpost) | **POST** /api/inventorystockmanage/transfer | 调拨|
|[**apiInventorystockmanageUnlockPost**](#apiinventorystockmanageunlockpost) | **POST** /api/inventorystockmanage/unlock | 解锁库存|

# **apiInventorystockmanageAdjustPost**
> apiInventorystockmanageAdjustPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockAdjustRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockAdjustRequest: StockAdjustRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageAdjustPost(
    stockAdjustRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockAdjustRequest** | **StockAdjustRequest**|  | |


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

# **apiInventorystockmanageGetPost**
> RESTfulResultInventoryStockDto apiInventorystockmanageGetPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    InventoryStockQueryDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let inventoryStockQueryDto: InventoryStockQueryDto; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageGetPost(
    inventoryStockQueryDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockQueryDto** | **InventoryStockQueryDto**|  | |


### Return type

**RESTfulResultInventoryStockDto**

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

# **apiInventorystockmanageListPost**
> RESTfulResultListInventoryStockDto apiInventorystockmanageListPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    InventoryStockQueryDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let inventoryStockQueryDto: InventoryStockQueryDto; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageListPost(
    inventoryStockQueryDto
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **inventoryStockQueryDto** | **InventoryStockQueryDto**|  | |


### Return type

**RESTfulResultListInventoryStockDto**

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

# **apiInventorystockmanageLockPost**
> apiInventorystockmanageLockPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockLockRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockLockRequest: StockLockRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageLockPost(
    stockLockRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockLockRequest** | **StockLockRequest**|  | |


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

# **apiInventorystockmanageStockinPost**
> apiInventorystockmanageStockinPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockInRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockInRequest: StockInRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageStockinPost(
    stockInRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockInRequest** | **StockInRequest**|  | |


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

# **apiInventorystockmanageStockoutPost**
> apiInventorystockmanageStockoutPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockOutRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockOutRequest: StockOutRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageStockoutPost(
    stockOutRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockOutRequest** | **StockOutRequest**|  | |


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

# **apiInventorystockmanageTransferPost**
> apiInventorystockmanageTransferPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockTransferRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockTransferRequest: StockTransferRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageTransferPost(
    stockTransferRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockTransferRequest** | **StockTransferRequest**|  | |


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

# **apiInventorystockmanageUnlockPost**
> apiInventorystockmanageUnlockPost()


### Example

```typescript
import {
    InventorystockmanageApi,
    Configuration,
    StockLockRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockmanageApi(configuration);

let stockLockRequest: StockLockRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockmanageUnlockPost(
    stockLockRequest
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **stockLockRequest** | **StockLockRequest**|  | |


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

