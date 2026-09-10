<template>
    <PageInfo :pageConfig="pageConfig" />
</template>
<script setup lang="ts">
import PageInfo from '@/components/ListPage/PageInfo.vue'
import EditDic from '@/views/DataDic/EditDic.vue'

const pageConfig = {
    url: '/api/dataDic',
    wherePars: {
        'type_custom':"1"
    },
    pageFun: {
        addDic: (data:any) => {
            console.log('新增数据字典', data)
            return {
                title: '新增数据字典',
                comp: EditDic,
                form: {
                    name: '1',
                    date: '2023-10-01'
                }
            }
        },
        editDic: (data: any) => {
            console.log('编辑数据字典', data)
            // 这里可以调用API获取数据列表
            return {
                title: '新增数据字典',
                comp: EditDic,
                form: {
                    name: '',
                    date: ''
                }
            }
        },
        delDic: (data: []) => {
            // 这里可以调用API获取数据列表
            console.log('获取数据列表')
        },
    }

}
</script>
<style scoped></style>