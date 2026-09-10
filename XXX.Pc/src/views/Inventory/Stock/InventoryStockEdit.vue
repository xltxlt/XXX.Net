




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { inventoryStockService } from "@/api/inventory";

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
            label: "租户",
            fieldName: "tenantId"
        },
        {
            formType: PageFormType.Input,
            label: "名称",
            fieldName: "name"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "DomainId",
            fieldName: "domainId"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "ItemId",
            fieldName: "itemId"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "WarehouseId",
            fieldName: "warehouseId"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "LocationId",
            fieldName: "locationId"
        },
        {
            formType: PageFormType.DecimalInput,
            label: "Quantity",
            fieldName: "quantity"
        },
        {
            formType: PageFormType.DecimalInput,
            label: "LockedQuantity",
            fieldName: "lockedQuantity"
        },
        {
            formType: PageFormType.DecimalInput,
            label: "AvailableQuantity",
            fieldName: "availableQuantity"
        },
        {
            formType: PageFormType.DecimalInput,
            label: "MinQuantity",
            fieldName: "minQuantity"
        },
        {
            formType: PageFormType.DecimalInput,
            label: "MaxQuantity",
            fieldName: "maxQuantity"
        },
    ],

    rules: {
    },

    formData: {
        id: pars?.id ?? null,
    },

    options: {
    },
});


inventoryStockService.apiInventoryStockDetailoptionGet(pars?.id)
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


    inventoryStockService.apiInventoryStockAddorupdatePost(formData)
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

