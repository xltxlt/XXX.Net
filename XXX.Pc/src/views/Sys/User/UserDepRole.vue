<template>
    <div class="field-list-page">
        <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
    </div>
</template>
<script setup lang="ts">
import PageInfo from "@/components/ListPage/PageInfo.vue";
import { ref } from "vue";
import SelectRoles from "./SelectRoles.vue";
import { FieldType, PagedSearchType, type TempListPageConfig } from "@/components/ListPage";
import { ElMessage } from "element-plus";
import { depService, userDepRoleService } from "@/api/index.ts";
import { handleSumbitResBox } from "@/utils/common.ts";
const emit = defineEmits<{
    (e: "closeDialog"): void;
    (e: "refreshList"): void;
}>();

const { pars } = defineProps<{ pars?: Record<string, any> }>()
const pageInfoRef = ref()
const roleIds = ref<string[]>([]);
const roleNames = ref<string>("");
const pageConfig: TempListPageConfig = {
    url: userDepRoleService.apiSysUserDepRoleDepuserrolesPost.bind(depService),
    hideSearch: true,
    treeField: 'label',
    where:{
        userId: pars?.userId
    },
    rowKey: 'id',
    isPage: false,
    expandAll: true,
    defChecked: true,
    treeProps: {
        checkStrictly: true,
    },
    tableProps: {
        children: 'children'
    },
    customListPage: {
        search: [
            { fieldName: "name", label: "部门名称", searchType: PagedSearchType.Input, value: '', option: [] }
        ],
        btns: [
            {
                label: "保存",
                eventName: "add",
                icon: "search",
                bgColor: "#28a745",
            }
        ],
        fields: [
            {
                fieldName: "name",
                label: "部门名称",
                fieldType: FieldType.Default,
            },
            {
                fieldName: "code",
                label: "编码",
                fieldType: FieldType.Default,
                width: "660px",
            },
            {
                fieldName: "sort",
                label: "排序",
                fieldType: FieldType.Default,
                width: "90px",
            },
            {
                fieldName: "roleNames",
                label: "当前角色",
                fieldType: FieldType.Default,
                width: "150px",
            },
            {
                fieldName: "rightTools",
                label: "操作角色",
                fieldType: FieldType.RightTools,
                width: "150px",
            },
        ],
        tableBtns: [
            {
                label: "点击修改",
                eventName: "edit",
                icon: "search",
                bgColor: "#28a745",
            }
        ],
    },
    pageFun: {
        edit: (data: any) => {
            const currentRow = data;
            // 定义回调函数，用于接收二级页面传回来的数据
            const handleUpdate = (payload: { roleIds: string[], roleNames: string }) => {
                // 更新当前行数据
                currentRow.roleIds = payload.roleIds;
                currentRow.roleNames = payload.roleNames;
                currentRow.checked = (currentRow.roleIds && currentRow.roleIds.length > 0) ? 1 : 0;
                pageConfig.defChecked = true;
                pageInfoRef.value?.resetTableRowData(currentRow)
                // pageInfoRef.value?.refresh?.();
            };
            return {
                title: "用户角色",
                comp: SelectRoles,
                pars: {
                    hasOne: false,
                    roleIds: currentRow.roleIds || [], // 初始值
                    // 把回调函数传下去
                    callback: handleUpdate,
                },

            };
        },
        add: async (data: any) => {
            const selectedRoles = pageInfoRef.value.getSelectionRows();
            const userId = pars?.userId;
            const orgDepList: { [key: string]: string[] | null; }  = {};
            selectedRoles.map((item: any) => {
                if (item.roleIds && item.roleIds.length > 0) {
                    orgDepList[item.id]=item.roleIds;
                }

            });
            // 获取上级传下来的参数
            var res = await userDepRoleService.apiSysUserDepRoleSetdepuserrolesPost({
                userId: userId,
                depRoles: orgDepList
            });
            handleSumbitResBox(res, "保存成功", () => {
                emit("closeDialog");
                emit("refreshList");
            })
        },
    }
};
</script>
<style scoped>
.field-list-page {
    padding-top: 10px;
    height: calc(100% - 25px);
}
</style>
