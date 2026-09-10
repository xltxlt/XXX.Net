


<template>
  <PageInfo :pageConfig="pageConfig" ref="pageInfoRef" />
</template>

<script setup lang="ts">
import { ref } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
import PageInfo from "@/components/ListPage/PageInfo.vue";
import { pmFlowTempService } from "@/api/workflow.ts";
import pmFlowTempEdit from "./pmFlowTempEdit.vue";
import FlowDesign from "./Handle/FlowDesign.vue";
import PmFlowStart from "./Handle/PmFlowStart.vue";
import { PagedSearchType, type TempListPageConfig } from "@/components/ListPage";
import { handleSumbitResBox } from "@/utils/common"; // 假设工具函数在此

const pageInfoRef = ref();

const pageConfig: TempListPageConfig = {
  url: pmFlowTempService.apiPmFlowTempPagelistPost.bind(pmFlowTempService),
  optionUrl: pmFlowTempService.apiPmFlowTempPageoptionGet.bind(pmFlowTempService),
  pageFun: {
    start: (data: any) => {
      if (!data?.workflowId || !data?.workflowDefinitionId) {
        ElMessage.warning('请先设计并发布流程');
        return;
      }
      return {
        title: "发起流程",
        comp: PmFlowStart,
        height: "80%",
        width: "70%",
        pars: {
          workflowId: data.workflowId,
          workflowDefinitionId: data.workflowDefinitionId,
        },
      };
    },
    setFlow: (data: any) => {
      return {
        title: "流程设计",
        comp: FlowDesign,
        height: "100%",
        width: "100%",
        pars: {
          workflowId: data?.workflowId,
          version: data?.lastVersion, 
          id:data?.id,
          workflowDefinitionId: data?.workflowDefinitionId,
        },
      };
    },
    add: (data: any) => {
      return {
        title: "新增",
        comp: pmFlowTempEdit,
        height: "70%",
        pars: {},
      };
    },
    edit: (data: any) => {
      return {
        title: "修改",
        comp: pmFlowTempEdit,
        height: "70%",
        pars: {
          id: data?.id, // 使用行数据的 id
        },
      };
    },
    batchDel: async (data: any[]) => {
      const ids = data.map(item => item.id);
      if (ids.length === 0) {
        ElMessage({ type: 'info', message: '请选择要删除的记录' });
        return;
      }
      if (ids.length !== 1) {
        ElMessage({ type: 'info', message: '批量删除仅支持单条记录' });
        return;
      }
      const res = await pmFlowTempService.apiPmFlowTempBatchlogicdeletePost(ids);
      handleSumbitResBox(res, '删除成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    del: async (data: any) => {
      await ElMessageBox.confirm('此操作将永久删除该记录, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
      });
      const res = await pmFlowTempService.apiPmFlowTempLogicdeleteIdPost(data.id);
      handleSumbitResBox(res, '删除成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    lock: (data: any) => {
      return {
        title: "查看",
        comp: pmFlowTempEdit,
        height: "70%",
        pars: {
          id: data?.id, // 使用行数据的 id
          lock: "lock",
        },
      };
    },
  },
};
</script>

<style lang="less" scoped>
// 如果需要额外样式，可在此添加
</style>