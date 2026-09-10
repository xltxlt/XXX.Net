import type { RouteRecordRaw } from "vue-router";

const inventoryRoutes: Array<RouteRecordRaw> = [
    {
        path: '/inventory/domain',
        name: "domain",
        component: () => import('@/views/Inventory/Domain/InventoryDomain.vue'),
    },
     {
        path: '/inventory/type',
        name: "type",
        component: () => import('@/views/Inventory/Type/InventoryType.vue'),
    },
     {
        path: '/inventory/item',
        name: "item",
        component: () => import('@/views/Inventory/Item/InventoryItem.vue'),
    },
     {
        path: '/inventory/warehouse',
        name: "warehouse",
        component: () => import('@/views/Inventory/Warehouse/InventoryWarehouse.vue'),
    },
     {
        path: '/inventory/location',
        name: "location",
        component: () => import('@/views/Inventory/Location/InventoryLocation.vue'),
    },
     {
        path: '/inventory/attributeDefinition',
        name: "attributeDefinition",
        component: () => import('@/views/Inventory/AttributeDefinition/InventoryAttributeDefinition.vue'),
    },
     {
        path: '/inventory/stock',
        name: "stock",
        component: () => import('@/views/Inventory/Stock/InventoryStock.vue'),
    },
     {
        path: '/inventory/document',
        name: "inventoryDocument",
        component: () => import('@/views/Inventory/Document/InventoryDocument.vue'),
    },
]

export default inventoryRoutes
