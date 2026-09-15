




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { onMounted,ref } from 'vue';
import { ElMessage } from 'element-plus';
import { pmFlowItemService } from "@/api/index.ts";

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
            formType: PageFormType.Input,
            label: "名称",
            fieldName: "name"
        },
        {
            formType: PageFormType.OneSelectSearch,
            label: "PmFlowTempId",
            fieldName: "pmFlowTempId"
        },
        {
            formType: PageFormType.Input,
            label: "StartTime",
            fieldName: "startTime"
        },
        {
            formType: PageFormType.Input,
            label: "EndTime",
            fieldName: "endTime"
        },
        {
            formType: PageFormType.Input,
            label: "PlanStartTime",
            fieldName: "planStartTime"
        },
        {
            formType: PageFormType.Input,
            label: "PlanEndTime",
            fieldName: "planEndTime"
        },
        {
            formType: PageFormType.TextAreaInput,
            label: "Description",
            fieldName: "description"
        },
        {
            formType: PageFormType.Radio,
            label: "Enabled",
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

onMounted(async () => {

    var res=await pmFlowItemService.apiPmFlowItemDetailoptionGet(pars?.id);
    

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



    pmFlowItemService.apiPmFlowItemAddorupdatePost(formData)
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

