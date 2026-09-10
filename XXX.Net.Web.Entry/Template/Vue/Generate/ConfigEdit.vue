




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { configService } from "@/api/index.ts";

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
            formType: PageFormType.Input,
            label: "配置键",
            fieldName: "key"
        },
        {
            formType: PageFormType.Input,
            label: "配置值",
            fieldName: "value"
        },
        {
            formType: PageFormType.TextAreaInput,
            label: "说明",
            fieldName: "description"
        },
        {
            formType: PageFormType.Radio,
            label: "是否全局通用",
            fieldName: "general"
        },
        {
            formType: PageFormType.Radio,
            label: "启用/禁用",
            fieldName: "enabled"
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


configService.apiSysConfigDetailoptionGet(pars?.id)
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


    configService.apiSysConfigAddorupdatePost(formData)
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

