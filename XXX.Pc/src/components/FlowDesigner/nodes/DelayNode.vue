<template>
  <BaseNode type="delay" :data="data" :selected="selected" :top-handle="true" :bottom-handle="true">
    <template #default>
      <div v-if="data.duration" class="delay-extra">
        ⏱ {{ data.duration }}{{ data.unit === 'hour' ? '小时' : data.unit === 'second' ? '秒' : '分钟' }}
      </div>
      <div v-else class="delay-placeholder">点击配置延时</div>
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
.delay-extra {
  font-size: 10px;
  color: #909399;
}

.delay-placeholder {
  font-size: 10px;
  color: #c0c4cc;
  text-align: center;
}
</style>
