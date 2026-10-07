<template>
  <div class="flow-design-page" style="height: 100%;">
    <FlowDesigner ref="designerRef" :condition-fields="conditionFields"  @save="onSave" @designer-form="onDesignForm" />
    <el-dialog v-model="formDesignVisible" title="设计表单" width="100%" draggable align-center style="height: 100%;top:0" :close-on-click-modal="false">
      <PageFormDesigner v-if="formDesignVisible" :designer-data="desingnFormData||{}" @release="saveForm" :workflow-id="workflowId" :node-id="designNodeId" :node-type="designNodeType" :node-name="designNodeName" :workflow-deginition-id="pars?.workflowDefinitionId" />
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { computed, onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import FlowDesigner from '@/components/FlowDesigner/index.vue'
import { workflowDefinitionService, workflowNodeFormService } from '@/api/pm'
import PageFormDesigner from '@/views/PageForm/PageFormDesigner.vue'
import type { WorkflowNodeForm } from '@/api-services/generated'
import type { ReleaseData } from '@/views/PageForm/PageFormDesigner.vue'
import { isEmptyVal, isNullOrUnDef } from '@/utils/is'
import type { ConditionField } from '@/components/FlowDesigner/condition'

const emit = defineEmits(['closeDialog', 'refreshList'])
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const designerRef = ref()
const workflowId = ref<string>(pars?.workflowId ?? '')
const formDesignVisible = ref(false)
const designNodeId = ref('')
const designNodeName = ref('')
const designNodeType = ref('')
const nodeForms = ref<Record<string, WorkflowNodeForm>>({})

const formTypeName = (value: any): string => {
  const text = String(value ?? '').toLowerCase()
  if (text.includes('number') || text.includes('amount') || text.includes('decimal') || text.includes('slider') || text.includes('rate')) return 'number'
  if (text.includes('switch') || text.includes('boolean')) return 'boolean'
  if (text.includes('date') || text.includes('time') || text.includes('year') || text.includes('month')) return 'date'
  if (text.includes('select') || text.includes('radio') || text.includes('checkbox') || text.includes('tree') || text.includes('cascader')) return 'select'

  const n = Number(value)
  if ([101, 110, 111, 112, 114].includes(n)) return 'number'
  if ([108].includes(n)) return 'boolean'
  if ([301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 311].includes(n)) return 'date'
  if ([102, 103, 200, 201, 202, 203, 204, 205, 206, 207, 208, 401, 402, 403].includes(n)) return 'select'
  return 'string'
}

const buildConditionFields = (nodeId: string, nodeName: string, form: any[]): ConditionField[] => {
  const result: ConditionField[] = []
  const walk = (items: any[], parentCollection?: ConditionField) => {
    ;(items || []).forEach(item => {
      const fieldId = String(item.fieldName || item.code || item.ident || '').trim()
      if (!fieldId) {
        if (Array.isArray(item.child)) walk(item.child, parentCollection)
        return
      }
      const children = Array.isArray(item.child)
        ? buildConditionFields(nodeId, nodeName, item.child)
        : []
      const options = Array.isArray(item.option)
        ? item.option.map((op: any) => ({
            label: String(op.label || op.title || op.name || op.value),
            value: op.value
          }))
        : []
      const field: ConditionField = {
        nodeId,
        nodeName,
        fieldId,
        label: String(item.title || item.label || item.fieldName || item.code || fieldId),
        type: formTypeName(item.formType),
        collection: children.length > 0,
        children,
        options
      }
      result.push(field)
    })
  }
  walk(form)
  return result
}

const conditionFields = computed<ConditionField[]>(() => {
  const result: ConditionField[] = []
  Object.entries(nodeForms.value).forEach(([nodeId, form]) => {
    let parsed: any[] = []
    try {
      parsed = isEmptyVal(form.formJson) ? [] : JSON.parse(form.formJson || '[]')
    } catch {
      parsed = []
    }
    const node = (designerRef.value?.getNodes?.() || []).find((n: any) => n.id === nodeId)
    result.push(...buildConditionFields(nodeId, node?.data?.label || nodeId, parsed))
  })
  return result
})

type NodeFormReleaseData = { form: any[]; attrData: Record<string, Record<string, any>> }
const desingnFormData=computed<ReleaseData>(()=>{
   var nodeForm= nodeForms.value[designNodeId.value] ;
   if(isNullOrUnDef(nodeForm))return {
    form:[],
    attrData:{},
    cols:2
   } as ReleaseData;
  return {
    cols:nodeForm.cols??2,
    form:isEmptyVal(nodeForm.formJson)?[]: JSON.parse(nodeForm.formJson??''), 
    attrData:isEmptyVal(nodeForm.attrDataJson)?[]: JSON.parse(nodeForm.attrDataJson??''), 
  } as ReleaseData
})
const getNodeId = (node: any): string => String(node?.Id ?? node?.id ?? '')
const getNodeType = (node: any): string => String(node?.Type ?? node?.type ?? '')
const getNodeName = (node: any): string => String(node?.Name ?? node?.name ?? node?.data?.label ?? node?.Id ?? node?.id ?? '')

const isFormDesigned = (form?: WorkflowNodeForm | null): boolean => {
  if (!form?.formJson) return false
  try { const data = JSON.parse(form.formJson); return Array.isArray(data) && data.length > 0 } catch { return false }
}

const onDesignForm = (node: any) => {
  designNodeId.value = getNodeId(node)
  designNodeType.value = getNodeType(node)
  designNodeName.value = getNodeName(node)
  const old = nodeForms.value[designNodeId.value]
  if (!designNodeId.value) return
  formDesignVisible.value = true
}

const loadNodeForms = async (definitionId: string, nodes: any[]) => {
  nodeForms.value = {}
  if (!definitionId || !nodes?.length) return
  const formNodes = nodes.filter((node: any) => ['start', 'task', 'approval', 'end'].includes(getNodeType(node)))
  const results = await Promise.all(formNodes.map(async (node: any) => {
    const nodeId = getNodeId(node)
    if (!nodeId) return null
    try {
      const res = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(definitionId, nodeId)
      if (res.data?.statusCode === 200 && res.data?.data) return { nodeId, form: res.data.data as WorkflowNodeForm }
    } catch { }
    return null
  }))
  results.forEach(item => { if (item?.form) nodeForms.value[item.nodeId] = item.form })
}

onMounted(async () => {
  if (!pars?.workflowId || !pars?.workflowDefinitionId) return
  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(pars.workflowDefinitionId)
    if (res.data.statusCode !== 200 || !res.data?.data) return
    const def = res.data.data
    designerRef.value?.loadDefinition(def)
    await loadNodeForms(String(pars.workflowDefinitionId), def.Nodes ?? def.nodes ?? [])
  } catch (e: any) { ElMessage.error(e?.message ?? '流程加载失败') }
})

