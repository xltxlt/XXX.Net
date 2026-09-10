# StockTransferRequest


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**tenantId** | **string** |  | [optional] [default to undefined]
**domainId** | **string** |  | [optional] [default to undefined]
**itemId** | **string** |  | [optional] [default to undefined]
**fromWarehouseId** | **string** |  | [optional] [default to undefined]
**toWarehouseId** | **string** |  | [optional] [default to undefined]
**fromLocationId** | **string** |  | [optional] [default to undefined]
**toLocationId** | **string** |  | [optional] [default to undefined]
**quantity** | **number** |  | [optional] [default to undefined]
**businessKey** | **string** |  | [optional] [default to undefined]
**remark** | **string** |  | [optional] [default to undefined]

## Example

```typescript
import { StockTransferRequest } from './api';

const instance: StockTransferRequest = {
    tenantId,
    domainId,
    itemId,
    fromWarehouseId,
    toWarehouseId,
    fromLocationId,
    toLocationId,
    quantity,
    businessKey,
    remark,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
