// src/api/common/oss.ts
import OSS from 'ali-oss'
import { post, uploadFile } from '@/axios/index'
import { useStsStore } from '@/store/modules/sts'
import { ossBucket, ossRegion } from '@/configs/pcConfig'
import type { UploadRequestOptions } from 'element-plus'
import { uploadPrivateUrl, uploadPubilcUrl } from '@/configs/pcConfig'
import { downloadFileByUrl } from '@/utils/common'
import imageCompression from 'browser-image-compression'
import { isEmptyVal } from '@/utils/is'
import { ElLoading } from 'element-plus'

const getStsToken = async () => {
  const stsStore = useStsStore()
  const now = Date.now()
  // 判断缓存是否有效（提前2分钟刷新）
  if (
    stsStore.token &&
    stsStore.token.expiration &&
    now < stsStore.token.expiration - 120 * 1000
  ) {
    return stsStore.token
  }
  const response = await post('auth-center/api/oss/sts/token/get')
    .then((res) => {
      if (res.code != 200) {
        alert(res.message);
      }
      return res;
    }).catch((err) => {
      console.log(err)
    });
  const token = response.data
  stsStore.setToken(token)
  return response.data;
}

/**
 * 创建 OSS 客户端
 * @param config 阿里云 OSS 配置信息
 */
export async function getOssClient(config: {
  region?: string
  bucket?: string
}) {
  const res = await getStsToken();
  return new OSS({
    region: config.region ?? ossRegion,
    accessKeyId: res.accessKeyId,
    accessKeySecret: res.accessKeySecret,
    bucket: config.bucket ?? ossBucket,
    stsToken: res.securityToken, // 如果用STS临时授权
    secure: true
  })
}

/**
 * 上传文件到 OSS
 * @param client OSS 客户端
 * @param file 文件对象（File/blob/Buffer）
 * @param bucket 桶
 * @param region 地域
 */
export async function uploadFileToOss(file: File, objectKey: string, bucket?: string, region?: string) {
  const client = await getOssClient({
    bucket: bucket ?? 'ld-tt',
    region: region ?? 'oss-cn-hangzhou'
  })
  // objectKey 例如 'folder/filename.jpg'
  // 对于大文件使用分片上传
  if (file.size > 100 * 1024 * 1024) { // 大于100MB
    return await client.multipartUpload(objectKey, file, {
      progress: (p) => console.log('上传进度:', p),
      partSize: 1024 * 1024 // 每片1MB
    });
  } else {
    const result = await client.put(objectKey, file)
    return result.url
  }
}

/**
 * 上传文件到 服务器
 * @param client OSS 客户端
 * @param bucket 桶
 * @param region 地域
 */
export async function uploadFileToService(file: File, objectKey: string, publicOss: boolean = false, oldUid: Number = Date.now()) {
  // objectKey 例如 'folder/filename.jpg'
  const result = await uploadFile(publicOss === true ? uploadPubilcUrl : uploadPrivateUrl, file, { path: objectKey })
  if (publicOss === true) {
    if (result.code === 200) {
      const url = result.data; // 上传后文件的公网地址
      const ossFileObj = parseOssUrlWithProtocol(decodeURIComponent(url));
      console.log(ossFileObj)
      const obj = {
        name: ossFileObj.filename,
        url: url,
        ossUrl: url,
        message: '上传成功',
        oldUid,
        uid: Date.now(),
        status: 'success'
      }
      return obj;
    }
    else {
      return {
        name: file.name,
        message: result.message,
        status: 'error',
        sourceUrl: '',
        oosUrl: '',
        oldUid,
        uid: Date.now()
      }
    }
    return;
  }
  if (result.code === 200) {
    const url = result.data; // 上传后文件的公网地址
    const ossFileObj = parseOssUrlWithProtocol(decodeURIComponent(url));
    const ossUrl = (await getOssSignedAllUrl(ossFileObj.url));
    const obj = {
      name: ossFileObj.filename,
      url: url,
      ossUrl: ossUrl,
      message: '上传成功',
      uid: Date.now(),
      oldUid,
      status: 'success'
    }
    return obj;
  }
  else {
    return {
      name: file.name,
      message: result.message,
      status: 'error',
      sourceUrl: '',
      oldUid,
      oosUrl: '',
      uid: Date.now()
    }
  }

}
// 修改错误类型定义，将 status 设为必填
interface CustomUploadError extends Error {
  status: number; // 修改为必填
  method: string;
  url: string;
}

