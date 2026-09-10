<template>
  <BaseNode type="start" :data="data" :selected="selected"  :bottom-handle="true" >
    <template #default>
      <div class="start-node-extra">流程起点</div>
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
.start-node-extra {
  font-size: 10px;
  color: #67c23a;
  text-align: center;
}
</style>
