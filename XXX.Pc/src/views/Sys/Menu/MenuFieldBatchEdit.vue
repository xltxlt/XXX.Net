<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus'
import  {type TempEditPageData , PageFormType} from '@/components/PageForm'
// import { fieldBatchEdit } from '@/api/field';
import { menuFieldService } from '@/api';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    form: [{
        formType: PageFormType.Radio,
        label: '初始隐藏',
        fieldName: 'hide'
    },
    {
        formType: PageFormType.Radio,
        label: '是否禁用',
        fieldName: 'isLock'
    }, {
        formType: PageFormType.Radio,
        label: '是否通用',
        fieldName: 'currencyStatus'
    }],
    rules: {
        
    },
    formData: {
        ids: pars?.ids ?? null,
    },
    options: {
        hide: [{
            label: '否',
            value: 0
        }, {
            label: '是',
            value: 1
        }],
        isLock: [{
            label: '启用',
            value: 0
        }, {
            label: '禁用',
            value: 1
        }],
        currencyStatus: [{
            label: '平台专用',
            value: 0
        }, {
            label: '所有通用',
            value: 1
        }],
    },
})

const showIconDialog = ref(false)
const sumbit = () => {
    // tempForm.value.loading = true;
    const formData = { ...tempForm.value.formData };
    menuFieldService.apiSysMenuFieldBatchupdatePost(formData).then((res) => {
        if (res.data.statusCode != 200) {
            ElMessage({
                message: '操作失败',
                type: 'error',
                plain: true,
            })
            return;
        }
        ElMessage({
            message: '操作成功',
            type: 'success',
            plain: true,
        })
        emit('closeDialog')
        emit('refreshList')
    }).finally(() => {
        // tempForm.value.loading = false;
    })
}
</script>
<template>
    <div class="edit-sys-page">
        <page-form :temp-form="tempForm" @on-submit="sumbit" v-loading="tempForm.loading ?? false">
        </page-form>
    </div>
</template>
<style lang='less' scoped>
.edit-sys-page {
    height: 100%;
}
</style>