/**
 * 适配 el-upload 的自定义上传方法，上传到 OSS
 */
export async function elUploadToOss(options: UploadRequestOptions, path?: string, publicOss: boolean = false) {
  const { file, onSuccess, onError, onProgress } = options
  let loadingInstance: any = null;
  try {
    // 生成唯一文件名，可根据实际需求自定义
    const ext = (file as File).name.split('.').pop()
    const objectKey = `${isEmptyVal(path) ? 'uploads' : path}/${Date.now()}_${Math.random().toString(36).slice(2)}.${ext}`
    
    loadingInstance = ElLoading.service({
      lock: true,
      text: '上传中...',
      background: 'rgba(0, 0, 0, 0.1)',
    });
    // 上传到 OSS
    const client = await getOssClient({
      bucket: publicOss ? 'ldbj-pubilc-files' : 'ld-tt',
      region: 'oss-cn-hangzhou'
    });
    const result = await client.put(objectKey, file);
    if (result.res.status === 200) {
      if (onSuccess) onSuccess(result);
      const url = result.url;
      let ossUrl = url;
      console.log(result)
      const ossFileObj = parseOssUrlWithProtocol(decodeURIComponent(url));
      const name = ossFileObj.filename;
      if (!publicOss) {
        ossUrl = (await getOssSignedAllUrl(ossFileObj.url));
      }

      console.log({
        name: name,
        url: url,
        ossUrl: ossUrl,
        message: '上传成功',
        oldUid: options.file.uid ?? Date.now(),
        uid: Date.now(),
        status: 'success'
      })
      return {
        name: name,
        url: url,
        ossUrl: ossUrl,
        message: '上传成功',
        oldUid: options.file.uid ?? Date.now(),
        uid: Date.now(),
        status: 'success'
      }
    }
    else {
      return {
        name: file.name,
        message: '上传失败',
        status: 'error',
        sourceUrl: '',
        oosUrl: '',
        oldUid: options.file.uid ?? Date.now(),
        uid: Date.now()
      }
    }

  } catch (err) {
    if (onError) onError(err as any)
  } finally {
    loadingInstance.close();
    loadingInstance = null;
  }

}
/**
 * 上传文件至服务器识别
 * @param options 
 * @param type 识别类型 1: 身份证人像面 2: 身份证国徽面 3: 驾驶证正页 4: 驾驶证副页 5: 行驶证正页 6: 行驶证副页7: 银行卡 8: 从业资格证正面 9: 从业资格证副面 10: 道路运输证正面 11: 道路运输证反面 12: 道路运输经营许可证13: 行驶证年审页 14: 驾驶证电子版正页 15: 驾驶证电子版副页 16: 营业执照 25: 特种设备使用标志 26: 特种设备使用登记证 27: 手写文字识别 999: 自定义证件
 */
export async function elUploadToServiceDis(options: UploadRequestOptions, type: number) {
  const { file, onSuccess, onError, onProgress } = options
  try {
    // 生成唯一文件名，可根据实际需求自定义
    const ext = (file as File).name.split('.').pop();
    // // 压缩到2MB以下
    // if (file.size / 1024 / 1024 > 2) {
    //   try {
    //     const options = {
    //       maxSizeMB: 2,
    //       maxWidthOrHeight: 1920,
    //       useWebWorker: true
    //     }
    //     const compressedFile = await imageCompression(file, options)
    //   } catch (e) {
    //     ElMessage.error('图片压缩失败')
    //   }
    // }
    const res = await uploadCertificate(file, type);
    if (res.code != 200) {
      throw new Error(res);
    }
    return res.data;
  } catch (err) {
    if (onError) onError(err as any)
  }
}
/**
 * 通过文件的存储路径访问文件
 * @param objectKey /文件夹名/文件名
 * @param expires 过期时间，单位秒，默认3600秒
 * @param bucket 桶
 * @param region 地域
 * @returns 
 */
