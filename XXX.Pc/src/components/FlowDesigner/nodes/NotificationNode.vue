<template>
  <BaseNode type="notification" :data="data" :selected="selected" :top-handle="true" >
    <template #default>
      <div v-if="data.message" class="notification-extra">
        ✉ {{ data.message }}
      </div>
      <div v-else class="notification-placeholder">点击配置通知</div>
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
.notification-extra {
  font-size: 10px;
  color: #67c23a;
  word-break: break-all;
}

.notification-placeholder {
  font-size: 10px;
  color: #c0c4cc;
  text-align: center;
}
</style>
