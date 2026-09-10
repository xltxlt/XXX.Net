<script setup lang='ts'>
import { ref } from 'vue';
import PageForm from '@/components/PageForm/PageForm.vue';
import SelectIcon from '@/components/common/SelectIcon/SelectIcon.vue';
import type { TempEditPageData } from '@/components/PageForm'
import { saveMatter, getMatterPageRender } from '@/api/common/matter';
const { pars } = defineProps<{ pars?: Record<string, any> }>()
import { handleSumbitResBox } from '@/utils/common';
import { isEmptyVal } from '@/utils/is';
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    cols: 2,
    form: [
        {
            type: "group",
            title: "事项配置",
            name: "",
            child: [{
                type: 'input',
                title: '事项名称',
                name: "title",
            }, {
                type: 'input',
                title: '事项简称',
                name: "singleTitle",
            }, {
                type: 'input',
                title: '事项编码',
                name: "menuCode",
            },
            {
                type: 'treeSelect',
                title: '所属层级',
                name: 'classList',
                comProps: {
                    filterable: true,
                    props: {
                        clearable: true,
                        checkStrictly: true,
                    }
                }
            },
            {
                type: "input",
                title: "事项地址",
                placeholder: "重写事项时需填写地址",
                name: 'linkUrl'
            },
            {
                type: "input",
                title: "发起地址",
                placeholder: "发起事项时需填写地址",
                name: 'launchMatterUrl'
            },
            {
                type: 'input',
                title: '其他数据接口',
                name: "otherApiUrl",
            }, {
                type: 'input',
                title: '其他数据接口参数',
                name: "otherApiPars",
            },
            {
                type: 'input',
                title: '地址参数',
                name: "urlPars",
            },
            {
                type: "input",
                title: "事项排序",
                name: 'sortNum'
            }, {
                type: 'textarea',
                title: '事项描述',
                name: "matterDesc",
            }, {
                type: 'textarea',
                title: '事项备注',
                name: "remark",
            },],
        },
        {
            type: "group",
            title: "事项队列配置",
            name: "",
            child: [
                {
                    type: "input",
                    title: "事前队列主体",
                    name: 'matterBeforeTopic'
                },
                {
                    type: "input",
                    title: "事前队列标签",
                    name: 'matterBeforeTag'
                },
                {
                    type: "input",
                    title: "事中队列主体",
                    name: 'matterMiddleTopic'
                },
                {
                    type: "input",
                    title: "事中队列标签",
                    name: 'matterMiddleTag'
                },
                {
                    type: "input",
                    title: "事后队列主体",
                    name: 'matterAfterTopic'
                },
                {
                    type: "input",
                    title: "事后队列标签",
                    name: 'matterAfterTag'
                },
            ]
        },
        {
            type: "group",
            title: "菜单配置",
            name: "",
            child: [

                {
                    type: 'input',
                    title: '资源图标',
                    comOn: {
                        click: () => {
                            showIconDialog.value = true
                        }
                    },
                    name: "icon"
                },

                {
                    type: "input",
                    title: "资源事件",
                    name: 'funName'
                }, {
                    type: 'radio',
                    title: '开启分页',
                    name: 'isPage'
                },
                {
                    type: 'radio',
                    title: '适用终端',
                    name: 'typeId'
                }, {
                    type: 'radio',
                    title: '是否通用',
                    name: 'currencyStatus'
                }
            ]
        }
        , {
            type: "group",
            title: "工作台",
            name: "",
            child: [{
                type: "uploadImgOne",
                title: "工作台图标",
                name: 'stagingIcon',
                comProps: {
                    uploadPath: 'workbench',
                    publicOss: true,
                }
            },]

        }],
    rules: {
        title: [{ required: true, message: '请填写资源名称', trigger: 'blur' },],
        isOpen: [{ required: true }],
        isPage: [{ required: true }],
        isTree: [{ required: true }],

    },
    formData: {
        id: pars?.id ?? null,
        sortNum: 1,
        classList: [],
        currencyStatus: 1,
        isPage: 0,
        typeId: 4,
        isOpen: 0,
        isTree: 0,
    },
    options: {
        typeId: [{
            label: 'pc端',
            value: 1
        }, {
            label: 'H5端',
            value: 2
        }, {
            label: 'pc顶部导航',
            value: 3
        }, {
            label: 'app端',
            value: 4
        }, {
            label: '小程序端',
            value: 5
        }],
        isPage: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        isOpen: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        isTree: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
        currencyStatus: [{
            label: '平台专用',
            value: 0
        }, {
            label: '所有通用',
            value: 1
        }]
    },

})
const showIconDialog = ref(false)
const selectIcon = (name: string) => {
    showIconDialog.value = false;
    tempForm.value.formData['icon'] = name;
}

getMatterPageRender(pars?.id).then(([res1, res2]) => {
    res1 && res1.code == 200 && (tempForm.value.options['classList'] = res1.data);
    res2 && res2.code == 200 && (tempForm.value.formData = res2.data);
})
const sumbit = async () => {
    const formData = { ...tempForm.value.formData };
    formData.parentId=null;
    if (Array.isArray(formData.classList) && formData.classList?.length > 0) {
        formData.parentId = formData.classList[0]
    }
    formData.classLayer = formData.classList?.length ?? 0;
    const res = await saveMatter(formData);
    handleSumbitResBox(res, isEmptyVal(pars?.id)?'新增事项成功':'修改事项成功', () => {
        emit('closeDialog')
        emit('refreshList')
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