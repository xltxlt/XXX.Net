<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref, watch, toRefs } from 'vue';
import { ElMessage } from 'element-plus';
import SelectIcon from '@/components/common/SelectIcon/SelectIcon.vue';
import type { TempEditPageData, TempEditForm } from '@/components/PageForm';
import { menuService } from '@/api';
import { PageFormType } from '@/components/PageForm';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    form: [{
        formType: PageFormType.Input,
        label: "菜单名称",
       fieldName: 'name'
    }, {
        formType:PageFormType.Input,
        label: "菜单简称",
       fieldName: "alias"
    },

    {
        formType: PageFormType.OneSelectSearch,
        label: "所属租户",
       fieldName: 'tenantId'
    },
    
    {
        formType: PageFormType.OneSelectSearch,
        label: "菜单类型",
       fieldName: 'pageType'
    },
    
    {
        formType:PageFormType.Input,
        label: "资源地址",
       fieldName: 'route'
    },
    {
        formType: PageFormType.Input,
        label: '资源图标',
        comOn: {
            click: () => {
                showIconDialog.value = true
            }
        },
       fieldName: "icon"
    },
    {
        formType: PageFormType.UploadOneImg,
        label: "工作台图标",
       fieldName: 'workbenchIcon',
        comProps: {
            uploadPath: 'workbench',
            publicOss: true,
        }
    }, {
        formType: PageFormType.TreeSelect,
        label: '所属层级',
       fieldName: 'path',
        comProps: {
            filterable: true,
            props: {
                clearable: true,
                checkStrictly: true,
            }
        }
    },
    {
        formType:PageFormType.Input,
        label: "资源事件",
       fieldName: 'eventName'
    },
    {
        formType: PageFormType.Radio,
        label: '是否禁用',
       fieldName: 'enabled'
    },
    {
        formType:PageFormType.Input,
        label: "资源排序",
       fieldName: 'sort'
    }, {
        formType: PageFormType.Radio,
        label: '适用终端',
       fieldName: 'target'
    }, {
        formType: PageFormType.Radio,
        label: '是否通用',
       fieldName: 'general'
    }, {
        formType: PageFormType.TextAreaInput,
        label: "说明",
       fieldName: 'description',
    }],
    rules: {
        name: [{ required: true, message: '请填写资源名称', trigger: 'blur' },],
        icon: [{ required: true, message: '请选择资源图标', trigger: 'blur' },],
        tenantId: [{ required: true, message: '请选择所属租户' },],

        enabled: [{ required: true }],
        pageTpye: [{ required: true }],
        

    },
    formData: {
        id: pars?.id ?? null,
        sort: 1,
        enabled:1,
        general:1,
        target:99
    },
    options: {

    },

})
const showIconDialog = ref(false)
const selectIcon = (name: string) => {
    showIconDialog.value = false;
    tempForm.value.formData['icon'] = name;
}
menuService.apiSysMenuDetailoptionGet(pars?.id).then((res) => {
    tempForm.value.options = (res.data.data?.options) ?? {};
    tempForm.value.formData =Object.assign(tempForm.value.formData,res.data.data?.detail??{})  ;

})
const sumbit = () => {
    const formData = { ...tempForm.value.formData };
    if (Array.isArray(formData.classList) && formData.classList?.length > 0) {
        formData.parentId = formData.classList[formData.classList?.length - 1]
    }
    formData.classLayer = formData.classList?.length ?? 0;
    menuService.apiSysMenuAddorupdatePost(formData).then((res) => {
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
    })
}
</script>
<template>
    <div class="edit-sys-page">
        <page-form :temp-form="tempForm" @on-submit="sumbit">
        </page-form>
        <el-dialog v-model="showIconDialog" draggable width="700px">
            <template #header>
                选择图标
            </template>
            <SelectIcon v-on:select-icon="selectIcon"></SelectIcon>
        </el-dialog>
    </div>
</template>
<style lang='less' scoped>
.edit-sys-page {
    height: 100%;
}
</style>