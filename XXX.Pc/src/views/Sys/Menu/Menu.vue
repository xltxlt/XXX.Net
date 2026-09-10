<template>
  <PageInfo :pageConfig="pageConfig" ref="pageInfoRef" />
</template>
<script setup lang="ts">
import PageInfo from "@/components/ListPage/PageInfo.vue";
import MenuEdit from "./MenuEdit.vue";
import { menuService } from "@/api/index.ts";
import MenuFieldList from "./MenuFieldList.vue";
import MenuButtonList from "./MenuButtonList.vue";
import { FieldType, FloatType, PagedSearchType, type TempListPageConfig } from "@/components/ListPage";
import { ref } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
const pageInfoRef = ref();
const pageConfig: TempListPageConfig = {
  url: menuService.apiSysMenuTreelistPost.bind(menuService),
  customListPage: {
    search: [
    ],
    btns: [
      {
        label: "新增",
        eventName: "addDic",
        icon: "search",
        bgColor: "#28a745",
      },
      {
        label: "删除",
        eventName: "delDic",
        icon: "search",
        bgColor: "#FA5151",
      },
    ],
    fields: [
      {
        fieldName: "name",
        label: "菜单名称",
        width: "200",
      },
      {
        fieldName: "alias",
        label: "菜单别名",
        width: "200",
      },
    
      {
        fieldName: "route",
        label: "地址",
        width: "",
      },
      {
        fieldName: "rightTools",
        label: "功能操作",
        fieldType: FieldType.RightTools,
        width: "580",
        floatType: FloatType.Right,
      },
    ],
    tableBtns: [
      {
        label: "修改",
        eventName: "editDic",
        icon: "search",
        bgColor: "#28a745",
      },
      {
        label: "表头字段",
        eventName: "addField",
        icon: "search",
        bgColor: "#8183FF",
      },
      {
        label: "菜单按钮",
        eventName: "addToolsBtn",
        icon: "search",
        bgColor: "#FA9D3B",
      },
      {
        label: "菜单镜像",
        eventName: "menuMirror",
        icon: "search",
        bgColor: "#30656d",
      },
    ],
  },
  pageFun: {
    addDic: (data: any) => {
      return {
        title: "新增菜单资源",
        comp: MenuEdit,
        height: "70%",
        pars: {
          name: "1",
          date: "2023-10-01",
        },
      };
    },
    editDic: (data: any) => {
      return {
        title: "编辑菜单资源",
        comp: MenuEdit,
        pars: {
          id: data.id,
          date: "",
        },
      };
    },
     menuMirror: (data: any) => {
      ElMessageBox.confirm(
        '确认要复制菜单镜像嘛？',
        '提示',
        {
          confirmButtonText: '确认',
          cancelButtonText: '取消',
          type: 'warning',
        }
      )
        .then(() => {
          const formData = {
            menuId: data.id
          }
          // menuMirror(formData).then((res:any) => {
          //   if (res.code == "200") {
          //     pageInfoRef.value.onRefresh();

          //     ElMessage({
          //       type: 'success',
          //       message: '复制成功',
          //     })
          //   } else
          //     ElMessage({
          //       type: 'info',
          //       message: '复制失败',
          //     })

          // })
        })
        .catch(() => {
          ElMessage({
            type: 'info',
            message: '网络错误',
          })
        })

    },
    delDic: (data: []) => {
      // 这里可以调用API获取数据列表
      console.log("获取数据列表");
      console.log(data);
    },
    addSearchField: (data: any) => {
      return {
        title: "搜索字段管理",
        // comp: MenuSearchList,
        width: "80%",
        height: "80%",
        pars: {
          menuId: data.id,
          type: 1,
        },
      };
    },
    addField: (data: any) => {
      return {
        title: "表头字段管理",
        width: "80%",
        height: "80%",
        comp: MenuFieldList,
        pars: {
          menuId: data.id,
          type: 2,
        },
      };
    },
    addToolsBtn: (data: any) => {
      return {
        comp: MenuButtonList,
        width: "80%",
        height: "80%",
        pars: {
          menuId: data.id,
          type: 1,
        },
      };
    },
    addTableBtn: (data: any) => {
      return {
        title: "表格按钮管理",
        width: "80%",
        height: "80%",
        comp: MenuButtonList,
        pars: {
          menuId: data.id,
          type: 2,
        },
      };
    },
  },
  maxBtn: 7
};
</script>
