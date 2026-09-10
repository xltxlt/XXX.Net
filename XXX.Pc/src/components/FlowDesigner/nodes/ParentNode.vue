<template>
  <BaseNode type="parent" :data="data" :selected="selected" :top-handle="true" :left-handle="true">
    <template #default>
      <div class="parent-node-extra">拖入节点作为子流程</div>
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
.parent-node-extra {
  font-size: 10px;
  color: #13c2c2;
  text-align: center;
}
</style>
