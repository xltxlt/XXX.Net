<template>
    <div class="temp-edit-page" :class="{
        'temp-edit-page-disabled': tempForm.disabledForm === true
    }" v-bind="$attrs">
        <el-form ref="ruleFormRef" class="temp-page-form" :show-message="false" :model="tempForm.formData"
            :rules="formRules" style="padding:30px 0px;" require-asterisk-position='left' label-suffix="："
            label-width="150px" required="auto" v-bind="tempForm?.props ?? {}" v-on="tempForm?.on ?? {}">
            <el-row :gutter="0">
                <template v-for="(m, i) in tempForm.form" :key="i">
                    <template v-if="(m?.hide ?? false) !== true">

                        <slot :item="m"></slot>
                        <template v-if="(tempForm.design&&(m.formType == PageFormGroup.Table||m.formType == PageFormGroup.List)) || m.formType == PageFormGroup.Group">
                            <div class="temp-page-form-group" v-bind="m?.comProps ?? {}" v-on="m?.comOn ?? {}">
                                <div class="temp-page-form-group-title">
                                    <slot name="groupTitle" :item="m">
                                        <span>{{ m.title ?? m.label }}</span>
                                    </slot>
                                </div>
                                <slot name="group" :item="m">
                                    <el-row :gutter="0">
                                        <template v-if="(m?.child?.length ?? 0 > 0)" v-for="(item, index) in m.child"
                                            :key="index">
                                            <template v-if="(item?.hide ?? false) !== true">
                                                <page-form-core :cols="cols" :item="item" :temp-form="tempForm"
                                                    :temp-form-data="tempForm.formData"></page-form-core>
                                            </template>
                                        </template>
                                    </el-row>
                                </slot>

                            </div>

                        </template>
                        <template v-else-if="m.formType == PageFormGroup.List">

                            <div class="temp-page-form-group temp-page-form-list" v-bind="m?.comProps ?? {}"
                                v-on="m?.comOn ?? {}">
                                <!-- 标题 -->
                                <div class="temp-page-form-group-title">
                                    <slot name="groupTitle" :item="m">
                                        <span>{{ m.title ?? m.label }}</span>
                                    </slot>
                                </div>
                                <!-- 添加 -->
                                <div class="temp-page-form-group-right">
                                    <el-button type="success" @click.stop="pageFun.addGroupItem(m)">
                                        添加项
                                    </el-button>
                                </div>
                                <slot name="group" :item="m">
                                    <el-row :gutter="0">
                                        <template v-for="(row, sonIndex) in (tempForm.formData[m.fieldName] ?? [])"
                                            :key="sonIndex">
                                            <div class="temp-page-form-group" v-bind="m.child?.[0]?.comProps ?? {}"
                                                v-on="m.child?.[0]?.comOn ?? {}">
                                                <!-- 行标题 -->
                                                <div class="temp-page-form-group-title">
                                                    <slot name="groupTitle" :item="m.child?.[0]">
                                                        <span>
                                                            {{ m.title ?? m.label }}-第{{ Number(sonIndex) + 1 }}项
                                                        </span>
                                                    </slot>
                                                </div>
                                                <!-- 删除 -->
                                                <div class="temp-page-form-group-right">

                                                   
                                                    <el-button type="danger"
                                                        @click.stop="pageFun.delGroupItem(m, Number(sonIndex))">
                                                        删除项
                                                    </el-button>
                                                    <el-button @click.stop="pageFun.copyGroupItem(m, Number(sonIndex))">
                                                        复制项
                                                    </el-button>
                                                </div>

                                                <!-- 行内容 -->
                                                <slot name="group" :item="m.child?.[0]">

                                                    <el-row :gutter="0">

                                                        <template v-for="(item, index) in (m.child?.[0]?.child ?? [])"
                                                            :key="item.fieldName ?? index">

                                                            <template v-if="(item?.hide ?? false) !== true">

                                                                <page-form-core :cols="cols" :item="item"
                                                                    :temp-form="tempForm" :field-name="m.fieldName"
                                                                    :index="sonIndex"
                                                                    :temp-form-data="tempForm.formData[m.fieldName][sonIndex]" />

                                                            </template>

                                                        </template>

                                                    </el-row>

                                                </slot>

                                            </div>

                                        </template>

                                    </el-row>

                                </slot>

                            </div>

                        </template>
                        <!-- <template v-else-if="m.formType == PageFormGroup.List">

                            <div class="temp-page-form-group temp-page-form-list" v-bind="m?.comProps ?? {}" v-on="m?.comOn ?? {}">
                                <div class="temp-page-form-group-title">
                                    <slot name="groupTitle" :item="m">
                                        <span>{{ m.title ?? m.label }}</span>
                                    </slot>

                                </div>
                                <div class="temp-page-form-group-right">
                                    <el-button type="success" @click.stop="() => {
                                        tempForm.formData[m.fieldName].push({} as any);
                                        m.child?.push((m.child ?? [])[0]);
                                    }">添加项</el-button>
                                </div>
                                <slot name="group" :item="m">
                                    <el-row :gutter="0">
                                        <template v-for="(son, sonIndex) in m.child" :key="sonIndex">
                                            <template v-if="(son?.hide ?? false) !== true">

                                                <slot :item="son"></slot>
                                                <template v-if="son.formType == PageFormGroup.Group">
                                                    <div class="temp-page-form-group" v-bind="son?.comProps ?? {}"
                                                        v-on="son?.comOn ?? {}">
                                                        <div class="temp-page-form-group-title">
                                                            <slot name="groupTitle" :item="son">
                                                                <span>{{ m.title ?? m.label }}-第{{ sonIndex + 1
                                                                }}项</span>
                                                            </slot>
                                                        </div>
                                                        <div class="temp-page-form-group-right">
                                                            <el-button type="danger" @click.stop="async() => {
                                                                tempForm.formData[m.fieldName].splice(sonIndex, 1);
                                                                await ElMessageBox.confirm('确定删除吗？', '提示', { type: 'warning' })
                                                                m.child?.splice(sonIndex, 1);
                                                            }">删除项</el-button>
                                                        </div>
                                                        <slot name="group" :item="son">
                                                            <el-row :gutter="0">
                                                                <template v-if="(son?.child?.length ?? 0 > 0)"
                                                                    v-for="(item, index) in son.child" :key="index">
                                                                    <template v-if="(item?.hide ?? false) !== true">
                                                                        <page-form-core :cols="cols" :item="item"
                                                                            :temp-form="tempForm"
                                                                             :field-name="m.fieldName"
                                                                             :index="sonIndex"
                                                                            :temp-form-data="tempForm.formData[m.fieldName][sonIndex]"></page-form-core>
                                                                    </template>
                                                                </template>
                                                            </el-row>
                                                        </slot>

                                                    </div>
                                                </template>
                                                <template v-else></template>
                                            </template>
                                        </template>
                                    </el-row>
                                </slot>

                            </div>

                        </template> -->
                        <template v-else-if="m.formType == PageFormGroup.Table">

                            <div class="temp-page-form-group temp-page-form-table" v-bind="m?.comProps ?? {}"
                                v-on="m?.comOn ?? {}">
                                <div class="temp-page-form-group-title">
                                    <slot name="groupTitle" :item="m">
                                        <span>{{ m.title ?? m.label }}</span>
                                    </slot>

                                </div>
                                <div class="temp-page-form-group-right">
                                    <el-button type="success" @click.stop="pageFun.addGroupItem(m)">
                                        添加项
                                    </el-button>
                                </div>
                                <slot name="group" :item="m">
                                    <el-row :gutter="0">
                                        <page-table-form-core :cols="cols" :items="(m?.child ?? [])[0].child ?? []"
                                            @del-item="(index: number) => pageFun.delGroupItem(m, index)"
                                            @copy-item="(index:number)=>pageFun.copyGroupItem(m,index)"
                                            :temp-form="tempForm" :field-name="m.fieldName"
                                            :temp-form-data="tempForm.formData[m.fieldName]"></page-table-form-core>
                                    </el-row>
                                </slot>

                            </div>

                        </template>
                        <page-form-core v-else :cols="cols" :item="m" :temp-form="tempForm"
                            :temp-form-data="tempForm.formData"></page-form-core>
                    </template>
                </template>
            </el-row>
        </el-form>
        <div class="temp-edit-footer" v-if="tempForm.hideBtn !== true">
            <slot name="footer">
                <el-button type="primary" :loading="tempForm.loading" @click="onSubmit">{{
                    props.tempForm.btnText
                    ?? '确认' }}</el-button>
            </slot>
        </div>
    </div>
