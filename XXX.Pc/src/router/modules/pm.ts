import type { RouteRecordRaw } from "vue-router";

const pmRoutes: Array<RouteRecordRaw> = [

    {
        path: '/pm/pmFlowTemp',
        name: "PmFlowTemp",
        component: () => import('@/views/Pm/PmFlowTemp.vue'),
    },


    {
        path: '/pm/pmFlowItem',
        name: "PmFlowItem",
        component: () => import('@/views/Pm/FlowItem/PmFlowItem.vue'),
    },
    {
        path: '/pm/setup',
        name: "PmSetup",
        component: () => import('@/views/Pm/Handle/PnFlowSetup.vue'),
    }
]


export default pmRoutes