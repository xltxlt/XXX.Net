// src/utils/cookie.ts

import { is, isEmptyVal } from "./is"

/**
 * 设置 Cookie
 * @param name 名称
 * @param value 值
 * @param days 过期天数，默认 7 天
 */
export function setCookie(name: string, value: string, days = 7, domain: string = ''): void {
    const expires = new Date(Date.now() + days * 864e5).toUTCString()
    document.cookie = `${encodeURIComponent(name)}=${encodeURIComponent(value)}; expires=${expires}; path=/;${isEmptyVal(domain) ? '' : ' domain=' + domain}`
}

/**
 * 获取 Cookie
 * @param name 名称
 * @returns 值或 null
 */
export function getCookie(name: string): string | null {
    const match = document.cookie.match(
        new RegExp('(?:^|; )' + encodeURIComponent(name) + '=([^;]*)')
    )
    return match ? decodeURIComponent(match[1]) : null
}

/**
 * 删除 Cookie
 * @param name 名称
 */
export function delCookie(name: string, domain: string = ''): void {
    setCookie(name, '', -1, domain)
}
