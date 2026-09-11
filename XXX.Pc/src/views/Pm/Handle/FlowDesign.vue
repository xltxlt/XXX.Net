<template>
  <div class="flow-design-page">
    <FlowDesigner ref="designerRef" @save="onSave" @designer-form="onDesignForm" />
    <el-dialog v-model="formDesignVisible" title="设计表单" width="100%" draggable align-center style="height: 100%;top:0" :close-on-click-modal="false">
      <template v-for="node in formDesignNodes" :key="node.id">
        <PageFormDesigner
          v-show="formDesignVisible && designNodeId === node.id"
          @release="saveForm"
          :workflow-id="workflowId"
          :node-id="node.id"
          :node-type="node.type"
          :node-name="node.name"
          :workflow-deginition-id="pars?.workflowDefinitionId"
        />
      </template>
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import FlowDesigner from '@/components/FlowDesigner/index.vue'
import { workflowDefinitionService, workflowNodeFormService } from '@/api/workflow'
import PageFormDesigner from '@/views/PageForm/PageFormDesigner.vue'
import type { WorkflowNodeForm } from '@/api-services/generated'

const emit = defineEmits(['closeDialog', 'refreshList'])
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const designerRef = ref()
const workflowId = ref<string>(pars?.workflowId ?? '')
const formDesignVisible = ref(false)
const designNodeId = ref('')
const designNodeName = ref('')
const designNodeType = ref('')

/**
 * FlowDesign 页面级表单缓存。
 * key   = 节点 Id
 * value = 当前节点的整张表单 JSON + 自定义属性 JSON
 *
 * 设计表单时先写这里，不立即写数据库；最终点击流程保存时统一提交。
 */
const nodeForms = ref<Record<string, WorkflowNodeForm>>({})

/** 用于为每个节点保留一个独立的 PageFormDesigner 实例。 */
const formDesignNodes = ref<Array<{ id: string; type: string; name: string }>>([])

type NodeFormReleaseData = {
  form: any[]
  attrData: Record<string, Record<string, any>>
}

const getNodeId = (node: any): string => String(node?.Id ?? node?.id ?? '')
const getNodeType = (node: any): string => String(node?.Type ?? node?.type ?? '')
const getNodeName = (node: any): string => String(node?.Name ?? node?.name ?? node?.data?.label ?? node?.Id ?? node?.id ?? '')

const isFormDesigned = (form?: WorkflowNodeForm | null): boolean => {
  if (!form?.formJson) return false
  try {
    const data = JSON.parse(form.formJson)
    return Array.isArray(data) && data.length > 0
  } catch {
    return false
  }
}

const setFormDesignNodes = (nodes: any[]) => {
  formDesignNodes.value = (nodes ?? [])
    .filter((node: any) => ['start', 'task', 'end'].includes(getNodeType(node)))
    .map((node: any) => ({
      id: getNodeId(node),
      type: getNodeType(node),
      name: getNodeName(node),
    }))
    .filter((node: any) => !!node.id)
}

const onDesignForm = (node: any) => {
  designNodeId.value = getNodeId(node)
  designNodeType.value = getNodeType(node)
  designNodeName.value = getNodeName(node)
  if (!designNodeId.value) return

  // 新节点如果还没有进入节点实例列表，也立即加入。
  if (!formDesignNodes.value.some(item => item.id === designNodeId.value)) {
    formDesignNodes.value.push({
      id: designNodeId.value,
      type: designNodeType.value,
      name: designNodeName.value,
    })
  }

  formDesignVisible.value = true
}

const loadNodeForms = async (definitionId: string, nodes: any[]) => {
  nodeForms.value = {}
  setFormDesignNodes(nodes)

  if (!definitionId || !nodes?.length) return

  const formNodes = nodes.filter((node: any) =>
    ['start', 'task', 'end'].includes(getNodeType(node))
  )

  const results = await Promise.all(formNodes.map(async (node: any) => {
    const nodeId = getNodeId(node)
    if (!nodeId) return null

    try {
      const res = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(
        definitionId,
        nodeId
      )

      if (res.data?.statusCode === 200 && res.data?.data) {
        return {
          nodeId,
          form: res.data.data as WorkflowNodeForm,
        }
      }
    } catch {
      // 节点没有历史表单时保持空缓存。
    }

    return null
  }))

  results.forEach(item => {
    if (item?.form) {
      nodeForms.value[item.nodeId] = item.form
    }
  })
}