</template>
<script setup lang="ts">
import { computed, ref } from 'vue';
import { type TempEditForm, type TempEditPageData, PageFormGroup } from './index'
import type { FormInstance, FormRules } from 'element-plus'
import { ElMessage, ElMessageBox } from 'element-plus'
import PageFormCore from './PageFormCore.vue';
import PageTableFormCore from './PageTableFormCore.vue';
import { json } from 'stream/consumers';
import { isNullOrUnDef } from '@/utils/is.ts';
const props = defineProps<{
    tempForm: TempEditPageData
}>()

const emit = defineEmits(['onSubmit'])
const ruleFormRef = ref<FormInstance>()
const cols = computed(() => {
    return 24 / (props.tempForm.cols ?? 1);
})

const onSubmit = async () => {

    if (!ruleFormRef.value) {
        return;
    }

    try {

        await ruleFormRef.value.validate();

        // 验证通过
        emit('onSubmit');

    } catch (fields) {

        console.log('表单验证失败：', fields);

        const errorFields = fields as Record<string, any[]>;

        const names = Object.keys(errorFields);

        if (names.length > 0) {

            const firstName = names[0];

            const firstError = errorFields[firstName]?.[0];

            ElMessage({
                message: `${getTitleByName(firstName) ?? firstName}：${firstError?.message ?? '不能为空或格式不正确'}`,
                type: 'error'
            });
        }
    }
};
// const onSubmit = (formEl?: FormInstance | undefined) => {
//     ruleFormRef.value?.validate((valid, fields) => {
//         if (valid) {
//             emit('onSubmit', formEl)
//         } else {
//             if (!fields) return;
//             const names = Object.getOwnPropertyNames(fields);
//             names.length > 0 && ElMessage({
//                 message: `${getTitleByName(names[0])}：${fields[names[0]][0].message?.indexOf(names[0]) == -1 ? fields[names[0]][0].message : "不能为空或格式不对"} `,
//                 type: 'error'
//             })
//         }
//     })

