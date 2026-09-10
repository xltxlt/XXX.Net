<script setup lang='ts'>
import { onMounted, ref, watch } from 'vue'
import DataList from '@/components/ListPage/DataList.vue'
import { ElMessage } from 'element-plus';
import type { TableFormField } from '.';
const emits = defineEmits(['update:data'])
const props = defineProps<{
    tableData?: any[],
    fields: TableFormField[],
    tableOptions?: Record<string, any[]>,
    emptyText?: string,
    hideAdd?: boolean,
    hideDel?: boolean
}>()
const pageConfig = {
    emptyText: props.emptyText,
    pageFun: {
        del: (row: any, scope: any) => {
            console.log(row.scope)
            deleteRow(scope.$index)
        }
    }
}
const deleteRow = (index: number) => {
    data.value.splice(index, 1)
}
const tableConfig = {
    tableBtns: props.hideDel != true ? [{
        name: "删除",
        type: "del",
        icon: "",
        bgColor: "#FA5151",
    }] : [],
    fields: props.hideDel != true ? [
        ...props.fields,
        {
            name: "rightTools",
            label: "功能操作",
            type: "rightTools",
            width: "150",
            align: "center",
            fixed: "right",
        },
    ] : props.fields,
    btns: [

    ]
};
const tableProps = {
    tableLayout: 'auto'
};
const data = ref<any[]>([{}])

watch(() => props.tableData, (newValue, oldValue) => {
    data.value = newValue ?? []
}, { deep: true })

onMounted(() => {
    data.value = props.tableData || [{}]
})

const onAddItem = () => {
    data.value.push({})
}
const getValues = () => {
    return data.value;
}
const resetValues = (value: any[]) => {
    data.value = value;
}
const verify = () => {
    const tableFormData = getValues()
    console.log(tableFormData)
    for (const m of props.fields) {
        if (m.must) {
            for (const item of tableFormData) {
                if (item[m.name] == undefined || item[m.name] == null || item[m.name] === '') {
                    ElMessage.error(m.label + '不能为空');
                    return false;
                }
            }
        }
    }
}
watch(() => data.value, () => {
    emits('update:data', data.value)
}, {
    immediate: true,
    deep: true
});
defineExpose({
    resetValues,
    getValues,
    verify
})
export type { TableFormField }
</script>
<template>
    <div class="table-form">
        <data-list :tableOptions="tableOptions" :open-dialog="() => { }" :table-props="tableProps"
            :changeRows="() => { }" :page-config="pageConfig" :data="data" :page-pars="tableConfig">
        </data-list>
        <el-button class="mt-4" v-if="hideAdd != true" style="margin-top:10px;width: 100%;height: 40px;color:#22A2FF"
            @click="onAddItem">
            新增
        </el-button>
    </div>

</template>
<style lang='less'>
.table-form {
    .el-table__row {
        .el-table__cell:last-child {
            border-right: var(--el-table-border);
        }
    }
}
</style>