




<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { onMounted,ref } from 'vue';
import { ElMessage } from 'element-plus';
import { pmFlowItemService } from "@/api/pm.ts";

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
            label: "流程模板",
            fieldName: "pmFlowTempId"
        },
       
        {
            formType: PageFormType.DateSelect,
            label: "计划开始时间",
            fieldName: "planStartTime"
        },
        {
            formType: PageFormType.DateSelect,
            label: "计划结束时间",
            fieldName: "planEndTime"
        },
         {
            formType: PageFormType.DateSelect,
            label: "开始时间",
            fieldName: "startTime"
        },
        {
            formType: PageFormType.DateSelect,
            label: "结束时间",
            fieldName: "endTime"
        },
         {
            formType: PageFormType.Radio,
            label: "状态",
            fieldName: "enabled"
        },
        {
            formType: PageFormType.TextAreaInput,
            label: "说明",
            fieldName: "description"
        },
    ],

    rules: {
         name: [{ required: true, message: '请填写名称', trigger: 'blur' },],
         enabled: [{ required: true, message: '请填写状态', trigger: 'blur' },],
         pmFlowTempId: [{ required: true, message: '请选择流程模板', trigger: 'blur' },],
         planStartTime: [{ required: true, message: '请选择计划开始时间', trigger: 'blur' },],
         planEndTime: [{ required: true, message: '请选择计划结束时间', trigger: 'blur' },],

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

