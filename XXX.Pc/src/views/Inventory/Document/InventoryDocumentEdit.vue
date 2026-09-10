<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { onMounted, ref } from 'vue';
import { ElMessage } from 'element-plus';
import { inventoryDocumentService } from "@/api/inventory.ts";

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
            label: "基础信息",
            fieldName: "",
            child: [
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "所属库域",
                    fieldName: "domainId"
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "所属仓库",
                    fieldName: "fromWarehouseId"
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "调往仓库",
                    fieldName: "toWarehouseId"
                },
                {
                    formType: PageFormType.Input,
                    label: "单据号",
                    fieldName: "documentNo"
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "单据类型",
                    fieldName: "documentType"
                },
                {
                    formType: PageFormType.TextAreaInput,
                    label: "备注",
                    fieldName: "remark"
                },]
        },

    ],

    rules: {
        domainId: [
            { required: true, message: '请选择所属库域', trigger: 'blur' }
        ],

    },

    formData: {
        id: pars?.id ?? null,
        enabled: 1
    },

    options: {
    },
});

onMounted(async () => {
    inventoryDocumentService.apiInventoryDocumentDetailoptionGet(pars?.id)
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


    inventoryDocumentService.apiInventoryDocumentAddorupdatePost(formData)
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
