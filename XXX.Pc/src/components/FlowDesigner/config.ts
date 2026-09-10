import type { NodePanelItem, WorkflowNodeType } from './types'

/**
 * Vue Flow 共享 store id（index.vue 与 useDnD 通过同一 id 拿到同一个 store）
 */
export const FLOW_ID = 'flow-designer'

/**
 * 默认节点面板配置
 */
export const defaultConfig = {
  nodePanelItems: [
    { type: 'start', label: '开始节点', icon: '▶', color: '#67c23a' },
    { type: 'task', label: '任务节点', icon: '📋', color: '#409eff' },
    { type: 'parent', label: '父流程', icon: '⬒', color: '#13c2c2' },
    { type: 'condition', label: '条件分支', icon: '◆', color: '#e6a23c' },
    { type: 'approval', label: '审批节点', icon: '✓', color: '#9c27b0' },
    { type: 'parallel', label: '并行节点', icon: '⧉', color: '#409eff' },
    { type: 'delay', label: '延时节点', icon: '⏱', color: '#909399' },
    { type: 'notification', label: '通知节点', icon: '✉', color: '#67c23a' },
    { type: 'service', label: '服务节点', icon: '⚙', color: '#e6a23c' },
    { type: 'end', label: '结束节点', icon: '■', color: '#f56c6c' },
  ] as NodePanelItem[],
}

/**
 * 各类型节点的专属默认字段
 */
const typeExtraData: Record<WorkflowNodeType, Record<string, any>> = {
  start: {},
  task: { assignee: '', description: '' },
  parent: {},
  condition: { condition: '' },
  approval: { approver: '', approvalMode: 'single' },
  parallel: {},
  delay: { duration: null, unit: 'minute' },
  notification: { channel: 'dingtalk', message: '' },
  service: { serviceUrl: '', method: 'POST' },
  end: {},
}

/**
 * 生成某类型节点的初始 data（含 label/icon/color 与专属字段）
 */
export function defaultNodeData(type: WorkflowNodeType) {
  const item = defaultConfig.nodePanelItems.find((i) => i.type === type)
  return {
    label: item?.label ?? type,
    icon: item?.icon ?? '●',
    color: item?.color ?? '#409eff',
    ...typeExtraData[type],
  }
}
