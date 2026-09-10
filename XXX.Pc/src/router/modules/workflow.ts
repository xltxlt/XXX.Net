import type { RouteRecordRaw } from "vue-router";

const workflowRoutes: Array<RouteRecordRaw> = [
    {
        path: '/workflow/todo',
        name: "workflowTodo",
        component: () => import('@/views/Workflow/WorkflowTodo.vue'),
    },
]

export default workflowRoutes
