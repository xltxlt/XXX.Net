<template>
    <div class="dep-user-page">
        <div class="left-page">
            <tree-dep-user @item-click="onTreeItemClick"></tree-dep-user>
        </div>
        <div class="right-page">
            <div class="right-header">
                部门负责人列表
            </div>
            <div class="right-content">
                <UserItem v-for="(value, index) in checkedData" :key="index" :user="value"
                    @delete="pageFun.delManageUser"></UserItem>
            </div>
            <div class="right-footer"></div>
        </div>
    </div>
</template>
<script setup lang='ts'>
import { ref, watch, provide, onMounted } from 'vue'
import TreeDepUser from '@/components/common/TreeDepUser/TreeDepUser.vue'
import UserItem from '@/components/common/UserItem/UserItem.vue';
// import { getCompanyDepUserManageTree, setCompanyDepUserManage, delCompanyDepUserManage } from '@/api/organize';
import { ElMessageBox } from 'element-plus';
import { handleSumbitResTip } from '@/utils/common';

const { pars } = defineProps<{
    pars: any
}>()
const checkedItemType = ref(0)
const checkedData = ref<any[]>([])
const data = ref<any[]>([])
provide('treeDepUserData', data)
const onTreeItemClick = async (data: any, node: any) => {
    checkedItemType.value = data.type ?? 0;

    if (data.type == 2 && data.checked != true && data.disabled == false) {
        ElMessageBox.confirm(`确定设置${data.title}为部门（${pars.depTitle}）的负责人吗？`, '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning',
        }).then(async () => {
            // const res = await setCompanyDepUserManage({
            //     id: pars.id,
            //     userIds: [data.id]
            // });
            // handleSumbitResTip(res, '设置成功', () => {
            //     pageFun.loadData();
            //     // checkedData.value = [...checkedData.value, data];
            //     // data.checked = true;
            // });
        });

    } else {

    }
}
const pageFun = {
    loadData: async () => {
        // const pageData = await getCompanyDepUserManageTree(pars.id ?? '');
        // data.value = pageData.userDeptTree ?? [];
        // checkedData.value = pageData.userList ?? [];
    },
    delManageUser: async (data: any) => {
        ElMessageBox.confirm(`确定移除部门负责人${data.title}吗？`, '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning',
        }).then(async () => {
            // const res = await delCompanyDepUserManage(pars.id, data.id);
            // handleSumbitResTip(res, '移除成功', () => {
            //     pageFun.loadData();
            // });
        });

    },
}
onMounted(async () => {
    pageFun.loadData();
})
</script>
<style lang='less' scoped>
.dep-user-page {
    display: flex;
    height: calc(100% - 30px);
    padding: 15px 15px;


    .left-page {
        width: 60%;
        overflow: hidden;
    }

    .right-page {
        width: 40%;
        margin: 0 20px 0 30px;
    }

    .right-content {
        height: calc(100% - 70px);
        overflow-y: auto;
    }

    .right-header {
        font-size: 16px;
        padding: 20px 0;
        font-weight: 500;
    }

}
</style>
