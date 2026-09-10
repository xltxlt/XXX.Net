<template>
  <div class="flow-start-page" v-loading="loading">
    <el-form label-width="100px" @submit.prevent>
      <el-form-item label="任务名称" required>
        <el-input v-model.trim="taskName" maxlength="100" show-word-limit placeholder="请输入任务名称" />
      </el-form-item>
    </el-form>

    <YzCustomForm
      ref="customFormRef"
      :form="formData.form"
      :attr-data="formData.attrData"
      :component-group-list="[]"
    />

    <div class="flow-start-page__actions">
      <el-button @click="emit('closeDialog')">取消</el-button>
      <el-button type="primary" :loading="submitting" @click="startFlow">发起流程</el-button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import YzCustomForm from '@/components/common/YzCustomForm/index.vue'
import type { matterExpose, ReleaseData } from '@/components/common/YzCustomForm/index'
import { workflowDefinitionService, workflowInstanceService, workflowNodeFormService } from '@/api/workflow'

const { pars } = defineProps<{ pars: { workflowId?: string; workflowDefinitionId?: string } }>()
const emit = defineEmits(['closeDialog', 'refreshList'])

const customFormRef = ref<matterExpose>()
const formData = ref<ReleaseData>({ form: [], attrData: {} })
const taskName = ref('')
const loading = ref(false)
const submitting = ref(false)

const getFormValues = () => {
  const data = customFormRef.value?.getData() ?? formData.value
  const values: Record<string, unknown> = {}
  Object.values(data.attrData ?? {}).forEach((attributes: any) => {
    attributes.forEach((attribute: any) => {
      if (attribute.name) values[attribute.name] = attribute.value
    })
  })
  return values
}

const loadStartForm = async () => {
  if (!pars.workflowDefinitionId || !pars.workflowId) {
    ElMessage.error('流程尚未设计或发布')
    return
  }

  loading.value = true
  try {
    const definitionResponse = await workflowDefinitionService.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(pars.workflowDefinitionId)
    const nodes = definitionResponse.data?.data?.nodes ?? []
    const startNode = nodes.find((node: any) => node.type === 'start')
    if (!startNode?.id) throw new Error('未找到开始节点')

    const formResponse = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
      pars.workflowDefinitionId,
      startNode.id,
    )
    const nodeForm = formResponse.data?.data
    if (!nodeForm) throw new Error('请先为开始节点关联表单')

    formData.value = {
      form: nodeForm.formJson ? JSON.parse(nodeForm.formJson) : [],
      attrData: nodeForm.attrDataJson ? JSON.parse(nodeForm.attrDataJson) : {},
    }
  } catch (error: any) {
    ElMessage.error(error?.message ?? '加载开始节点表单失败')
  } finally {
    loading.value = false
  }
}

const startFlow = async () => {
  if (!taskName.value) {
    ElMessage.warning('请输入任务名称')
    return
  }
  if (!pars.workflowId) {
    ElMessage.error('流程尚未发布')
    return
  }

  submitting.value = true
  try {
    await workflowInstanceService.apiWorkflowInstanceStartWorkflowidPost(pars.workflowId, {
      ...getFormValues(),
      taskName: taskName.value,
    } as Record<string, object>)
    ElMessage.success('流程发起成功')
    emit('refreshList')
    emit('closeDialog')
  } catch (error: any) {
    ElMessage.error(error?.message ?? '流程发起失败')
  } finally {
    submitting.value = false
  }
}

onMounted(loadStartForm)
</script>

<style lang="less" scoped>
.flow-start-page {
  min-height: 300px;
  padding: 20px;

  &__actions {
    display: flex;
    justify-content: flex-end;
    gap: 12px;
    margin-top: 20px;
    padding-top: 16px;
    border-top: 1px solid #ebeef5;
  }
}
</style>
