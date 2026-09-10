<template>
  <div class="workflow-todo-page">
    <el-table :data="todoList" v-loading="loading" height="100%">
      <el-table-column prop="nodeName" label="节点" min-width="140" />
      <el-table-column prop="workflowId" label="流程" min-width="160" />
      <el-table-column prop="instanceId" label="实例" min-width="180" />
      <el-table-column label="操作" width="120" fixed="right">
        <template #default="{ row }">
          <el-button type="primary" size="small" @click="openForm(row)">处理</el-button>
        </template>
      </el-table-column>
    </el-table>

    <el-dialog v-model="formVisible" :title="`处理：${current?.nodeName ?? ''}`" width="80%" top="5vh"
      :close-on-click-modal="false">
      <WorkflowTodoForm v-if="formVisible && current" :task-id="current.id" :workflow-definition-id="current.workflowDefinitionId"
        :node-id="current.nodeId" />
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import WorkflowTodoForm from './WorkflowTodoForm.vue'
import { workflowTaskService } from '@/api/workflow'

const todoList = ref<any[]>([])
const loading = ref(false)
const formVisible = ref(false)
const current = ref<any>(null)

const loadList = async () => {
  loading.value = true
  try {
    const res = await workflowTaskService.apiWorkflowTaskTodoListGet()
    todoList.value = res.data?.data ?? []
  } catch (e: any) {
    ElMessage.error(e?.message ?? '加载待办失败')
  } finally {
    loading.value = false
  }
}

const openForm = (row: any) => {
  current.value = row
  formVisible.value = true
}

onMounted(loadList)
</script>

<style lang="less" scoped>
.workflow-todo-page {
  height: 100%;
  padding: 12px;
  background: #fff;
}
</style>
