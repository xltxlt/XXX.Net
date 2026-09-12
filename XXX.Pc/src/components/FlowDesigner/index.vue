<template>
  <div class="flow-designer" ref="designerRef">
    <!-- 顶部工具栏 -->
    <div class="flow-toolbar">
      <div class="toolbar-left">
        <slot name="toolbar-left">
          <span class="flow-title">{{ title }}</span>
        </slot>
      </div>
      <div class="toolbar-center">
        <slot name="toolbar-center">
          <el-button @click="zoomIn" :icon="Plus" title="放大">
          </el-button>

          <el-button @click="zoomOut" :icon="Minus" title="缩小">
          </el-button>
          <el-button @click="fitView" :icon="Aim" title="适应视图">
          </el-button>
          <el-button :icon="RefreshLeft" :disabled="historyIndex <= 0" @click="undo" title="撤销">
          </el-button>
          <el-button :icon="RefreshRight" :disabled="historyIndex >= history.length - 1" @click="redo" title="重做">
          </el-button>
          <el-button :icon="Grid" @click="autoLayout" title="自动排版">
          </el-button>
          <el-button type="danger" :icon="Delete" @click="handleDeleteSelected" title="删除选中">
          </el-button>
        </slot>
      </div>
      <div class="toolbar-right">
        <slot name="toolbar-right">
          <el-button type="success" :icon="Coin" @click="handleSave" title="保存流程">
            保存
          </el-button>
          <el-button type="warning" :icon="Refresh" @click="handleReset" title="重置">
            重置
          </el-button>
        </slot>
      </div>
    </div>

    <div class="flow-body">
      <!-- 左侧节点面板 -->
      <div class="flow-panel-left" v-if="showNodePanel">
        <div class="panel-title"><span>节点面板</span><small>拖入画布</small></div>
        <div v-for="item in nodePanelItems" :key="item.type" class="panel-node-item" draggable="true"
          @dragstart="onDragStart($event, item)">
          <span class="node-icon" :style="{ background: item.color }">{{
            item.icon
          }}</span>
          <span class="node-label">{{ item.label }}</span>
        </div>
      </div>

      <!-- 中间画布 -->
      <div class="flow-canvas-wrap" @drop="onDrop" @dragover.prevent>
        <div class="canvas-status">
          <span><b>{{ nodes.length }}</b> 个节点</span>
          <i></i>
          <span><b>{{ edges.length }}</b> 条连线</span>
          <i></i>
          <span>拖拽节点，拖动连接点建立流转</span>
        </div>
        <VueFlow :id="FLOW_ID" v-model:nodes="nodes" v-model:edges="edges" :node-types="nodeTypes"
          :default-edge-options="defaultEdgeOptions"
          :connection-line-options="{ style: { stroke: '#409eff', strokeWidth: 2 } }" :snap-grid="[16, 16]"
          :min-zoom="0.2" :max-zoom="2" fit-view-on-init @connect="onConnect" @node-click="onNodeClick"
          @edge-click="onEdgeClick" @pane-click="onPaneClick" @nodes-change="onNodesChange"
          @edges-change="onEdgesChange" @node-drag-stop="onNodeDragStop" @edge-update="onEdgeUpdate">
          <Background :pattern-color="'#aaa'" :gap="16" />
          <Controls position="bottom-right" />
          <MiniMap pannable zoomable node-color="#409eff" mask-color="rgba(0,0,0,0.1)" />
        </VueFlow>
      </div>

      <!-- 右侧属性面板 -->
      <div class="flow-panel-right" v-if="(selectedNode || selectedEdge) && showPropsPanel">
        <!-- 节点属性 -->
        <template v-if="selectedNode">
          <div class="panel-title">节点属性</div>
          <el-form label-width="auto" style="max-width: 600px">
            <el-form-item label="节点标识">
              <el-input :model-value="selectedNode.id" disabled />
            </el-form-item>
            <el-form-item label="节点类型">
              <el-input :model-value="selectedNode.type" disabled />
            </el-form-item>
            <el-form-item label="节点名称">
              <el-input v-model="selectedNode.data.label" @input="emitChange" />
            </el-form-item>

            <!-- 动态表单插槽 -->
            <slot name="node-props" :node="selectedNode" :update="emitChange">
              <!-- 审批节点额外属性 -->
              <template v-if="selectedNode.type === 'approval'">
                <el-form-item label="审批人">

                  <el-input v-model="selectedNode.data.approver" @input="emitChange" />
                </el-form-item>
                <el-form-item label="审批模式">
                  <el-select v-model="selectedNode.data.approvalMode" @change="emitChange"
                    placeholder="please select your zone">
                    <el-option label="单人审批" value="single" />
                    <el-option label="会签" value="multi" />
                    <el-option label="或签" value="any" />
                  </el-select>
                </el-form-item>
              </template>

              <!-- 条件节点额外属性 -->
              <template v-if="selectedNode.type === 'condition'">
                <el-form-item label="条件表达式">
                  <el-input v-model="selectedNode.data.condition" type="textarea" placeholder="如: amount > 1000"
                    @input="emitChange" />
                </el-form-item>
              </template>

              <!-- 任务节点额外属性 -->
              <template v-if="selectedNode.type === 'task'">
                <el-form-item label="负责人" required>
                  <ElInputTag @change="emitChange" readonly v-model="selectedNode.data.responsibleUser" draggable
                    placeholder="请选择负责人" @click="pageFun['openSelectUser']('responsibleUser')" delimiter=",">

                  </ElInputTag>
                </el-form-item>
                <!-- <el-form-item label="负责部门" required>
                  <el-select v-model="selectedNode.data.responsibleDepartmentIds" multiple filterable allow-create
                    default-first-option placeholder="输入部门 ID 后回车" @change="emitChange" />
                </el-form-item> -->
                <el-form-item label="抄送人">
                  <ElInputTag @change="emitChange" readonly v-model="selectedNode.data.ccUser" draggable
                    placeholder="请选择抄送人" @click="pageFun['openSelectUser']('ccUser')" delimiter=",">
                  </ElInputTag>
                </el-form-item>
                <el-form-item label="预计工期（天）" required>
                  <el-input-number v-model="selectedNode.data.estimatedDurationDays" :min="1" @change="emitChange" />
                </el-form-item>
                <el-form-item label="到期前提醒（天）" required>
                  <el-input-number v-model="selectedNode.data.reminderBeforeDays" :min="0" @change="emitChange" />
                </el-form-item>
                <el-form-item label="任务描述">
                  <el-input v-model="selectedNode.data.description" placeholder="请输入任务描述" type="textarea"
                    @input="emitChange" />
                </el-form-item>
              </template>

              <!-- 延时节点额外属性 -->
              <template v-if="selectedNode.type === 'delay'">
                <el-form-item label="延时时长">
                  <el-input-number v-model="selectedNode.data.duration" :min="0" @change="emitChange" />
                </el-form-item>
                <el-form-item label="时间单位">
                  <el-select v-model="selectedNode.data.unit" @change="emitChange">
                    <el-option label="秒" value="second" />
                    <el-option label="分钟" value="minute" />
                    <el-option label="小时" value="hour" />
                  </el-select>
                </el-form-item>
                <el-form-item label="指定时间">
                  <el-input v-model="selectedNode.data.delayTime" @change="emitChange" placeholder="请输入指定时间或参数" />
                </el-form-item>

              </template>

              <!-- 通知节点额外属性 -->
              <template v-if="selectedNode.type === 'notification'">
                <el-form-item label="通知渠道">
                  <el-select v-model="selectedNode.data.channel" @change="emitChange">
                    <el-option label="钉钉" value="dingtalk" />
                    <el-option label="微信" value="wechat" />
                    <el-option label="邮件" value="email" />
                  </el-select>
                </el-form-item>
                <el-form-item label="通知内容">
                  <el-input v-model="selectedNode.data.message" type="textarea" placeholder="请输入通知内容"
                    @input="emitChange" />
                </el-form-item>
                <el-form-item label="接受者">
                  <el-input v-model="selectedNode.data.recipient" type="textarea" placeholder="请输入接受者"
                    @input="emitChange" />
                </el-form-item>
              </template>

              <!-- 服务节点额外属性 -->
              <template v-if="selectedNode.type === 'service'">
                <el-form-item label="服务地址">
                  <el-input v-model="selectedNode.data.serviceUrl" placeholder="请输入服务地址" @input="emitChange" />
                </el-form-item>
                <el-form-item label="请求方式">
                  <el-select v-model="selectedNode.data.method" @change="emitChange">
                    <el-option label="GET" value="GET" />
                    <el-option label="POST" value="POST" />
                    <el-option label="PUT" value="PUT" />
                  </el-select>
                </el-form-item>
              </template>
            </slot>
          </el-form>
        </template>

        <!-- 边属性 -->
        <template v-else-if="selectedEdge">
          <div class="panel-title">连线属性</div>
          <el-form label-width="auto" style="max-width: 600px">
            <el-form-item label="起点">
              <el-input :model-value="selectedEdge.source" disabled />
            </el-form-item>
            <el-form-item label="终点">
              <el-input :model-value="selectedEdge.target" disabled />
            </el-form-item>
            <el-form-item label="条件表达式">
              <el-input v-model="selectedEdge.data.condition" placeholder="如: amount > 1000"
                @input="onEdgeDataChange" />
            </el-form-item>
          </el-form>
        </template>

        <div class="flow-panel-right-tools">
          <el-button class="tool-btn" type="danger" @click="handleDeleteSelected">
            <span>删除</span>
          </el-button>
          <el-button v-if="selectedNode" class="tool-btn" type="primary" @click="designerForm">
            <span>设计表单</span>
          </el-button>
        </div>
      </div>
    </div>
    <SelectUser v-if="selectUserShow" :checked-items="selectUserItems" :pars={} v-model:show="selectUserShow"
      @sure="(items) => { pageFun['setResponsibleUserIds'](items) }">
    </SelectUser>
  </div>

