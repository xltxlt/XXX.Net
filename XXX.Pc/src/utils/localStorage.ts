// src/utils/localStorage.ts
/**
 * 设置 localStorage
 * @param key 键名
 * @param value 值（支持对象和字符串）
 */
export function setLocal(key: string, value: any): void {
    const data = typeof value === 'string' ? value : JSON.stringify(value)
    window.localStorage.setItem(key, data)
}

/**
 * 获取 localStorage
 * @param key 键名
 * @returns 字符串或对象，未找到返回 null
 */
export function getLocal<T = any>(key: string): T | null {
    const data = window.localStorage.getItem(key)
    if (data === null) return null
    try {
        return JSON.parse(data) as T
    } catch {
        return data as unknown as T
    }
}

/**
 * 删除 localStorage
 * @param key 键名
 */
export function removeLocal(key: string): void {
    window.localStorage.removeItem(key)
}

/**
 * 清空所有 localStorage
 */
export function clearLocal(): void {
    window.localStorage.clear()
}
