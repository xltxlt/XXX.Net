import type { Node, Edge } from '@vue-flow/core'
import type {
  WorkflowDefinitionDto,
  WorkflowNodeDto,
  WorkflowEdgeDto,
} from './types'
import { defaultNodeData } from './config'

/** 序列化时需从节点 data 剥离的展示字段 */
const DISPLAY_KEYS = ['label', 'icon', 'color']

/**
 * Vue Flow 节点/边 → 后端 WorkflowDefinition 结构
 */
export function toWorkflowDefinition(
  nodes: Node[],
  edges: Edge[],
  meta?: { workflowId?: string; name?: string; version?: number }
): WorkflowDefinitionDto {
  const nodeDtos: WorkflowNodeDto[] = nodes.map((node) => {
    const config: Record<string, any> = {}
    for (const [k, v] of Object.entries(node.data ?? {})) {
      if (!DISPLAY_KEYS.includes(k)) config[k] = v
    }
    // 保留子流程嵌套关系
    if (node.parentNode) config.parentNode = node.parentNode

    return {
      Id: node.id,
      Type: node.type ?? '',
      Name: node.data?.label ?? node.id,
      Config: config,
      NodeJson: JSON.stringify(node),
    }
  })

  const edgeDtos: WorkflowEdgeDto[] = edges.map((edge) => ({
    Source: edge.source,
    Target: edge.target,
    Condition: (edge.data as any)?.condition ?? edge.label ?? undefined,
    EdgeJson: JSON.stringify(edge),
  }))

  return {
    WorkflowId: meta?.workflowId ?? '',
    Name: meta?.name ?? '',
    Version: meta?.version ?? 1,
    Nodes: nodeDtos,
    Edges: edgeDtos,
  }
}

/** 后端 config 字段可能是 JSON 字符串，也可能是对象，统一解析为对象 */
function parseConfig(config: any): Record<string, any> {
  if (config == null) return {}
  if (typeof config === 'string') {
    try {
      return JSON.parse(config) || {}
    } catch {
      return {}
    }
  }
  return config
}

/**
 * 后端 WorkflowDefinition → Vue Flow 节点/边
 * 兼容 PascalCase（Nodes/Edges/Id/Config 对象）与 camelCase（nodes/edges/id/config 字符串）两种返回结构。
 */
export function fromWorkflowDefinition(def: any): {
  nodes: Node[]
  edges: Edge[]
} {
  const rawNodes: any[] = def?.Nodes ?? def?.nodes ?? []
  const rawEdges: any[] = def?.Edges ?? def?.edges ?? []

  const nodes: Node[] = rawNodes.map((n, i) => {
    const rawNode = n.NodeJson ?? n.nodeJson
    if (rawNode) {
      try { return typeof rawNode === 'string' ? JSON.parse(rawNode) : rawNode } catch { /* fall back to DTO fields */ }
    }
    const id: string = n.Id ?? n.id ?? `node_${i}`
    const type: string = n.Type ?? n.type ?? 'task'
    const name: string = n.Name ?? n.name ?? type
    const config = parseConfig(n.Config ?? n.config)
    return {
      id,
      type,
      position: n.Position ?? n.position ?? { x: (i % 4) * 220, y: Math.floor(i / 4) * 140 },
      data: { ...defaultNodeData(type as any), ...config, label: name || type },
      ...(config.parentNode ? { parentNode: config.parentNode, expandParent: true } : {}),
    }
  })

  const edges: Edge[] = rawEdges.map((e, i) => {
    const rawEdge = e.EdgeJson ?? e.edgeJson
    if (rawEdge) {
      try { return typeof rawEdge === 'string' ? JSON.parse(rawEdge) : rawEdge } catch { /* fall back to DTO fields */ }
    }
    const source = e.Source ?? e.source
    const target = e.Target ?? e.target
    const condition = e.Condition ?? e.condition ?? undefined
    return { id: e.Id ?? e.id ?? `e_${source}_${target}_${i}`, source, target, type: 'smoothstep', animated: true, style: { stroke: '#409eff', strokeWidth: 2 }, label: condition, data: condition ? { condition } : {} }
  })

  return { nodes, edges }
}

/**
 * 流程校验：返回是否合法与错误信息列表
 */
export function validate(nodes: Node[], edges: Edge[]): { valid: boolean; errors: string[] } {
  const errors: string[] = []

  const startNodes = nodes.filter((n) => n.type === 'start')
  if (startNodes.length === 0) errors.push('流程必须包含一个开始节点')
  if (startNodes.length > 1) errors.push('流程只能有一个开始节点')

  const endNodes = nodes.filter((n) => n.type === 'end')
  if (endNodes.length === 0) errors.push('流程必须包含至少一个结束节点')

  for (const node of nodes) {
    if (node.type !== 'task') continue
    const data = node.data as any
    const hasResponsibleUser = Array.isArray(data?.responsibleUserIds) && data.responsibleUserIds.length > 0
    const hasResponsibleDepartment = Array.isArray(data?.responsibleDepartmentIds) && data.responsibleDepartmentIds.length > 0
    if (!hasResponsibleUser && !hasResponsibleDepartment)
      errors.push(`任务节点「${data?.label || node.id}」必须指定负责人或负责部门`)
    if (!Number.isInteger(data?.estimatedDurationDays) || data.estimatedDurationDays < 1)
      errors.push(`任务节点「${data?.label || node.id}」必须设置预计工期`)
    if (!Number.isInteger(data?.reminderBeforeDays) || data.reminderBeforeDays < 0 || data.reminderBeforeDays > data.estimatedDurationDays)
      errors.push(`任务节点「${data?.label || node.id}」的提醒天数必须在工期范围内`)
  }

  // 条件节点需要有出边且出边设置条件表达式
  for (const node of nodes) {
    if (node.type !== 'condition') continue
    const outEdges = edges.filter((e) => e.source === node.id)
    if (outEdges.length === 0) {
      errors.push(`条件节点「${node.data?.label || node.id}」缺少出口连线`)
      continue
    }
    // for (const e of outEdges) {
    //   const cond = (e.data as any)?.condition ?? e.label
    //   if (!cond) {
    //     errors.push(`条件节点「${node.data?.label || node.id}」的出口连线缺少条件表达式`)
    //   }
    // }
  }

  // 非结束节点应有出边（排除父流程容器：其出边非必须）
  for (const node of nodes) {
    if (node.type === 'end' || node.type === 'parent') continue
    if (node.type === 'notification') continue;
    const hasOut = edges.some((e) => e.source === node.id)
    if (!hasOut) {
      errors.push(`节点「${node.data?.label || node.id}」缺少出口连线`)
    }
  }

  // 非开始节点应有入边
  for (const node of nodes) {
    if (node.type === 'start') continue;

    const hasIn = edges.some((e) => e.target === node.id)
    if (!hasIn) {
      errors.push(`节点「${node.data?.label || node.id}」缺少入口连线`)
    }
  }

  return { valid: errors.length === 0, errors }
}
