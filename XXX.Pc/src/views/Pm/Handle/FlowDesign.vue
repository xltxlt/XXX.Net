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

import { buildConditionFields } from '@/components/FlowDesigner/conditionSchema'

const conditionFields = computed<ConditionField[]>(() => {
  const result: ConditionField[] = []

  Object.entries(nodeForms.value).forEach(([nodeId, form]) => {
    let parsed: any[] = []
    try {
      const value = isEmptyVal(form.formJson) ? [] : JSON.parse(form.formJson || '[]')
      parsed = Array.isArray(value) ? value : []
    } catch {
      parsed = []
    }

    const node = (designerRef.value?.getNodes?.() || []).find((n: any) => n.id === nodeId)
    const nodeName = String(node?.data?.label ?? node?.label ?? nodeId)

    result.push(...buildConditionFields(nodeId, nodeName, parsed))
  })

  return result
})

type NodeFormReleaseData = { form: any[]; attrData: Record<string, Record<string, any>> }
const desingnFormData = computed<ReleaseData>(() => {
  var nodeForm = nodeForms.value[designNodeId.value];
  if (isNullOrUnDef(nodeForm)) return {
    form: [],
    attrData: {},
    cols: 2
  } as ReleaseData;
  return {
    cols: nodeForm.cols ?? 2,
    form: isEmptyVal(nodeForm.formJson) ? [] : JSON.parse(nodeForm.formJson ?? ''),
    attrData: isEmptyVal(nodeForm.attrDataJson) ? [] : JSON.parse(nodeForm.attrDataJson ?? ''),
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
    cols: formData.cols,
  }
  formDesignVisible.value = false
}

const onSave = async (def: any) => {
  const rawNodes = def.Nodes ?? def.nodes ?? []
  const rawEdges = def.Edges ?? def.edges ?? []
  // 条件表达式只保存在“条件节点 -> 出口边”上。
  // 不再从条件节点 data.condition 读取，否则会覆盖可视化条件设计器生成的 DSL。


  const nodes = rawNodes.map((node: any) => ({ id: getNodeId(node), type: getNodeType(node), name: node.Name ?? node.name, config: typeof (node.Config ?? node.config) === 'string' ? (node.Config ?? node.config) : JSON.stringify(node.Config ?? node.config ?? {}), nodeJson: node.NodeJson ?? node.nodeJson ?? '' }))

  const edges = rawEdges.map((edge: any) => {

    const sourceId = edge.Source ?? edge.source

    // 条件只取连线自身的 condition。
    // ConditionDesigner 保存的是 JSON DSL 字符串，必须原样传给后端。
    const condition = edge.Condition ?? edge.condition ?? edge.data?.condition ?? null

    return {
      source: sourceId,
      target: edge.Target ?? edge.target,
      condition,
      edgeJson: edge.EdgeJson ?? edge.edgeJson ?? ''
    }
  })
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
