<template>
  <BaseNode type="parallel" :data="data" :selected="selected"
    :handles="[
      { position: 'top', type: 'target' },
      { position: 'bottom', type: 'source' },
      { position: 'left', type: 'source' },
      { position: 'right', type: 'source' },
    ]">
    <template #default>
      <div class="parallel-node-extra">并行分支</div>
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
.parallel-node-extra {
  font-size: 10px;
  color: #409eff;
  text-align: center;
}
</style>
