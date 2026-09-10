<template>
  <div class="todo-form-page">
    <div class="todo-form-body">
      <YzCustomForm ref="yzCustomFormRef" :form="formData.form" :attr-data="formData.attrData"
        :component-group-list="[]" />
    </div>
    <div class="todo-form-tools">
      <el-button @click="submit('save')">保存</el-button>
      <el-button type="primary" @click="submit('complete')">完成</el-button>
      <el-button type="warning" @click="submit('skip')">跳过</el-button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import YzCustomForm from '@/components/common/YzCustomForm/index.vue'
import type { ReleaseData, matterExpose } from '@/components/common/YzCustomForm/index'
import { workflowTaskService, workflowFormService } from '@/api/workflow'
import { ElMessage } from 'element-plus'

const { taskId, workflowId, nodeId } = defineProps<{
  taskId: string
  workflowId: string
  nodeId: string
}>()

const yzCustomFormRef = ref<matterExpose>()
const formData = ref<ReleaseData>({ form: [], attrData: {} })

const submit = async (action: 'save' | 'complete' | 'skip') => {
  const data = yzCustomFormRef.value?.getData() ?? formData.value
  const formDataPayload: Record<string, any> = {}
  // 从 attrData 里提取每个组件填写的 value 作为表单数据
  Object.entries(data.attrData ?? {}).forEach(([ident, attrs]) => {
    attrs.forEach((attr: any) => {
      if (attr.name) formDataPayload[attr.name] = attr.value
    })
  })

  try {
    const res = await workflowTaskService.apiWorkflowTaskPost({
      taskId,
      action,
      formData: formDataPayload,
      comment: '',
    })
    ElMessage.success(action === 'save' ? '已保存' : action === 'complete' ? '已完成' : '已跳过')
  } catch (e: any) {
    ElMessage.error(e?.message ?? '操作失败')
  }
}

onMounted(async () => {
  try {
    const res = await workflowFormService.apiWorkflowFormWorkflowidNodeidGet(workflowId, nodeId)
    const data = res.data?.data
    if (data) {
      formData.value.form = data.formJson ? JSON.parse(data.formJson) : []
      formData.value.attrData = data.attrDataJson ? JSON.parse(data.attrDataJson) : {}
    }
  } catch {
    // 无表单，忽略
  }
})
</script>

<style lang="less" scoped>
.todo-form-page {
  display: flex;
  flex-direction: column;
  height: 100%;

  .todo-form-body {
    flex: 1;
    overflow-y: auto;
    min-height: 0;
  }

  .todo-form-tools {
    display: flex;
    justify-content: flex-end;
    gap: 12px;
    padding: 12px 16px;
    border-top: 1px solid #ebeef5;
    background: #fff;
  }
}
</style>
