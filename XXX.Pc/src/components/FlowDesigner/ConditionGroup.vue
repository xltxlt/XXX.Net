<template>
  <div class="condition-group">
    <div class="condition-group-head">
      <el-select v-model="group.operator" size="small" style="width:90px" @change="emitChange">
        <el-option label="并且" value="and" />
        <el-option label="或者" value="or" />
      </el-select>
      <el-button link type="primary" size="small" @click="addCondition">+ 条件</el-button>
      <el-button link type="primary" size="small" @click="addCollection">+ 明细条件</el-button>
      <el-button link type="primary" size="small" @click="addAggregate('sum')">+ SUM</el-button>
      <el-button link type="primary" size="small" @click="addAggregate('count')">+ COUNT</el-button>
      <el-button link type="primary" size="small" @click="addGroup">+ 条件组</el-button>
      <el-button v-if="removable" link type="danger" size="small" @click="$emit('remove')">删除组</el-button>
    </div>

    <div v-if="!group.children.length" class="condition-empty">暂无条件</div>

    <template v-for="(item, index) in group.children" :key="index">
      <ConditionGroup
        v-if="item.type === 'group'"
        v-model="group.children[index]"
        :fields="fields"
        :removable="true"
        @remove="remove(index)"
        @change="emitChange"
      />

      <div v-else-if="item.type === 'condition'" class="condition-row">
        <el-select v-model="(item.left as any).nodeId" filterable placeholder="节点" @change="leftNodeChanged(item)">
          <el-option v-for="node in nodes" :key="node.nodeId" :label="node.nodeName" :value="node.nodeId" />
        </el-select>
        <el-select v-model="(item.left as any).fieldId" filterable placeholder="字段" @change="leftFieldChanged(item)">
          <el-option v-for="field in fieldsForNode((item.left as any).nodeId)" :key="field.fieldId" :label="field.label" :value="field.fieldId" />
        </el-select>
        <el-select v-model="item.operator" style="width:125px" @change="emitChange">
          <el-option v-for="op in getOperators(currentField(item))" :key="op.value" :label="op.label" :value="op.value" />
        </el-select>
        <el-select v-if="isEnumField(currentField(item))" v-model="(item.right as any).value" placeholder="值" @change="emitChange">
          <el-option v-for="op in currentField(item)?.options || []" :key="String(op.value)" :label="op.label" :value="op.value" />
        </el-select>
        <el-input v-else v-model="(item.right as any).value" placeholder="值" @input="emitChange" />
        <el-button link type="danger" @click="remove(index)">删除</el-button>
      </div>

      <div v-else-if="item.type === 'condition' && (item.left as any).type === 'aggregate'" class="condition-row collection-row">
        <span class="aggregate-title">{{ (item.left as any).function.toUpperCase() }}</span>
        <el-select v-model="(item.left as any).source.nodeId" filterable placeholder="节点" @change="aggregateNodeChanged(item)">
          <el-option v-for="node in nodes" :key="node.nodeId" :label="node.nodeName" :value="node.nodeId" />
        </el-select>
        <el-select v-model="(item.left as any).source.fieldId" filterable placeholder="明细表" @change="aggregateSourceChanged(item)">
          <el-option v-for="field in collectionFields((item.left as any).source.nodeId)" :key="field.fieldId" :label="field.label" :value="field.fieldId" />
        </el-select>
        <el-select v-if="(item.left as any).function === 'sum'" v-model="(item.left as any).childFieldId" placeholder="求和字段" @change="aggregateChildChanged(item)">
          <el-option v-for="field in aggregateChildren(item)" :key="field.fieldId" :label="field.label" :value="field.fieldId" />
        </el-select>
        <el-select v-model="item.operator" style="width:125px" @change="emitChange">
          <el-option v-for="op in getOperators({ type: 'number' } as any)" :key="op.value" :label="op.label" :value="op.value" />
        </el-select>
        <el-input-number v-model="(item.right as any).value" :controls="false" placeholder="数值" @change="emitChange" />
        <el-button link type="danger" @click="remove(index)">删除</el-button>
      </div>

      <div v-else class="condition-row collection-row">
        <span class="aggregate-title">明细</span>
        <el-select v-model="(item.source as any).nodeId" filterable placeholder="节点" @change="collectionNodeChanged(item)">
          <el-option v-for="node in nodes" :key="node.nodeId" :label="node.nodeName" :value="node.nodeId" />
        </el-select>
        <el-select v-model="(item.source as any).fieldId" filterable placeholder="明细表" @change="collectionChanged(item)">
          <el-option v-for="field in collectionFields((item.source as any).nodeId)" :key="field.fieldId" :label="field.label" :value="field.fieldId" />
        </el-select>
        <el-select v-model="item.quantifier" style="width:90px" @change="emitChange">
          <el-option label="任意" value="any" />
          <el-option label="全部" value="all" />
          <el-option label="没有" value="none" />
        </el-select>
        <el-select v-model="item.childFieldId" placeholder="明细字段" @change="childChanged(item)">
          <el-option v-for="field in collectionChildren(item)" :key="field.fieldId" :label="field.label" :value="field.fieldId" />
        </el-select>
        <el-select v-model="item.operator" style="width:125px" @change="emitChange">
          <el-option v-for="op in getOperators(collectionChild(item))" :key="op.value" :label="op.label" :value="op.value" />
        </el-select>
        <el-input v-model="(item.value as any).value" placeholder="值" @input="emitChange" />
        <el-button link type="danger" @click="remove(index)">删除</el-button>
      </div>
    </template>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import type { ConditionField, ConditionGroup, ConditionItem, CollectionCondition } from './condition'
