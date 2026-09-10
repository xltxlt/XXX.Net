<template>
    <el-table v-if="refreshTable" ref="tableRef" @selection-change="handleSelectChange" :summary-method="getSummaries"
        :show-summary="showSummary" :tree-props="props.pageConfig?.treeProps ?? {}"
        :row-key="props.pageConfig?.rowKey ?? 'id'" :data="data" style="width: 100%" border class="page-table"
        :default-expand-all="expandAllColumn"
        @cell-click="(row: any, column: any, cell: HTMLTableCellElement, event: Event) => handleCellBtnClick(row, column, cell, event)"
        v-bind="props.tableProps ?? {}" v-on="props.tableOn ?? {}" :empty-text="props.pageConfig.emptyText ?? '暂无数据'">
        <el-table-column type="selection" width="55" :selectable="(row: any) => {
            if (row.isCancelSelect == undefined) return true;
            return row.isCancelSelect
        }" align="center" :fixed="'left'" />
        <template v-for='m in pagePars.fields'>
            <el-table-column v-if="m.template == 'index'" type="index" :index="(index: number) => { return index + 1 }"
                :class-name="m.must === true ? 'el-table-column-must' : ''"
                :fixed="(!m.floatType || m.floatType == 0) ? false : (m.floatType == 1 ? 'left' : 'right')"
                :show-overflow-tooltip="props.pageConfig.showTooltip !== false" :label="m.label" :property="m.fieldName"
                :width="m.width" :align="(m.alignType == 1 ? 'left' : (m.alignType == 2 ? 'right' : 'center'))"
                v-bind='m.props || {}'>
            </el-table-column>
            <template v-else>

                <el-table-column :sortable="m.fieldType != FieldType.RightTools" :class-name="m.must === true ? 'el-table-column-must' : ''
                    " :fixed="(!m.floatType || m.floatType == 0) ? false : (m.floatType == 1 ? 'left' : 'right')"
                    :show-overflow-tooltip="props.pageConfig.showTooltip !== false" :label="m.label"
                    :property="m.fieldName" :width="m.width"
                    :align="(m.alignType == 1 ? 'left' : (m.alignType == 2 ? 'right' : 'center'))"
                    v-bind='m.props || {}' #default="{ row, scope }">
                    <template v-if="m.fieldName == (props.pageConfig?.treeField ?? 'name')">
                        <span class="tree-flex"
                            :class="{ 'tree-flex--has-children': row.children && row.children.length > 0 }">
                            {{ row[(props.pageConfig?.treeField ?? 'name')] }}
                        </span>
                    </template>

                    <template v-else-if="m.fieldType == FieldType.Decimal">
                        <el-input v-model="row[m.fieldName]" style="width: 100%" placeholder="请输入" />
                    </template>

                    <template v-else-if="m.fieldType == FieldType.Number">
                        <el-input v-model="row[m.fieldName]" :type="'number'" style="width: 100%" placeholder="请输入" />
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Decimal">
                        <el-input-number v-model="row[m.fieldName]" :precision="2" :step="0.1" style="width: 100%"
                            placeholder="请输入" />
                    </template>
                    <template v-else-if="m.fieldType == FieldType.OneSelect">
                        <el-select placeholder="请选择" @change="(val: any) => {
                            row[m.fieldName] = tableOptions[m.fieldName ?? ''].filter((m: any) => m.value == val).map((m: any) => m.label).join()

                        }" style="width: 100%" v-model="row[m.fieldName]" v-bind="m?.comProps ?? {}"
                            v-on="m?.comOn ?? {}">
                            <el-option v-for="item in tableOptions[m.fieldName ?? '']" :key="item.value"
                                :label="item.label" :value="item.value" />
                        </el-select>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.TreeSelect">
                        <el-cascader v-model="row[m.fieldName]" style="flex:1;width: 100%;" suffix-icon="CaretBottom"
                            :options="tableOptions[m.fieldName ?? '']"
                            :placeholder="m?.placeholder ?? '请选择' + (m?.label ?? '')" v-bind="m?.comProps ?? {}"
                            v-on="m?.comOn ?? {}" />
                    </template>
                    <template v-else-if="m.fieldType == FieldType.DateSelect">
                        <el-date-picker :format="'YYYY-MM-DD'" :value-format="'YYYY-MM-DD'" v-model="row[m.fieldName]"
                            type="date" placeholder="请选择" />
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Custom">
                        <slot name="custom" :row="row" :scope="scope" :item="m">
                        </slot>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Look">
                        <div style="color:#1485EE ;cursor: pointer;">
                            {{ row[m.fieldName] }}
                        </div>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.AuditStatus">
                        <el-button type="primary" size="small" style="color:#fff"
                            :color="getAuditColorByVal(row[m.fieldName])">
                            {{ row[m.fieldName] }}
                        </el-button>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.ColorBtn">
                        <el-button type="primary" size="small" style="color:#fff"
                            :color="getColorByVal(row[m.fieldName])">
                            {{ getLabel(row, m.fieldName ?? "") }}
                        </el-button>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.ColorText">
                        <span :style="{ color: getColorByVal(row[m.fieldName]) }">
                            {{ getLabel(row, m.fieldName ?? "") }}
                        </span>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.AuditText">
                        <span :style="{ color: getAuditColorByVal(row[m.fieldName]) }">
                            {{ getLabel(row, m.fieldName ?? "") }}
                        </span>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.StatusColor">
                        <span :style="{ color: getStatusColorByVal(row[m.fieldName]) }">
                            {{ getLabel(row, m.fieldName ?? "") }}
                        </span>
                    </template>

                    <template v-else-if="m.fieldType == FieldType.Switch">
                        <el-switch :model-value="row[m.fieldName] === 1"></el-switch>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Table">
                        <el-popover placement="right" :width="Object.keys(row[m.fieldName][0]).join().length * 10 + 150"
                            trigger="click">
                            <template #reference>
                                <el-button link type="primary">点击查看</el-button>
                            </template>
                            <el-table :data="row[m.fieldName]">
                                <el-table-column :width="30 + key.length * 10" :property="key" :label="key"
                                    v-for="key in Object.keys(row[m.fieldName][0])" :key="key" />
                            </el-table>
                        </el-popover>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Img">
                        <el-button link type="primary" @click.stop="() => imgPreview(row[m.fieldName])">点击查看</el-button>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.File">
                        <el-button link type="primary" @click.stop="() => fileDown(row[m.fieldName])">点击查看</el-button>
                    </template>
                    <template v-else-if="m.fieldType == FieldType.Tip">
                        <el-popover effect="light" trigger="hover" placement="top" width="auto">
                            <template #default>
                                {{ scope.row.name }}
                            </template>
                            <template #reference>
                                <el-tag>{{ scope.row.name }}</el-tag>
                            </template>
                        </el-popover>
                    </template>
                    <template v-else-if="m.fieldName == 'rightTools' || m.fieldType == FieldType.RightTools">

                        <div ref="btnWrap"
                            style="display: flex; flex-wrap: wrap; gap: 4px;justify-content: space-around;">
                            <el-button
                                v-for="(item, idx) in setRowTableBtns(pagePars.tableBtns, scope).slice(0, props.maxBtn)"
                                :key="item.type" type="primary" style="color:#ffffff;margin-left: 0px;"
                                :color="item.bgColor || '#28a745'" size="small"
                                @click="handleTableBtnClick(item.eventName, row, scope)">
                                {{ item.label }}
                            </el-button>
                            <el-dropdown v-if="setRowTableBtns(pagePars.tableBtns, scope).length > props.maxBtn"
                                trigger="click">
                                <el-button type="primary" size="small"
                                    style="color:#fff;background:#666;border:none;margin-left: 0px;">更多</el-button>
                                <template #dropdown>
                                    <el-dropdown-menu>
                                        <el-dropdown-item
                                            v-for="item in setRowTableBtns(pagePars.tableBtns, scope).slice(props.maxBtn)"
                                            :key="item.type"
                                            @click="handleTableBtnClick(item.eventName, scope.row, scope)">
                                            {{ item.label }}
                                        </el-dropdown-item>
                                    </el-dropdown-menu>
                                </template>
                            </el-dropdown>
                        </div>
                    </template>

                    <template v-else-if="!!m.template">
                        <slot name="cell" :scope="scope"></slot>
                    </template>
                    <template v-else>
                        {{ getLabel(row, m.fieldName ?? "") }}
                    </template>
                </el-table-column>
            </template>
        </template>

    </el-table>
    <el-image-viewer v-if="viewerVisible" :url-list="previewUrl" @close="viewerVisible = false" />
