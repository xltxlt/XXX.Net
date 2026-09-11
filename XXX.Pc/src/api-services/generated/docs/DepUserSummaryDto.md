# DepUserSummaryDto


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**id** | **string** |  | [optional] [default to undefined]
**name** | **string** |  | [optional] [default to undefined]
**shortName** | **string** |  | [optional] [default to undefined]
**code** | **string** |  | [optional] [default to undefined]
**parentId** | **string** |  | [optional] [default to undefined]
**leaderUserId** | **string** |  | [optional] [default to undefined]
**sort** | **number** |  | [optional] [default to undefined]
**userCount** | **number** | 当前部门用户数 | [optional] [default to undefined]
**depCount** | **number** | 子部门数量 | [optional] [default to undefined]

## Example

```typescript
import { DepUserSummaryDto } from './api';

const instance: DepUserSummaryDto = {
    id,
    name,
    shortName,
    code,
    parentId,
    leaderUserId,
    sort,
    userCount,
    depCount,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
