<template>
  <BaseNode type="service" :data="data" :selected="selected" :top-handle="true" :bottom-handle="true">
    <template #default>
      <div v-if="data.serviceUrl" class="service-extra">
        ⚙ {{ data.method }} {{ data.serviceUrl }}
      </div>
      <div v-else class="service-placeholder">点击配置服务</div>
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
.service-extra {
  font-size: 10px;
  color: #e6a23c;
  word-break: break-all;
}

.service-placeholder {
  font-size: 10px;
  color: #c0c4cc;
  text-align: center;
}
</style>
