<template>
    <PageInfo ref="pageInfoRef" :pageConfig="pageConfig" />
</template>
<script setup lang="ts">
import { ref, computed } from 'vue'
import { ElMessage, ElMessageBox } from 'element-plus';
import PageInfo from '@/components/ListPage/PageInfo.vue'
import MatterForm from './Handle/MatterForm.vue';
import CustomMatterEdit from './Handle/CustomMatterEdit.vue';
import type { TempListPageConfig } from '@/components/ListPage'
import { delMatterTemp } from '@/api/common/matter';
import { handleSumbitResBox } from '@/utils/common';
const pageInfoRef = ref()
const pageConfig: TempListPageConfig =
{
    url: '/auth-center/api/matter/manage/list',
    treeProps: {},
    wherePars: {},
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
        matterForm:(data:any)=>{
             return {
                title: '事项表单',
                comp: MatterForm,
                width: '100%',
                height: '100%',
                class:'matter-form-dialog',
                pars: {
                    id:data.id??''
                }
            }
        },
        edit: (data: any) => {
            return {
                title: '添加',
                comp: CustomMatterEdit,
                width: '80%',
                height: '80%',
                pars: {
                    id:data.id
                }
            }
        },
        add: (data: any) => {
            return {
                title: '添加',
                comp: CustomMatterEdit,
                width: '80%',
                height: '80%',
                pars: {}
            }
        },
        form: (data: any) => {
            return {
                title: '事项表单',
                comp: MatterForm,
                width: '100%',
                height: '100%',
                class:'matter-form-dialog',
                pars: {
                    
                }
            }
        },
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
        },
        del:(data:any)=>{
            ElMessageBox.confirm('此操作将永久删除该记录, 是否继续?', '提示', {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning',
            }).then(async() => { 
                const res= await delMatterTemp(data.id);
                handleSumbitResBox(res, '删除成功', () => {
                    pageInfoRef.value&&pageInfoRef.value.onRefresh();
                });
            });
        }

    }
} 
</script>
<style type="less">
.matter-form-dialog.el-dialog{
    .el-dialog__body{
        padding: 0;
        width: 100%;
        height: calc(100% - 36px);
    }
}
</style>