</template>
<script setup lang="ts">
import { ref, watch, computed, nextTick, h } from 'vue'
import type { TableColumnCtx } from 'element-plus'
import type { VNode } from 'vue'
import type { PagedOptions, SysMenuTableButtonDto, SysMenuTableFieldDto } from '@/api-services/generated'
import { FieldType, type TableField } from '.'
interface SummaryMethodProps<T = any> {
    columns: TableColumnCtx<any>[]
    data: T[]
}

const handleSwitchChange = (value: boolean, row: any, fieldName: string) => {
    row[fieldName] = value ? 1 : 0;
};
const viewerVisible = ref(false)
const previewUrl = ref<string[]>([])
const showSummary = ref(true)
const imgPreview = async (url: string | Array<string>, isOss: boolean = false) => {
    previewUrl.value = [];
    if (Array.isArray(url)) {
        previewUrl.value = url;
    } else {
        previewUrl.value = [url];
    }
    viewerVisible.value = true
}
const getLabel = (row: any, fieldName: string) => {
    var val = row[fieldName];
    var option = props.options?.[fieldName];
    if (option == undefined || option.length == 0) return val;
    if (val == 0 && fieldName.indexOf('Id') > -1) {
        return '无'
    }
    if (typeof (val) == 'object' && val != null) {
        return option?.filter(m => val.includes(m.value)).map(m => m.label).join(',')
    }
    else {
        var label = option?.find((m: any) => m.value == val)?.label
        return label || val;
    }
}
const fileDown = async (url: string, isOss: boolean = false) => {
    // perviewFile(url)
}
const tableRef = ref()
const props = withDefaults(defineProps<{
    pageConfig: any;
    openDialog: (config: any) => void;
    changeRows: (rows: any[]) => void;
    pagePars: {
        fields: TableField[];
        tableBtns: SysMenuTableButtonDto[];
    };
    tableProps?: any;
    tableOn?: any;
    data: any;
    options?: Record<string, PagedOptions[]>,
    maxBtn?: number;
    tableOptions?: Record<string, any[]>;
}>(), {
    tableOptions: () => ({}),
    maxBtn: 5
})
const expandAllColumn = ref(false);
const refreshTable = ref(true);

