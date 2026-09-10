<template>
  <PageInfo :pageConfig="pageConfig" ref="pageInfoRef" />
</template>

<script setup lang="ts">
import { ref } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
import PageInfo from "@/components/ListPage/PageInfo.vue";
import { inventoryDocumentService } from "@/api/inventory.ts";
import InventoryOutboundDocument from "./InventoryOutboundDocument.vue";
import InventoryInboundDocument from "./InventoryInboundDocument.vue";
import InventoryDocumentEdit from "./InventoryDocumentEdit.vue";
import { PagedSearchType, type TempListPageConfig } from "@/components/ListPage";
import { handleSumbitResBox } from "@/utils/common"; // 假设工具函数在此
import { InventoryDocumentType } from "@/api-services/generated/index.ts";

const pageInfoRef = ref();

const pageConfig: TempListPageConfig = {
  url: inventoryDocumentService.apiInventoryDocumentPagelistPost.bind(inventoryDocumentService),
  optionUrl: inventoryDocumentService.apiInventoryDocumentPageoptionGet.bind(inventoryDocumentService),
  pageFun: {
    outbound: (data: any) => {
      return {
        title: "出库单",
        comp: InventoryOutboundDocument,
        height: "70%",
        pars: {
          documentType: 2
        },
      };
    },
    Inbound: (data: any) => {
      return {
        title: "入库单",
        comp: InventoryInboundDocument,
        height: "70%",
      };
    },
    edit: (data: any) => {
      return {
        title: "修改",
        comp: InventoryOutboundDocument,
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
      const res = await inventoryDocumentService.apiInventoryDocumentBatchlogicdeletePost(ids);
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
      const res = await inventoryDocumentService.apiInventoryDocumentLogicdeleteIdPost(data.id);
      handleSumbitResBox(res, '删除成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    cancel: async (data: any) => {
      await ElMessageBox.confirm('此操作将取消单据, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
      });
      const res = await inventoryDocumentService.apiInventoryDocumentCancelIdPost(data.id);
      handleSumbitResBox(res, '取消单据成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    
     complete: async (data: any) => {
      await ElMessageBox.confirm('此操作确认执行单据, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
      });
      const res = await inventoryDocumentService.apiInventoryDocumentCompleteIdPost(data.id);
      handleSumbitResBox(res, '确认执行单据成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    lock: (data: any) => {
      return {
        title: "查看",
        comp: InventoryDocumentEdit,
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