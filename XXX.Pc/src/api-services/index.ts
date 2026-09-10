/**
 * Axios 1.9.0 + TypeScript
 * 适配 Swagger Generator typescript-axios
 */

import axios from "axios";

import type {
  AxiosInstance,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from "axios";
import { Configuration } from "./generated";
import { BASE_PATH, BaseAPI } from "./generated/base";
import { ElMessage } from "element-plus";

/**
 * 接口服务器配置
 */
export const serveConfig = new Configuration({
  basePath:
    import.meta.env.DEV
      ? "https://localhost:44342"
      : "https://localhost:44342",
});

/**
 * Token Key
 */
export const accessTokenKey = "access-token";
export const refreshAccessTokenKey = `x-${accessTokenKey}`;

/**
 * 清除 Token
 */
export const clearAccessTokens = () => {
  localStorage.removeItem(accessTokenKey);
  localStorage.removeItem(refreshAccessTokenKey);

  // 这里可以清除其他登录信息
};

/**
 * 抛出错误
 */
export const throwError = (message: string) => {
  ElMessage.error(message);
  throw new Error(message);
};

/**
 * Axios 实例
 */
export const axiosInstance: AxiosInstance = axios.create({
  timeout: 1000 * 60 * 10,
});

/**
 * ==============================
 * Axios 请求拦截
 * ==============================
 */
axiosInstance.interceptors.request.use(
  (config: InternalAxiosRequestConfig) => {
    const accessToken = localStorage.getItem(accessTokenKey);

    if (accessToken) {
      /**
       * Axios 1.x 推荐使用 set()
       */
      config.headers.set(
        "Authorization",
        `Bearer ${accessToken}`
      );

      /**
       * 判断 JWT 是否过期
       */
      try {
        const jwt = decryptJWT(accessToken);
        const exp = getJWTDate(jwt.exp);

        /**
         * AccessToken 已过期
         */
        if (new Date() >= exp) {
          const refreshAccessToken =
            localStorage.getItem(refreshAccessTokenKey);

          if (refreshAccessToken) {
            config.headers.set(
              "X-Authorization",
              `Bearer ${refreshAccessToken}`
            );
          }
        }
      } catch {
        // Token 无法解析，交给后端处理
      }
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

/**
 * ==============================
 * Axios 响应拦截
 * ==============================
 */
axiosInstance.interceptors.response.use(
  (res: AxiosResponse) => {
    /**
     * 检查并存储 Token
     */
    checkAndStoreAuthentication(res);

    /**
     * Furion 规范化错误
     *
     * {
     *   errors: "401 Unauthorized"
     * }
     */
    const serve = res.data;

    if (
      serve &&
      Object.prototype.hasOwnProperty.call(serve, "errors") &&
      serve.errors
    ) {
      if (serve.errors === "401 Unauthorized") {
        clearAccessTokens();
      }

      throwError(
        typeof serve.errors === "string"
          ? serve.errors
          : JSON.stringify(serve.errors)
      );
    }

    return res;
  },
  (error) => {
    /**
     * HTTP 错误
     */
    if (error.response) {
      const res = error.response;
      const status: number = res.status;

      /**
       * 检查 Token
       */
      checkAndStoreAuthentication(res);

      /**
       * 401
       */
      if (status === 401) {
        clearAccessTokens();
      }
    }

    return Promise.reject(error);
  }
);

/**
 * ==============================
 * 检查并保存 Token
 * ==============================
 */
export function checkAndStoreAuthentication(
  res: AxiosResponse
): void {
  const accessToken =
    res.headers[accessTokenKey];

  const refreshAccessToken =
    res.headers[refreshAccessTokenKey];

  /**
   * Token 无效
   */
  if (accessToken === "invalid_token") {
    clearAccessTokens();
    return;
  }

  /**
   * 保存新的 Token
   */
  if (
    refreshAccessToken &&
    accessToken &&
    accessToken !== "invalid_token"
  ) {
    localStorage.setItem(
      accessTokenKey,
      accessToken
    );

    localStorage.setItem(
      refreshAccessTokenKey,
      refreshAccessToken
    );
  }
}

/**
 * ==============================
 * Promise 包装
 * ==============================
 */
export function feature<T, U = Error>(
  promise: Promise<T>,
  errorExt?: object
): Promise<[U, undefined] | [null, T]> {
  return promise
    .then<[null, T]>((data: T) => {
      return [null, data];
    })
    .catch<[U, undefined]>((err: U) => {
      if (errorExt) {
        const parsedError = Object.assign(
          {},
          err,
          errorExt
        );

        return [parsedError, undefined];
      }

      return [err, undefined];
    });
}

/**
 * ==============================
 * 获取 API 实例
 * ==============================
 */
export function getAPI<T extends BaseAPI>(
  apiType: new (
    configuration?: Configuration,
    basePath?: string,
    axiosInstance?: AxiosInstance
  ) => T,
  configuration: Configuration = serveConfig,
  basePath: string = BASE_PATH,
  axiosObject: AxiosInstance = axiosInstance
): T {
  return new apiType(
    configuration,
    basePath,
    axiosObject
  );
}

/**
 * ==============================
 * JWT 解码
 * ==============================
 */
export function decryptJWT(token: string): any {
  try {
    const base64Url = token.split(".")[1];

    if (!base64Url) {
      throw new Error("Invalid JWT");
    }

    const base64 = base64Url
      .replace(/-/g, "+")
      .replace(/_/g, "/");

    const json = decodeURIComponent(
      Array.prototype.map
        .call(
          window.atob(base64),
          (c: string) =>
            "%" +
            ("00" + c.charCodeAt(0).toString(16))
              .slice(-2)
        )
        .join("")
    );

    return JSON.parse(json);
  } catch {
    throw new Error("Invalid JWT token");
  }
}

/**
 * ==============================
 * JWT 时间
 * ==============================
 */
export function getJWTDate(timestamp: number): Date {
  return new Date(timestamp * 1000);
}

/**
 * ==============================
 * 获取当前 Token 信息
 * ==============================
 */
export function getAccessInfo(): any {
  const accessToken =
    localStorage.getItem(accessTokenKey);

  if (!accessToken) {
    return null;
  }

  try {
    return decryptJWT(accessToken);
  } catch {
    return null;
  }
}

/**
 * ==============================
 * 延迟
 * ==============================
 */
export function sleep(delay: number): Promise<void> {
  return new Promise((resolve) =>
    setTimeout(resolve, delay)
  );
}


export const getPageListByUrl=(url:string,pageListPars:any)=>axios.post(url,pageListPars)
export const getPageOptionByUrl=(url:string)=>axios.post(url)
export const getPageRenderByUrl=(url:string,pars:any)=>axios.post(url,pars)


