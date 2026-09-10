<template>
  <BaseNode type="task" :data="data" :selected="selected" :top-handle="true" :bottom-handle="true" >
    <template #default>
      <div v-if="data.assignee" class="task-extra">
        👤 {{ data.assignee }}
      </div>
      <div v-if="data.description" class="task-desc">
        {{ data.description }}
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
.task-extra {
  font-size: 10px;
  color: #409eff;
}
.task-desc {
  font-size: 10px;
  color: #999;
  margin-top: 4px;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  max-width: 140px;
}
</style>
