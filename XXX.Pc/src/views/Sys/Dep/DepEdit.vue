<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { ref } from 'vue';
import { ElMessage } from 'element-plus';
import { depService } from "@/api/index.ts";

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
            label: "所属租户",
            fieldName: "tenantId"
        },
        {
            formType: PageFormType.Input,
            label: "部门名称",
            fieldName: "name"
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
            formType: PageFormType.TreeSelect,
            label: "层级",
            fieldName: "path"
        },

        {
            formType: PageFormType.Input,
            label: "排序",
            fieldName: "sort"
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
            label: "顶级组织",
            fieldName: "isTopOrg"
        },
        {
            formType: PageFormType.Radio,
            label: "状态",
            fieldName: "enabled"
        },
    ],

    rules: {
        name: [{ required: true, message: '请填写部门名称', trigger: 'blur' },],
        code: [{ required: true, message: '请填写部门编码', trigger: 'blur' },],
        tenantId: [{ required: true, message: '请选择所属租户' },],
        enabled: [{ required: true }],
        isTopOrg: [{ required: true }],
    },
    formData: {
        id: pars?.id ?? null,
        sort: 1,
        isTopOrg:0,
        enabled: 1,
        general: 1,
        target: 99
    },
    options: {
    },
});


depService.apiSysDepDetailoptionGet(pars?.id)
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

    depService.apiSysDepAddorupdatePost(formData)
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
