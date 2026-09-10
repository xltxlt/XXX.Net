# LoginVo


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**accessToken** | **string** | 令牌 | [optional] [default to undefined]
**refreshToken** | **string** | 刷新令牌 | [optional] [default to undefined]
**homepage** | **string** | 首页 | [optional] [default to undefined]
**userInfo** | [**LoginUserInfo**](LoginUserInfo.md) |  | [optional] [default to undefined]

## Example

```typescript
import { LoginVo } from './api';

const instance: LoginVo = {
    accessToken,
    refreshToken,
    homepage,
    userInfo,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
