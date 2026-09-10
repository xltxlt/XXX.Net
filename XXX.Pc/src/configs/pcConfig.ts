const isDev = import.meta.env.MODE === 'development';

// 从全局配置获取或者使用默认值
const appConfig = (window as any).__APP_CONFIG__ || {};

export const baseApiURL = appConfig.baseApiURL || 'http://localhost:5287/'
export const baseUrl = appConfig.baseUrl || 'http://localhost:5287/'

export const viewsUrl=`${baseUrl}/#`

export const uploadPrivateUrl=`${baseApiURL}resource-center/api/file/upload`
export const uploadPubilcUrl=`${baseApiURL}resource-center/api/file/public/upload`