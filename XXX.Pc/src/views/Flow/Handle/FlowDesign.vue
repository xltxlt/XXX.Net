<template>
  <div class="flow-design">
    <div class="flow-design__header">
      <div class="flow-design__title">
        <el-button text @click="goBack">
          <el-icon><ArrowLeft /></el-icon>
          返回
        </el-button>
        <span>流程设计</span>
        <el-tag v-if="activeNode" size="small">{{ activeNode.name }}</el-tag>
      </div>
      <div class="flow-design__actions">
        <el-button @click="saveAll" :loading="saving">保存全部</el-button>
      </div>
    </div>

    <div class="flow-design__body">
      <aside class="flow-design__nodes">
        <div class="panel-title">流程节点</div>
        <div
          v-for="node in normalizedNodes"
          :key="node.id"
          class="node-item"
          :class="{ active: node.id === activeNodeId }"
          @click="selectNode(node.id)"
        >
          <div class="node-item__name">{{ node.name }}</div>
          <el-tag v-if="hasForm(node.id)" size="small" type="success">已设计</el-tag>
          <span v-else class="node-item__empty">未设计</span>
        </div>
      </aside>

      <main class="flow-design__content">
        <div v-if="!activeNode" class="empty-state">
          <el-empty description="请选择流程节点" />
        </div>

        <template v-else>
          <!-- 关键点：节点切换只改变 activeNodeId。
               每个节点自己的 schema 永远保存在 formMap[nodeId] 中。 -->
          <WorkflowFormDesign
            :key="activeNode.id"
            :node-id="activeNode.id"
            :workflow-id="workflowId"
            :node-type="activeNode.type"
            :workflow-deginition-id="workflowDefinitionId"
            :initial-data="formMap[activeNode.id]"
            @release="handleNodeRelease"
            @close-dialog="handleDesignerClose"
          />
        </template>
      </main>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref, watch } from 'vue'
import { useRouter, useRoute } from 'vue-router'
import { ArrowLeft } from '@element-plus/icons-vue'
import { ElMessage } from 'element-plus'
import WorkflowFormDesign from './WorkflowFormDesign.vue'

export interface FlowDesignNode {
  id: string
  name: string
  type?: string
}

export interface NodeFormJson {
  nodeId: string
  form: any[]
  attrData: Record<string, any>
  buttonList?: any[]
}

/**
 * FlowDesign 的核心状态：
 *
 * formMap = {
 *   [nodeId]: {
 *      nodeId,
 *      form,
 *      attrData,
 *      buttonList
 *   }
 * }
 *
 * 因此 A -> B -> A 时，A 使用的仍然是 formMap[A]，
 * 不会被 B 的表单覆盖。
 */
const props = withDefaults(defineProps<{
  nodes?: FlowDesignNode[]
  workflowId?: string
  workflowDefinitionId?: string
  initialNodeId?: string
  modelValue?: Record<string, NodeFormJson>
}>(), {
  nodes: () => [],
  workflowId: '',
  workflowDefinitionId: '',
  initialNodeId: '',
  modelValue: () => ({})
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: Record<string, NodeFormJson>): void
  (e: 'back'): void
  (e: 'save', value: Record<string, NodeFormJson>): void
  (e: 'release', value: any): void
  (e: 'node-change', nodeId: string): void
}>()

const router = useRouter()
const route = useRoute()

const saving = ref(false)
const activeNodeId = ref('')
const formMap = ref<Record<string, NodeFormJson>>({})

const normalizedNodes = computed(() => {
  if (props.nodes.length) return props.nodes

  // 兼容通过路由进入 FlowDesign 的场景。
  // query.nodes 可以是 JSON 数组，也可以不传。
  const raw = route.query.nodes
  if (typeof raw === 'string') {
    try {
      const value = JSON.parse(raw)
      if (Array.isArray(value)) return value
    } catch {
      // ignore invalid query
    }
  }
  return []
})

const activeNode = computed(() =>
  normalizedNodes.value.find(item => item.id === activeNodeId.value)
)

const clone = <T>(value: T): T => {
  if (value === undefined || value === null) return value
  return JSON.parse(JSON.stringify(value))
}

const hasForm = (nodeId: string) => {
  const data = formMap.value[nodeId]
  return !!data && (
    (Array.isArray(data.form) && data.form.length > 0) ||
    Object.keys(data.attrData || {}).length > 0 ||
    (Array.isArray(data.buttonList) && data.buttonList.length > 0)
  )
}

const normalizeSaved = (nodeId: string, value: any): NodeFormJson => ({
  nodeId,
  form: clone(Array.isArray(value?.form) ? value.form : []),
  attrData: clone(value?.attrData && typeof value.attrData === 'object' ? value.attrData : {}),
  buttonList: clone(Array.isArray(value?.buttonList) ? value.buttonList : [])
})

