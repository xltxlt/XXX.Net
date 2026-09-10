<script setup lang="ts">

import { ref } from 'vue'
import { ElMessage, ElMessageBox } from 'element-plus';
import PageInfo from '@/components/ListPage/PageInfo.vue'
import type { TempListPageConfig } from '@/components/ListPage'
import { addTemp, deleteTemp } from '@/api/temp';
import { handleSumbitResTip } from '@/utils/common';


const pageInfoRef = ref()
const pageConfig: TempListPageConfig =
{
    //数据列表来源地址
    url: '',
    //请求数据列表时 body中其他参数
    otherPars: {},
    //请求数据列表时where中其他参数
    wherePars: {},
    //注意当前参数 当api返回的字段没有这个时，需要更换为唯一值
    rowKey: 'id',
    //表格事件监听
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
    //工具栏和功能操作表格按钮事件
    pageFun: {
        //功能操作表格按钮事件
        tAdd: async (data: any) => {
            const res = await addTemp(data);
            handleSumbitResTip(res, '添加成功', () => {
                pageInfoRef.value && pageInfoRef.value.onRefresh();
            });
            return {
                title: '添加',
                comp: null,
                width: '80%',
                height: '80%',
                pars: {}
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