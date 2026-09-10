import type { RouteRecordRaw } from "vue-router";

const matterRoutes: Array<RouteRecordRaw> = [
 
   {
        path: 'CustomMatter',
        name: "CustomMatter",
        component: () => import('@/views/Matter/CustomMatter.vue'),
    },
    

]

export default matterRoutes