const getSummaries = (param: SummaryMethodProps) => {
    const { columns, data } = param
    const sums: (string | VNode)[] = []
    if (!(!!props.pagePars.fields &&
        (props.pagePars.fields.filter((m: any) =>
            m.totalRow == 1

        ).length > 0))) {
        showSummary.value = false
        return sums;
    }

    columns.forEach((column, index) => {
        // 添加安全检查
        if (!props.pagePars?.fields) return;

        const field = props.pagePars.fields.filter((m: any) => m.name == column.property).pop();

        if (index === 0) {
            sums[index] = h('div', { style: {} }, [
                '合计',
            ])
            return
        }

        // 添加字段存在性检查
        if (!field || field.totalRow) {
            sums[index] = '';
            return;
        }

        // 你的合计逻辑
        const values = data.map((item) => Number(item[column.property]))
        if (!values.every((value) => Number.isNaN(value))) {
            sums[index] = `${values.reduce((prev, curr) => {
                const value = Number(curr)
                if (!Number.isNaN(value)) {
                    return prev + curr
                } else {
                    return prev
                }
            }, 0)}`
        } else {
            sums[index] = ''
        }
    })
    return sums;
}
const showBtnCount = (rightToolsWidth: string) => {
    const width = Number(rightToolsWidth.toLowerCase().replace('px', ''));
    const btnsCount = props.pagePars.tableBtns.length;
    const sizeCount = props.pagePars.tableBtns.map((m: any) => {
        return m.name;
    }).join('').length
    let btnCount = 0;
    let thisWidth = 0;
    props.pagePars.tableBtns.forEach((m: any, i: number) => {
        thisWidth += 30 + m.name.length * 12;
        if (thisWidth >= width) { }
        else btnCount += 1;
    })
    if (btnCount != btnsCount && thisWidth + 24 >= width) {
        btnCount = btnCount - 1;
    }
    return btnCount > 0 ? btnCount : 0;
};

const selectedRows = ref<any[]>([])
const handleSelectChange = (rows: any[]) => {
    selectedRows.value = rows;
    props.changeRows(rows);
}

watch(() => props.data, (nVal: any[], oVal: any[]) => {
    if (props.pageConfig.defChecked) {
        console.log('data change', nVal)
        nextTick(() => {
            exposeFuns.setDefChecked(nVal, exposeFuns.toggleRowSelection)
            props.pageConfig.defChecked = false;
        })
    }

}, {
    deep: true,

})
// 判断某行是否展开
const isRowExpanded = (row: any) => {
    if (!tableRef.value) return false
    // 获取所有已展开行的 row-key 数组
    const treeData = tableRef.value.store.states.treeData.value
    const rowKey = props.pageConfig?.rowKey ?? 'id'
    // treeData[row[rowKey]]?.expanded 为 true 时表示已展开
    return !!treeData[row[rowKey]]?.expanded
}
// 手动收缩某一行
const collapseRo = (row: any) => {
    if (tableRef.value) {
        tableRef.value.toggleRowExpansion(row)
    }
}
const handleTableBtnClick = (eventName: string, row: any, scope: any) => {
    const fun = props.pageConfig.pageFun['' + eventName];
    if (typeof fun != 'function') {
        // 如果是函数，则调用
        return;
    }
    const config = fun(row, scope);
    props.openDialog(config);
}
const handleCellBtnClick = (row: any, column: any, cell: HTMLTableCellElement, event: Event) => {
    const fun = props.pageConfig.pageFun['' + column.funName];
    if (typeof fun != 'function') {
        // 如果是函数，则调用
        return;
    }
    const config = fun({
        row,
        column,
        cell,
        event
    });
    if (config != null && config) {
        props.openDialog(config);
    }
}
const getColorByVal = (val: string | number) => {
    try {
        const index = Number(val)
        const colorVar = `--btn-color-${index}`;
        const color = getComputedStyle(document.documentElement).getPropertyValue(colorVar).trim();
        return color || '#409EFF';
    }
    catch {
    }
    return '#409EFF';
}
const getStatusColorByVal = (val: string | number) => {
    try {
        if (val == undefined) return '';
        const index = Number(val)
        const colorVar = `--status-color-${index}`;
        const color = getComputedStyle(document.documentElement).getPropertyValue(colorVar).trim();
        return color || '#409EFF';
    }
    catch {
    }
    return '#409EFF';
}
const getLockColorByVal = (val: string | number) => {
    try {
        if (val == undefined) return '';
        const index = Number(val)
        const colorVar = `--lock-color-${index}`;
        const color = getComputedStyle(document.documentElement).getPropertyValue(colorVar).trim();
        return color || '#409EFF';
    }
    catch {
    }
    return '#409EFF';
}

