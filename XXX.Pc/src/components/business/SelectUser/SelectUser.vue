<template>
    <YzDialog destroy-on-close v-model:show="show" @colse-dialog="emits('update:show', false); emits('cancel')"
        ref="yzDialogRef" title="用户选择" width="60%" height="70%">
        <div class="dep-user-page">
            <tree-dep-user style="flex:1" @item-click="(item: any) => { pageFun.setChecked(item) }"></tree-dep-user>
            <div class="dep-user-selectds">
                <div class="dep-user-selectds-label">
                    已选用户{{ checkedUser.length }}人
                </div>
                <div class="dep-user-selectds-items">
                    <div class="dep-user-selectds-item" v-for="user, index in checkedUser" :key="index">
                        <el-button type="primary" plain @click="user.checked = false">
                            {{ user.name }}
                            <el-icon :color="'red'">
                                <Delete />
                            </el-icon>
                        </el-button>

                    </div>

                </div>

            </div>
            <div style="position: absolute;bottom: 20px;right: 30px;">
                <el-button type="success" @click="sure">
                    确认选择
                </el-button>
            </div>
        </div>

    </YzDialog>

</template>
<script setup lang='ts'>
import { ref, provide, onMounted } from 'vue'
import TreeDepUser from '@/components/common/TreeDepUser/TreeDepUser.vue'
import { userDepRoleService } from '@/api';
import { computed } from '@vue/reactivity';
import YzDialog from '@/components/common/YzDialog/YzDialog.vue';


const { pars ,checkedItems} = defineProps<{
    pars: any,
    checkedItems:any[]
}>()
const show = ref<boolean>(true)
const data = ref<any[]>([])
const emits = defineEmits(["sure", "update:show", "cancel"])
const checkedUser = computed(() => {
    return findUser(data.value);
});
const yzDialogRef = ref()
provide('treeDepUserData', data)
const findUser = (data: any[]) => {
    var checkedItems = [] as any[];
    for (var i in data) {
        var item = data[i];
        if (item.checked == true) {
            checkedItems.push(item);
        }
        if (item.children && item.children.length > 0) {
            var childrenItmes: any[] = findUser(item.children) || [];
            checkedItems = [].concat(childrenItmes);
        }
    }
    return checkedItems;
}
const SetDefCheckedUser = (data: any[],items:any[]) => {
    var checkedItems = [] as any[];
    for (var i in data) {
        var item = data[i];
        if (items.filter(x=>x==item['id']).length>0) {
            item.checked = true;
        }
        if (item.children && item.children.length > 0) {
            SetDefCheckedUser(item.children,items);
        }
    }
    return ;
}
const sure = () => {
    // yzDialogRef.value.handleClose(); 
    emits('sure', checkedUser.value)
}

const pageFun: Record<string, Function> = {
    loadData: async () => {
        // data.value = pageData
        var res = await userDepRoleService.apiSysUserDepRoleDepuseroptionPost({
            where: {
            }
        });
        if(checkedItems&&checkedItems.length>0){
            SetDefCheckedUser(res.data.data||[],checkedItems)
        }
        data.value = res.data.data || [];
    },
    setChecked: (item: any) => {
        item.checked = !item.checked;
    }
}
onMounted(async () => {
    await pageFun.loadData()
})
</script>
<style scoped lang="less">
.dep-user-page {
    display: flex;
    padding: 20px;
    overflow: hidden;

    .dep-user-selectds {
        width: 40%;
        margin-left: 50px;
        height: 100%;

        &-label {

            padding: 10px 15px;
            background-color: #f3f3f3;
            text-align: left;
            color: #000;
            border-radius: 5px;
            font-weight: bold;


        }

        &-items {
            padding: 15px 10px;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;

            span {
                padding: 6px 10px;
                background-color: #fefefe;
            }
        }

        &-item {
            position: relative;
            margin-right: 15px;
            margin-bottom: 15px;

            >div {}
        }


    }
}
</style>