</template>

<script setup lang="ts">
import { ref, computed, watch, markRaw, nextTick, onMounted } from 'vue'
import {
  VueFlow,
  useVueFlow,
  type Node,
  type Edge,
  type Connection,
  type NodeChange,
  type EdgeChange,
  type NodeMouseEvent,
  type EdgeMouseEvent,
  type EdgeUpdateEvent,
  type NodeTypesObject,
} from '@vue-flow/core'
import { Background } from '@vue-flow/background'
import { Controls } from '@vue-flow/controls'
import { MiniMap } from '@vue-flow/minimap'
import '@vue-flow/core/dist/style.css'
import '@vue-flow/core/dist/theme-default.css'
import '@vue-flow/controls/dist/style.css'
import '@vue-flow/minimap/dist/style.css'
import { ElInputTag, ElMessage } from 'element-plus'

import StartNode from './nodes/StartNode.vue'
import TaskNode from './nodes/TaskNode.vue'
import ParentNode from './nodes/ParentNode.vue'
import ConditionNode from './nodes/ConditionNode.vue'
import ApprovalNode from './nodes/ApprovalNode.vue'
import ParallelNode from './nodes/ParallelNode.vue'
import DelayNode from './nodes/DelayNode.vue'
import NotificationNode from './nodes/NotificationNode.vue'
import ServiceNode from './nodes/ServiceNode.vue'
import EndNode from './nodes/EndNode.vue'
import { defaultConfig, FLOW_ID } from './config'
import { toWorkflowDefinition, fromWorkflowDefinition, validate } from './serialize'
import type { FlowDesignerProps, FlowDesignerEmits } from './types'
import {
  Plus,
  Delete,
  Minus,
  Aim,
  Refresh, Coin, RefreshLeft, RefreshRight, Grid
} from '@element-plus/icons-vue'
import useDragAndDrop from './hooks/useDnD'
import type { VfWorkflowDefinition } from '@/api-services/generated/index.ts'
import SelectUser from '../business/SelectUser/SelectUser.vue'
import type { YzDialogPars } from '../common/YzPopup/index.ts'

