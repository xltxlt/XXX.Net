import type { RouteRecordRaw } from "vue-router";

const pmRoutes: Array<RouteRecordRaw> = [
 
   {
        path: '/pm/pmFlowTemp',
        name: "pmFlowTemp",
        component: () => import('@/views/Pm/PmFlowTemp.vue'),
    },

     
   {
        path: '/pm/pmFlowItem',
        name: "pmFlowItem",
        component: () => import('@/views/Pm/FlowItem/PmFlowItem.vue'),
    },

]

export default pmRoutes