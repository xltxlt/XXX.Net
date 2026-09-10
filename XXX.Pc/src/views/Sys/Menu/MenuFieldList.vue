<template>
  <div class="field-list-page">
    <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
  </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import PageInfo from "@/components/ListPage/PageInfo.vue";
import MenuFieldEdit from "./MenuFieldEdit.vue";
import MenuFieldBatchEdit from "./MenuFieldBatchEdit.vue";
import type { TempListPageConfig } from "@/components/ListPage";
import { copySysData, handleSumbitResBox } from "@/utils/common";
import { ElMessage, ElMessageBox } from "element-plus";
import { ConditionalType, FieldType, FloatType } from "@/components/ListPage";
// import { fieldEdit, getFieldEditPageRenderAsync } from "@/api/field";
import { menuFieldService } from "@/api/index.ts";
import MenuFieldBatchAdd from "./MenuFieldBatchAdd.vue";
const { pars } = defineProps<{ pars?: Record<string, any> }>()
const pageInfoRef = ref()
const pageConfig: TempListPageConfig = {
  url: menuFieldService.apiSysMenuFieldListPost.bind(menuFieldService),
  optionUrl: menuFieldService.apiSysMenuFieldPageoptionGet.bind(menuFieldService),
  renderUrl: menuFieldService.apiSysMenuFieldPageoptionGet.bind(menuFieldService),
  treeProps: {},
  customWhere: [{
    filedName: "menuId",
    filedValue: pars?.menuId,
    conditionalType: ConditionalType.Equal
  }],
  customListPage: {
    search: [
    ],
    btns: [
      {
        label: "新增",
        eventName: "add",
        icon: "search",
        bgColor: "#28a745",
      },
      {
        label: "获取数据",
        eventName: "getData",
        icon: "search",
        bgColor: "#1485EE",
      },
      {
        label: "批量新增",
        eventName: "addByJson",
        icon: "search",
        bgColor: "#FA9D3B",
      },
      {
        label: "批量修改",
        eventName: "batchEdit",
        icon: "search",
        bgColor: "#FA9D3B",
      },
      {
        label: "自动新增",
        eventName: "syncAdd",
        icon: "search",
        bgColor: "#FA9D3B",
      },
    ],
    fields: [
      {
        label: "字段名称",
        fieldName: 'name',
        width: '120'
      }, {
        label: "显示名称",
        fieldName: "label",
        width: '120'

      },
      {
        label: "关联字段",
        fieldName: "fieldName",
        width: '120'

      },

      {
        label: "事件名称",
        fieldName: "eventName",
        width: '120',
        searchField: false,

      },

      {
        label: "宽度",
        fieldName: 'width',
        searchField: false,
        width: '120',

      },
      {
        label: "搜索类型",
        fieldName: 'inputType',
        width: '120'

      },
      {
        label: "浮动类型",
        fieldName: 'floatType',
        width: '120'

      },
      {
        label: "合计行",
        fieldName: 'totalRow',
        width: '120'

      },
      {
        label: "初始隐藏",
        fieldName: 'initHide',
        width: '120'

      },
      {
        label: "对齐方式",
        fieldName: 'alignType',
        width: '120'

      },


      {
        label: "应用搜索",
        fieldName: 'searchField',
        width: '120'

      },
      {
        label: "数据来源",
        fieldName: 'dataSourceType',
        width: '140'

      },
      {
        label: "关联数据源",
        fieldName: 'DataSourceValue',
        width: '140',
        searchField: false,


      },
      {
        label: "数据源参数",
        fieldName: 'dataSourcePars',
        searchField: false,
        width: '140',

      },
      {
        label: "自定义模板",
        fieldName: 'template',
        searchField: false,
        width: '140',

      },
      {
        label: "排序",
        fieldName: 'sort',
        width: '120',
        searchField: false,
      },
      {
        label: '状态',
        fieldName: 'enabled',
        width: '120'

      }, {
        label: '是否通用',
        fieldName: 'general',
        width: '120'

      }, {
        label: "说明",
        fieldName: 'description',
        width: '120',
        searchField: false,


      },
      {
        fieldName: "rightTools",
        label: "功能操作",
        fieldType: FieldType.RightTools,
        width: "150px",
        floatType: FloatType.Right,
      },
    ],
    tableBtns: [
      {
        label: "修改",
        eventName: "edit",
        icon: "search",
        bgColor: "#28a745",
      },
       {
        label: "删除",
        eventName: "del",
        bgColor: "#fa3e3e",
      }
    ],
  },
  pageFun: {
    add: (data: any) => {
      return {
        title: "新增表头字段",
        comp: MenuFieldEdit,
        height: "80%",
        pars: {
          menuId: pars?.menuId,
          type: pars?.type,
        },
      };
    },
    del:async (data: any) => {
      await ElMessageBox.confirm('此操作将永久删除该记录, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
      });
      const res = await menuFieldService.apiSysMenuFieldDeleteIdPost(data.id);
      handleSumbitResBox(res, '删除成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    batchEdit: (data: any) => {
      const ids = Array.isArray(data) ? data.map(item => item.id) : [data?.id];
      if (ids?.length == 0) {
        ElMessage.error("请选择需要修改的数据");
        return;
      }
      console.log(ids);
      return {
        title: "批量修改表头字段",
        comp: MenuFieldBatchEdit,
        height: "80%",
        pars: {
          ids: ids,
        },
      };
    },
    edit: (data: any) => {
      // 这里可以调用API获取数据列表
      return {
        title: "编辑表头字段",
        comp: MenuFieldEdit,
        height: "80%",
        pars: {
          id: data.id,
          menuId: pars?.menuId,
          type: pars?.type,
        },
      };
    },
    syncAdd: (data: any) => {
      // 这里可以调用API获取数据列表
      return {
        title: "自动信息",
        comp: MenuFieldBatchAdd,
        height: "100%",
        width: '100%',
        pars: {
          id: data.id,
          menuId: pars?.menuId,
          type: pars?.type,
        },
      };
    },
    getData: (data: any) => {
      copySysData(data, async (id: string) => {
        try {
          const res = await menuFieldService.apiSysMenuFieldDetailIdGet(id);
          if (res.data.statusCode == 200) {
            return res.data.data;
          }
        }
        catch {
          return null;
        }

      })
    },
    addByJson: () => {
      ElMessageBox.prompt(
        '请输入字段JSON',
        '提示',
        {
          confirmButtonText: '确认',
          cancelButtonText: '取消',
        }
      ).then((res: any) => {
        if (res.value === '') {
          ElMessage.error("请输入字段JSON")
          return;
        }
        const data = JSON.parse(res.value)
        data.forEach(async (item: any) => {
          item.menuId = pars?.menuId ?? '';
          await menuFieldService.apiSysMenuFieldAddorupdatePost(item);
          pageInfoRef.value.onRefresh();
        });
      })
    }
  },
};
</script>
<style scoped>
.field-list-page {
  padding-top: 10px;
  height: calc(100% - 25px);
}
</style>
