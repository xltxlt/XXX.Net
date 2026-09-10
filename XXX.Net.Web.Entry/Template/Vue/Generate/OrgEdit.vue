




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { orgService } from "@/api/index.ts";

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
            label: "TenantId",
            fieldName: "tenantId"
        },
        {
            formType: PageFormType.Input,
            label: "Name",
            fieldName: "name"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "Sort",
            fieldName: "sort"
        },
        {
            formType: PageFormType.TreeSelect,
            label: "Path",
            fieldName: "path"
        },
        {
            formType: PageFormType.Input,
            label: "编码",
            fieldName: "code"
        },
        {
            formType: PageFormType.Input,
            label: "简称",
            fieldName: "shortName"
        },
        {
            formType: PageFormType.Radio,
            label: "顶级组织",
            fieldName: "isTopOrg"
        },
        {
            formType: PageFormType.Input,
            label: "域名",
            fieldName: "domainName"
        },
        {
            formType: PageFormType.Input,
            label: "企业信用代码",
            fieldName: "companyCode"
        },
        {
            formType: PageFormType.Input,
            label: "联系人",
            fieldName: "contacts"
        },
        {
            formType: PageFormType.Input,
            label: "联系人手机",
            fieldName: "contactsPhone"
        },
        {
            formType: PageFormType.Input,
            label: "地址",
            fieldName: "contactsAddress"
        },
        {
            formType: PageFormType.Radio,
            label: "状态",
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


orgService.apiSysOrgDetailoptionGet(pars?.id)
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


    orgService.apiSysOrgAddorupdatePost(formData)
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

