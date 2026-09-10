<template>
  <div class="flow-design-page">
    <FlowDesigner ref="designerRef" @save="onSave" @designer-form="onDesignForm">
      <template #toolbar-left>
        <span class="flow-title">流程设计</span>
        <el-button size="small" type="warning" :disabled="!workflowId" @click="publish">发布当前版本</el-button>
      </template>
    </FlowDesigner>

    <el-dialog v-model="formDesignVisible" title="设计表单" width="100%" draggable align-center style="height: 100%;top:0" :close-on-click-modal="false">
      <WorkflowFormDesign @release="saveForm" v-if="formDesignVisible" :workflow-id="workflowId" :node-id="designNodeId" :node-type="designNodeType"
        :node-name="designNodeName" :workflow-deginition-id="pars?.workflowDefinitionId" />
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import FlowDesigner from '@/components/FlowDesigner/index.vue'
import WorkflowFormDesign from '@/views/Workflow/WorkflowFormDesign.vue'
import { workflowDefinitionService } from '@/api/workflow'
import type { WorkflowNodeForm } from '@/api-services/generated'
const emit = defineEmits([
    'closeDialog',
    'refreshList'
]);

const { pars } = defineProps<{ pars?: Record<string, any> }>()

const designerRef = ref()
const workflowId = ref<string>(pars?.workflowId ?? '')
const formDesignVisible = ref(false)
const designNodeId = ref('')
const designNodeName = ref('')
const designNodeType = ref('')


onMounted(async () => {
  if (pars?.workflowId) {
    var res = await workflowDefinitionService.apiWorkflowDefinitionDetailWorkflowdefinitionidGet(pars.workflowDefinitionId);
    if (res.data.statusCode == 200) {
      const def = res.data?.data
      if (def) {
        designerRef.value?.loadDefinition(def)

      }
    }
  }
})
const nodeForms = ref<Record<string, WorkflowNodeForm>>({})
const saveForm = (formData: WorkflowNodeForm) => {
  if (!designNodeId.value) return
  nodeForms.value[designNodeId.value] = {
    ...formData,
    nodeId: designNodeId.value,
  }
  formDesignVisible.value = false
}
// 保存流程定义
const onSave = async (def: any) => {
  // FlowDesigner 的 save 事件是 PascalCase WorkflowDefinitionDto，转成后端 camelCase，且 config 序列化为 JSON 字符串
  // const nodes = (def.Nodes ?? def.nodes ?? []).map((n: any) => {
  //   const cfg = n.Config ?? n.config ?? {}
  //   return {
  //     id: n.Id ?? n.id,
  //     type: n.Type ?? n.type,
  //     name: n.Name ?? n.name,
  //     config: typeof cfg === 'string' ? cfg : JSON.stringify(cfg),
  //   }
  // })
  // const edges = (def.Edges ?? def.edges ?? []).map((e: any) => ({
  //   source: e.Source ?? e.source,
  //   target: e.Target ?? e.target,
  //   condition: e.Condition ?? e.condition ?? null,
  // }))
  const nodes = (def.Nodes ?? def.nodes ?? []).map((node: any) => ({
    id: node.Id ?? node.id,
    type: node.Type ?? node.type,
    name: node.Name ?? node.name,
    config: typeof (node.Config ?? node.config) === 'string'
      ? (node.Config ?? node.config)
      : JSON.stringify(node.Config ?? node.config ?? {}),
    nodeJson: node.NodeJson ?? node.nodeJson ?? '',
  }))
  const edges = (def.Edges ?? def.edges ?? []).map((edge: any) => ({
    source: edge.Source ?? edge.source,
    target: edge.Target ?? edge.target,
    condition: edge.Condition ?? edge.condition ?? null,
    edgeJson: edge.EdgeJson ?? edge.edgeJson ?? '',
  }))
  const payload = {
    pmFlowTempId: pars?.id ?? '',
    workflowId: workflowId.value,
    name: def.Name ?? def.name ?? '',
    version: def.Version ?? def.version ?? 1,
    nodes,
    edges,
  }
  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionSavePost({
      pmFlowTempId:pars?.id??'',
      workflowDefinition: payload,
    workflowNodeForm: Object.values(nodeForms.value)
    })
    const data = res.data?.data
    // 后端生成的 workflowId 存回，后续复用
    if (data?.workflowId) workflowId.value = data.workflowId
    ElMessage({
      message: '操作成功',
      type: 'success',
      plain: true,
    });

    emit('closeDialog');
    emit('refreshList');
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
  designNodeId.value = node.id ?? node.Id
  designNodeName.value = node.data?.label ?? node.name ?? node.Name ?? node.id
  designNodeType.value = node.type ?? node.Type
  formDesignVisible.value = true
}
</script>

<style lang="less" scoped>
.flow-design-page {
  width: 100%;
  height: 100%;
}
</style>
