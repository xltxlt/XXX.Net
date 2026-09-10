import { createRouter, createWebHashHistory } from "vue-router";
import type { RouteRecordRaw } from "vue-router";
import systemRoutes from "./modules/system";
import matterRoutes from "./modules/matter";
import pmRoutes from "./modules/pm";
import workflowRoutes from "./modules/workflow";
import inventoryRoutes from "./modules/inventory";
import formRoutes from "./modules/form";
const routes: Array<RouteRecordRaw> = [
    {
        path: '/',
        redirect: '/login'
    },
    {
        path: '/login',
        name: 'Login',
        component: () => import('@/views/Login/Login.vue')
    },
    {
        path: '/Home',
        name: 'Home',
        component: () => import('@/views/Home/Home.vue'),

        children: [
            {
                path: '/:pathMatch(.*)*',
                name: 'NotFound',
                component: () => import('@/views/404/404.vue')
            },
           
            // {
            //     path: 'Role',
            //     name: "Role",
            //     component: () => import('@/views/Role/Role.vue'),
            // }, 
            // {
            //     path: 'Role',
            //     name: "Role",
            //     component: () => import('@/views/Flow/Handle/FlowDesign.vue'),
            // },
            {
                path: 'DataDic',
                name: "DataDic",
                component: () => import('@/views/DataDic/DataDic.vue'),
            }
            ,
            ...inventoryRoutes,
            ...formRoutes,
            ...systemRoutes,
            ...matterRoutes,
            ...pmRoutes,
            ...workflowRoutes,
        ]
    },
]
const router = createRouter({
    history: createWebHashHistory(),
    routes
})
export default router