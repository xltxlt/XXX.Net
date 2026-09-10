<template>
    <div class="field-list-page">
        <TableForm :fields="fields"></TableForm>
    </div>
</template>
<script setup lang="ts">
import { ref } from "vue";
import TableForm from "@/components/business/TableForm/TableForm.vue";
const fields= [
    {
        label: "字段名称",
        name: 'name',
        width: '120',
        type: "input",
        must:true,
    }, {
        label: "显示名称",
        name: "label",
        width: '120',
        type: "input"
    },
    {
        label: "关联字段",
        name: "fieldName",
        width: '120',
        type: "input"


    },

    {
        label: "关联事件",
        name: "eventName",
        width: '120',
        type: "input"


    },

    {
        label: "宽度",
        name: 'width',
        width: '120',
        type: "input"


    },
    {
        label: "搜索类型",
        name: 'inputType',
        width: '120',
        type: "select"


    },
    {
        label: "浮动类型",
        name: 'floatType',
        width: '120',
        type: "select"


    },
    {
        label: "合计行",
        name: 'fotalRow',
        width: '120',
        type: "switch"


    },
    {
        label: "初始隐藏",
        name: 'initHide',
        width: '120',
        type: "switch"


    },
    {
        label: "对齐方式",
        name: 'alignType',
        width: '120',
        type: "select"


    },


    {
        label: "应用搜索",
        name: 'searchField',
        width: '120',
        type: "switch"

    },
    {
        label: "数据源类型",
        name: 'dataSourceType',
        width: '140',
        type: "select"


    },
    {
        label: "数据源配置值",
        name: 'DataSourceValue',
        width: '140',
        type: "input"


    },
    {
        label: "数据源参数",
        name: 'dataSourcePars',
        width: '140',
        type: "input"


    },

    {
        label: "自定义模板",
        name: 'template',
        width: '140',
        type: "input"


    },
    {
        label: "排序",
        name: 'sort',
        width: '120',
        type: "input"

    },
    {
        label: '状态',
        name: 'enabled',
        width: '120',
        type: "switch"


    }, {
        label: '是否通用',
        name: 'general',
        width: '120',
        type: "switch"


    }, {
        label: "说明",
        name: 'description',
        width: '120',
        type: "input"

    },
];
</script>
<style scoped>
.field-list-page {
    padding-top: 10px;
    height: calc(100% - 25px);
}
</style>
