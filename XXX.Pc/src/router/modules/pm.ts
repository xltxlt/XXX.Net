import type { RouteRecordRaw } from "vue-router";

const pmRoutes: Array<RouteRecordRaw> = [
 
   {
        path: '/pm/pmFlowTemp',
        name: "pmFlowTemp",
        component: () => import('@/views/Pm/PmFlowTemp.vue'),
    },

]

export default pmRoutes