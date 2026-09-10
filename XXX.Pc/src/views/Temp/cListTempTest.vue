<script setup lang="ts">
import PageInfo from '@/components/ListPage/PageInfo.vue'
import type { TempListPageConfig } from '@/components/ListPage'
import { ElMessage, ElMessageBox } from 'element-plus';
import { ref } from 'vue'
import { deleteTemp } from '@/api/temp';
import { handleSumbitResTip } from '@/utils/common';

const pageInfoRef = ref();
const pageConfig: TempListPageConfig = {
    url: '',
    //注意当前参数 当api返回的字段没有这个时，需要更换为唯一值
    rowKey: 'id',
    //请求数据列表时 body中其他参数
    otherPars: {},
    //请求数据列表时where中其他参数
    wherePars: {},
    //自定义页面参数
    customListPage: {
        //配置搜索栏
        'search': [
            { 'label': '测试文本', 'name': 'text', 'type': 1, 'placeholder': '', 'icon': '', 'value': '', 'options': [], 'style': {} },
        ],
        //配置工具栏按钮
        'btns': [
            { 'name': '新增', 'type': 'add', 'icon': '', 'bgColor': '#28a745' },
        ],
        //配置表头字段
        'fields': [
            { 'name': 'testText', 'label': '测试文本', 'type': 'text', 'width': '300', 'align': 'center', 'fixed': '' },
            { 'name': 'auditStatusDesc', 'label': '审核状态', 'type': 'text', 'width': '260', 'templet': 'auditStatus', 'align': 'center', 'fixed': '' },
            { 'name': 'rightTools', 'label': '功能操作', 'type': 'text', 'width': '300', 'templet': 'rightTools', 'align': 'center', 'fixed': '' },
        ],
        //配置表格按钮
        'tableBtns': [
            { 'name': '查看', 'type': 'tAdd', 'icon': 'search', 'bgColor': '#07C160' },
        ]
    },
    //表格字段事件监听
    tableOn:
    {
        cellClick: (row: any, column: any, cell: HTMLTableCellElement) => {
            const filedName = column.property;
            if (filedName == 'celltap') {
                pageInfoRef.value.openDialog({
                    title: `（${row.title}）`,
                    comp: null,
                    pars: { id: row.id },
                    width: '80%',
                    height: '80%',
                    refreshList: true
                })
            }
        }
    },
    pageFun: {
        //功能操作表格按钮事件
        tAdd: (data: any) => {
            return {
                title: '添加',
                // 组件
                comp: null,
                width: '80%',
                height: '80%',
                //向组件传参
                pars: {},
                //关闭组件后是否自动刷新列表
                refreshList: true
            }
        },
        //工具按钮多选
        dels: (data: any[]) => {
            const ids = data.map(item => item.id);
            if (ids.length == 0) {
                ElMessage({ type: 'info', message: '请选择', });
                return;
            }
            if (ids.length != 1) {
                ElMessage({ type: 'info', message: '只能选择一条记录', });
                return;
            }
            ElMessageBox.confirm('确定要删除吗？', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning',
            }).then(async () => {
                const res = await deleteTemp(ids);
                handleSumbitResTip(res, '删除成功', () => {
                    pageInfoRef.value && pageInfoRef.value.onRefresh();
                });
            })
        },
    }
} 
</script>
<template>
    <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
</template>
<style scoped></style>