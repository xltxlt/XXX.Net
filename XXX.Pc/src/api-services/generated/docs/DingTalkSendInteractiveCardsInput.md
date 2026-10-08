# DingTalkSendInteractiveCardsInput


## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**cardTemplateId** | **string** |  | [default to undefined]
**openConversationId** | **string** |  | [optional] [default to undefined]
**receiverUserIdList** | **Array&lt;string&gt;** |  | [default to undefined]
**outTrackId** | **string** |  | [default to undefined]
**robotCode** | **string** |  | [optional] [default to undefined]
**conversationType** | [**DingTalkConversationTypeEnum**](DingTalkConversationTypeEnum.md) |  | [default to undefined]
**callbackRouteKey** | **string** |  | [optional] [default to undefined]
**cardData** | [**DingTalkCardData**](DingTalkCardData.md) |  | [default to undefined]

## Example

```typescript
import { DingTalkSendInteractiveCardsInput } from './api';

const instance: DingTalkSendInteractiveCardsInput = {
    cardTemplateId,
    openConversationId,
    receiverUserIdList,
    outTrackId,
    robotCode,
    conversationType,
    callbackRouteKey,
    cardData,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
