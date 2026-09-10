<script setup lang="ts">
import * as Icons from '@element-plus/icons-vue'
// 获取所有图标名
const iconNames = Object.keys(Icons)
const emit=defineEmits(['selectIcon'])
const selectIcon=(name:string)=>{
     emit('selectIcon',name)
}
</script>

<template>
  <div class="icon-select-page">
    <el-row :gutter="30" style="align-items: center;">
      <el-col :span="6" style="cursor: pointer;margin-top: 20px;" v-for="name in iconNames" :key="name" @click="selectIcon(name)">
        <el-icon :size="26" >
          <component :is="name" />
        </el-icon>
        <div style="font-size: 12px; margin-top: 4px;">{{ name }}</div>
      </el-col>
    </el-row>
  </div>

</template>

<style lang="less" scoped>
.icon-select-page {
  padding: 20px;
  height: 100%;

}
</style>