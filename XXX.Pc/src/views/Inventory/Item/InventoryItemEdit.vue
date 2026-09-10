<script setup lang='ts'>

import PageForm from '@/components/PageForm/PageForm.vue';
import { computed, onMounted, ref } from 'vue';
import { ElMessage } from 'element-plus';
import { inventoryAttributeDefinitionService, inventoryItemService } from "@/api/inventory.ts";

import {
    type TempEditForm,
    type TempEditPageData,
    PageFormGroup,
    PageFormType
} from '@/components/PageForm';
import { ConditionalType } from '@/components/ListPage';
import { isEmptyVal } from '@/utils/is';


const { pars } = defineProps<{
    pars?: Record<string, any>
}>();

const emit = defineEmits([
    'closeDialog',
    'refreshList'
]);
const attrForm = ref<TempEditForm[]>([]);
const hideAttr = computed(() => {
    return !(attrForm.value && attrForm.value.length > 0);
});
const baseRules = {
    name: [
        { required: true, message: '请输入名称', trigger: 'blur' },
    ],

    inventoryTypeId: [
        { required: true, message: '请选择所属库存域', trigger: 'blur' },
    ],
    code: [
        { required: true, message: '请输入编码', trigger: 'blur' },
    ],
    unit: [
        { required: true, message: '请输入单位', trigger: 'blur' },
    ],
    enabled: [
        { required: true, message: '请输入状态', trigger: 'blur' },
    ],
};
const tempForm = ref<TempEditPageData>({
    loading: false,
    hideBtn: pars?.lock == 'lock' ? true : false,
    cols: 2,
    form: [
        {
            formType: PageFormGroup.Group,
            fieldName: '',
            label: "基本信息",
            child: [


                {
                    formType: PageFormType.OneSelectSearch,
                    label: "物品类型",
                    fieldName: "inventoryTypeId",
                    comOn: {
                        change: async (val: any) => {
                            if (!val) {
                                return;
                            }
                            await getItemType(val);
                        }
                    }
                },
                {
                    formType: PageFormType.Input,
                    label: "名称",
                    fieldName: "name"
                },
                {
                    formType: PageFormType.Input,
                    label: "编码",
                    fieldName: "code"
                },
                {
                    formType: PageFormType.Input,
                    label: "单位",
                    fieldName: "unit"
                },
                {
                    formType: PageFormType.Radio,
                    label: "状态",
                    fieldName: "enabled"
                },
            ]
        },
        {
            formType: PageFormGroup.Group,
            fieldName: '',
            label: "属性信息",
            hide: hideAttr.value,
            child: attrForm.value
        }

    ],

    rules: {
        ...baseRules
    },

    formData: {
        id: pars?.id ?? null,
        enabled: 1
    },

    options: {
    },
});

onMounted(async () => {
    inventoryItemService.apiInventoryItemDetailoptionGet(pars?.id)
        .then(async (res) => {

            tempForm.value.options = Object.assign(
                tempForm.value.options,
                res.data.data?.options ?? {}
            );
            var attrs =JSON.parse(res.data.data?.detail?.attributesJson??'') ;
            var attrForm:Record<string, any> = {};
            for (const key in attrs) {
                 attrForm['attrJson:'+key]=attrs[key];
            }
            tempForm.value.formData =
                Object.assign(
                    tempForm.value.formData,
                    res.data.data?.detail ?? {}
                    ,attrForm
                );
            await getItemType(tempForm.value.formData.inventoryTypeId ?? '');
        });
});



const sumbit = () => {

    const formData = {
        ...tempForm.value.formData
    };
    var attrs: Record<string, any>={}
    for (const key in formData) {
       if(key.indexOf("attrJson:")==0){
            attrs[key.replace('attrJson:','')] = formData[key];
       }
    }
    formData.attributesJson =JSON.stringify(attrs) ;
    if (
        Array.isArray(formData.classList) &&
        formData.classList.length > 0
    ) {
        formData.parentId =
            formData.classList[
            formData.classList.length - 1
            ];
    }

    formData.classLayer =
        formData.classList?.length ?? 0;


    inventoryItemService.apiInventoryItemAddorupdatePost(formData)
        .then((res) => {

            if (res.data.statusCode != 200) {

                ElMessage({
                    message: '操作失败',
                    type: 'error',
                    plain: true,
                });

                return;
            }

            ElMessage({
                message: '操作成功',
                type: 'success',
                plain: true,
            });

            emit('closeDialog');
            emit('refreshList');
        })
        .finally(() => {
        });


};
const getItemType = async (inventoryTypeId: string) => {
    if (isEmptyVal(inventoryTypeId)) {
        attrForm.value = [];
        return;
    }
    const res = await inventoryAttributeDefinitionService.apiInventoryAttributeDefinitionListPost({
        customWhere: [
            {
                filedName: "inventoryTypeId",
                conditionalType: ConditionalType.Equal,
                filedValue: inventoryTypeId
            }
        ]
    });
    if (res.data.statusCode != 200) return;
    var rules: Record<string, any> = {};
    attrForm.value = res.data.data?.map(item => {
        if (item.required) rules['attrJson:'+ (item.code ?? '')] = [
            { required: true, message: item.name + '不能为空', trigger: 'blur' },
        ];
        return {
            formType: PageFormType.Input,
            label: item.name,
            fieldName:'attrJson:'+ item.code,
            must: item.required
        } as TempEditForm;
    }) || [];
    tempForm.value.form[1].child = attrForm.value;
    tempForm.value.form[1].hide = hideAttr.value;
    tempForm.value.rules = {
        ...baseRules,
        ...rules
    };
}

onMounted(async () => {

});

</script>

<template>

    <div class="edit-page">

        <page-form :temp-form="tempForm" @on-submit="sumbit">
        </page-form>

    </div>

</template>

<style lang='less' scoped>
.edit-page {
    height: 100%;
    overflow-y: scroll;
}
</style>
