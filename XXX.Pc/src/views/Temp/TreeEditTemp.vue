<script setup lang='ts'>
import { ref, onMounted } from 'vue';
import PageForm from '@/components/PageForm/PageForm.vue';
import type { TempEditPageData } from '@/components/PageForm'
import { handleSumbitResBox } from '@/utils/common';

import { getTempPageInfo, getTempPageOptions } from '@/api/temp';
import { sumbitSys } from '@/api/sys';

//用来获取父级页面传参
const { pars } = defineProps<{ pars?: Record<string, any> }>()
//用于抛出事件
const emit = defineEmits(['closeDialog', 'refreshList'])
const tempForm = ref<TempEditPageData>({
    loading: false,
    form: [
        {
            type: "input",
            title: "名称",
            name: 'title'
        },
        {
            type: 'treeSelect',
            title: '所属层级',
            name: 'classList',
            comProps: {
                filterable: true,
                props: {
                    clearable: true,
                    checkStrictly: true,
                }
            }
        },
        {
            type: 'radio',
            title: "是否为页面",
            name: 'isPage',
        },
        {
            type: 'textarea',
            title: "备注",
            name: 'remark',
        }],
    rules: {
        title: [{ required: true, message: '请填写名称' },],
        isPage: [{ required: true }],
    },
    formData: {
        id: pars?.id ?? null,
        classList: [],
        isPage: 0,
    },
    options: {
        isPage: [{
            label: '是',
            value: 1
        }, {
            label: '否',
            value: 0
        }],
    },

})
onMounted(async () => {
    //获取下拉数据
    const optionsData = await getTempPageOptions();
    tempForm.value.options['classList'] = optionsData['classList'] ?? [];

    //获取页面渲染数据
    if (!pars?.id) return;
    const pageInfo = await getTempPageInfo(pars?.id ?? '');
    pageInfo && (tempForm.value.formData = pageInfo.data);
})

//提交数据
const sumbit = () => {
    const formData = { ...tempForm.value.formData };
    if (Array.isArray(formData.classList) && formData.classList?.length > 0) {
        formData.parentId = formData.classList[formData.classList.length - 1]
    }
    formData.classLayer = formData.classList?.length ?? 0;

    //注意替换成自己的方法 这个方法包含 编辑和新增 
    //后台api通过id是否存在来判断 
    sumbitSys(formData).then((res) => {
        handleSumbitResBox(res, formData.id ? '修改成功' : '新增成功', () => {
            //成功后关闭弹窗
            emit('closeDialog');
            //刷新列表
            emit('refreshList');
        })
    }).finally(() => {
    })
}
</script>
<template>
    <div class="edit-temp-page">
        <page-form :temp-form="tempForm" @on-submit="sumbit">
        </page-form>
    </div>
</template>
<style lang='less' scoped>
.edit-temp-page {
    height: 100%;
}
</style>