onMounted(async () => {
  if (!pars?.workflowId || !pars?.workflowDefinitionId) return

  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(
      pars.workflowDefinitionId
    )

    if (res.data.statusCode !== 200 || !res.data?.data) return

    const def = res.data.data
    const rawNodes = def.Nodes ?? def.nodes ?? []

    designerRef.value?.loadDefinition(def)
    await loadNodeForms(String(pars.workflowDefinitionId), rawNodes)
  } catch (e: any) {
    ElMessage.error(e?.message ?? '流程加载失败')
  }
})

/**
 * 当前节点表单设计完成后，只更新 FlowDesign 的节点表单缓存。
 *
 * A 节点：nodeForms[A] = A 表单 JSON
 * B 节点：nodeForms[B] = B 表单 JSON
 * 再回到 A：仍然使用 A 对应的 PageFormDesigner 实例，不会被 B 覆盖。
 */
const saveForm = (formData: NodeFormReleaseData) => {
  const nodeId = designNodeId.value
  if (!nodeId) return

  const old = nodeForms.value[nodeId]

  nodeForms.value[nodeId] = {
    ...(old ?? {}),
    nodeId,
    formJson: JSON.stringify(formData.form ?? []),
    attrDataJson: JSON.stringify(formData.attrData ?? {}),
  }

  formDesignVisible.value = false
}

const onSave = async (def: any) => {
  const rawNodes = def.Nodes ?? def.nodes ?? []
  const rawEdges = def.Edges ?? def.edges ?? []

  // 流程设计器保存后重新同步节点实例列表，但不清空 nodeForms。
  setFormDesignNodes(rawNodes)

  const nodes = rawNodes.map((node: any) => ({
    id: getNodeId(node),
    type: getNodeType(node),
    name: node.Name ?? node.name,
    config: typeof (node.Config ?? node.config) === 'string'
      ? (node.Config ?? node.config)
      : JSON.stringify(node.Config ?? node.config ?? {}),
    nodeJson: node.NodeJson ?? node.nodeJson ?? '',
  }))

  const edges = rawEdges.map((edge: any) => ({
    source: edge.Source ?? edge.source,
    target: edge.Target ?? edge.target,
    condition: edge.Condition ?? edge.condition ?? null,
    edgeJson: edge.EdgeJson ?? edge.edgeJson ?? '',
  }))

  // 删除已经从流程图中移除的节点对应表单。
  const validNodeIds = new Set(nodes.map((node: any) => node.id))
  Object.keys(nodeForms.value).forEach(nodeId => {
    if (!validNodeIds.has(nodeId)) {
      delete nodeForms.value[nodeId]
    }
  })

  // Start / Task 必须设计表单，End 可以没有表单。
  const requiredFormNodes = rawNodes.filter((node: any) =>
    ['start', 'task'].includes(getNodeType(node))
  )

  const missingForms = requiredFormNodes.filter((node: any) => {
    const nodeId = getNodeId(node)
    return !nodeForms.value[nodeId] || !isFormDesigned(nodeForms.value[nodeId])
  })

  if (missingForms.length > 0) {
    ElMessage.warning(`以下节点尚未设计表单：${missingForms.map(getNodeName).join('、')}`)
    return
  }

  const payload = {
    pmFlowTempId: pars?.id ?? '',
    workflowId: workflowId.value,
    name: def.Name ?? def.name ?? '',
    version: def.Version ?? def.version ?? 1,
    nodes,
    edges,
  }

  // 只提交当前流程节点对应的表单。
  const workflowNodeForm = Object.values(nodeForms.value).filter(form =>
    validNodeIds.has(String(form.nodeId ?? ''))
  )

  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionSavePost({
      pmFlowTempId: pars?.id ?? '',
      workflowDefinition: payload,
      workflowNodeForm,
    })

    const data = res.data?.data
    if (data?.workflowId) workflowId.value = data.workflowId

    ElMessage({ message: '流程保存成功', type: 'success', plain: true })
    emit('closeDialog')
    emit('refreshList')
  } catch (e: any) {
    ElMessage.error(e?.message ?? '流程保存失败')
  }
}
</script>