const restoreFromStorage = () => {
  const storageKey = getStorageKey()
  try {
    const raw = sessionStorage.getItem(storageKey)
    if (!raw) return
    const value = JSON.parse(raw)
    if (value && typeof value === 'object') {
      Object.entries(value).forEach(([nodeId, data]) => {
        formMap.value[nodeId] = normalizeSaved(nodeId, data)
      })
    }
  } catch {
    // ignore invalid cache
  }
}

const persist = () => {
  const snapshot = clone(formMap.value)
  emit('update:modelValue', snapshot)
  try {
    sessionStorage.setItem(getStorageKey(), JSON.stringify(snapshot))
  } catch {
    // sessionStorage is only a cache, not the source of truth.
  }
}

const getStorageKey = () =>
  `flow-design-form:${props.workflowDefinitionId || route.query.workflowDefinitionId || 'default'}:${props.workflowId || route.query.workflowId || 'default'}`

const selectNode = (nodeId: string) => {
  if (!nodeId || nodeId === activeNodeId.value) return
  activeNodeId.value = nodeId
  emit('node-change', nodeId)
}

const handleNodeRelease = (data: any) => {
  const nodeId = String(data?.nodeId || activeNodeId.value)
  if (!nodeId) return

  // 深拷贝，避免子设计器后续修改引用到 FlowDesign 的其他节点数据。
  formMap.value[nodeId] = normalizeSaved(nodeId, {
    form: data?.formJson ? parseJson(data.formJson, data.form) : data?.form,
    attrData: data?.attrDataJson ? parseJson(data.attrDataJson, data.attrData) : data?.attrData,
    buttonList: data?.buttonListJson ? parseJson(data.buttonListJson, data.buttonList) : data?.buttonList
  })

  persist()
  ElMessage.success(`${activeNode.value?.name || '节点'}表单已保存`)
}

const parseJson = (value: any, fallback: any) => {
  if (value === undefined || value === null || value === '') return clone(fallback)
  if (typeof value !== 'string') return clone(value)
  try {
    return JSON.parse(value)
  } catch {
    return clone(fallback)
  }
}

const handleDesignerClose = () => {
  persist()
  goBack()
}

const saveAll = async () => {
  saving.value = true
  try {
    persist()
    emit('save', clone(formMap.value))
    ElMessage.success('节点表单数据已保存')
  } finally {
    saving.value = false
  }
}

const goBack = () => {
  persist()
  emit('back')
  // 如果父组件没有接管返回，则自动返回上一页。
  if (window.history.length > 1) router.back()
}

onMounted(() => {
  const external = props.modelValue || {}
  Object.entries(external).forEach(([nodeId, data]) => {
    formMap.value[nodeId] = normalizeSaved(nodeId, data)
  })

  restoreFromStorage()

  const firstNode =
    props.initialNodeId ||
    String(route.query.nodeId || '') ||
    normalizedNodes.value[0]?.id ||
    ''

  if (firstNode) activeNodeId.value = firstNode
})

watch(
  () => props.modelValue,
  value => {
    if (!value) return
    Object.entries(value).forEach(([nodeId, data]) => {
      formMap.value[nodeId] = normalizeSaved(nodeId, data)
    })
  },
  { deep: true }
)

defineExpose({
  formMap,
  activeNodeId,
  getNodeForm: (nodeId: string) => clone(formMap.value[nodeId]),
  getAllNodeForms: () => clone(formMap.value),
  saveAll
})
</script>

<style scoped lang="less">
.flow-design {
  display: flex;
  flex-direction: column;
  width: 100%;
  height: 100%;
  min-height: 700px;
  overflow: hidden;
  background: #f5f7fa;

  &__header {
    display: flex;
    align-items: center;
    justify-content: space-between;
    height: 56px;
    padding: 0 18px;
    background: #fff;
    border-bottom: 1px solid #e4e7ed;
  }

  &__title {
    display: flex;
    align-items: center;
    gap: 10px;
    font-size: 17px;
    font-weight: 600;
    color: #303133;
  }

  &__body {
    display: flex;
    flex: 1;
    min-height: 0;
  }

  &__nodes {
    width: 250px;
    flex: 0 0 250px;
    overflow-y: auto;
    background: #fff;
    border-right: 1px solid #e4e7ed;
  }

  &__content {
    flex: 1;
    min-width: 0;
    min-height: 0;
    overflow: hidden;
    background: #f5f7fa;
  }
}

.panel-title {
  padding: 16px;
  font-size: 14px;
  font-weight: 600;
  color: #303133;
  border-bottom: 1px solid #ebeef5;
}

.node-item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 8px;
  min-height: 52px;
  padding: 0 14px;
  cursor: pointer;
  border-left: 3px solid transparent;
  border-bottom: 1px solid #f0f2f5;

  &:hover {
    background: #f5f9ff;
  }

  &.active {
    color: #409eff;
    background: #ecf5ff;
    border-left-color: #409eff;

    .node-item__name {
      font-weight: 600;
    }
  }

  &__name {
    min-width: 0;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
  }

  &__empty {
    flex: 0 0 auto;
    font-size: 12px;
    color: #a8abb2;
  }
}

.empty-state {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
}
</style>
