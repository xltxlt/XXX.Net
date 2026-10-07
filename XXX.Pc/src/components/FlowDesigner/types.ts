import type { Node, Edge } from '@vue-flow/core'
import type { ConditionField } from './condition'

/**
 * 节点面板项
 */
export interface NodePanelItem {
  type: string
  label: string
  icon: string
  color: string
}

/**
 * 流程数据（v-model 使用，保持 Vue Flow 原始结构）
 */
export interface FlowData {
  nodes: Node[]
  edges: Edge[]
  savedAt?: string
}

/**
 * 节点类型联合（对齐后端 WorkflowNodeType + 前端 task/parent）
 */
export type WorkflowNodeType =
  | 'start'
  | 'task'
  | 'parent'
  | 'condition'
  | 'approval'
  | 'parallel'
  | 'delay'
  | 'notification'
  | 'service'
  | 'end'

/**
 * 组件 Props
 */
export interface FlowDesignerProps {
  modelValue?: FlowData
  title?: string
  showNodePanel?: boolean
  showPropsPanel?: boolean
  nodePanelItems?: NodePanelItem[]
  defaultEdgeOptions?: Record<string, any>
  /** 条件设计器可引用的节点表单字段 */
  conditionFields?: ConditionField[]
}

/**
 * 组件 Emits
 */
export interface FlowDesignerEmits {
  (e: 'update:modelValue', value: FlowData): void
  (e: 'change', value: FlowData): void
  (e: 'save', value: WorkflowDefinitionDto): void
  (e: 'reset'): void
  (e: 'node-click', node: Node): void
  (e: 'edge-click', edge: Edge): void
  (e: 'pane-click'): void
  (e: 'designer-form', node: Node): void
}

/**
 * 节点数据扩展（自定义节点 data 字段）
 */
export interface BaseNodeData {
  label: string
  icon?: string
  color?: string
}

export interface StartNodeData extends BaseNodeData {
  type: 'start'
}

export interface TaskNodeData extends BaseNodeData {
  type: 'task'
  assignee?: string
  responsibleUserIds?: Array<number | string>
  responsibleDepartmentIds?: Array<number | string>
  ccUserIds?: Array<number | string>
  estimatedDurationDays?: number
  reminderBeforeDays?: number
  description?: string
}

export interface ParentNodeData extends BaseNodeData {
  type: 'parent'
}

export interface ConditionNodeData extends BaseNodeData {
  type: 'condition'
  condition?: string
}

export interface ApprovalNodeData extends BaseNodeData {
  type: 'approval'
  approver?: string
  approvalMode?: 'single' | 'multi' | 'any'
}

export interface ParallelNodeData extends BaseNodeData {
  type: 'parallel'
}

export interface DelayNodeData extends BaseNodeData {
  type: 'delay'
  duration?: string
  unit?: string
}

export interface NotificationNodeData extends BaseNodeData {
  type: 'notification'
  channel?: string
  message?: string
}

export interface ServiceNodeData extends BaseNodeData {
  type: 'service'
  serviceUrl?: string
  method?: string
}

export interface EndNodeData extends BaseNodeData {
  type: 'end'
}

export type CustomNodeData =
  | StartNodeData
  | TaskNodeData
  | ParentNodeData
  | ConditionNodeData
  | ApprovalNodeData
  | ParallelNodeData
  | DelayNodeData
  | NotificationNodeData
  | ServiceNodeData
  | EndNodeData

// ===== 后端模型映射类型（WorkflowDefinition / Node / Edge） =====

export interface WorkflowNodeDto {
  Id: string
  Type: string
  Name: string
  Config: Record<string, any>
  NodeJson?: string
}

export interface WorkflowEdgeDto {
  Source: string
  Target: string
  Condition?: string
  EdgeJson?: string
}

export interface WorkflowDefinitionDto {
  WorkflowId: string
  Name: string
  Version: number
  Nodes: WorkflowNodeDto[]
  Edges: WorkflowEdgeDto[]
}

export type ConditionOperator =
  | 'eq'
  | 'ne'
  | 'gt'
  | 'gte'
  | 'lt'
  | 'lte'
  | 'contains'
  | 'startsWith'
  | 'endsWith'
  | 'isEmpty'
  | 'isNotEmpty'

export interface WorkflowConditionField {
  nodeId: string
  path: string
}

export interface WorkflowCondition {
  type: 'group' | 'field' | 'aggregate' | 'any'

  operator?: string

  children?: WorkflowCondition[]

  field?: WorkflowConditionField

  value?: any

  aggregate?: {
    nodeId: string
    path: string
    field: string
    function: 'count' | 'sum' | 'avg' | 'min' | 'max'
  }

  any?: {
    nodeId: string
    path: string
    where: WorkflowCondition
  }
}
export interface WorkflowConditionFieldOption {
  nodeId: string
  nodeName: string

  field: string
  label: string

  type: 'string' | 'number' | 'boolean' | 'date' | 'table'

  isTable?: boolean

  children?: WorkflowConditionFieldOption[]
}