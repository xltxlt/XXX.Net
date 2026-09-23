<template>
    <PageForm ref="pageFormRef" :temp-form="tempForm" @on-submit="() => {
        emits('onSubmit', tempForm);
    }">

    </PageForm>
</template>
<script lang="ts" setup>
import { computed, ref, watch, type PropType, type Ref } from 'vue';
import type { componentAttrData, componentForm, ReleaseData } from './enhancedIndex';
import { PageFormGroup, PageFormType, type TempEditPageData, type TempFormItemOption, type TempFormRules, type TempFormTreeOption } from '.';
import PageForm from './PageForm.vue';
import type { FormInstance, FormItemRule } from 'element-plus';
import type { BaseDataSource, PagedOptions } from '@/api-services/generated/index.ts';
import axios from 'axios';
import { optionService } from '@/api/index.ts';
import { isNullOrUnDef } from '@/utils/is.ts';
const pageFormRef = ref();
const props = defineProps({
    hideBtn: {
        type: Boolean,
        required: true
    },
    cols: {
        type: Number,
        required: true
    },
    form: {
        type: Array as PropType<componentForm[]>,
        required: true
    },
    attrData: {
        type: Object as PropType<Record<string, componentAttrData[]>>,
        required: true
    }
})
const tempForm = ref<TempEditPageData>({
    hideBtn: props.hideBtn === true,
    loading: false,
    cols: props?.cols ?? 2,
    form: [
    ],
    rules: {
    },
    formData: {
    },
    options: {
    },
});

