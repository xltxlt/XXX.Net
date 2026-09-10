import { SysCodeStatus } from "@/api-services/apiCodeStatus"
import { ElMessage, ElMessageBox } from "element-plus"
import { isFunction } from "./is"
export function getUuid(): string {
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
    const r = Math.random() * 16 | 0
    const v = c === 'x' ? r : (r & 0x3 | 0x8)
    return v.toString(16)
  })
}
/**
 * 统一处理提交操作的返回
 * @param res 
 * @param cb 
 * @returns 
 */
export const handleSumbitResTip = (res: any, successMsg?: string, cb?: Function, errorCb?: Function) => {
  if (res.data.statusCode == SysCodeStatus.Ok.code) {
    ElMessage({
      message: successMsg ? successMsg : res.message,
      type: 'success',
      plain: true,
    })
    cb && cb(res);
    return;
  }
  ElMessage({
    message: res.message,
    type: 'error',
    plain: true,
  })
  errorCb && errorCb(res);
  return;
}
/**
 * 统一处理提交操作的返回
 * @param res 
 * @param cb 
 * @returns 
 */
export const handleSumbitResBox = (res: any, successMsg?: string, cb?: Function, errorCb?: Function) => {
  if (res.data.statusCode == SysCodeStatus.Ok.code) {
    ElMessageBox.alert(successMsg ? successMsg : res.message, '提示', {
      showClose: false,
      callback: () => {
        cb && cb(res);
      }
    })
    return;
  }
  ElMessage({
    message: res.message,
    type: 'error',
    plain: true,
  })
  errorCb && errorCb(res);
  return;
}
/**
 * 
 * @param msg 
 * @param confirmCb 
 * @param cancel 
 * @param btns 
 */
export const yzPrompt = (msg: string, confirmCb?: Function, cancelCb?: Function, btns?: string[]) => {
  ElMessageBox.prompt(msg, '提示', {
    confirmButtonText: btns ? btns[0] : '确认',
    cancelButtonText: btns ? btns[1] : '取消',
  })
    .then(({ value }) => {
      confirmCb && confirmCb(value);
    })
    .catch(() => {
      cancelCb && cancelCb();
    })
}

export function downloadFileByUrl(url: string, filename?: string) {
  const link = document.createElement('a');
  link.href = url;
  link.download = filename ?? '';
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
}

/**
 * 在树形数据中查找节点的完整路径
 * @param nodes 树形数据数组
 * @param targetValue 要查找的目标值
 * @param currentPath 当前路径（递归内部使用）
 * @returns 包含所有父级value的数组，如 ["33", "46"]
 */
export function findNodePath(
  nodes: any[],
  targetValue: string | number,
  currentPath: string[] = []
): string[] | null {
  for (const node of nodes) {
    const newPath = [...currentPath, String(node.value)];

    // 如果当前节点匹配
    if (String(node.value) === String(targetValue)) {
      return newPath;
    }

    // 递归检查子节点
    if (Array.isArray(node.children)) {
      const foundPath = findNodePath(node.children, targetValue, newPath);
      if (foundPath) return foundPath;
    }
  }

  return null; // 未找到
}

export const getStatusLabel = (
  status: unknown,
  statusConfig: Record<number, { label: string; color: string }>
): string => {
  if (status === null || status === undefined) return '未知状态';
  const key = Number(status);
  if (Number.isNaN(key) || !(key in statusConfig)) return '未知状态';
  return statusConfig[key].label;
};

export const getStatusColor = (
  status: unknown,
  statusConfig: Record<number, { label: string; color: string }>
): string => {
  if (status === null || status === undefined) return '#999';
  const key = Number(status);
  if (Number.isNaN(key) || !(key in statusConfig)) return '#999';
  return statusConfig[key].color;
};

/**
 * 获取当前日期
 * @returns 当前日期
 */
export function getNowDate() {
  const now = new Date();
  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0');
  const day = String(now.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

/**
 * 获取当前日期和时间
 * @returns 当前日期时间字符串，格式为 "YYYY-MM-DD HH:mm"
 */
export function getNowDateTime() {
  const now = new Date();
  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0');
  const day = String(now.getDate()).padStart(2, '0');
  const hour = String(now.getHours()).padStart(2, '0');
  const minute = String(now.getMinutes()).padStart(2, '0');
  return `${year}-${month}-${day} ${hour}:${minute}`;
}
/**
 * 获取当前日期和时间
 * @returns 当前日期时间字符串，格式为 "YYYYMMDDHHmmss"
 */
export function getDateTime() {
  const now = new Date();
  const year = now.getFullYear();
  const month = String(now.getMonth() + 1).padStart(2, '0');
  const day = String(now.getDate()).padStart(2, '0');
  const hour = String(now.getHours()).padStart(2, '0');
  const minute = String(now.getMinutes()).padStart(2, '0');
  const second = String(now.getSeconds()).padStart(2, '0');

  return `${year}${month}${day}${hour}${minute}${second}`;
}
export async function copySysData(data: any, cb: Function) {
  if (!data || data.length == 0) {
    ElMessage.error("请选择数据");
    return;
  }
  const dataList: any[] = [];
  if (isFunction(cb)) {
    // 并发执行所有cb，等待全部完成
    const results = await Promise.all(
      data.map(async (item: any) => {
        const newData = await cb(item.id);
        return newData ? { ...newData, id: null } : null;
      })
    );
    results.forEach(res => {
      if (res) dataList.push(res);
    });
  } else {
    data.forEach((item: any) => {
      dataList.push({ ...item, id: null });
    });
  }
  const jsonText = JSON.stringify(dataList.sort(a => a.sortNum ?? 99));
  console.log(jsonText);
  navigator.clipboard.writeText(jsonText).then(() => {
    ElMessage.success("已复制JSON文本");
  }).catch(() => {
    ElMessage.error("复制失败");
  });
}

/**
 * 下载文件
 * @param response 
 * @param fileName 
 */
export async function downloadFile(response: any, fileName?: string) {
  try {
    // 从响应头获取文件名
    if (!fileName) {
      const disposition = response.headers['content-disposition'];
      if (disposition) {
        const filenameRegex = /filename[^;=\n]*=((['"]).*?\2|[^;\n]*)/;
        const matches = filenameRegex.exec(disposition);
        if (matches != null && matches[1]) {
          fileName = matches[1].replace(/['"]/g, '');
        }
      }
    }

    // 如果仍然没有文件名，使用默认名称
    if (!fileName) {
      fileName = getDateTime() + '.xlsx';;
    }

    // 创建下载链接
    const blob = new Blob([response.data]);
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = fileName;

    // 触发下载
    document.body.appendChild(link);
    link.click();

    // 清理
    window.URL.revokeObjectURL(link.href);
    document.body.removeChild(link);
  }
  catch (error) {
    console.error('下载文件失败：', error);
  }
}
/**
 * 生成唯一值（UUID v4 简易版）
 * @returns 唯一字符串
 */
export function getUniqueValue(): string {
  return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
    const r = (Math.random() * 16) | 0;
    const v = c === 'x' ? r : (r & 0x3) | 0x8;
    return v.toString(16);
  });
}
/**
 * 首字母大写
 * @param str 
 * @returns 
 */
export function capitalize(str: string): string {
  if (!str) return str
  return str[0]!.toUpperCase() + str.slice(1)
}