const { onDragStart, onDrop } = useDragAndDrop()
const selectUserShow = ref<boolean>(false)
const selectUserItems = computed(()=>{
    var node = nodes.value.find((n) => n.id === selectedNodeId.value) ?? null;
    return node?.data[thisNodeAttr.value+'Ids']||[];
   
});
const props = withDefaults(defineProps<FlowDesignerProps>(), {
  title: '流程设计器',
  showNodePanel: true,
  showPropsPanel: true,
  nodePanelItems: () => defaultConfig.nodePanelItems,
  defaultEdgeOptions: () => ({
    type: 'smoothstep',
    animated: true,
    style: { stroke: '#409eff', strokeWidth: 2 },
  }),
})

const emit = defineEmits<FlowDesignerEmits>()

// 流程数据（v-model 双向同步，类型用公开 Node/Edge 避免 GraphNode 约束）
const nodes = ref<Node[]>([])
const edges = ref<Edge[]>([])

// 共享同一 store（与 <VueFlow :id>、useDnD 一致），此处仅用于视口操作
const { zoomIn, zoomOut, fitView } = useVueFlow(FLOW_ID)

// 节点类型映射
const nodeTypes = {
  start: markRaw(StartNode),
  task: markRaw(TaskNode),
  parent: markRaw(ParentNode),
  condition: markRaw(ConditionNode),
  approval: markRaw(ApprovalNode),
  parallel: markRaw(ParallelNode),
  delay: markRaw(DelayNode),
  notification: markRaw(NotificationNode),
  service: markRaw(ServiceNode),
  end: markRaw(EndNode),
} as unknown as NodeTypesObject

