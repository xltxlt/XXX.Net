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
                    label: "所属仓库",
                    fieldName: "fromWarehouseId"
                },
                {
                    formType: PageFormType.Input,
                    label: "单据号",
                    fieldName: "documentNo",
                    comProps: {
                        disabled: true,
                        readonly: true,
                        placeholder: '自动生成',
                    }
                },
                {
                    formType: PageFormType.OneSelectSearch,
                    label: "单据类型",
                    fieldName: "documentType",
                    comProps: {
                        disabled: true
                    }
                },
                {
                    formType: PageFormType.TextAreaInput,
                    label: "备注",
                    fieldName: "remark"
                },]
        },
        {
            formType: PageFormGroup.List,
            label: "出库明细",
            fieldName: "children",
            child: [

                {
                    formType: PageFormGroup.Group,
                    label: "",
                    fieldName: "",
                    child: [{
                        formType: PageFormType.OneSelectSearch,
                        label: "物品",
                        fieldName: "itemId"
                    },
                    {
                        formType: PageFormType.Number,
                        label: "数量",
                        fieldName: "quantity",
                    },
                    {
                        formType: PageFormType.TreeSelectLast,
                        label: "来源仓位",
                        fieldName: "fromLocationId",
                    },
                    {
                        formType: PageFormType.Number,
                        label: "可用数量",
                        fieldName: "useQuantity",
                        comProps: {
                            disabled: true,
                            readonly: true,
                            placeholder: '选择物品和仓位后自动带出',
                        }
                    },
                    {
                        formType: PageFormType.TextAreaInput,
                        label: "备注",
                        fieldName: "remark"
                    }]
                }
            ]
        },

    ],

    rules: {
        domainId: [
            { required: true, message: '请选择所属库域', trigger: 'blur' }
        ],
        fromWarehouseId: [
            { required: true, message: '请选择所属仓库', trigger: 'blur' }
        ],

    },

    formData: {
        id: pars?.id ?? null,
        enabled: 1,
        documentType: pars?.documentType ?? null,
        children: [{} as any]
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

    

    inventoryDocumentService.apiInventoryDocumentCreatePost(formData)
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
