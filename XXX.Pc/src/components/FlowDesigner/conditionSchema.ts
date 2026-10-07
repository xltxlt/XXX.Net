import { PageFormGroup, PageFormType, type TempEditForm } from '@/components/PageForm'
import type { ConditionField } from './condition'

type ConditionValueType = 'string' | 'number' | 'boolean' | 'date' | 'select' | 'collection'
type PageFormDesignerItem = TempEditForm & { optionText?: string }

const NUMBER_TYPES = new Set<number>([
  PageFormType.Number,
  PageFormType.Stepper,
  PageFormType.Rate,
  PageFormType.NumberInput,
  PageFormType.DecimalInput,
  PageFormType.Amount,
  PageFormType.Slider,
])

const BOOLEAN_TYPES = new Set<number>([
  PageFormType.Switch,
])

const DATE_TYPES = new Set<number>([
  PageFormType.DateSelect,
  PageFormType.DateTimeSelect,
  PageFormType.TimeSelect,
  PageFormType.DateRangeSelect,
  PageFormType.YaerSelect,
  PageFormType.MultYaerSelect,
  PageFormType.MonthSelect,
  PageFormType.MonthRangeSelect,
  PageFormType.MultMonthSelect,
  PageFormType.MultDateSelect,
  PageFormType.YaerRangeSelect,
])

const SELECT_TYPES = new Set<number>([
  PageFormType.Checkbox,
  PageFormType.Radio,
  PageFormType.OneSelect,
  PageFormType.OneSelectSearch,
  PageFormType.MultSelect,
  PageFormType.TreeSelect,
  PageFormType.MultTreeSelect,
  PageFormType.MultSelfTreeSelect,
  PageFormType.SelfTreeSelect,
  PageFormType.LazyTreeSelect,
  PageFormType.CascaderSelect,
  PageFormType.CustomOptions,
  PageFormType.TreeSelectLast,
  PageFormType.AreaSelect,
  PageFormType.CitySelect,
  PageFormType.ProvinceSelect,
])

function getValueType(formType: number): Exclude<ConditionValueType, 'collection'> {
  if (NUMBER_TYPES.has(formType)) return 'number'
  if (BOOLEAN_TYPES.has(formType)) return 'boolean'
  if (DATE_TYPES.has(formType)) return 'date'
  if (SELECT_TYPES.has(formType)) return 'select'
  return 'string'
}

function getLabel(item: TempEditForm, fieldId: string) {
  return String(item.title ?? item.label ?? fieldId)
}

function normalizeOptions(item: PageFormDesignerItem) {
  if (Array.isArray(item.option)) {
    return item.option
      .filter((option: any) => option && typeof option === 'object')
      .map((option: any) => ({
        label: String(option.label ?? option.title ?? option.name ?? option.value ?? ''),
        value: option.value,
      }))
      .filter((option: any) => option.label !== '')
  }

  // PageFormDesigner 当前保存的真实设计结构使用 optionText。
  // 不再从字段名、formType 等信息推测选项。
  if (typeof item.optionText === 'string') {
    return item.optionText
      .split('\n')
      .map(line => line.trim())
      .filter(Boolean)
      .map(line => {
        const [label, ...rest] = line.split(',')
        const text = label.trim()
        return { label: text, value: rest.join(',').trim() || text }
      })
  }

  return []
}

function toField(
  nodeId: string,
  nodeName: string,
  item: PageFormDesignerItem,
  collection = false,
  children: ConditionField[] = [],
): ConditionField | null {
  const fieldId = String(item.fieldName ?? '').trim()
  if (!fieldId) return null

  const valueType: ConditionValueType = collection
    ? 'collection'
    : getValueType(Number(item.formType))

  return {
    nodeId,
    nodeName,
    fieldId,
    label: getLabel(item, fieldId),
    type: valueType,
    formType: Number(item.formType),
    collection,
    children: collection ? children : undefined,
    options: !collection ? normalizeOptions(item) : undefined,
  }
}

function buildFields(
  nodeId: string,
  nodeName: string,
  items: PageFormDesignerItem[],
): ConditionField[] {
  const result: ConditionField[] = []

  for (const item of items ?? []) {
    const formType = Number(item.formType)

    if (formType === PageFormGroup.Table || formType === PageFormGroup.List) {
      // PageForm 的真实运行结构：
      // table/list.fieldName -> Array<Row>
      // table/list.child[0].child -> Row 字段
      const rowItems = (item.child?.[0]?.child ?? []) as TempEditForm[]
      const children = buildCollectionChildren(nodeId, nodeName, rowItems)
      const collection = toField(nodeId, nodeName, item, true, children)
      if (collection) result.push(collection)
      continue
    }

    if (formType === PageFormGroup.Group || formType === PageFormGroup.PreviewGroup) {
      // 普通分组不是集合，只递归其真实 child。
      result.push(...buildFields(nodeId, nodeName, (item.child ?? []) as TempEditForm[]))
      continue
    }

    const field = toField(nodeId, nodeName, item)
    if (field) result.push(field)
  }

  return result
}

function buildCollectionChildren(
  nodeId: string,
  nodeName: string,
  items: TempEditForm[],
): ConditionField[] {
  const result: ConditionField[] = []

  for (const item of items ?? []) {
    const formType = Number(item.formType)

    if (formType === PageFormGroup.Group || formType === PageFormGroup.PreviewGroup) {
      result.push(...buildCollectionChildren(nodeId, nodeName, (item.child ?? []) as TempEditForm[]))
      continue
    }

    // 不允许在集合层再把 Table/List 当成普通字段嵌套，
    // 当前 PageForm 的真实表格/列表数据结构并不支持这里按一个 childFieldId 直接求值。
    if (formType === PageFormGroup.Table || formType === PageFormGroup.List) continue

    const field = toField(nodeId, nodeName, item)
    if (field) result.push(field)
  }

  return result
}

export function buildConditionFields(
  nodeId: string,
  nodeName: string,
  form: PageFormDesignerItem[],
): ConditionField[] {
  return buildFields(nodeId, nodeName, form ?? [])
}

export function isNumericConditionField(field?: ConditionField | null) {
  return field?.type === 'number'
}
