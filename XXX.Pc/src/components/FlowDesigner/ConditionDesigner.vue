<template>
  <el-dialog v-model="visible" title="设置流转条件" width="1000px" destroy-on-close>
    <div class="condition-tip">
      条件保存为安全的 JSON DSL，不执行任意脚本。支持跨节点字段、AND / OR、明细 ANY / ALL / NONE、SUM、COUNT。
    </div>

    <el-alert v-if="!fields.length" type="warning" :closable="false" title="当前流程还没有可用于条件判断的节点表单字段" />

    <ConditionGroup
      v-else
      v-model="draft"
      :fields="fields"
      @change="onChange"
    />

    <template #footer>
      <el-button @click="visible = false">取消</el-button>
      <el-button type="danger" plain @click="clear">清空条件</el-button>
      <el-button type="primary" @click="save">确定</el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import type { ConditionField, ConditionGroup as ConditionGroupModel } from './condition'
import { emptyGroup } from './condition'
import ConditionGroup from './ConditionGroup.vue'

const props = defineProps<{
  modelValue?: string | null
  fields: ConditionField[]
}>()

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
  (e: 'change', value: string): void
}>()

const visible = ref(false)
const draft = ref<ConditionGroupModel>(emptyGroup())

const parsed = computed(() => {
  if (!props.modelValue) return emptyGroup()
  try {
    const value = JSON.parse(props.modelValue)
    return value?.type === 'group' ? value : emptyGroup()
  } catch {
    return emptyGroup()
  }
})

watch(() => props.modelValue, () => {
  draft.value = JSON.parse(JSON.stringify(parsed.value))
}, { immediate: true })

function open() {
  draft.value = JSON.parse(JSON.stringify(parsed.value))
  visible.value = true
}

function onChange() {
  emit('change', JSON.stringify(draft.value))
}

function clear() {
  draft.value = emptyGroup()
  save()
}

function save() {
  const value = draft.value.children.length
    ? JSON.stringify(draft.value)
    : ''
  emit('update:modelValue', value)
  emit('change', value)
  visible.value = false
}

defineExpose({ open })
</script>

<style scoped lang="less">
.condition-tip {
  margin-bottom: 12px;
  color: var(--el-text-color-secondary);
  font-size: 13px;
}
</style>
