<template>
  <div class="field-list-page">
    <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
  </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import PageInfo from "@/components/ListPage/PageInfo.vue";
import MenuButtonEdit from "./MenuButtonEdit.vue";
import type { TempListPageConfig } from "@/components/ListPage";
import { ConditionalType, FieldType, FloatType } from "@/components/ListPage";
import { copySysData, handleSumbitResBox } from "@/utils/common";
import { ElMessage, ElMessageBox } from "element-plus";
import { menuButtonService } from "@/api/index.ts";
const pageInfoRef = ref()
const { pars } = defineProps<{ pars?: Record<string, any> }>()
menuButtonService.apiSysMenuButtonPageoptionGet()
const pageConfig: TempListPageConfig = {
  url: menuButtonService.apiSysMenuButtonPagelistPost.bind(menuButtonService),
  renderUrl: menuButtonService.apiSysMenuButtonPageoptionGet.bind(menuButtonService),
  treeProps: {},
  customWhere: [{
    filedName: "menuId",
    filedValue: pars?.menuId,
    conditionalType: ConditionalType.Equal
  }],
  customListPage: {
    search: [],
    btns: [
      {
        label: "新增",
        eventName: "add",
        icon: "search",
        bgColor: "#28a745",
      }, {
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
      }
    ],
    fields: [
      {
        fieldName: "name",
        label: "按钮名称",
      },
      {
        fieldName: "label",
        label: "显示名称",
      },

      {
        fieldName: "eventName",
        label: "按钮事件",
        width: "160",
      },

      {
        fieldName: "buttonType",
        label: "按钮类型",
        width: "160",
      },
      {
        fieldName: "icon",
        label: "图标",
        width: "100",
      },
      {
        fieldName: "bgColor",
        label: "颜色",
        width: "100",
      },
      {
        fieldName: "target",
        label: "目标应用",
        width: "110",
      },
      {
        fieldName: "sort",
        label: "排序",
        width: "110",
      },
      {
        fieldName: "enabled",
        label: "按钮状态",
        width: "120",
      },
      {
        fieldName: "general",
        label: "适用范围",
        width: "120",
      },
      {
        fieldName: "rightTools",
        label: "功能操作",
        fieldType: FieldType.RightTools,
        width: "150",
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
        title: "新增按钮字段",
        comp: MenuButtonEdit,
        height: "80%",
        pars: {
          menuId: pars?.menuId,
          type: pars?.type,
        },
      };
    },
    edit: (data: any) => {
      // 这里可以调用API获取数据列表
      return {
        title: "编辑按钮字段",
        comp: MenuButtonEdit,
        height: "80%",
        pars: {
          id: data.id,
          menuId: pars?.menuId,
          type: pars?.type,
        },
      };
    },
    del: async (data: any) => {
      await ElMessageBox.confirm('此操作将永久删除该记录, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
      });
      const res = await menuButtonService.apiSysMenuButtonDeleteIdPost(data.id);
      handleSumbitResBox(res, '删除成功', () => {
        pageInfoRef.value?.onRefresh();
      });
    },
    getData: (data: any) => {
      copySysData(data, async (id: string) => {
        try {
          // const res = await getButtonEditPageRender(id)
          // if (res.code == 200) {
          //   return res.data
          // }
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
        // data.forEach(async (item: any) => {
        //   item.menuId=pars?.menuId??'';
        //   await buttonEdit(item);
        //   pageInfoRef.value.onRefresh();
        // });
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
