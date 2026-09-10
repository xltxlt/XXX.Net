<template>
    <div class="field-list-page">
        <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
    </div>
</template>

<script setup lang="ts">
import PageInfo from "@/components/ListPage/PageInfo.vue";
import { FieldType, type TempListPageConfig } from "@/components/ListPage";
import { nextTick, ref, watch } from "vue";
import { ElMessage } from "element-plus";
import { roleService } from "@/api";
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const pageInfoRef = ref()

// 定义事件类型
interface SubmitEventData {
    roleIds: string[] | number[];
    roleNames: string;
}

// 定义自定义事件
const emit = defineEmits<{
    (e: "closeDialog"): void;
    (e: "refreshList"): void;
}>();

const setDefChecked = (selections: any[], handleFun: Function) => {
    selections.forEach(item => {
        if (pars?.roleIds && pars.roleIds.includes(item.roleId)) {
            handleFun(item, true);
        }
        if (item.children && item.children.length > 0) {
            setDefChecked(item.children, handleFun)
        }
    })
}
watch(
    () => pars?.roleIds,
    (newRoleIds) => {
        if (!newRoleIds || !Array.isArray(newRoleIds)) return;

        // 清除当前所有选中
        pageInfoRef.value?.clearSelection?.();

        // 重新设置默认选中
        nextTick(() => {
            setDefChecked(pageInfoRef.value.getTableData(), pageInfoRef.value.toggleRowSelection);
        });
    },
    { immediate: false } // 不立即执行，因为第一次由 successCb 处理
);
const pageConfig: TempListPageConfig = {
    url: roleService.apiSysRoleListPost.bind(roleService),
    hideSearch: true,
    isPage: false,
    customListPage: {
        search: [],
        btns: [
            {
                label: "提交",
                eventName: "add",
                icon: "search",
                bgColor: "#28a745",
            }
        ],
        fields: [
            {
                fieldName: "roleName",
                label: "标题",
                fieldType: FieldType.Default,
            },
            {
                fieldName: "roleCode",
                label: "编码",
                fieldType: FieldType.Default,
                width: "660px",
            },
            {
                fieldName: "sortNum",
                label: "排序",
                fieldType:  FieldType.Default,
                width: "90px",
            }
        ],
        tableBtns: [],
    },
    pageFun: {
        add: (data: any) => {
            const selectionRows = pageInfoRef.value.getSelectionRows();
            if (selectionRows.length === 0) {
                ElMessage.error("请至少选择一个用户角色");
                return;
            }
            const newRoleIds = selectionRows.map((item: any) => item.roleId);
            const newRoleNames = selectionRows.map((item: any) => item.roleName).join(",");
            // 触发 submit 事件，把数据传回去
            if (pars?.callback) {
                pars.callback({
                    roleIds: newRoleIds,
                    roleNames: newRoleNames
                });
            }
            emit("closeDialog");
        },
    },
    successCb: (data: any) => {
        nextTick(() => {
            if (pars?.roleIds && Array.isArray(pars?.roleIds)) {
                setDefChecked(data, pageInfoRef.value.toggleRowSelection);
            }
        });
    }
};
</script>

<style scoped>
.field-list-page {
    padding-top: 10px;
    height: calc(100% - 25px);
}
</style>