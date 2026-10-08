<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { onMounted, ref } from 'vue';
import { ElMessage } from 'element-plus';
import { tenantService } from "@/api/index.ts";
import { DingTalkTenantApi } from '@/api-services/generated';
import { getAPI } from '@/api-services';
import {
    type TempEditPageData,
    PageFormType
} from '@/components/PageForm';

const dingtalktenantService = getAPI(DingTalkTenantApi)
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
            label: "AppName",
            fieldName: "name"
        },
        {
            formType: PageFormType.Input,
            label: "CorpId",
            fieldName: "corpId"
        },
        {
            formType: PageFormType.Input,
            label: "ClientId",
            fieldName: "clientId"
        },
        {
            formType: PageFormType.Input,
            label: "ClientSecret",
            fieldName: "clientSecret"
        },
        {
            formType: PageFormType.Input,
            label: "AgentId",
            fieldName: "agentId"
        },
        {
            formType: PageFormType.Input,
            label: "CallbackToken",
            fieldName: "callbackToken"
        },
        {
            formType: PageFormType.Input,
            label: "CallbackEncodingAesKey",
            fieldName: "callbackEncodingAesKey"
        },
    ],

    rules: {
    },

    formData: {
        tenantId: pars?.tenantId ?? null,
    },

    options: {
    },
});

onMounted(async () => {
    var res = await dingtalktenantService.apiDingTalkTenantDetailbytenantTenantidGet(pars?.tenantId ?? '')
    // tempForm.value.options = Object.assign(
    //     tempForm.value.options,
    //     res.data.data?.options ?? {}
    // );
    tempForm.value.formData =
        Object.assign(
            tempForm.value.formData,
            res.data.data ?? {}
        );
})


const sumbit = () => {
    const formData = {
        ...tempForm.value.formData,
        tenantId: pars?.tenantId
    };
    dingtalktenantService.apiDingTalkTenantAddorupdatePost(formData)
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