const thisNodeAttr=ref<string>();
const pageFun: Record<string, Function> = {
  openSelectUser: (name:string) => {
    thisNodeAttr.value=name;
    selectUserShow.value = true;
  },
  setResponsibleUserIds: (items: any[]) => {
    selectUserShow.value = false;
    var node = nodes.value.find((n) => n.id === selectedNodeId.value) ?? null;
    if (node) {
      node.data[thisNodeAttr.value+'Ids'] = items.map(m => m.id);
      node.data[thisNodeAttr.value+''] = items.map(m => m.name);
    }
  }
};
// 选中状态（用 id 而非对象快照，实时解析）
const selectedNodeId = ref<string | null>(null)
const selectedEdgeId = ref<string | null>(null)

const selectedNode = computed<Node | null>(
  () => nodes.value.find((n) => n.id === selectedNodeId.value) ?? null
)
const selectedEdge = computed<Edge | null>(
  () => edges.value.find((e) => e.id === selectedEdgeId.value) ?? null
)

type HistorySnapshot = { nodes: Node[]; edges: Edge[] }
const history = ref<HistorySnapshot[]>([])
const historyIndex = ref(-1)
let applyingHistory = false
const cloneGraph = (): HistorySnapshot => JSON.parse(JSON.stringify({ nodes: nodes.value, edges: edges.value }))
const recordHistory = () => {
  if (applyingHistory) return
  const snapshot = cloneGraph()
  const current = history.value[historyIndex.value]
  if (current && JSON.stringify(current) === JSON.stringify(snapshot)) return
  history.value.splice(historyIndex.value + 1)
  history.value.push(snapshot)
  historyIndex.value = history.value.length - 1
}
const restoreHistory = (index: number) => {
  const snapshot = history.value[index]
  if (!snapshot) return
  applyingHistory = true
  nodes.value = JSON.parse(JSON.stringify(snapshot.nodes))
  edges.value = JSON.parse(JSON.stringify(snapshot.edges))
  historyIndex.value = index
  selectedNodeId.value = null
  selectedEdgeId.value = null
  nextTick(() => { applyingHistory = false; emitChange() })
}
const undo = () => restoreHistory(historyIndex.value - 1)
const redo = () => restoreHistory(historyIndex.value + 1)
onMounted(() => recordHistory())

// 避免外部赋值触发的回显再次 emit
let silent = false

// 加载外部流程数据
watch(
  () => props.modelValue,
  (val) => {
    if (!val) return
    silent = true
    if (Array.isArray(val.nodes) && val.nodes !== nodes.value) nodes.value = val.nodes
    if (Array.isArray(val.edges)) {
      edges.value = val.edges.map((e) => ({ ...e, data: e.data ?? {} }))
    }
    nextTick(() => { silent = false; history.value = []; historyIndex.value = -1; recordHistory() })
  },
  { immediate: true }
)

// 任何变化 → 通知父组件
watch([nodes, edges], () => {
  if (!silent) { recordHistory(); emitChange() }
}, { deep: true, flush: 'post' })

function designerForm() {
  if (!selectedNode.value) return
  emit('designer-form', selectedNode.value)
}

// 节点/边变化（Vue Flow 已自动 apply，此处仅通知）
function onNodesChange(_changes: NodeChange[]) {
  emitChange()
}
function onEdgesChange(_changes: EdgeChange[]) {
  emitChange()
}

// 连接节点
function onConnect(conn: Connection) {
  if (!conn.source || !conn.target || conn.source === conn.target) {
    ElMessage.warning('请选择两个不同的节点进行连接')
    return
  }
  if (edges.value.some((edge) => edge.source === conn.source && edge.target === conn.target && edge.sourceHandle === (conn.sourceHandle ?? undefined))) {
    ElMessage.warning('相同的连线已存在')
    return
  }
  const edge: Edge = {
    id: `e_${Date.now()}_${Math.random().toString(36).slice(2, 6)}`,
    source: conn.source!,
    target: conn.target!,
    sourceHandle: conn.sourceHandle ?? undefined,
    targetHandle: conn.targetHandle ?? undefined,
    type: 'smoothstep',
    animated: true,
    style: { stroke: '#409eff', strokeWidth: 2 },
    data: {},
  }
  edges.value.push(edge)
  emitChange()
}

// 重新连线
function onEdgeUpdate({ edge, connection }: EdgeUpdateEvent) {
  const target = edges.value.find((e) => e.id === edge.id)
  if (target) {
    target.source = connection.source!
    target.target = connection.target!
    target.sourceHandle = connection.sourceHandle ?? undefined
    target.targetHandle = connection.targetHandle ?? undefined
  }
  emitChange()
}

