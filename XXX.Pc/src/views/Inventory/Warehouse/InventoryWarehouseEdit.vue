




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { inventoryWarehouseService } from "@/api/inventory.ts";

import {
    type TempEditPageData,
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
    hideBtn:pars?.lock=='lock' ? true : false,
    form: [
        
       
        {
            formType: PageFormType.OneSelectSearch,
            label: "所属库域",
            fieldName: "domainId"
        },
        
        {
            formType: PageFormType.OneSelectSearch,
            label: "所属部门",
            fieldName: "departmentId"
        },
        {
            formType: PageFormType.Input,
            label: "仓库名称",
            fieldName: "name"
        },
        {
            formType: PageFormType.Input,
           label: "编码",
            fieldName: "code"
        },
        {
            formType: PageFormType.Radio,
            label: "状态",
            fieldName: "enabled"
        },
    ],

    rules: {
        name: [
            { required: true, message: '请输入仓库名称', trigger: 'blur' },
        ],
        code: [
            { required: true, message: '请输入编码', trigger: 'blur' },
        ],
        enabled: [
            { required: true, message: '请选择状态', trigger: 'change' },
        ],
       
        domainId: [
            { required: true, message: '请选择所属库域', trigger: 'change' },
        ],
        departmentId: [
            { required: true, message: '请选择所属部门', trigger: 'change' },
        ],
    },

    formData: {
        id: pars?.id ?? null,
        enabled:1
    },

    options: {
    },
});


inventoryWarehouseService.apiInventoryWarehouseDetailoptionGet(pars?.id)
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


    inventoryWarehouseService.apiInventoryWarehouseAddorupdatePost(formData)
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

