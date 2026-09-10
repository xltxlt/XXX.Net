# SysFileOutput



## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**fileId** | **string** | 文件ID（数据库主键） | [optional] [default to undefined]
**originalName** | **string** | 原始文件名 | [optional] [default to undefined]
**fileName** | **string** | 服务端存储文件名 | [optional] [default to undefined]
**url** | **string** | 文件访问URL | [optional] [default to undefined]
**fileSize** | **string** | 文件大小（bytes） | [optional] [default to undefined]
**contentType** | **string** | MIME类型 | [optional] [default to undefined]
**extension** | **string** | 文件扩展名 | [optional] [default to undefined]
**uploadTime** | **string** | 上传时间 | [optional] [default to undefined]

## Example

```typescript
import { SysFileOutput } from './api';

const instance: SysFileOutput = {
    fileId,
    originalName,
    fileName,
    url,
    fileSize,
    contentType,
    extension,
    uploadTime,
};
```

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
