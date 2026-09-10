<template>
    <div class="temp-edit-page" v-bind="$attrs">
        <el-form ref="ruleFormRef" class="temp-page-form" :show-message="false" :model="tempForm.formData"
            :rules="tempForm?.rules ?? {}" style="padding:30px 0px;" require-asterisk-position='left' label-suffix="："
            label-width="150px" required="auto" v-bind="tempForm?.props ?? {}" v-on="tempForm?.on ?? {}">
            <el-row :gutter="0">

                <YzPageFormItem :col="tempForm.cols ?? 2" :options="tempForm.options ?? []"
                :page-data="tempForm.formData" :form-items="tempForm.form">
                <template #customType="{item}">
                        <slot name="customType" :item="item"></slot>
                    </template>
                </YzPageFormItem>
            </el-row>
        </el-form>
        <div class="temp-edit-footer" v-if="tempForm.hideBtn !== true">
            <slot name="footer">
                <el-button type="primary" :loading="tempForm.loading" @click="onSubmit(ruleFormRef)">{{
                    props.tempForm.btnText
                    ?? '确认' }}</el-button>
            </slot>
        </div>
    </div>
</template>
<script setup lang="ts">
import { ref } from 'vue';
import YzPageFormItem from './item.vue';
import { PageFormGroup, type TempEditPageData } from '@/components/PageForm/index.ts';
import type { FormInstance } from 'element-plus'
import { ElMessage } from 'element-plus'
const props = defineProps<{
    tempForm: TempEditPageData
}>()
const emit = defineEmits(['onSubmit'])
const ruleFormRef = ref<FormInstance>()

const onSubmit = (formEl?: FormInstance | undefined) => {
    ruleFormRef.value?.validate((valid, fields) => {
        if (valid) {
            emit('onSubmit', formEl)
        } else {
            if (!fields) return;
            const names = Object.getOwnPropertyNames(fields);
            console.log(names);
            console.log(fields)
            names.length > 0 && ElMessage({
                message: `${getTitleByName(names[0])}：${fields[names[0]][0].message?.indexOf(names[0]) == -1 ? fields[names[0]][0].message : "不能为空或格式不对"} `,
                type: 'error'
            })
        }
    })

}
const selectFieldText = '_Text';
/**
 * 根据name获取title
 * @param name 
 */
function getTitleByName(name: string): string | undefined {
    name = name.replace(selectFieldText, '');
    for (const group of props.tempForm.form ?? []) {
        if (Array.isArray(group.child) && group.formType == PageFormGroup.Group) {
            const found = group.child.find(item => item.fieldName === name);
            if (found) return found.title ?? found.label;
        }
        else if (group.formType !== PageFormGroup.Group && group.fieldName === name) {
            return group.title ?? group.label;
        }

    }
    return undefined;
}
defineExpose({
    ruleFormRef: ruleFormRef,
    onSubmit: onSubmit
})
</script>
<style lang="less" scoped>
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
        width: 100%;
        margin-bottom: 35px;
        padding: 45px 15px 25px;
        position: relative;

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