// 点击处理
function onNodeClick({ node }: NodeMouseEvent) {
  selectedNodeId.value = node.id
  selectedEdgeId.value = null
  emit('node-click', node)
}
function onEdgeClick({ edge }: EdgeMouseEvent) {
  selectedNodeId.value = null
  selectedEdgeId.value = edge.id
  emit('edge-click', edge)
}
function onPaneClick() {
  selectedNodeId.value = null
  selectedEdgeId.value = null
  emit('pane-click')
}
function onNodeDragStop() {
  emitChange()
}

// 边条件编辑：同步 label 显示在画布上
function onEdgeDataChange() {
  const e = selectedEdge.value
  if (!e) return
  e.label = (e.data as any)?.condition || undefined
  emitChange()
}

// 删除选中（节点或边）
function handleDeleteSelected() {
  if (selectedNodeId.value) {
    const id = selectedNodeId.value
    nodes.value = nodes.value.filter((n) => n.id !== id)
    edges.value = edges.value.filter((e) => e.source !== id && e.target !== id)
    selectedNodeId.value = null
    emitChange()
  } else if (selectedEdgeId.value) {
    const id = selectedEdgeId.value
    edges.value = edges.value.filter((e) => e.id !== id)
    selectedEdgeId.value = null
    emitChange()
  }
}

// 保存（先校验）
function handleSave() {
  const { valid, errors } = validate(nodes.value, edges.value)
  if (!valid) {
    ElMessage.error(errors[0] ?? '流程校验失败')
    return
  }
  const def = toWorkflowDefinition(nodes.value, edges.value)
  emit('save', def)
  ElMessage.success('流程校验通过')
}

// 重置
function handleReset() {
  nodes.value = []
  edges.value = []
  selectedNodeId.value = null
  selectedEdgeId.value = null
  emit('reset')
  emitChange()
}
function autoLayout() {
  if (!nodes.value.length) return
  const levels = new Map<string, number>()
  const startIds = nodes.value.filter((node) => node.type === 'start').map((node) => node.id)
    ; (startIds.length ? startIds : [nodes.value[0].id]).forEach((id) => levels.set(id, 0))
  for (let pass = 0; pass < nodes.value.length; pass += 1) {
    edges.value.forEach((edge) => {
      const sourceLevel = levels.get(edge.source)
      if (sourceLevel !== undefined) levels.set(edge.target, Math.max(levels.get(edge.target) ?? 0, sourceLevel + 1))
    })
  }
  const columns = new Map<number, Node[]>()
  nodes.value.forEach((node, index) => {
    const level = levels.get(node.id) ?? index
    columns.set(level, [...(columns.get(level) ?? []), node])
  })
  columns.forEach((column, level) => column.forEach((node, index) => {
    node.position = { x: 90 + level * 260, y: 100 + index * 160 }
  }))
  emitChange()
  nextTick(() => fitView({ padding: 0.22, duration: 300 }))
}
function loadDefinition(data: any) {
  const { nodes: ns, edges: es } = fromWorkflowDefinition(data)
  nodes.value = ns;
  edges.value = es;
  history.value = []
  historyIndex.value = -1
  recordHistory()
  emitChange();
}
// 导出 JSON（后端结构）
function exportJSON() {
  return JSON.stringify(toWorkflowDefinition(nodes.value, edges.value), null, 2)
}

// 导入 JSON（兼容 Vue Flow {nodes,edges} 与后端 WorkflowDefinition）
function importJSON(json: string) {
  try {
    const data = JSON.parse(json)
    if (data.Nodes || data.Edges) {
      const { nodes: ns, edges: es } = fromWorkflowDefinition(data)
      nodes.value = ns
      edges.value = es
    } else if (Array.isArray(data.nodes) || Array.isArray(data.edges)) {
      nodes.value = data.nodes ?? []
      edges.value = (data.edges ?? []).map((e: Edge) => ({ ...e, data: e.data ?? {} }))
    } else {
      return false
    }
    emitChange()
    return true
  } catch (e) {
    console.error('[FlowDesigner] importJSON error:', e)
  }
  return false
}

// 通知父组件
function emitChange() {
  emit('update:modelValue', { nodes: nodes.value, edges: edges.value })
  emit('change', { nodes: nodes.value, edges: edges.value })
}

// 暴露方法
defineExpose({
  exportJSON,
  importJSON,
  handleSave,
  handleReset,
  loadDefinition,
  toDefinition: () => toWorkflowDefinition(nodes.value, edges.value),
  getNodes: () => nodes.value,
  getEdges: () => edges.value,
})
</script>

<style lang="less" src="./style.less"></style>
<style></style>
