import type { RouteRecordRaw } from "vue-router";

const systemRoutes: Array<RouteRecordRaw> = [
    {
        path: '/sys/menu',
        name: "menu",
        component: () => import('@/views/Sys/Menu/Menu.vue'),
    },
    {
        path: '/sys/user',
        name: "user",
        component: () => import('@/views/Sys/User/User.vue'),
    },
    {
        path: '/sys/role',
        name: "role",
        component: () => import('@/views/Sys/Role/Role.vue'),
    },
    {
        path: '/sys/generate',
        name: "generate",
        component: () => import('@/views/Sys/Generate/Generate.vue'),
    },
    {
        path: '/sys/config',
        name: "config",
        component: () => import('@/views/Sys/Config/Config.vue'),
    },
    {
        path: '/sys/position',
        name: "position",
        component: () => import('@/views/Sys/Position/Position.vue'),
    },
    {
        path: '/sys/dep',
        name: "dep",
        component: () => import('@/views/Sys/Dep/Dep.vue'),
    },
     {
        path: '/sys/dict',
        name: "dict",
        component: () => import('@/views/Sys/Dict/DictType.vue'),
    },
    {
        path: '/sys/tenant',
        name: "tenant",
        component: () => import('@/views/Sys/Tenant/Tenant.vue'),
    },
    {
        path: '/sys/document',
        name: "document",
        component: () => import('@/views/Sys/Document/Document.vue'),
    },
{
        path: '/sys/tenantDep',
        name: "tenantDep",
        component: () => import('@/views/Sys/Dep/TenantDep.vue'),
    },


    
]

export default systemRoutes