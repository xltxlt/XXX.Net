<template>
  <BaseNode type="end" :data="data" :selected="selected" :top-handle="true"  >
    <template #default>
      <div class="end-node-extra">流程终点</div>
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
.end-node-extra {
  font-size: 10px;
  color: #f56c6c;
  text-align: center;
}
</style>