const saveForm = (formData: ReleaseData) => {
  if (!designNodeId.value) return

  nodeForms.value[designNodeId.value] = {
    nodeId: designNodeId.value,
    formJson: JSON.stringify(formData.form ?? []),
    attrDataJson: JSON.stringify(formData.attrData ?? {}),
    cols:formData.cols,
  }
  formDesignVisible.value = false
}

const onSave = async (def: any) => {
  const rawNodes = def.Nodes ?? def.nodes ?? []
  const rawEdges = def.Edges ?? def.edges ?? []
  const nodes = rawNodes.map((node: any) => ({ id: getNodeId(node), type: getNodeType(node), name: node.Name ?? node.name, config: typeof (node.Config ?? node.config) === 'string' ? (node.Config ?? node.config) : JSON.stringify(node.Config ?? node.config ?? {}), nodeJson: node.NodeJson ?? node.nodeJson ?? '' }))
  const edges = rawEdges.map((edge: any) => ({ source: edge.Source ?? edge.source, target: edge.Target ?? edge.target, condition: edge.Condition ?? edge.condition ?? null, edgeJson: edge.EdgeJson ?? edge.edgeJson ?? '' }))

  const validNodeIds = new Set(nodes.map((node: any) => node.id))
  Object.keys(nodeForms.value).forEach(nodeId => { if (!validNodeIds.has(nodeId)) delete nodeForms.value[nodeId] })

  const requiredFormNodes = rawNodes.filter((node: any) => ['start', 'task'].includes(getNodeType(node)))
  const missingForms = requiredFormNodes.filter((node: any) => !nodeForms.value[getNodeId(node)] || !isFormDesigned(nodeForms.value[getNodeId(node)]))
  if (missingForms.length > 0) { ElMessage.warning(`以下节点尚未设计表单：${missingForms.map(getNodeName).join('、')}`); return }

  const payload = { pmFlowTempId: pars?.id ?? '', workflowId: workflowId.value, name: def.Name ?? def.name ?? '', version: def.Version ?? def.version ?? 1, nodes, edges }
  const workflowNodeForm = Object.values(nodeForms.value).filter(form => validNodeIds.has(String(form.nodeId ?? '')))

  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionSavePost({ pmFlowTempId: pars?.id ?? '', workflowDefinition: payload, workflowNodeForm })
    const data = res.data?.data
    if (data?.workflowId) workflowId.value = data.workflowId
    ElMessage({ message: '流程保存成功', type: 'success', plain: true })
    emit('closeDialog')
    emit('refreshList')
  } catch (e: any) { ElMessage.error(e?.message ?? '流程保存失败') }
}
</script>
