<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import { ElMessage } from 'element-plus';
import PageForm from '@/components/PageForm/PageForm.vue';
import type { ReleaseData } from '@/components/PageForm/enhancedIndex';
import type { PageFormEnhancedExpose } from '@/components/PageForm/PageFormEnhanced.vue';
import { pmFlowItemService, pmFlowTempService, workflowDefinitionService, workflowNodeFormService } from "@/api/pm.ts";
import {
    type TempEditPageData,
    PageFormType
} from '@/components/PageForm';
import PageFormEnhanced from '@/components/PageForm/PageFormEnhanced.vue';

const { pars } = defineProps<{
    pars?: Record<string, any>
}>();

const emit = defineEmits([
    'closeDialog',
    'refreshList'
]);

const isCreate = !pars?.id;
const businessFormRef = ref<any>();
const startFormRef = ref<PageFormEnhancedExpose>();
const currentStep = ref(0);
const startFormLoading = ref(false);
const startFormData = ref<ReleaseData>({ form: [], attrData: {} });
const startNodeId = ref('');
const startFormReady = ref(false);
let loadedStartTemplateId = '';

const tempForm = ref<TempEditPageData>({
    loading: false,
    hideBtn: true,
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
        name: [{ required: true, message: '请填写名称', trigger: 'blur' }],
        enabled: [{ required: true, message: '请填写状态', trigger: 'blur' }],
        pmFlowTempId: [{ required: true, message: '请选择流程模板', trigger: 'blur' }],
        planStartTime: [{ required: true, message: '请选择计划开始时间', trigger: 'blur' }],
        planEndTime: [{ required: true, message: '请选择计划结束时间', trigger: 'blur' }],
    },
    formData: {
        id: pars?.id ?? null,
    },
    options: {},
});

const parseJson = (value: any, fallback: any) => {
    if (!value) return fallback;
    if (typeof value === 'object') return value;
    try { return JSON.parse(value); } catch { return fallback; }
};

const clearStartForm = () => {
    startNodeId.value = '';
    startFormData.value = { form: [], attrData: {} };
    startFormReady.value = false;
};

const loadStartForm = async (templateId: string | number | undefined) => {
    if (!isCreate || !templateId || String(templateId) === loadedStartTemplateId) return;

    loadedStartTemplateId = String(templateId);
    startFormLoading.value = true;
    startFormReady.value = false;

    try {
        const tempRes = await workflowDefinitionService.apiWorkflowDefinitionTempPublishStatusTemplateidGet(String(templateId));
        const temp = tempRes.data?.data || {};
        const workflowId = temp?.workflowId;
        const workflowDefinitionId = temp?.workflowDefinitionId;

        if (!workflowId || !workflowDefinitionId) {
            clearStartForm();
            ElMessage.warning('该流程模板尚未发布流程，无法发起');
            return;
        }

        const definitionRes = await workflowDefinitionService.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(
            String(workflowDefinitionId)
        );
        const definition = definitionRes.data?.data;
        const nodes = definition?.nodes ?? definition?.Nodes ?? [];
        const startNode = nodes.find((node: any) => String(node.type ?? node.Type) === 'start');

        if (!startNode?.id && !startNode?.Id) {
            clearStartForm();
            ElMessage.error('流程定义缺少开始节点');
            return;
        }

        startNodeId.value = String(startNode.id ?? startNode.Id);

        const formRes = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
            String(workflowDefinitionId),
            startNodeId.value
        );
        const nodeForm = formRes.data?.data;

        if (!nodeForm) {
            clearStartForm();
            ElMessage.error('开始节点尚未设计表单');
            return;
        }

        startFormData.value = {
            form: parseJson(nodeForm.formJson, []),
            attrData: parseJson(nodeForm.attrDataJson, {}),
        };
        startFormReady.value = startFormData.value.form.length > 0;

        if (!startFormReady.value) {
            ElMessage.error('开始节点表单为空，请先设计开始节点表单');
        }
    } catch (error: any) {
        clearStartForm();
        ElMessage.error(error?.message ?? '加载开始节点表单失败');
    } finally {
        startFormLoading.value = false;
    }
};

watch(
    () => tempForm.value.formData.pmFlowTempId,
    (value) => loadStartForm(value),
);

onMounted(async () => {
    const res = await pmFlowItemService.apiPmFlowItemDetailoptionGet(pars?.id);

    tempForm.value.options = Object.assign(
        tempForm.value.options,
        res.data.data?.options ?? {}
    );
    tempForm.value.formData = Object.assign(
        tempForm.value.formData,
        res.data.data?.detail ?? {}
    );

    if (isCreate) {
        await loadStartForm(tempForm.value.formData.pmFlowTempId);
    }
});

