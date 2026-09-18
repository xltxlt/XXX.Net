<script setup lang="ts">
import { onMounted, ref, watch } from 'vue';
import { ElMessage } from 'element-plus';
import PageForm from '@/components/PageForm/PageForm.vue';
import YzCustomForm from '@/components/common/YzCustomForm/index.vue';
import type { matterExpose, ReleaseData } from '@/components/common/YzCustomForm/index';
import { pmFlowItemService, pmFlowTempService, workflowDefinitionService, workflowNodeFormService } from "@/api/pm.ts";
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

const isCreate = !pars?.id;
const startFormRef = ref<matterExpose>();
const startFormLoading = ref(false);
const startFormData = ref<ReleaseData>({ form: [], attrData: {} });
const startNodeId = ref('');
const startFormReady = ref(false);
let loadedStartTemplateId = '';

const tempForm = ref<TempEditPageData>({
    loading: false,
    hideBtn: pars?.lock == 'lock',
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
        const tempRes = await pmFlowTempService.apiPmFlowTempDetailoptionGet(String(templateId));
        const temp = tempRes.data?.data?.detail;
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

const getStartFormValues = () => {
    const data = startFormRef.value?.getData() ?? startFormData.value;
    const values: Record<string, unknown> = {};

    Object.values(data.attrData ?? {}).forEach((attributes: any) => {
        attributes.forEach((attribute: any) => {
            if (attribute.name) values[attribute.name] = attribute.value;
        });
    });

    return values;
};

const sumbit = async () => {
    if (isCreate) {
        if (!startFormReady.value || !startNodeId.value) {
            ElMessage.error('请先配置开始节点表单');
            return;
        }
        if (startFormLoading.value) {
            ElMessage.warning('开始节点表单正在加载，请稍候');
            return;
        }
    }

    const formData: any = {
        ...tempForm.value.formData,
    };

    if (isCreate) {
        formData.startFormData = getStartFormValues();
    }

    tempForm.value.loading = true;
    try {
        const res = await pmFlowItemService.apiPmFlowItemAddorupdatePost(formData);

        if (res.data.statusCode != 200) {
            ElMessage({
                message: '操作失败',
                type: 'error',
                plain: true,
            });
            return;
        }

        ElMessage({
            message: isCreate ? '流程发起成功' : '操作成功',
            type: 'success',
            plain: true,
        });

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
    <div class="edit-page">
        <page-form
            :temp-form="tempForm"
            @on-submit="sumbit"
        />

        <div v-if="isCreate" class="start-form-section" v-loading="startFormLoading">
            <div class="start-form-section__header">
                <div>
                    <div class="start-form-section__title">发起表单</div>
                    <div class="start-form-section__desc">
                        请填写开始节点表单，提交流程时与上面的流程参数一起保存并发起。
                    </div>
                </div>
                <el-tag v-if="startFormReady" type="success">开始节点</el-tag>
            </div>

            <div v-if="startFormReady" class="start-form-section__body">
                <YzCustomForm
                    ref="startFormRef"
                    :form="startFormData.form"
                    :attr-data="startFormData.attrData"
                    :component-group-list="[]"
                />
            </div>

            <el-empty
                v-else
                description="当前流程模板没有可用的开始节点表单"
            />
        </div>
    </div>
</template>

<style lang='less' scoped>
.edit-page {
    height: 100%;
    overflow-y: auto;
    padding-bottom: 40px;
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
