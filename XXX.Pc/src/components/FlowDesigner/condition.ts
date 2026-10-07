export type ConditionLogic = 'and' | 'or'
export type ConditionOperator =
  | 'eq' | 'neq' | 'gt' | 'gte' | 'lt' | 'lte'
  | 'contains' | 'notContains' | 'startsWith' | 'endsWith'
  | 'isNull' | 'isNotNull' | 'isEmpty' | 'isNotEmpty'

export interface ConditionField {
  nodeId: string
  nodeName: string
  fieldId: string
  label: string
  type: string
  collection?: boolean
  children?: ConditionField[]
  options?: Array<{ label: string; value: any }>
}

export interface ConditionFieldRef {
  type: 'field'
  source?: 'node'
  nodeId: string
  fieldId: string
  fieldLabel?: string
}

export interface ConditionValue {
  type: 'value'
  value: any
}

export interface ConditionAggregate {
  type: 'aggregate'
  function: 'sum' | 'count'
  source: ConditionFieldRef
  childFieldId?: string
  childFieldLabel?: string
}

export interface ConditionItem {
  type: 'condition'
  left: ConditionFieldRef | ConditionAggregate
  operator: ConditionOperator
  right?: ConditionValue | ConditionFieldRef
}

export interface CollectionCondition {
  type: 'collection'
  source: ConditionFieldRef
  quantifier: 'any' | 'all' | 'none'
  childFieldId?: string
  childFieldLabel?: string
  operator: ConditionOperator
  value?: ConditionValue | ConditionFieldRef
}

export interface ConditionGroup {
  type: 'group'
  operator: ConditionLogic
  children: Array<ConditionItem | CollectionCondition | ConditionGroup>
}

export type ConditionRule = ConditionGroup

export const operatorOptions: Record<string, Array<{ label: string; value: ConditionOperator }>> = {
  string: [
    { label: '等于', value: 'eq' }, { label: '不等于', value: 'neq' },
    { label: '包含', value: 'contains' }, { label: '不包含', value: 'notContains' },
    { label: '开头是', value: 'startsWith' }, { label: '结尾是', value: 'endsWith' },
    { label: '为空', value: 'isEmpty' }, { label: '不为空', value: 'isNotEmpty' }
  ],
  number: [
    { label: '等于', value: 'eq' }, { label: '不等于', value: 'neq' },
    { label: '大于', value: 'gt' }, { label: '大于等于', value: 'gte' },
    { label: '小于', value: 'lt' }, { label: '小于等于', value: 'lte' },
    { label: '为空', value: 'isNull' }, { label: '不为空', value: 'isNotNull' }
  ],
  boolean: [
    { label: '等于', value: 'eq' }, { label: '不等于', value: 'neq' }
  ],
  date: [
    { label: '等于', value: 'eq' }, { label: '不等于', value: 'neq' },
    { label: '晚于', value: 'gt' }, { label: '晚于等于', value: 'gte' },
    { label: '早于', value: 'lt' }, { label: '早于等于', value: 'lte' }
  ],
  default: [
    { label: '等于', value: 'eq' }, { label: '不等于', value: 'neq' },
    { label: '大于', value: 'gt' }, { label: '大于等于', value: 'gte' },
    { label: '小于', value: 'lt' }, { label: '小于等于', value: 'lte' }
  ]
}

export function getOperators(field?: ConditionField | null) {
  if (!field) return operatorOptions.default
  if (field.type.includes('number') || field.type.includes('amount')) return operatorOptions.number
  if (field.type.includes('date') || field.type.includes('time')) return operatorOptions.date
  if (field.type.includes('switch') || field.type.includes('boolean')) return operatorOptions.boolean
  return operatorOptions.string
}

export function emptyGroup(): ConditionGroup {
  return {
    type: 'group',
    operator: 'and',
    children: []
  }
}

export function emptyCondition(field?: ConditionField): ConditionItem {
  const f = field ?? { nodeId: '', nodeName: '', fieldId: '', label: '', type: 'string' }
  return {
    type: 'condition',
    left: {
      type: 'field',
      source: 'node',
      nodeId: f.nodeId,
      fieldId: f.fieldId,
      fieldLabel: f.label
    },
    operator: getOperators(f)[0]?.value ?? 'eq',
    right: { type: 'value', value: '' }
  }
}
