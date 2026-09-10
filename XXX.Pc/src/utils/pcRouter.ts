import { useRoute } from 'vue-router'

/**
 * 获取当前路由参数
 * @param type 'query' | 'params' | 'all'
 * @returns 对应的参数对象
 */
export function getRouterParams(type: 'query' | 'params' | 'all' = 'all') {
  const route = useRoute()
  if (type === 'query') return route.query
  if (type === 'params') return route.params
  return { ...route.params, ...route.query }
}
export function getParByName(key: string) {
  const val = getRouterParams('params')[key];
  if (Array.isArray(val)) {
    return val[0] ?? '';
  }
  return typeof val === 'string' ? val : '';
}
/**
 * 获取指定 query 参数的值
 * @param key 参数名
 * @returns 参数值（string 或空字符串）
 */
export function getQueryByName(key: string): string {
  const query = getRouterParams('query')
  const val = query[key]
  if (Array.isArray(val)) {
    return val[0] ?? ''
  }
  return typeof val === 'string' ? val : ''
}