import { emptyCondition, getOperators } from './condition'

defineOptions({ name: 'ConditionGroup' })

const props = withDefaults(defineProps<{
  modelValue: ConditionGroup
  fields: ConditionField[]
  removable?: boolean
}>(), { removable: false })

const emit = defineEmits<{
  (e: 'update:modelValue', value: ConditionGroup): void
  (e: 'change'): void
  (e: 'remove'): void
}>()

const group = computed(() => props.modelValue)
const nodes = computed(() => {
  const map = new Map<string, ConditionField>()
  props.fields.forEach(f => map.set(f.nodeId, f))
  return [...map.values()]
})

function fieldsForNode(nodeId: string) {
  return props.fields.filter(f => f.nodeId === nodeId && !f.collection)
}
function collectionFields(nodeId: string) {
  return props.fields.filter(f => f.nodeId === nodeId && f.collection)
}
function collectionChildren(item: CollectionCondition) {
  const source = props.fields.find(f => f.nodeId === item.source.nodeId && f.fieldId === item.source.fieldId)
  return source?.children ?? []
}
function aggregateChildren(item: ConditionItem) {
  const left = item.left as any
  const source = props.fields.find(f => f.nodeId === left.source.nodeId && f.fieldId === left.source.fieldId)
  return source?.children ?? []
}
function aggregateNodeChanged(item: ConditionItem) {
  const left = item.left as any
  const source = collectionFields(left.source.nodeId)[0]
  if (source) {
    left.source.fieldId = source.fieldId
    left.source.fieldLabel = source.label
    const child = source.children?.[0]
    left.childFieldId = left.function === 'sum' ? child?.fieldId : undefined
    left.childFieldLabel = left.function === 'sum' ? child?.label : undefined
  }
  emitChange()
}
function aggregateSourceChanged(item: ConditionItem) {
  const left = item.left as any
  const source = props.fields.find(f => f.nodeId === left.source.nodeId && f.fieldId === left.source.fieldId)
  left.source.fieldLabel = source?.label
  const child = source?.children?.[0]
  left.childFieldId = left.function === 'sum' ? child?.fieldId : undefined
  left.childFieldLabel = left.function === 'sum' ? child?.label : undefined
  emitChange()
}
function aggregateChildChanged(item: ConditionItem) {
  const left = item.left as any
  const child = aggregateChildren(item).find(f => f.fieldId === left.childFieldId)
  left.childFieldLabel = child?.label
  emitChange()
}

function collectionChild(item: CollectionCondition) {
  return collectionChildren(item).find(f => f.fieldId === item.childFieldId)
}
function currentField(item: ConditionItem) {
  const left = item.left as any
  return props.fields.find(f => f.nodeId === left.nodeId && f.fieldId === left.fieldId)
}
function isEnumField(field?: ConditionField) {
  return !!field?.options?.length
}

function emitChange() {
  emit('update:modelValue', group.value)
  emit('change')
}

