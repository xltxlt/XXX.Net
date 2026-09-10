<template>
  <BaseNode type="condition" :data="data" :selected="selected"
    :handles="[
      { position: 'top', type: 'target',title:'' },
      { position: 'left', type: 'source',title:'真' },
      { position: 'right', type: 'source',title:'假', bgColor:'#f56c6c' },
    ]">
    <template #default>
      <div v-if="data.condition" class="condition-extra">
        🔀 {{ data.condition }}
      </div>
      <div v-else class="condition-placeholder">点击配置条件</div>
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
.condition-extra {
  font-size: 10px;
  color: #e6a23c;
  word-break: break-all;
}

.condition-placeholder {
  font-size: 10px;
  color: #c0c4cc;
  text-align: center;
}
</style>
