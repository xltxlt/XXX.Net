import type { RouteRecordRaw } from 'vue-router'

const formRoutes: Array<RouteRecordRaw> = [
  {
    path: '/page-form/designer',
    name: 'pageFormDesigner',
    component: () => import('@/views/PageForm/PageFormDesigner.vue'),
  },
]

export default formRoutes
