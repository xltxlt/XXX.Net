# InventorystockApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**apiInventorystockAdjustPost**](#apiinventorystockadjustpost) | **POST** /api/inventorystock/adjust | 库存调整|
|[**apiInventorystockGetPost**](#apiinventorystockgetpost) | **POST** /api/inventorystock/get | 获取库存|
|[**apiInventorystockListPost**](#apiinventorystocklistpost) | **POST** /api/inventorystock/list | 库存列表|
|[**apiInventorystockLockPost**](#apiinventorystocklockpost) | **POST** /api/inventorystock/lock | 锁定库存|
|[**apiInventorystockStockinPost**](#apiinventorystockstockinpost) | **POST** /api/inventorystock/stockin | 入库|
|[**apiInventorystockStockoutPost**](#apiinventorystockstockoutpost) | **POST** /api/inventorystock/stockout | 出库|
|[**apiInventorystockTransferPost**](#apiinventorystocktransferpost) | **POST** /api/inventorystock/transfer | 调拨|
|[**apiInventorystockUnlockPost**](#apiinventorystockunlockpost) | **POST** /api/inventorystock/unlock | 解锁库存|

# **apiInventorystockAdjustPost**
> apiInventorystockAdjustPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockAdjustRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockAdjustRequest: StockAdjustRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockAdjustPost(
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

# **apiInventorystockGetPost**
> RESTfulResultInventoryStockDto apiInventorystockGetPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    InventoryStockQueryDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let inventoryStockQueryDto: InventoryStockQueryDto; // (optional)

const { status, data } = await apiInstance.apiInventorystockGetPost(
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

# **apiInventorystockListPost**
> RESTfulResultListInventoryStockDto apiInventorystockListPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    InventoryStockQueryDto
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let inventoryStockQueryDto: InventoryStockQueryDto; // (optional)

const { status, data } = await apiInstance.apiInventorystockListPost(
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

# **apiInventorystockLockPost**
> apiInventorystockLockPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockLockRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockLockRequest: StockLockRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockLockPost(
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

# **apiInventorystockStockinPost**
> apiInventorystockStockinPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockInRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockInRequest: StockInRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockStockinPost(
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

# **apiInventorystockStockoutPost**
> apiInventorystockStockoutPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockOutRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockOutRequest: StockOutRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockStockoutPost(
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

# **apiInventorystockTransferPost**
> apiInventorystockTransferPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockTransferRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockTransferRequest: StockTransferRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockTransferPost(
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

# **apiInventorystockUnlockPost**
> apiInventorystockUnlockPost()


### Example

```typescript
import {
    InventorystockApi,
    Configuration,
    StockLockRequest
} from './api';

const configuration = new Configuration();
const apiInstance = new InventorystockApi(configuration);

let stockLockRequest: StockLockRequest; // (optional)

const { status, data } = await apiInstance.apiInventorystockUnlockPost(
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