const getAuditColorByVal = (val: string | number) => {
    try {
        const index = Number(val)
        const colorVar = `--audit-color-${index}`;
        const color = getComputedStyle(document.documentElement).getPropertyValue(colorVar).trim();
        return color || '#1485EE';
    }
    catch {
    }
    return '#1485EE';
}

const setRowTableBtns = (tableBtns: SysMenuTableButtonDto[], scope: any, cb?: Function): any[] => {
    if (!props.pageConfig?.setRowTableBtns) return tableBtns;
    else return props.pageConfig?.setRowTableBtns(tableBtns, scope);
}
const exposeFuns = {
    setDefChecked: (selections: any[], handleFun: Function) => {
        selections.forEach((item: any) => {
            if (item.checked == 1) {
                handleFun(item, true);
            }
            else{
                handleFun(item, false);
            }
            if (item.children && item.children.length > 0) {
                exposeFuns.setDefChecked(item.children, handleFun)
            }
        })
    },
    expandAll: (checked: boolean) => {
        // 设置默认展开状态
        expandAllColumn.value = checked;

        // 重新渲染表格以应用 default-expand-all 属性
        refreshTable.value = false;
        nextTick(() => {
            refreshTable.value = true;
        });
    },
    getSelectionRows: () => {
        return tableRef.value.getSelectionRows();
    },
    toggleRowSelection: (row: any, selected?: boolean) => {
        nextTick(() => {
            try {
                tableRef.value.toggleRowSelection(row, selected);

            } catch (error) {
                console.error('Error calling toggleRowSelection:', error);
            }
        });
        // return tableRef.value.toggleRowSelection(row, selected);
    },
    toggleRowExpansion: (row: any, expanded?: boolean) => {
        nextTick(() => {
            try {
                tableRef.value.toggleRowExpansion(row, expanded);
            } catch (error) {
                console.error('Error calling toggleRowExpansion:', error);
            }
        });
    }

}
defineExpose({
    expandAll: exposeFuns.expandAll,
    getSelectionRows: exposeFuns.getSelectionRows,
    toggleRowSelection: exposeFuns.toggleRowSelection,
    toggleRowExpansion: exposeFuns.toggleRowExpansion,

})
</script>
<style>
.page-table.el-table--border:after {
    content: none;
}

.page-table {
    height: 100%;
    --el-table-header-bg-color: #f2f2f2;

    .el-table__cell {
        padding: 5px 0;
        font-weight: 400;

    }

    th.el-table-column-must {
        .cell::after {
            content: "*";
            color: red;
        }
    }

    .el-checkbox__inner {
        width: 18px;
        height: 18px;

        &::after {
            top: 2px;
            left: 5px;
            height: 8px;
            width: 5px;
        }
    }

    .el-checkbox__input.is-checked .el-checkbox__inner:after {
        background-color: #1E9FFF;
    }

    .el-button--small {
        --el-button-size: 22px;
        padding: 4px 11px;
    }

    .el-table--border:after,
    .el-table--border:before {
        content: none;
    }

    .el-table__border-left-patch {
        content: none;
    }

    .el-table__row .el-table__cell:last-child {
        border-right: none;
    }

    .el-table__row .el-table__cell:first-child {
        border-left: none;
    }

}

.data-list-div {
    .tree-flex {
        display: inline-flex;
        align-items: center;
        gap: 6px;
    }

    .tree-toggle-icon {
        pointer-events: auto;
        cursor: pointer;
        flex-shrink: 0;
    }
}
</style>