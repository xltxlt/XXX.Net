<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref, watch, toRefs } from 'vue';
import { generateService } from '@/api';
import { ElMessage } from 'element-plus';
import { type TempEditPageData, PageFormType, PageFormGroup } from '@/components/PageForm';
import { menuService } from '@/api';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emit = defineEmits(['closeDialog', 'refreshList'])
const radioOptions = [
    {
        label: '生成',
        value: 1
    },
    {
        label: '不生成',
        value: 0
    }
]
const tempForm = ref<TempEditPageData>({
    loading: false,
    cols: 2,
    btnText: '确认生成',
    form: [
        {
            formType: PageFormGroup.Group,
            title: "配置信息",
            fieldName: '',
            child: [
                {
                    formType: PageFormType.Input,
                    title: "命名空间",
                    fieldName: 'namespaceName',
                },
                {
                    formType: PageFormType.Input,
                    title: "关联Dto",
                    fieldName: 'dtoName',
                },
                {
                    formType: PageFormType.Input,
                    title: "关联实体",
                    fieldName: 'entityName',
                },
                {
                    formType: PageFormType.Input,
                    title: "关联服务",
                    fieldName: 'serviceName',
                },
                {
                    formType: PageFormType.Radio,
                    title: "新增功能",
                    fieldName: 'addBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "修改功能",
                    fieldName: 'editBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "查看功能",
                    fieldName: 'lockBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "删除功能",
                    fieldName: 'delBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "导入功能",
                    fieldName: 'importBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "导出功能",
                    fieldName: 'exportBtn',
                },
                {
                    formType: PageFormType.Radio,
                    title: "菜单生成",
                    fieldName: 'menuGenerate',
                },

            ]
        },
    ],
    rules: {
        namespaceName: [{ required: true, message: '请填写命名空间' },],
        dtoName: [{ required: true, message: '请填写' },],
        serviceName: [{ required: true, message: '请填写' },],
        entityName: [{ required: true, message: '请填写' },],
    },
    formData: {
        sort: 1,
        enabled: 0,
        general: 1,
        target: 99,
        exportBtn: 1,
        importBtn: 1,
        addBtn: 1,
        lockBtn: 1,
        delBtn: 1,
        editBtn: 1,
        menuGenerate: 1,
    },
    options: {
        exportBtn: radioOptions,
        importBtn: radioOptions,
        addBtn: radioOptions,
        lockBtn: radioOptions,
        delBtn: radioOptions,
        editBtn: radioOptions,
        menuGenerate: radioOptions,
    },

})
const menuTempForm = ref<TempEditPageData>({
    loading: false,
    cols: 2,
    hideBtn: true,
    form: [

        {
            formType: PageFormGroup.Group,
            title: "菜单配置信息",
            fieldName: '',
            child: [{
                formType: PageFormType.Input,
                title: "菜单名称",
                fieldName: 'name'
            }, {
                formType: PageFormType.Input,
                title: "菜单简称",
                fieldName: "alias"
            },

            {
                formType: PageFormType.OneSelectSearch,
                title: "所属租户",
                fieldName: 'tenantId'
            },

            {
                formType: PageFormType.OneSelectSearch,
                title: "菜单类型",
                fieldName: 'pageType'
            },

            {
                formType: PageFormType.Input,
                title: "资源地址",
                fieldName: 'route'
            },
            {
                formType: PageFormType.Icon,
                title: '资源图标',
                fieldName: "icon"
            },
            {
                formType: PageFormType.UploadOneImg,
                title: "工作台图标",
                fieldName: 'workbenchIcon',
                comProps: {
                    uploadPath: 'workbench',
                    publicOss: true,
                }
            }, {
                formType: PageFormType.TreeSelect,
                title: '所属层级',
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
                formType: PageFormType.Input,
                title: "资源事件",
                fieldName: 'eventName'
            },
            {
                formType: PageFormType.Radio,
                title: '是否禁用',
                fieldName: 'enabled'
            },
            {
                formType: PageFormType.Input,
                title: "资源排序",
                fieldName: 'sort'
            }, {
                formType: PageFormType.Radio,
                title: '适用终端',
                fieldName: 'target'
            }, {
                formType: PageFormType.Radio,
                title: '是否通用',
                fieldName: 'general'
            }, {
                formType: PageFormType.TextAreaInput,
                title: "说明",
                fieldName: 'description',
            }],
        },
    ],
    rules: {
        name: [{ required: true, message: '请填写资源名称', trigger: 'blur' },],
        // icon: [{ required: true, message: '请选择资源图标', trigger: 'blur' },],
        tenantId: [{ required: true, message: '请选择所属租户' },],

        enabled: [{ required: true }],
        pageTpye: [{ required: true }],


    },
    formData: {
        sort: 1,
        enabled: 0,
        general: 1,
        target: 99,
        exportBtn: 1,
        importBtn: 1,
        addBtn: 1,
        lockBtn: 1,
        delBtn: 1,
        editBtn: 1,
        menuGenerate: 1,
    },
    options: {
        exportBtn: radioOptions,
        importBtn: radioOptions,
        addBtn: radioOptions,
        lockBtn: radioOptions,
        delBtn: radioOptions,
        editBtn: radioOptions,
        menuGenerate: radioOptions,
    },

})
const showIconDialog = ref(false)

