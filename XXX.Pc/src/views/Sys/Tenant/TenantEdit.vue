<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { onMounted, ref } from 'vue';
import { ElMessage } from 'element-plus';
import { tenantService } from "@/api/index.ts";

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
    hideBtn: pars?.lock == 'lock' ? true : false,

    form: [
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
            formType: PageFormType.TreeSelect,
            label: '所属层级',
            fieldName: 'path',
            comProps: {
                filterable: true,
                props: {
                    clearable: true,
                    checkStrictly: true,
                }
            }
        },
        {
            formType: PageFormType.Radio,
            label: "状态",
            fieldName: "enabled"
        },
        {
            formType: PageFormType.TextAreaInput,
            label: "备注",
            fieldName: "remark"
        },
    ],

    rules: {
        enabled: [{ required: true }],
        name: [{ required: true, message: '请填写名称', trigger: 'blur' },],
        code: [{ required: true, message: '请填写编码', trigger: 'blur' },],
    },

    formData: {
        id: pars?.id ?? null,
        enabled: 1
    },

    options: {
    },
});

onMounted(async () => {
    var res = await tenantService.apiSysTenantDetailoptionGet(pars?.id);
    tempForm.value.options = Object.assign(
        tempForm.value.options,
        res.data.data?.options ?? {}
    );
    tempForm.value.formData =
        Object.assign(
            tempForm.value.formData,
            res.data.data?.detail ?? {}
        );
})


const sumbit = () => {

    const formData = {
        ...tempForm.value.formData
    };
    tenantService.apiSysTenantAddorupdatePost(formData)
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
