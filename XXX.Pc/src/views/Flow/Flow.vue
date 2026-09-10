<template>
  <PageInfo :pageConfig="pageConfig" ref="pageInfoRef" />
</template>
<script setup lang="ts">
import PageInfo from "@/components/ListPage/PageInfo.vue";
import EditSys from "./EditSys.vue";
import SearchFieldList from "./SearchFieldList.vue";
import FieldList from "./FieldList.vue";
import ButtonList from "./ButtonList.vue";
import type { TempListPageConfig } from "@/components/ListPage";
import { ref } from "vue";
import { ElMessage, ElMessageBox } from "element-plus";
import { menuMirror } from "@/api/sys";
const pageInfoRef = ref();
const pageConfig: TempListPageConfig = {
  url: "sysmenu/tree/hierarchical",
  treeProps: {},
  wherePars: {},
  treeField:"label",
  customListPage: {
    search: [
      {
        label: "菜单名称",
        name: "label",
        type: 1,
        placeholder: "",
        icon: "",
        value: "",
        options: [],
        style: {},
      },
      {
        label: "是否通用",
        name: "currencyStatus",
        type: 2,
        placeholder: "",
        icon: "",
        value: "",
        options: [
          {
            label: "平台菜单",
            value: "1",
          },
          {
            label: "通用菜单",
            value: "2",
          },
        ],
        style: {},
      },
      {
        label: "适用终端",
        name: "typeId",
        type: 2,
        placeholder: "",
        icon: "",
        value: "",
        options: [
          {
            label: "PC端",
            value: "1",
          },
          {
            label: "H5端",
            value: "2",
          },
          {
            label: "pc顶部导航",
            value: "3",
          },
          {
            label: "App端",
            value: "4",
          },
          {
            label: "小程序端",
            value: "5",
          },
        ],
        style: {},
      },
    ],
    btns: [
      {
        name: "新增",
        type: "addDic",
        icon: "search",
        bgColor: "#28a745",
      },
      {
        name: "删除",
        type: "delDic",
        icon: "search",
        bgColor: "#FA5151",
      },
    ],
    fields: [
      {
        name: "label",
        label: "菜单名称",
        type: "text",
        width: "200",
        align: "left",
        fixed: "",
      },
      {
        name: "alias",
        label: "菜单简称",
        type: "text",
        width: "150",
        align: "center",
        fixed: "",
      },
      {
        name: "route",
        label: "地址",
        type: "text",
        width: "",
        align: "center",
        fixed: "",
      },
      {
        name: "rightTools",
        label: "功能操作",
        type: "rightTools",
        width: "580",
        align: "center",
        fixed: "right",
      },
    ],
    tableBtns: [
      {
        name: "修改",
        type: "editDic",
        icon: "search",
        bgColor: "#28a745",
      },
      {
        name: "搜索字段",
        type: "addSearchField",
        icon: "search",
        bgColor: "#1485EE",
      },
      {
        name: "表头字段",
        type: "addField",
        icon: "search",
        bgColor: "#8183FF",
      },
      {
        name: "工具栏按钮",
        type: "addToolsBtn",
        icon: "search",
        bgColor: "#FA9D3B",
      },
      {
        name: "表格按钮",
        type: "addTableBtn",
        icon: "search",
        bgColor: "#576B95",
      },
      {
        name: "菜单镜像",
        type: "menuMirror",
        icon: "search",
        bgColor: "#30656d",
      },
    ],
  },
  pageFun: {
    addDic: (data: any) => {
      console.log("新增菜单资源", data);
      return {
        title: "新增菜单资源",
        comp: EditSys,
        height: "70%",
        pars: {
          name: "1",
          date: "2023-10-01",
        },
      };
    },
    editDic: (data: any) => {
      console.log("编辑菜单资源", data);
      // 这里可以调用API获取数据列表
      return {
        title: "编辑菜单资源",
        comp: EditSys,
        pars: {
          id: data.id,
          date: "",
        },
      };
    }, menuMirror: (data: any) => {
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
          menuMirror(formData).then(res => {
            if (res.code == "200") {
              pageInfoRef.value.onRefresh();

              ElMessage({
                type: 'success',
                message: '复制成功',
              })
            } else
              ElMessage({
                type: 'info',
                message: '复制失败',
              })

          })
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
        comp: SearchFieldList,
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
        comp: FieldList,
        pars: {
          menuId: data.id,
          type: 2,
        },
      };
    },
    addToolsBtn: (data: any) => {
      return {
        comp: ButtonList,
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
        comp: ButtonList,
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
<style scoped></style>