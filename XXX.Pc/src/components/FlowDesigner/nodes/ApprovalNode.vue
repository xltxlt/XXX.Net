<template>
  <BaseNode type="approval" :data="data" :selected="selected" :top-handle="true" :bottom-handle="true"
    :right-handle="true">
    <template #default>
      <div v-if="data.approver" class="approval-extra">
        👤 {{ data.approver }}
      </div>
      <div v-if="data.approvalMode" class="approval-mode">
        {{
          data.approvalMode === 'single'
            ? '单人审批'
            : data.approvalMode === 'multi'
            ? '会签'
            : '或签'
        }}
      </div>
      <div v-if="!data.approver" class="approval-placeholder">
        点击配置审批人
      </div>
    </template>
  </BaseNode>
</template>

<script setup lang="ts">
import BaseNode from './BaseNode.vue'

defineProps<{
  data: Record<string, any>
  selected?: boolean
}>()
</script>

<style lang="less" scoped>
.approval-extra {
  font-size: 10px;
  color: #9c27b0;
}
.approval-mode {
  font-size: 10px;
  color: #e6a23c;
  margin-top: 2px;
}
.approval-placeholder {
  font-size: 10px;
  color: #c0c4cc;
  text-align: center;
}
</style>
