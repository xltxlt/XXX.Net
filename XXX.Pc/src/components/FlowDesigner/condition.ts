import { PageFormGroup, PageFormType } from '@/components/PageForm'
import type {
  WorkflowConditionFieldOption,
} from './types'

const numberTypes = new Set([
  PageFormType.Number,
  PageFormType.NumberInput,
  PageFormType.DecimalInput,
  PageFormType.Amount,
  PageFormType.Stepper,
  PageFormType.Rate,
  PageFormType.Slider,
])

const dateTypes = new Set([
  PageFormType.DateSelect,
  PageFormType.DateTimeSelect,
])

const booleanTypes = new Set([
  PageFormType.Switch,
])

function getFieldType(
  item: any
): 'string' | 'number' | 'boolean' | 'date' | 'table' {
  if (numberTypes.has(item.formType))
    return 'number'

  if (dateTypes.has(item.formType))
    return 'date'

  if (booleanTypes.has(item.formType))
    return 'boolean'

  if (
    item.formType === PageFormGroup.Table ||
    item.formType === PageFormGroup.List
  )
    return 'table'

  return 'string'
}

export function extractConditionFields(
  nodeId: string,
  nodeName: string,
  form: any[]
): WorkflowConditionFieldOption[] {
  const result: WorkflowConditionFieldOption[] = []

  const walk = (
    items: any[],
    parentPath = ''
  ) => {
    for (const item of items ?? []) {
      const fieldName =
        item.fieldName

      if (
        !fieldName &&
        !item.child?.length
      )
        continue

      const path = parentPath
        ? `${parentPath}.${fieldName}`
        : fieldName

      if (
        item.formType === PageFormGroup.Table ||
        item.formType === PageFormGroup.List
      ) {
        result.push({
          nodeId,
          nodeName,
          field: path,
          label: item.label || fieldName,
          type: 'table',
          isTable: true,
          children: extractTableFields(
            nodeId,
            nodeName,
            item.child ?? []
          ),
        })

        continue
      }

      if (
        item.formType === PageFormGroup.Group
      ) {
        walk(
          item.child ?? [],
          parentPath
        )

        continue
      }

      if (!fieldName)
        continue

      result.push({
        nodeId,
        nodeName,
        field: path,
        label:
          item.label ||
          fieldName,
        type: getFieldType(item),
      })
    }
  }

  walk(form)

  return result
}

function extractTableFields(
  nodeId: string,
  nodeName: string,
  items: any[]
): WorkflowConditionFieldOption[] {
  const result: WorkflowConditionFieldOption[] = []

  const walk = (list: any[]) => {
    for (const item of list ?? []) {
      if (
        item.formType === PageFormGroup.Group
      ) {
        walk(item.child ?? [])
        continue
      }

      if (
        !item.fieldName
      )
        continue

      result.push({
        nodeId,
        nodeName,
        field: item.fieldName,
        label:
          item.label ||
          item.fieldName,
        type:
          getFieldType(item),
      })
    }
  }

  walk(items)

  return result
}