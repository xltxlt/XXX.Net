




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { inventoryAttributeDefinitionService } from "@/api/inventory.ts";

import {
    type TempEditPageData,
    PageFormType
} from '@/components/PageForm';
import { is } from '@/utils/is';


const { pars } = defineProps<{
    pars?: Record<string, any>
}>();

const emit = defineEmits([
    'closeDialog',
    'refreshList'
]);

const tempForm = ref<TempEditPageData>({
    loading: false,
    hideBtn:pars?.lock=='lock' ? true : false,
    form: [
       
        {
            formType: PageFormType.OneSelectSearch,
            label: "库存类型",
            fieldName: "inventoryTypeId"
        },
         {
            formType: PageFormType.Input,
            label: "名称",
            fieldName: "name"
        },
        {
            formType: PageFormType.Input,
           label: "编码",
            fieldName: "code"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "数据类型",
            fieldName: "dataType"
        },
        {
            formType: PageFormType.Radio,
            label: "是否必填",
            fieldName: "required"
        },
        {
            formType: PageFormType.Radio,
            label: "是否唯一",
            fieldName: "unique"
        },
        {
            formType: PageFormType.Radio,
            label: "是否主键",
            fieldName: "isKey"
        },
        {
            formType: PageFormType.Input,
            label: "排序",
            fieldName: "sort"
        },
        {
            formType: PageFormType.CustomOptions,
            label: "自定义选项",
            fieldName: "optionsJson"
        },
    ],

    rules: {
        name: [
            { required: true, message: '请输入名称', trigger: 'blur' },
        ],
        inventoryTypeId: [
            { required: true, message: '请选择库存类型', trigger: 'blur' },
        ],
        code: [
            { required: true, message: '请输入编码', trigger: 'blur' },
        ],
        dataType: [
            { required: true, message: '请选择数据类型', trigger: 'blur' },
        ],
        sort: [
            { required: true, message: '请输入排序', trigger: 'blur' },
        ],
        required: [
            { required: true, message: '请选择是否必填', trigger: 'blur' },
        ],
        isKey: [
            { required: true, message: '请选择是否主键', trigger: 'blur' },
        ],
        unique: [
            { required: true, message: '请选择是否唯一', trigger: 'blur' },
        ],


    },

    formData: {
        id: pars?.id ?? null,
        unique:0,
        isKey:0,
        required:1
    },

    options: {
        
    },
});


inventoryAttributeDefinitionService.apiInventoryAttributeDefinitionDetailoptionGet(pars?.id)
    .then((res) => {

        tempForm.value.options =  Object.assign(
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


    inventoryAttributeDefinitionService.apiInventoryAttributeDefinitionAddorupdatePost(formData)
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

        <page-form
            :temp-form="tempForm"
            @on-submit="sumbit"
        >
        </page-form>

    </div>

</template>

<style lang='less' scoped>

.edit-page {
    height: 100%;
    overflow-y: scroll;
}

</style>