const validateBusinessForm = async () => {
    try {
        await businessFormRef.value?.ruleFormRef?.validate();
        return true;
    } catch {
        return false;
    }
};

const validateStartForm = async () => {
    if (!startFormReady.value || !startNodeId.value) {
        ElMessage.error('当前流程没有可用的 Start 节点表单');
        return false;
    }
    const result = await startFormRef.value?.validate?.();
    if (result === false) {
        // ElMessage.error('请完善 Start 节点表单必填项');
        return false;
    }
    return true;
};

const goNext = async () => {
    if (await validateBusinessForm()) currentStep.value = 1;
};

const goPrev = () => { currentStep.value = 0; };

const getStartFormValues = () => {
    const data = startFormRef.value?.getData() ?? startFormData.value;
    return data;
};

const sumbit = async () => {
    if (isCreate) {
        if (startFormLoading.value) {
            ElMessage.warning('Start 节点表单正在加载，请稍候');
            return;
        }
        var validateResult = await validateStartForm();
        if (!validateResult) return;
    }

    const formData: any = { ...tempForm.value.formData };
    if (isCreate) formData.startFormData = getStartFormValues();
    tempForm.value.loading = true;
    try {
        const res = await pmFlowItemService.apiPmFlowItemAddorupdatePost(formData);
        if (res.data.statusCode != 200) {
            ElMessage({ message: '操作失败', type: 'error', plain: true });
            return;
        }
        ElMessage({ message: isCreate ? '流程发起成功' : '操作成功', type: 'success', plain: true });
        emit('closeDialog');
        emit('refreshList');
    } catch (error: any) {
        ElMessage.error(error?.message ?? '操作失败');
    } finally {
        tempForm.value.loading = false;
    }
};
</script>

<template>
    <div class="edit-page flow-item-page">
        <div v-if="isCreate" class="step-header">
            <el-steps :active="currentStep" align-center>
                <el-step title="填写基础参数" description="项目名称、时间、流程模板等" />
                <el-step title="填写项目表单" description="完成流程发起所需业务信息" />
            </el-steps>
        </div>

        <div v-show="!isCreate || currentStep === 0" class="business-form-section">
            <page-form ref="businessFormRef" :temp-form="tempForm" />
        </div>

        <div v-if="isCreate && currentStep === 1" class="start-form-section" v-loading="startFormLoading">

            <div v-if="startFormReady" class="start-form-section__body">
                <PageFormEnhanced :hide-btn="true" ref="startFormRef" :cols="2" :form="startFormData.form"
                    :attr-data="startFormData.attrData"></PageFormEnhanced>
            </div>

            <el-empty v-else description="当前流程模板没有可用的开始节点表单" />
        </div>

        <div v-if="isCreate" class="step-footer">
            <el-button v-if="currentStep === 1" @click="goPrev">上一步</el-button>
            <el-button v-if="currentStep === 0" type="primary" @click="goNext">下一步：填写 Start 节点表单</el-button>
            <el-button v-if="currentStep === 1" type="primary" :loading="tempForm.loading"
                @click="sumbit">保存并发起流程</el-button>
        </div>
        <div v-else class="step-footer">
            <el-button type="primary" :loading="tempForm.loading" @click="sumbit">保存</el-button>
        </div>
    </div>
</template>

<style lang='less' scoped>
.edit-page {
    height: 100%;
    overflow-y: auto;
    padding-bottom: 40px;
}

.step-header {
    padding: 20px 25px 10px 10px;
    background: #fff;
    border-bottom: 1px solid #edf1f7;
}

.business-form-section {
    min-height: calc(100% - 100px);
}

.step-footer {
    position: sticky;
    bottom: 0;
    z-index: 10;
    display: flex;
    justify-content: flex-end;
    gap: 10px;
    padding: 12px 25px 12px 10px;
    background: #fff;
}

.start-form-section {
    margin: 0 25px 80px 10px;
    border: 1px solid #e5eaf3;
    border-radius: 8px;
    background: #fff;
    overflow: hidden;

    &__header {
        display: flex;
        align-items: center;
        justify-content: space-between;
        padding: 18px 20px;
        border-bottom: 1px solid #edf1f7;
        background: #f8fafc;
    }

    &__title {
        color: #1f2937;
        font-size: 16px;
        font-weight: 600;
    }

    &__desc {
        margin-top: 5px;
        color: #8a94a6;
        font-size: 13px;
    }

    &__body {
        padding: 10px 10px 20px;
    }
}
</style>
<style lang="less">
.flow-item-page.edit-page {
    overflow: hidden !important;
}
</style>
