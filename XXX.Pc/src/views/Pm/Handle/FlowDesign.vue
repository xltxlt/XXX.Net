<template>
  <div class="flow-design-page">
    <FlowDesigner ref="designerRef" @save="onSave" @designer-form="onDesignForm">
      <!-- <template #toolbar-left>
        <span class="flow-title">流程设计</span>
        <el-button size="small" type="warning" :disabled="!workflowId" @click="publish">发布当前版本</el-button>
      </template> -->
    </FlowDesigner>
    <el-dialog v-model="formDesignVisible" title="设计表单" width="100%" draggable align-center style="height: 100%;top:0" :close-on-click-modal="false">
      <PageFormDesigner
        v-if="formDesignVisible"
        @release="saveForm"
        :workflow-id="workflowId"
        :node-id="designNodeId"
        :node-type="designNodeType"
        :node-name="designNodeName"
        :workflow-deginition-id="pars?.workflowDefinitionId"
      />
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

const emit = defineEmits([
  'closeDialog',
  'refreshList'
])

const { pars } = defineProps<{ pars?: Record<string, any> }>()

const designerRef = ref()
const workflowId = ref<string>(pars?.workflowId ?? '')
const formDesignVisible = ref(false)
const designNodeId = ref('')
const designNodeName = ref('')
const designNodeType = ref('')

/**
 * 当前正在编辑的流程版本对应的节点表单。
 * key = WorkflowDefinition.Nodes[].Id
 */
const nodeForms = ref<Record<string, WorkflowNodeForm>>({})

const getNodeId = (node: any): string => String(node?.Id ?? node?.id ?? '')
const getNodeType = (node: any): string => String(node?.Type ?? node?.type ?? '')
const getNodeName = (node: any): string => String(
  node?.Name ?? node?.name ?? node?.data?.label ?? node?.Id ?? node?.id ?? ''
)

/**
 * 判断节点表单是否真正完成设计。
 * FormJson 必须是一个至少包含一个组件的数组。
 */
const isFormDesigned = (form?: WorkflowNodeForm | null): boolean => {
  if (!form || !form.formJson) return false

  try {
    const data = JSON.parse(form.formJson)
    return Array.isArray(data) && data.length > 0
  } catch {
    return false
  }
}

/**
 * 从当前 WorkflowDefinition 加载所有节点的表单。
 * 只读取当前版本，不读取 WorkflowId 下的历史版本，保证重新打开旧版本时
 * 恢复的就是该版本自己的表单快照。
 */
const loadNodeForms = async (definitionId: string, nodes: any[]) => {
  nodeForms.value = {}

  if (!definitionId || !nodes?.length) return

  const formNodes = nodes.filter((node: any) => {
    const type = getNodeType(node)
    return type === 'start' || type === 'task' || type === 'end'
  })

  const results = await Promise.all(
    formNodes.map(async (node: any) => {
      const nodeId = getNodeId(node)
      if (!nodeId) return null

      try {
        const res = await workflowNodeFormService
          .apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(definitionId, nodeId)

        if (res.data?.statusCode === 200 && res.data?.data) {
          return {
            nodeId,
            form: res.data.data as WorkflowNodeForm,
          }
        }
      } catch {
        // 当前版本没有表单时不阻断流程打开，保存时统一校验。
      }

      return null
    })
  )

  results.forEach(item => {
    if (!item?.form) return
    nodeForms.value[item.nodeId] = item.form
  })
}

onMounted(async () => {
  // 新流程还没有 WorkflowDefinition，不需要加载节点表单。
  if (!pars?.workflowId || !pars?.workflowDefinitionId) return

  try {
    const res = await workflowDefinitionService
      .apiWorkflowDefinitionDetailWorkflowdefinitionidGet(pars.workflowDefinitionId)

    if (res.data.statusCode !== 200) return

    const def = res.data?.data
    if (!def) return

    designerRef.value?.loadDefinition(def)

    const nodes = def.Nodes ?? def.nodes ?? []
    await loadNodeForms(String(pars.workflowDefinitionId), nodes)
  } catch (e: any) {
    ElMessage.error(e?.message ?? '流程加载失败')
  }
})

/**
 * 表单设计器只负责编辑表单，保存按钮由外层流程设计器统一提交。
 * 这里将表单按照 nodeId 放入当前编辑快照。
 */
const saveForm = (formData: WorkflowNodeForm) => {
  if (!designNodeId.value) return

  nodeForms.value[designNodeId.value] = {
    ...(nodeForms.value[designNodeId.value] ?? {}),
    ...formData,
    nodeId: designNodeId.value,
  }

  formDesignVisible.value = false
}

// 保存流程定义
const onSave = async (def: any) => {
  const rawNodes = def.Nodes ?? def.nodes ?? []
  const rawEdges = def.Edges ?? def.edges ?? []

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

  /**
   * 删除节点后立即从当前表单快照中剔除对应表单。
   * 历史版本不会受到影响；这里只处理本次准备保存的新版本。
   */
  const validNodeIds = new Set(nodes.map((node: any) => node.id))
  Object.keys(nodeForms.value).forEach(nodeId => {
    if (!validNodeIds.has(nodeId)) {
      delete nodeForms.value[nodeId]
    }
  })

  /**
   * 开始节点和任务节点必须完成表单设计。
   * 结束节点不强制要求表单，但仍允许用户按需设计并保存。
   */
  const requiredFormNodes = rawNodes.filter((node: any) => {
    const type = getNodeType(node)
    return type === 'start' || type === 'task'
  })

  const missingForms = requiredFormNodes.filter((node: any) => {
    const nodeId = getNodeId(node)
    return !nodeForms.value[nodeId] || !isFormDesigned(nodeForms.value[nodeId])
  })

  if (missingForms.length > 0) {
    ElMessage.warning(
      `以下节点尚未设计表单：${missingForms.map(getNodeName).join('、')}`
    )
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

  /**
   * 只提交当前流程中仍然存在的节点表单。
   * 后端保存时会绑定新的 WorkflowDefinition.Id + Version，
   * 因此修改不会覆盖历史版本。
   */
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

    // 后端生成的 workflowId 存回，后续保存继续沿用同一个流程。
    if (data?.workflowId) workflowId.value = data.workflowId

    ElMessage({
      message: '流程保存成功',
      type: 'success',
      plain: true,
    })

    emit('closeDialog')
    emit('refreshList')
  } catch (e: any) {
    ElMessage.error(e?.message ?? '流程保存失败')
  }
}

const publish = async () => {
  if (!workflowId.value) return

  try {
    await workflowDefinitionService.apiWorkflowDefinitionPublishWorkflowidPost(workflowId.value)
    ElMessage.success('流程已发布，可用于发起实例')
  } catch (e: any) {
    ElMessage.error(e?.message ?? '流程发布失败')
  }
}

// 打开表单设计器
const onDesignForm = (node: any) => {
  designNodeId.value = getNodeId(node)
  designNodeName.value = getNodeName(node)
  designNodeType.value = getNodeType(node)
  formDesignVisible.value = true
}
</script>

<style lang="less" scoped>
.flow-design-page {
  width: 100%;
  height: 100%;
}
</style>