export async function getOssSignedUrl(objectKey: string, expires = 3600, bucket?: string, region?: string) {
  if (!objectKey) return '';
  const client = await getOssClient({
    bucket: bucket,
    region: region
  })
  return client.signatureUrl(objectKey, { expires })
}
/**
 * 通过 文件的完整路径访问文件
 * @param objectKey /文件夹名/文件名
 * @param expires 过期时间，单位秒，默认3600秒
 * @returns 
 */
export async function getOssSignedAllUrl(objectKey: string, expires = 3600) {
  objectKey = decodeURIComponent(objectKey);
  if (!objectKey.startsWith('http://') && !objectKey.startsWith('https://')) { return objectKey; }
  const config = parseOssUrl(objectKey);
  const client = await getOssClient({
    bucket: config.bucket,
    region: config.region
  })
  return client.signatureUrl(config.objectKey, { expires })
}
/**
 * 通过 文件的完整路径访问文件
 * @param objectKey /文件夹名/文件名
 * @param expires 过期时间，单位秒，默认3600秒
 * @returns 
 */
export function getOssUrl(objectKey: string, expires = 3600) {
  if (!objectKey.startsWith('http://') && !objectKey.startsWith('https://')) { return objectKey; }
  const config = parseOssUrl(objectKey);
  return getOssClient({
    bucket: config.bucket,
    region: config.region
  }).then((res) => {
    return res.signatureUrl(config.objectKey, { expires })
  })
}
export function parseOssUrl(url: string) {
  let match = url.match(/^https?:\/\/([^.]+)\.oss-([^.]+)\.aliyuncs\.com\/(.+)$/)
  if (match) {
    const bucket = match[1]
    const region = 'oss-' + match[2]
    const objectKey = match[3]
    return { bucket, region, objectKey }
  }
  match = url.match(/^https?:\/\/oss-([^.]+)\.aliyuncs\.com\/([^\/]+)\/(.+)$/);
  if (match) {
    return {
      bucket: match[2],
      region: 'oss-' + match[1],
      objectKey: match[3]
    };
  }
  return { bucket: '', region: '', objectKey: '' }
}
/**
 * 证件上传
 * @param file 
 * @param objectName 
 */
export async function uploadCertificate(file: File, type: number) {
  return await uploadFile('license-center/api/file/upload/Certificate', file, { type: type });
}

export function parseOssUrlWithProtocol(url: string): {
  fullDomain: string;
  prefix: string;
  url: string;
  filename: string;
} {

  // 匹配协议 + 域名部分，以及路径中的前两级（prefix + filename）
  const pattern = /^(\w+:\/\/[^\/]+)(?:\/([^\/?#]+))?\/?([^\/?#]*)/;
  const match = url.match(pattern);

  if (!match) {
    // throw new Error('Invalid OSS URL format');
    return {
      fullDomain: '',
      prefix: '',
      url: '',
      filename: '',
    };
  }

  const fullDomain = match[1];                   // 协议 + 域名
  const prefix = match[2] ? `/${match[2]}/` : '/'; // 路径前缀（如 /common/），如果没有则为根 /
  const encodedFilename = match[3];              // 文件名（URL 编码格式）
  console.log(match)
  return {
    fullDomain,
    prefix,
    filename: decodeURIComponent(encodedFilename), // 解码中文等字符
    url: `${fullDomain}${prefix}${encodedFilename}`,
  };
}


export async function perviewOssFile(url: string) {
  const config = parseOssUrlWithProtocol(url)
  const ossUrl = await getOssSignedAllUrl(url)
  downloadFileByUrl(ossUrl, config.filename)
}

export async function perviewFile(url: string) {

  const config = parseOssUrlWithProtocol(url)
  downloadFileByUrl(url, config.filename)
}