// }
// const formRules = computed<FormRules>(() => {
//     return buildFormRules();
// });
const formRules = computed<FormRules>(() => {

    const result: FormRules = {};

    const rules = props.tempForm.rules;

    if (!rules) {
        return result;
    }

    Object.entries(rules).forEach(
        ([fieldName, rule]) => {

            // ========================================
            // 普通字段
            // ========================================
            if (Array.isArray(rule)) {

                result[fieldName] = rule;

                return;
            }

            // ========================================
            // Table
            // ========================================
            const tableData =
                props.tempForm.formData?.[fieldName];

            if (!Array.isArray(tableData)) {
                return;
            }

            Object.entries(rule).forEach(
                ([childFieldName, childRule]) => {

                    tableData.forEach(
                        (_row: any, index: number) => {

                            result[
                                `${fieldName}.${index}.${childFieldName}`
                            ] = childRule;

                        }
                    );

                }
            );

        }
    );

    // console.log('最终 FormRules：', result);

    return result;
});
const selectFieldText = '_Text';
/**
 * 根据name获取title
 * @param name 
 */
// function getTitleByName(name: string): string | undefined {
//     name = name.replace(selectFieldText, '');
//     console.log(name)
//     for (const group of props.tempForm.form ?? []) {
//         if (Array.isArray(group.child) && group.formType == PageFormGroup.Group) {
//             const found = group.child.find(item => item.fieldName === name);
//             if (found) return found.title ?? found.label;
//         }
//         else if (group.formType !== PageFormGroup.Group && group.fieldName === name) {
//             return group.title ?? group.label;
//         }

