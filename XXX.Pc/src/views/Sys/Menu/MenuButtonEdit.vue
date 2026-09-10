<script setup lang='ts'>
import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus'
import { type TempEditPageData, PageFormType } from '@/components/PageForm'
import SelectIcon from '@/components/common/SelectIcon/SelectIcon.vue';
import { menuButtonService } from '@/api';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    form: [{
        formType: PageFormType.Input,
        label:"按钮名称",
        fieldName: 'name'
    }, {
        formType: PageFormType.Input,
        label:"显示名称",
        fieldName: 'label'
    },
    {
        formType: PageFormType.OneSelectSearch,
        label:"按钮类型",
        fieldName: "buttonType",
    },
    {
        formType: PageFormType.OneSelectSearch,
        label:"所属租户",
        fieldName: 'tenantId'
    }, {
        formType: PageFormType.Input,
        label:"按钮事件",
        fieldName: "eventName",
    },

    {
        formType: PageFormType.Input,
        label:'图标',
        comProps: {
            readonly: true,
        },
        comOn: {
            click: () => {
                showIconDialog.value = true
            }
        },
        fieldName: "icon"
    },
    // {
    //     formType: "color",
    //     label:"字体颜色",
    //     fieldName: 'color',
    // },
    {
        formType: PageFormType.Color,
        label:"背景颜色",
        fieldName: 'bgColor',
        comOn: {
            click: () => {
                showCustomColorDialog.value = true;
            }
        }
    }, {
        formType: PageFormType.Input,
        label:"排序",
        fieldName: 'sort'
    }, {
        formType: PageFormType.Radio,
        label:'按钮状态',
        fieldName: 'enabled'
    }, {
        formType: PageFormType.Radio,
        label:'是否通用',
        fieldName: 'general'
    }, {
        formType: PageFormType.TextAreaInput,
        label:"资源备注",
        fieldName: 'describe',
    }],
    rules: {
        name: [{ required: true, message: '请填写按钮名称', trigger: 'blur' },],
        label: [{ required: true, message: '请填写显示名称', trigger: 'blur' },],
        tenantId: [{ required: true, message: '请选择所属租户', trigger: 'blur' },],
        buttonType: [{ required: true, message: '请选择按钮类型', trigger: 'blur' },],
        eventName: [{ required: true, message: '请填写按钮事件', trigger: 'blur' },],

    },
    formData: {
        id: pars?.id ?? null,
        menuId: pars?.menuId ?? null,
        enabled: 1,
        general: 1,
        buttonType: 1
    },
    options: {

    },
})
menuButtonService.apiSysMenuButtonDetailoptionGet(pars?.id).then((res) => {
    tempForm.value.options = (res.data.data?.options) ?? {};
    !!pars?.id && (tempForm.value.formData = res.data.data?.detail);
})
const showIconDialog = ref(false)
const showCustomColorDialog = ref(false)

const selectIcon = (name: string) => {
    showIconDialog.value = false;
    tempForm.value.formData['icon'] = name;
}
const sumbit = () => {
    // tempForm.value.loading = true;
    const formData = { ...tempForm.value.formData };
    menuButtonService.apiSysMenuButtonAddorupdatePost(formData).then((res) => {
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
        <el-dialog v-model="showIconDialog" draggable width="700px" align-center>
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

    .custom-color {
        .custom-color-box {
            display: flex;
            justify-content: space-between;
            margin-top: 50px;

            /* 可选间距 */
            .custom-color-item {
                width: 60px;
                height: 60px;
                border-radius: 50%;
            }

            .custom-color-text {
                text-align: center;
                line-height: 50px;
            }
        }
    }
}
</style>