function addCondition() {
  const field = props.fields.find(f => !f.collection)
  group.value.children.push(emptyCondition(field))
  emitChange()
}

function addAggregate(functionName: 'sum' | 'count') {
  const collection = props.fields.find(f => f.collection)
  if (!collection) return
  const child = collection.children?.find(f => f.type.includes('number') || f.type.includes('amount')) ?? collection.children?.[0]
  const item: ConditionItem = {
    type: 'condition',
    left: {
      type: 'aggregate',
      function: functionName,
      source: { type: 'field', source: 'node', nodeId: collection.nodeId, fieldId: collection.fieldId, fieldLabel: collection.label },
      childFieldId: functionName === 'sum' ? child?.fieldId : undefined,
      childFieldLabel: functionName === 'sum' ? child?.label : undefined
    } as any,
    operator: functionName === 'sum' ? 'gt' : 'gte',
    right: { type: 'value', value: 0 }
  }
  group.value.children.push(item)
  emitChange()
}

function addCollection() {
  const collection = props.fields.find(f => f.collection)
  if (!collection) return
  const child = collection.children?.[0]
  const item: CollectionCondition = {
    type: 'collection',
    source: { type: 'field', source: 'node', nodeId: collection.nodeId, fieldId: collection.fieldId, fieldLabel: collection.label },
    quantifier: 'any',
    childFieldId: child?.fieldId,
    childFieldLabel: child?.label,
    operator: getOperators(child)[0]?.value ?? 'eq',
    value: { type: 'value', value: '' }
  }
  group.value.children.push(item)
  emitChange()
}

function addGroup() {
  group.value.children.push({ type: 'group', operator: 'and', children: [] })
  emitChange()
}
function remove(index: number) {
  group.value.children.splice(index, 1)
  emitChange()
}

function leftNodeChanged(item: ConditionItem) {
  const left = item.left as any
  const field = fieldsForNode(left.nodeId)[0]
  if (field) {
    left.fieldId = field.fieldId
    left.fieldLabel = field.label
    item.operator = getOperators(field)[0]?.value ?? 'eq'
    if (item.right?.type === 'value') item.right.value = ''
  }
  emitChange()
}

function leftFieldChanged(item: ConditionItem) {
  const field = currentField(item)
  const left = item.left as any
  left.fieldLabel = field?.label
  item.operator = getOperators(field)[0]?.value ?? 'eq'
  if (item.right?.type === 'value') item.right.value = ''
  emitChange()
}

function collectionNodeChanged(item: CollectionCondition) {
  const field = collectionFields(item.source.nodeId)[0]
  if (field) {
    item.source.fieldId = field.fieldId
    item.source.fieldLabel = field.label
    item.childFieldId = field.children?.[0]?.fieldId
    item.childFieldLabel = field.children?.[0]?.label
    item.operator = getOperators(field.children?.[0])[0]?.value ?? 'eq'
  }
  emitChange()
}

function collectionChanged(item: CollectionCondition) {
  const field = props.fields.find(f => f.nodeId === item.source.nodeId && f.fieldId === item.source.fieldId)
  item.source.fieldLabel = field?.label
  item.childFieldId = field?.children?.[0]?.fieldId
  item.childFieldLabel = field?.children?.[0]?.label
  item.operator = getOperators(field?.children?.[0])[0]?.value ?? 'eq'
  emitChange()
}

function childChanged(item: CollectionCondition) {
  const child = collectionChild(item)
  item.childFieldLabel = child?.label
  item.operator = getOperators(child)[0]?.value ?? 'eq'
  emitChange()
}
</script>

<style scoped lang="less">
.condition-group {
  border: 1px solid var(--el-border-color);
  border-radius: 6px;
  padding: 10px;
  margin-bottom: 8px;
  background: var(--el-fill-color-blank);
}
.condition-group-head { display:flex; align-items:center; gap:6px; margin-bottom:8px; }
.condition-row { display:flex; align-items:center; gap:6px; margin:6px 0; }
.condition-row :deep(.el-select) { width:145px; }
.collection-row { background:var(--el-fill-color-light); padding:6px; border-radius:4px; }
.condition-empty { color:var(--el-text-color-secondary); padding:12px; text-align:center; }
.aggregate-title { font-size:12px; color:var(--el-color-primary); }
</style>
