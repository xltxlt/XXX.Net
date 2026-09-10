<template>
  <div class="flow-design-page">
    <FlowDesigner ref="designerRef" @save="onSave" @designer-form="onDesignForm" />

    <el-dialog v-model="formDesignVisible" title="设计表单" width="100%" draggable align-center style="height: 100%;top:0" :close-on-click-modal="false">
      <PageFormDesigner @release="saveForm" v-if="formDesignVisible" :workflow-id="workflowId" :node-id="designNodeId" :node-type="designNodeType"
        :node-name="designNodeName" :workflow-deginition-id="pars?.workflowDefinitionId" />
    </el-dialog>
  </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { ElMessage } from 'element-plus'
import FlowDesigner from '@/components/FlowDesigner/index.vue'
import WorkflowFormDesign, { type FormReleaseData } from '@/views/Workflow/WorkflowFormDesign.vue'
import PageFormDesigner from '@/views/PageForm/PageFormDesigner.vue'
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
const nodeForm = ref<Array<WorkflowNodeForm>>([])
const saveForm = async (formData:WorkflowNodeForm,nodeId:string) => { 
  formDesignVisible.value=false;
  nodeForm.value.push(formData);
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
  const payload = {
          pmFlowTempId:pars?.id??'',
    workflowId: workflowId.value,
    name: def.Name ?? def.name ?? '',
    version: def.Version ?? def.version ?? 1,
    nodes: (def.Nodes ?? def.nodes ?? []),
    edges: (def.Edges ?? def.edges ?? []),
  }
  try {
    const res = await workflowDefinitionService.apiWorkflowDefinitionSavePost({
      pmFlowTempId:pars?.id??'',
      workflowDefinition: payload,
      workflowNodeForm: nodeForm.value
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

// 打开表单设计器
const onDesignForm = (node: any) => {
  // if (!workflowId.value) {
  //   ElMessage.warning('请先保存流程，再设计表单')
  //   return
  // }
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