//     }
//     return undefined;
// }
function getTitleByName(name: string): string | undefined {
    name = name.replace(selectFieldText, '');

    const parts = name.split('.');

    // List / Table 子项
    if (parts.length === 3) {
        const [listFieldName, rowIndex, childFieldName] = parts;

        const list = props.tempForm.form.find(
            item =>
                (
                    item.formType === PageFormGroup.List ||
                    item.formType === PageFormGroup.Table
                ) &&
                item.fieldName === listFieldName
        );

        if (list) {
            const columns = list.child?.[0]?.child ?? [];

            const column = columns.find(
                item => item.fieldName === childFieldName
            );

            if (column) {
                return `第${Number(rowIndex) + 1}项${column.title ?? column.label}`;
            }
        }
    }

    // 普通字段
    const item = props.tempForm.form.find(
        item => item.fieldName === name
    );

    return item?.title ?? item?.label;
}
const pageFun = {
    // addTableItem: (item: any) => {

    //     const fieldName = item.fieldName;

    //     if (!Array.isArray(props.tempForm.formData[fieldName])) {
    //         props.tempForm.formData[fieldName] = [];
    //     }

    //     // 新增一行
    //     props.tempForm.formData[fieldName].push({});
    // },
    addGroupItem: (item: TempEditForm) => {
        const fieldName = item.fieldName;
        if (!fieldName) return;

        // 确保数组存在
        if (!Array.isArray(props.tempForm.formData[fieldName])) {
            props.tempForm.formData[fieldName] = [];
        }

        // 深拷贝默认值，避免多个项共用引用
        const newItem = JSON.parse(JSON.stringify(item.child?.[0]?.defaultValue ?? {}));
        props.tempForm.formData[fieldName].push(newItem);
    },
    copyGroupItem: (item: TempEditForm, index: number) => {
        const list = props.tempForm.formData[item.fieldName];
        const newItem = JSON.parse(
            JSON.stringify(list[index])
        );
        if(!isNullOrUnDef(newItem?.id))newItem.id=null;
        list.splice(Number(index) + 1, 0, newItem);
    },
    delGroupItem: async (item: any, index: number) => {

        const fieldName = item.fieldName;

        const tableData = props.tempForm.formData[fieldName];

        if (!Array.isArray(tableData)) {
            return;
        }

        if (index < 0 || index >= tableData.length) {
            return;
        }
        await ElMessageBox.confirm(
            '确定要删除这一项吗？',
            '提示',
            {
                confirmButtonText: '确定',
                cancelButtonText: '取消',
                type: 'warning'
            }
        );
        tableData.splice(index, 1);

    }
}
defineExpose({
    ruleFormRef: ruleFormRef,
    onSubmit: onSubmit,
})

</script>
<style lang="less" scoped>
.temp-edit-page-disabled {
    pointer-events: none;
}

.temp-edit-page {
    .yz-upload-file {
        width: 100%;
    }

    .file-detail-item {
        align-items: center;
    }

    .file-detail {
        cursor: pointer;
        overflow: hidden;
        width: 360px;
        background: #F6F8FC;
        padding: 5px 20px 5px 50px;
        color: #111111;
        font-size: 17px;
        text-align: left;
        border: 1px solid #E5E6EA;
        border-radius: 5px;
        display: flex;
        align-items: center;
    }

    .upload-file-icon {
        width: 25px;
        height: 25px;
        position: absolute;
        left: 15px;
    }
}
</style>
<style lang="less">
.el-form-item {
    :first-child {
        &.el-form-item__content {
            margin-left: 25px !important;
        }
    }
}

.temp-edit-page {
    padding: 0 25px 50px 10px;
    min-height: calc(100% - 60px);
    // position: relative;

    .temp-page-form-group {
        border: 1px solid #e6e6e6;
        margin-bottom: 35px;
        padding: 45px 15px 25px;
        position: relative;
        width: calc(100% - 30px);

        .temp-page-form-group-title {
            font-size: 15px;
            font-weight: bold;
            position: absolute;
            height: 30px;
            padding: 0 15px;
            text-align: left;
            display: flex;
            align-items: center;
            top: 0;
            transform: translateY(-50%);
            left: 20px;
            background-color: #fff;

        }

        .temp-page-form-group-right {
            position: absolute;
            padding: 0 15px;
            text-align: left;
            display: flex;
            align-items: center;
            top: 0;
            transform: translateY(-50%);
            right: 20px;
            background-color: #fff;
        }
    }

    .temp-page-form-list .temp-page-form-group {
        .temp-page-form-group-right {
            top: unset;
            bottom: -30px;
        }
    }

    .el-col {
        padding-right: 25px;
    }

    .el-form-item__label {
        width: 120px;
    }

    .temp-edit-footer {
        position: absolute;
        right: 30px;
        bottom: 15px;
        z-index: 3;
    }

    .temp-page-form {
        padding-bottom: 50px;
    }

    .el-cascader {}

    .el-date-editor.el-input,
    .el-date-editor.el-input__wrapper {
        width: 100%;
    }

    .el-select__caret.el-select__icon {
        font-size: 17px;
    }
}
</style>