menuService.apiSysMenuDetailoptionGet(pars?.id).then((res) => {
    tempForm.value.options = Object.assign(tempForm.value.options, res.data.data?.options ?? {});
    tempForm.value.formData = Object.assign(tempForm.value.formData, res.data.data?.detail ?? {});
    menuTempForm.value.options = Object.assign(menuTempForm.value.options, res.data.data?.options ?? {});
})
const sumbit = async () => {
    const formData = { ...tempForm.value.formData };
    if (formData.menuGenerate == 1) {
        menuPageFormref.value.ruleFormRef.validate(async(valid: boolean, fields: any) => {
            if (valid) {
                formData.sysMenuDto = menuTempForm.value.formData;
                await generateService.apiGenerateDetailPost(formData);
                ElMessage({
                    message: '操作成功',
                    type: 'success',
                    plain: true,
                })
            } else {
                if (!fields) return;
            }
        });
        return;
    }
    await generateService.apiGenerateDetailPost(formData);
    ElMessage({
        message: '操作成功',
        type: 'error',
        plain: true,
    })
    emit('closeDialog')
    emit('refreshList')

}

const testGenerate = async () => {
    var testJson: any = {
        "sysMenuDto": {
            "classLayer": 0, "sort": 1, "enabled": 0, "general": 1, "target": 99, "exportBtn": 1, "importBtn": 1, "addBtn": 1, "lockBtn": 1, "delBtn": 1, "editBtn": 1, "menuGenerate": 1, "name": "部门角色管理", "alias": "部门角色管理", "tenantId": "348993006306594815", "tenantIdValue": "平台", "route": "/sys/role", "icon": "DataAnalysis", "pageType": 2, "pageTypeValue": "分页列表页", "path": ["348993006306594816"],
        },
        "namespaceName": "Fyyy.Net.Core.Services.Role.Dto",
        "dtoName": "SysRoleDto",
        "entityName": "SysRole",
        "serviceName": "SysRoleService",
        "menuName": "Role",
        "menuGenerate": true,
        "addBtn": true,
        "editBtn": true,
        "delBtn": true,
        "lockBtn": true,
        "exportBtn": true,
        "importBtn": true,
    };
    await generateService.apiGenerateDetailPost(testJson);
}
const menuPageFormref = ref()
const menuPageFormVaild = ref(false)
</script>
<template>
    <div class="edit-generate-page">
        <page-form :temp-form="tempForm" @on-submit="sumbit">
        </page-form>
        <page-form @on-submit="menuPageFormVaild = true" v-if="tempForm.formData.menuGenerate == 1"
            ref="menuPageFormref" :temp-form="menuTempForm">
        </page-form>
    </div>
</template>
<style lang='less' scoped>
.edit-generate-page {
    height: 100%;
    overflow-y: scroll;
}
</style>
<style lang='less'>
.edit-generate-page {
    .temp-edit-page {
        min-height: unset;
        height: max-content;
        display: contents;
    }
}
</style>