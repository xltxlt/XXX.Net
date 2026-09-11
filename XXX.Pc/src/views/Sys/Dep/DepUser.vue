<template>
    <div class="dep-user-page">
        <div class="left-page">
            <tree-dep-user @item-click="onTreeItemClick"></tree-dep-user>
        </div>
        <div class="right-page" style="padding:0 50px;">
            <div class="right-header">
            </div>
            <div class="right-content">
                <UserInfo :user-info="checkedData" @btn-click="handleUserBtn" v-if="checkedItemType == 2">
                </UserInfo>
            </div>
            <div class="right-footer"></div>
        </div>
    </div>
    <YzPopup ref="yzPopupRef" class="" @close-dialog="" @refresh-list="()=>{pageFun['loadData']()}"></YzPopup>
</template>
<script setup lang='ts'>
import { ref, provide, onMounted } from 'vue'
import TreeDepUser from '@/components/common/TreeDepUser/TreeDepUser.vue'
import UserInfo from '@/components/common/UserInfo/UserInfo.vue';
import { ElMessageBox } from 'element-plus';
import { handleSumbitResTip } from '@/utils/common';
import YzPopup from '@/components/common/YzPopup/YzPopup.vue';
import type { YzDialogPars } from '@/components/common/YzPopup';
import { userDepRoleService,userService } from '@/api';


const { pars } = defineProps<{
    pars: any
}>()
const checkedItemType = ref(0)
const checkedData = ref({})
const depId = ref('')
const data = ref<any[]>([])
const yzPopupRef = ref()
const yzPopupPars: YzDialogPars = {
    title: '',
    comp: null,
    height: '80%',
    width: '1100px',
    pars: {}
}
provide('treeDepUserData', data)
const onTreeItemClick = async (data: any, node: any) => {
    checkedItemType.value = data.type ?? 0;
    if (data.type == 2) {
        // const itemInfo = await getDepUserBasicInfo(data.id, data.pId)
        // checkedData.value = itemInfo
        // depId.value = data.pId
        var res= await userService.apiSysUserDetailIdGet(data.id);
        checkedData.value = res.data.data||{};
        depId.value = data.pId
    }
}
const handleUserBtn = async (type: string, userInfo: any) => {
    await pageFun[type](userInfo)
}
const pageFun: Record<string, Function> = {
    loadData: async () => {
        // data.value = pageData
        var res=  await userDepRoleService.apiSysUserDepRoleDepusertreePost({
            where: {
                tenantId:pars.tenantId,
                departmentId:  pars.id
            }
        });
        data.value = res.data.data||[];
    },

    delMember: async (userInfo: any) => {
        ElMessageBox.confirm('是否确认移除该员工？', '提示', {
            confirmButtonText: '确认',
            cancelButtonText: '取消',
            type: 'warning',
        }).then(async () => {
            // const res = await delCompanyDepUser(depId.value, userInfo.id)
            // handleSumbitResTip(res, '员工移除成功', async () => {
            //     checkedData.value = {}
            //     checkedItemType.value = 0
            //     await pageFun.loadData()
            // })
        }).catch(() => {
        });
    },
    attendanceLook: async (userInfo: any) => {
    },
    setPermission: async (userInfo: any) => {
    },
    
}
onMounted(async () => {
    await pageFun.loadData()
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


}
</style>
