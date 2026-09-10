<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus'
import { type TempEditPageData, PageFormType, PageFormGroup } from '@/components/PageForm'
import { menuFieldService } from '@/api';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    cols: 2,
    form: [
        {
            formType: PageFormGroup.Group,
            fieldName: '',
            label: "字段设置",
            child: [
                {
                    formType: PageFormType.Input,
                    label: "字段名称",
                    fieldName: 'name',
                }, {
                    formType: PageFormType.Input,
                    label: "显示名称",
                    fieldName: "label"
                },
                {
                    formType: PageFormType.Input,
                    label: "关联字段",
                    fieldName: "fieldName"
                },

                {
                    formType: PageFormType.Input,
                    label: "关联事件",
                    fieldName: "eventName"
                },

                {
                    formType: PageFormType.Input,
                    label: "宽度",
                    fieldName: 'width'
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "浮动类型",
                    fieldName: 'floatType'
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "对齐方式",
                    fieldName: 'alignType'
                },
                {
                    formType: PageFormType.Input,
                    label: "排序",
                    fieldName: 'sort'
                },
                {
                    formType: PageFormType.Radio,
                    label: "合计行",
                    fieldName: 'totalRow'
                },
                {
                    formType: PageFormType.Radio,
                    label: "初始隐藏",
                    fieldName: 'initHide'
                },

                {
                    formType: PageFormType.Radio,
                    label: '状态',
                    fieldName: 'enabled'
                }, {
                    formType: PageFormType.Radio,
                    label: '是否通用',
                    fieldName: 'general'
                }, {
                    formType: PageFormType.TextAreaInput,
                    label: "说明",
                    fieldName: 'description',
                }
            ]
        },
        {
            formType: PageFormGroup.Group,
            fieldName: '',
            label: "其他设置",
            child: [{
                formType: PageFormType.Radio,
                label: "应用搜索",
                fieldName: 'searchField'
            },
            {
                formType: PageFormType.OneSelectSearch,
                label: "搜索类型",
                fieldName: 'searchType'
            },
            {
                formType: PageFormType.OneSelectSearch,
                label: "显示类型",
                fieldName: 'fieldType'
            },
            {
                formType: PageFormType.OneSelectSearch,
                label: "数据源类型",
                fieldName: 'dataSourceType'
            },
            {
                formType: PageFormType.Input,
                label: "数据源配置值",
                fieldName: 'DataSourceValue'
            },
            {
                formType: PageFormType.Input,
                label: "数据源参数",
                fieldName: 'dataSourcePars'
            },

            {
                formType: PageFormType.Input,
                label: "自定义模板",
                fieldName: 'template'
            },]
        },

    ],
    rules: {
        name: [{ required: true, message: '请填写', trigger: 'blur' },],
        label: [{ required: true, message: '请填写', trigger: 'blur' },],
        fieldName: [{ required: true, message: '请填写', trigger: 'blur' },],
        floatType: [{ required: true, message: '请选择', trigger: 'blur' },],
        totalRow: [{ required: true, message: '请选择', trigger: 'blur' },],
        initHide: [{ required: true, message: '请选择', trigger: 'blur' }],
        alignType: [{ required: true, message: '请选择', trigger: 'blur' },],
        searchField: [{ required: true, message: '请选择', trigger: 'blur' },],
        disabled: [{ required: true, message: '请选择', trigger: 'blur' },],
        general: [{ required: true, message: '请选择', trigger: 'blur' },],
        fieldType: [{ required: true, message: '请选择', trigger: 'blur' },],
        inputType: [{ required: true, message: '请选择', trigger: 'blur' },],




    },
    formData: {
        id: pars?.id ?? null,
        menuId: pars?.menuId ?? null,
        alignType: 0,
        floatType: 0,
        totalRow: 1,
        initHide: 1,
        searchField: 0,
        general: 1,
        enabled: 1,
        dataSourceType: 0,
        fieldType: 0,
        inputType: 100
    },
    options: {
    },
})
menuFieldService.apiSysMenuFieldDetailoptionGet(pars?.id).then((res) => {
    tempForm.value.options = (res.data.data?.options) ?? {};
    tempForm.value.formData = Object.assign(tempForm.value.formData, res.data.data?.detail ?? {});
})
const sumbit = () => {
    // tempForm.value.loading = true;
    console.log(tempForm.value.formData)
    const formData = { ...tempForm.value.formData };
    menuFieldService.apiSysMenuFieldAddorupdatePost(formData).then((res) => {
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