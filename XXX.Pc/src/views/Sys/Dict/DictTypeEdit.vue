<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { dictTypeService } from "@/api/index.ts";

import {
    type TempEditPageData,
    PageFormGroup,
    PageFormType
} from '@/components/PageForm';


const { pars } = defineProps<{
    pars?: Record<string, any>
}>();

const emit = defineEmits([
    'closeDialog',
    'refreshList'
]);

const tempForm = ref<TempEditPageData>({
    loading: false,
    hideBtn: pars?.lock == 'lock' ? true : false,
    cols: 2,
    form: [
        {
            formType: PageFormGroup.Group,
            fieldName: '',
            label: "字典信息",
            child: [{
                formType: PageFormType.Input,
                label: "名称",
                fieldName: "name"
            },
            {
                formType: PageFormType.Input,
                label: "类型编码",
                fieldName: "code"
            },
            {
                formType: PageFormType.Radio,
                label: "全局通用",
                fieldName: "general"
            },
            {
                formType: PageFormType.Radio,
                label: "状态",
                fieldName: "enabled"
            },]
        },
        {
            formType: PageFormGroup.List,
            fieldName: 'children',
            label: "字典项",
            child: [
                {
                    formType: PageFormGroup.Group,
                    label: "",
                    fieldName: "",
                    defaultValue: {
                        enabled: 1,
                        general: 1,
                    },
                    child: [
                        {
                            formType: PageFormType.Input,
                            label: "名称",
                            fieldName: "name"
                        },
                        {
                            formType: PageFormType.Input,
                            label: "显示名称",
                            fieldName: "label"
                        },
                        {
                            formType: PageFormType.Input,
                            label: "类型编码",
                            fieldName: "code"
                        },
                        {
                            formType: PageFormType.Input,
                            label: "关联值",
                            fieldName: "value"
                        },
                        {
                            formType: PageFormType.Number,
                            label: "排序",
                            fieldName: "sort"
                        },

                        {
                            formType: PageFormType.Radio,
                            label: "全局通用",
                            fieldName: "general"
                        },
                        {
                            formType: PageFormType.Radio,
                            label: "状态",
                            fieldName: "enabled"
                        },
                    ]
                },



            ]
        }
    ],

    rules: {
        name: [
            { required: true, message: '请输入名称', trigger: 'blur' },
        ],
        code: [
            { required: true, message: '请输入类型编码', trigger: 'blur' },
        ],
        enabled: [
            { required: true, message: '请选择状态', trigger: 'change' },
        ],
        general: [
            { required: true, message: '请选择全局通用', trigger: 'change' }
        ],
        children: {

            name: [
                {
                    required: true,
                    message: '请输入字典项名称',
                    trigger: 'blur'
                }
            ],

            label: [
                {
                    required: true,
                    message: '请输入显示名称',
                    trigger: 'blur'
                }
            ],

            code: [
                {
                    required: true,
                    message: '请输入字典项类型编码',
                    trigger: 'blur'
                }
            ],

            value: [
                {
                    required: true,
                    message: '请输入关联值',
                    trigger: 'blur'
                }
            ],

            sort: [
                {
                    required: true,
                    message: '请输入排序',
                    trigger: 'blur'
                }
            ],

            general: [
                {
                    required: true,
                    message: '请选择全局通用',
                    trigger: 'change'
                }
            ],

            enabled: [
                {
                    required: true,
                    message: '请选择状态',
                    trigger: 'change'
                }
            ]
        }
    },

    formData: {
        id: pars?.id ?? null,
        enabled: 1,
        general: 1,
        children: [{}]
    },

    options: {
    },
});


dictTypeService.apiSysDictTypeDetailoptionGet(pars?.id)
    .then((res) => {

        tempForm.value.options = Object.assign(
            tempForm.value.options,
            res.data.data?.options ?? {}
        );
        tempForm.value.formData =
            Object.assign(
                tempForm.value.formData,
                res.data.data?.detail ?? {}
            );
    });


const sumbit = () => {

    const formData = {
        ...tempForm.value.formData
    };

    if (
        Array.isArray(formData.classList) &&
        formData.classList.length > 0
    ) {
        formData.parentId =
            formData.classList[
            formData.classList.length - 1
            ];
    }

    formData.classLayer =
        formData.classList?.length ?? 0;


    dictTypeService.apiSysDictTypeAddorupdatePost(formData)
        .then((res) => {

            if (res.data.statusCode != 200) {

                ElMessage({
                    message: '操作失败',
                    type: 'error',
                    plain: true,
                });

                return;
            }

            ElMessage({
                message: '操作成功',
                type: 'success',
                plain: true,
            });

            emit('closeDialog');
            emit('refreshList');
        })
        .finally(() => {
        });


};

</script>

<template>

    <div class="edit-page">

        <page-form :temp-form="tempForm" @on-submit="sumbit">
        </page-form>

    </div>

</template>

<style lang='less' scoped>
.edit-page {
    height: 100%;
    overflow-y: scroll;
}
</style>