const pageFun = {
    initTempForm: async (data: ReleaseData) => {
        if (isNullOrUnDef(data)) {
            return;
        }
        var forms = data.form;
        var attrData = data.attrData;
        tempForm.value.form = await pageFun.setForm(forms, attrData);
        tempForm.value.rules = await pageFun.setRules(forms, attrData);
        tempForm.value.options = await pageFun.setOptions(forms, attrData) || {};
        tempForm.value.formData = await pageFun.setFormData(forms, attrData);
    },
    setForm: async (forms: componentForm[], attrData: Record<string, componentAttrData[]>) => {
        return forms;
    },
    setFormData: async (forms: componentForm[], attrData: Record<string, componentAttrData[]>) => {
        var formData: Record<string, any> = {};
        for (const key in attrData) {
            const attrs = attrData[key];
            const defaultValue = pageFun.getAttrValue(attrs, 'defaultValue');
            console.log(defaultValue)
            const item = pageFun.getFormItem(forms, key);
            if (item?.fieldName && defaultValue && !isNullOrUnDef(defaultValue)) {
                formData[item?.fieldName ?? ''] = defaultValue;
            }
        }
        return formData;
    },
    setRules: async (
        forms: componentForm[],
        attrData: Record<string, componentAttrData[]>
    ) => {
        console.log(forms)
        const rules: TempFormRules = {};
        console.log(attrData)
        for (const key in attrData) {

            const attrs = attrData[key] ?? [];
            if (isNullOrUnDef(attrs) || Object.keys(attrs).length == 0) continue;
            const item = pageFun.getFormItem(forms, key);
            console.log(item, attrs)
            if (!item) {
                continue;
            }

            // ==============================
            // 获取属性
            // ==============================

            const tip = attrs;
            const placeholder = pageFun.getAttrValue(attrs, 'placeholder');
            const must = pageFun.getAttrValue(attrs, 'must');


            const tipText = placeholder ?? '请输入';
            console.log(must)
            // 非必填，不生成规则
            if (must !== true) {
                continue;
            }

            // ==============================
            // 是否选择类组件
            // ==============================

            const isChoice = [
                PageFormType.OneSelect,
                PageFormType.OneSelectSearch,
                PageFormType.MultSelect,
                PageFormType.Radio,
                PageFormType.Checkbox,
            ].includes(item.formType);

            // ==============================
            // 验证提示
            // ==============================

            const message =
                tipText ||
                `请${isChoice ? '选择' : '输入'}${item.title ?? item.label ?? ''}`;

            const rule = [
                {
                    required: true,
                    message,
                    trigger: isChoice ? 'change' : 'blur',
                }
            ];

            // ==============================
            // 普通字段
            // ==============================

            if (
                item.formType !== PageFormGroup.Group &&
                item.formType !== PageFormGroup.Table &&
                item.formType !== PageFormGroup.List
            ) {

                if (item.fieldName) {
                    rules[item.fieldName] = rule as FormItemRule[];
                }

                continue;
            }

            // ==============================
            // Table / List
            // ==============================

            if (
                item.formType === PageFormGroup.Table ||
                item.formType === PageFormGroup.List
            ) {

                if (!item.fieldName) {
                    continue;
                }

                if (!rules[item.fieldName]) {
                    rules[item.fieldName] = {};
                }

                const tableRules =
                    rules[item.fieldName] as Record<string, any[]>;

                // key 是子字段 fieldName
                tableRules[item.fieldName] = rule;
            }
        }

        return rules;
    },
    //TODO 流程之前表单数值引用
    setOptionssss: async (forms: componentForm[], attrData: Record<string, componentAttrData[]>) => {
        let options: Record<string, TempFormTreeOption | TempFormItemOption[] | PagedOptions[] | null> = {};
        let dicts: Record<string, string> = {};
        let enums: Record<string, string> = {};
        let apis: Record<string, Function> = {};
        for (const key in attrData) {
            const attrs = attrData[key];
            if (isNullOrUnDef(attrs) || Object.keys(attrs).length == 0) continue;
            const dataSourceType = pageFun.getAttrValue(attrs, 'dataSourceType');
            const dataSourceValue = pageFun.getAttrValue(attrs, 'dataSourceValue');
            const item = pageFun.getFormItem(forms, key);
            if (!item) continue;
            //dataSourceType[0].value  0 默认，1枚举，2字典 ，3实体类 ,4api
            //0默认 直接解析  attrs.filter(v => v.name == 'dataSourceValue')[0].value 的值;
            switch (dataSourceType) {
                case 0:
                    options[item.fieldName] = JSON.parse(pageFun.getAttrValue(attrs, 'customOptions'))
                        ; break;
                case 1:
                    dicts[item.fieldName] = dataSourceValue;
                    break;
                case 2:

                    ; break;
                case 3: case 4:

                    ; break;
                default: ; break;

            }
        }
    },
    /**
        * 获取属性值
        */
    getAttrValue: (attrs: Record<string, any>, name: string) => {
        const attr = attrs[name];
        if (isNullOrUnDef(attr)) return '';
        return attr;
    },
    setOptions: async (
        forms: componentForm[],
        attrData: Record<string, componentAttrData[]>
    ) => {

        const options: Record<
            string,
            TempFormTreeOption[] |
            TempFormItemOption[] |
            PagedOptions[] |
            null
        > = {};

        // =========================================================
        // 1、统一数据源请求参数
        // =========================================================

        const pData: BaseDataSource[] = [];

        // API 类型请求
        const apiTasks: Promise<void>[] = [];


        /**
         * 将值转换成字符串
         *
         * BaseDataSource 中：
         *
         * DataSourceValue
         * DataSourcePars
         * DataSourceHeaders
         *
         * 都是 string
         */
        const toJsonString = (value: any): string => {

            if (
                value === undefined ||
                value === null ||
                value === ''
            ) {
                return '';
            }

            if (typeof value === 'string') {
                return value;
            }

            try {
                return JSON.stringify(value);
            } catch {
                return String(value);
            }
        };


        /**
         * 默认数据源解析
         */
        const parseDefaultOptions = (
            value: any
        ):
            | TempFormTreeOption[]
            | TempFormItemOption[]
            | PagedOptions[]
            | null => {

            if (
                value === undefined ||
                value === null ||
                value === ''
            ) {
                return null;
            }

            // 已经是数组/对象
            if (typeof value !== 'string') {
                return value;
            }

            try {
                return JSON.parse(value);
            } catch {
                return null;
            }
        };


        // =========================================================
        // 3、遍历表单
        // =========================================================

        for (const key in attrData) {

            const attrs = attrData[key];
            if (isNullOrUnDef(attrs) || Object.keys(attrs).length == 0) continue;

            // 根据 ident 找到表单项
            const item = pageFun.getFormItem(forms, key);

            if (!item?.fieldName) {
                continue;
            }


            // =====================================================
            // 数据源类型
            // =====================================================

            const dataSourceType = Number(
                pageFun.getAttrValue(attrs, 'dataSourceType') ?? 0
            );


            // =====================================================
            // 数据源值
            // =====================================================

            const dataSourceValue =
                pageFun.getAttrValue(attrs, 'dataSourceValue');


            // =====================================================
            // 数据源参数
            // =====================================================

            const dataSourcePars =
                pageFun.getAttrValue(attrs, 'dataSourcePars');


            // =====================================================
            // Headers
            // =====================================================

            const dataSourceHeaders =
                pageFun.getAttrValue(attrs, 'dataSourceHeaders');


            // =====================================================
            // HttpType
            // =====================================================

            const httpTypeValue =
                pageFun.getAttrValue(attrs, 'httpType');

            const httpType = Number(
                httpTypeValue ?? 1
            );


            // =====================================================
            // 0：默认数据
            // =====================================================

            if (dataSourceType === 0) {

                options[item.fieldName] =
                    parseDefaultOptions(
                        dataSourceValue
                    );

                continue;
            }


            // =====================================================
            // 1 / 2 / 3 / 4
            // 统一组装 BaseDataSource
            // =====================================================

            const dataSource: BaseDataSource = {
                fieldName: item.fieldName,

                dataSourceType,

                dataSourceValue:
                    toJsonString(dataSourceValue),

                httpType,

                dataSourcePars:
                    dataSourcePars == null
                        ? null
                        : toJsonString(dataSourcePars),

                dataSourceHeaders:
                    dataSourceHeaders == null
                        ? null
                        : toJsonString(dataSourceHeaders)
            };


            // =====================================================
            // 4：API
            //
            // 如果希望 4 单独 axios 请求，则在这里处理
            // =====================================================

            if (dataSourceType === 4) {

                const url =
                    dataSource.dataSourceValue;

                if (!url) {
                    options[item.fieldName] = null;
                    continue;
                }

                let pars: any = {};

                if (dataSource.dataSourcePars) {
                    try {
                        pars = JSON.parse(
                            dataSource.dataSourcePars
                        );
                    } catch {
                        pars =
                            dataSource.dataSourcePars;
                    }
                }


                // Headers
                let headers: Record<string, any> | undefined;

                if (dataSource.dataSourceHeaders) {
                    try {
                        headers = JSON.parse(
                            dataSource.dataSourceHeaders
                        );
                    } catch {
                        headers = undefined;
                    }
                }


                const fieldName =
                    item.fieldName;


                const task = (async () => {

                    try {

                        const res = await axios.post(
                            url,
                            pars,
                            {
                                headers
                            }
                        );

                        options[fieldName] =
                            res.data ?? null;

                    } catch (error) {

                        console.error(
                            `获取字段 ${fieldName} 的 API 选项失败`,
                            error
                        );

                        options[fieldName] = null;
                    }

                })();

                apiTasks.push(task);

                continue;
            }



            // =====================================================
            // 1 / 2 / 3
            // 交给后端统一处理
            // =====================================================

            if (
                dataSourceType === 1 ||
                dataSourceType === 2 ||
                dataSourceType === 3
            ) {
                pData.push(dataSource);
            }
        }


        // =========================================================
        // 4、统一请求 1 / 2 / 3
        // =========================================================

        if (pData.length > 0) {

            try {

                const result =
                    await optionService.apiSysOptionOptionsPost(
                        pData
                    );

                const data = result.data.data as Record<
                    string,
                    PagedOptions[] | null
                >;



                /*
                 * 这里取决于你的后端返回结构。
                 *
                 * 假设返回：
                 *
                 * {
                 *     fieldName1: [...],
                 *     fieldName2: [...],
                 *     fieldName3: [...]
                 * }
                 *
                 * 那么直接：
                 */

                for (const source of pData) {

                    if (!source.fieldName) {
                        continue;
                    }

                    options[source.fieldName] = data?.[source.fieldName] ?? [];
                }

            } catch (error) {

                console.error(
                    '获取数据源选项失败',
                    error
                );

                for (const source of pData) {

                    if (source.fieldName) {
                        options[source.fieldName] = null;
                    }
                }
            }
        }


        // =========================================================
        // 5、等待 API 类型请求
        // =========================================================

        if (apiTasks.length > 0) {
            await Promise.all(apiTasks);
        }


        // =========================================================
        // 6、返回
        // =========================================================
        return options;
    },
    getFormItem: (forms: componentForm[], ident: string): componentForm | undefined => {
        for (const form of forms) {
            if (form.ident === ident) {
                return form;
            }

            const result = form.child?.length
                ? pageFun.getFormItem(form.child, ident)
                : undefined;

            if (result) {
                return result;
            }
        }

        return undefined;
    }

}

const formData = computed<ReleaseData>(() => {
    var data = { form: props.form, attrData: props.attrData } as ReleaseData;
    pageFun.initTempForm(data);
    return data;
});

const initForm = async () => {
    const data: ReleaseData = {
        form: props.form,
        attrData: props.attrData
    };

    await pageFun.initTempForm(data);
};

watch(
    () => [
        props.form,
        props.attrData
    ],

    () => {
        initForm();
    },

    {
        immediate: true,
        deep: true
    }
);

const emits = defineEmits(['onSubmit']);
defineExpose<PageFormEnhancedExpose>({
    ruleFormRef: () => {
        return pageFormRef.value?.ruleFormRef;
    },
    onSubmit: () => {
        return pageFormRef.value?.onSubmit
    },
    getData: () => {
        console.log(tempForm.value.formData)
        return tempForm.value.formData
    },
    validate: async () => {
        return await pageFormRef.value.validate();
    }
})
export interface PageFormEnhancedExpose {
    ruleFormRef: () => Ref<FormInstance | undefined, FormInstance | undefined>,
    onSubmit: () => Promise<void>
    getData: () => Record<string, any>
    validate: () => Promise<boolean>

}



</script>
<style lang="less" scoped></style>