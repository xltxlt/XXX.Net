<script setup lang="ts">

import type {
    TempEditForm
} from '.';

import {
    PageFormType
} from '.';

import type {
    TempEditPageData,
    LocationDto
} from '.';

import { ref } from 'vue';

import {
    AddLocation
} from '@element-plus/icons-vue';

import YzUpload from '../common/YzUpload/YzUpload.vue';

import YzAddress from '../common/YzAddress/YzAddress.vue';

import LocationSelect from '../common/LocationSelect/LocationSelect.vue';

import SelectIcon from '@/components/common/SelectIcon/SelectIcon.vue';

import OptionEditor from '../common/OptionEditor/OptionEditor.vue';


const props = defineProps<{

    /**
     * 表格列定义
     */
    items: TempEditForm[];

    /**
     * 整个表单配置
     */
    tempForm: TempEditPageData;

    /**
     * 当前表格的数据
     *
     * [
     *   {
     *      name: '张三',
     *      age: 18
     *   }
     * ]
     */
    tempFormData: any[];
    fieldName: string;

}>();


const emit = defineEmits<{

    /**
     * 删除行
     */
    (e: 'delItem', index: number): void;
    /**
     * 复制行
     */
    (e: 'copyItem', index: number): void;

}>();


/**
 * 删除行
 */
const delItem = (index: number) => {

    emit(
        'delItem',
        index
    );

};
/**
 * 复制行
 */
const copyItem = (index: number) => {

    emit(
        'copyItem',
        index
    );

};
const isRequired = (fieldName: string) => {
    const rules = props.tempForm.rules?.[props.fieldName];

    if (!rules || Array.isArray(rules)) {
        return false;
    }

    const fieldRules = rules[fieldName];

    if (!Array.isArray(fieldRules)) {
        return false;
    }

    return fieldRules.some(rule => rule.required === true);
};
/**
 * 颜色
 */
const predefineColors = ref([

    '#FA5151',
    '#FA9D3B',
    '#FFC300',
    '#91D300',
    '#95EC69',
    '#07C160',
    '#10AEFF',
    '#1485EE',
    '#6467F0',
    '#576B95',
    '#ff4500',
    '#ff8c00',
    '#ffd700',
    '#90ee90',
    '#00ced1',
    '#1e90ff',
    '#c71585',

]);


/**
 * 文件预览
 */
const filePreview = async (
    url: any
) => {

};


/**
 * 地址选择
 */
const locationSelectConfirm = (
    val: any,
    item: TempEditForm,
    row: any
) => {

    item.showPicker = false;


    const city =
        (val.other.province ?? '') +
        (val.other.city ?? '') +
        (val.other.district ?? '');


    row[item.fieldName + '_City'] =
        city;


    row[item.fieldName + '_Address'] =
        val.address;


    row[item.fieldName] =
        val.address;


    const location: LocationDto = {

        address:
            (val.address ?? '')
                .replace(city, ''),

        city:
            val.other.city ?? '',

        province:
            val.other.province ?? '',

        region:
            val.other.district ?? '',

        code:
            val.other.adcode ?? '',

        lng:
            String(val.lng ?? ''),

        lat:
            String(val.lat ?? '')

    };


    row[item.fieldName + '_Data'] =
        location;

};
const getColumnWidth = (item: TempEditForm) => {
    const comProps = item.comProps;

    if (
        comProps &&
        typeof comProps === 'object' &&
        !Array.isArray(comProps) &&
        'width' in comProps
    ) {
        return (comProps as Record<string, any>).width ?? 150;
    }

    return 150;
};
</script>


<template>

    <!--
        注意：

        tempFormData 本身就是数组

        不要写：

        :data="[tempFormData]"

        应该写：

        :data="tempFormData"
    -->

    <el-table :data="tempFormData" border style="width: 100%">

        <!-- ==================== 动态列 ==================== -->

        <el-table-column v-for="item in items" :key="item.fieldName" :label="item.title ?? item.label"
            :min-width="getColumnWidth(item)" align="center">
            <template #header>
                <span v-if="isRequired(item.fieldName)" class="required-star">
                    *
                </span>
                <span>{{ item.label }}</span>
            </template>
            <template #default="{ row, $index }">
                <el-form-item :prop="`${props.fieldName}.${$index}.${item.fieldName}`" class="table-form-item">

                    <!-- ================= Input ================= -->

                    <el-input v-if="item.formType === PageFormType.Input" v-model="row[item.fieldName]" :placeholder="item?.placeholder ??
                        '请输入' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" @change="item?.on" />


                    <!-- ================= Number ================= -->

                    <el-input v-else-if="
                        item.formType ===
                        PageFormType.Number
                    " v-model="row[item.fieldName]" type="number" :placeholder="item?.placeholder ??
                        '请输入' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Decimal ================= -->

                    <el-input v-else-if="
                        item.formType ===
                        PageFormType.DecimalInput
                    " v-model="row[item.fieldName]" type="number" :precision="2" :step="0.1" :placeholder="item?.placeholder ??
                        '请输入' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= TextArea ================= -->

                    <el-input v-else-if="
                        item.formType ===
                        PageFormType.TextAreaInput
                    " v-model="row[item.fieldName]" type="textarea" :rows="4" :placeholder="item?.placeholder ??
                        '请输入' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Checkbox ================= -->

                    <el-checkbox-group v-else-if="
                        item.formType ===
                        PageFormType.Checkbox
                    " v-model="row[item.fieldName]" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">

                        <el-checkbox v-for="(
optItem,
    optIndex
                        ) in tempForm.options[item.fieldName]" :key="optIndex" :value="optItem.value"
                            :name="item.fieldName">
                            {{ optItem.label }}
                        </el-checkbox>

                    </el-checkbox-group>


                    <!-- ================= Radio ================= -->

                    <el-radio-group v-else-if="
                        item.formType ===
                        PageFormType.Radio
                    " v-model="row[item.fieldName]" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">

                        <el-radio v-for="(
optItem,
    optIndex
                        ) in tempForm.options[item.fieldName]" :key="optIndex" :value="optItem.value">
                            {{ optItem.label }}
                        </el-radio>

                    </el-radio-group>


                    <!-- ================= Color ================= -->

                    <el-color-picker v-else-if="
                        item.formType ===
                        PageFormType.Color
                    " v-model="row[item.fieldName]" show-alpha :predefine="predefineColors" />


                    <!-- ================= Select ================= -->

                    <el-select v-else-if="
                        item.formType ===
                        PageFormType.OneSelect
                    " v-model="row[item.fieldName]" suffix-icon="CaretBottom" :placeholder="item?.placeholder ??
                        '请选择' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%">

                        <el-option v-for="(
optItem,
    optIndex
                        ) in tempForm.options[item.fieldName]" :key="optIndex" :label="optItem.label"
                            :value="optItem.value" />

                    </el-select>


                    <!-- ================= Select Search ================= -->

                    <el-select v-else-if="
                        item.formType ===
                        PageFormType.OneSelectSearch
                    " v-model="row[item.fieldName]" filterable suffix-icon="CaretBottom" :placeholder="item?.placeholder ??
                        '请选择' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%">

                        <el-option v-for="(
optItem,
    optIndex
                        ) in tempForm.options[item.fieldName]" :key="optIndex" :label="optItem.label"
                            :value="optItem.value" />

                    </el-select>


                    <!-- ================= Multiple ================= -->

                    <el-select v-else-if="
                        item.formType ===
                        PageFormType.MultSelect
                    " v-model="row[item.fieldName]" filterable multiple collapse-tags suffix-icon="CaretBottom"
                        :placeholder="item?.placeholder ??
                            '请选择' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%">

                        <el-option v-for="(
optItem,
    optIndex
                        ) in tempForm.options[item.fieldName]" :key="optIndex" :label="optItem.label"
                            :value="optItem.value" />

                    </el-select>


                    <!-- ================= Custom Options ================= -->

                    <OptionEditor v-else-if="
                        item.formType ===
                        PageFormType.CustomOptions
                    " v-model="row[item.fieldName]" />


                    <!-- ================= Time ================= -->

                    <el-time-picker v-else-if="
                        item.formType ===
                        PageFormType.TimeSelect
                    " v-model="row[item.fieldName]" suffix-icon="CaretBottom" :placeholder="item?.placeholder ??
                        '请选择' +
                        (item.label ??
                            item?.title ??
                            '')
                        " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%" />


                    <!-- ================= Tree ================= -->

                    <el-cascader v-else-if="
                        item.formType ===
                        PageFormType.TreeSelect
                    " v-model="row[item.fieldName]" :options="tempForm.options[item.fieldName]
                        " style="width: 100%" :placeholder="item?.placeholder ??
                            '请选择' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                    <!-- ================= TreeLast ================= -->

                    <el-tree-select v-else-if="
                        item.formType ===
                        PageFormType.TreeSelectLast
                    " style="width: 100%" v-model="row[item.fieldName]" :data="tempForm.options[item.fieldName]"
                        :render-after-expand="false"
                        :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                        v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Date ================= -->

                    <el-date-picker v-else-if="
                        item.formType ===
                        PageFormType.DateSelect
                    " v-model="row[item.fieldName]" format="YYYY-MM-DD" value-format="YYYY-MM-DD"
                        suffix-icon="CaretBottom" :placeholder="item?.placeholder ??
                            '请选择' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%" />


                    <!-- ================= DateTime ================= -->

                    <el-date-picker v-else-if="
                        item.formType ===
                        PageFormType.DateTimeSelect
                    " v-model="row[item.fieldName]" type="datetime" format="YYYY-MM-DD HH:mm"
                        value-format="YYYY-MM-DD HH:mm" suffix-icon="CaretBottom" :placeholder="item?.placeholder ??
                            '请选择' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" style="width: 100%" />


                    <!-- ================= Rate ================= -->

                    <el-rate v-else-if="
                        item.formType ===
                        PageFormType.Rate
                    " v-model="row[item.fieldName]" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Slider ================= -->

                    <el-slider v-else-if="
                        item.formType ===
                        PageFormType.Slider
                    " v-model="row[item.fieldName]" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Switch ================= -->

                    <el-switch v-else-if="
                        item.formType ===
                        PageFormType.Switch
                    " v-model="row[item.fieldName]" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />


                    <!-- ================= Icon ================= -->

                    <template v-else-if="
                        item.formType ===
                        PageFormType.Icon
                    ">

                        <el-input v-model="row[item.fieldName]" :placeholder="item?.placeholder ??
                            '请输入' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" @click="
                                item.showPicker = true
                                " />


                        <el-dialog v-model="item.showPicker" width="700px" draggable>

                            <template #header>
                                选择图标
                            </template>


                            <SelectIcon @select-icon="(val: string) => {

                                row[item.fieldName] =
                                    val;

                                item.showPicker =
                                    false;

                            }" />

                        </el-dialog>

                    </template>


                    <!-- ================= Map ================= -->

                    <template v-else-if="
                        item.formType ===
                        PageFormType.MapSelect
                    ">

                        <el-input v-model="row[item.fieldName]" readonly :placeholder="item?.placeholder ??
                            '请输入' +
                            (item.label ??
                                item?.title ??
                                '')
                            " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" @click="
                                item.showPicker = true
                                ">

                            <template #append>

                                <el-button :icon="AddLocation" />

                            </template>

                        </el-input>


                        <LocationSelect v-model:show="item.showPicker
                            " @confirm="
                                (data: any) =>
                                    locationSelectConfirm(
                                        data,
                                        item,
                                        row
                                    )
                            " />

                    </template>


                    <!-- ================= Location ================= -->

                    <template v-else-if="
                        item.formType ===
                        PageFormType.LocationSelect
                    ">

                        <el-input v-model="row[
                            item.fieldName +
                            'Address'
                        ]
                            " :placeholder="item?.placeholder ??
                                '请输入详细地址'
                                " v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">

                            <template #prepend>

                                <div style="cursor: pointer" @click.stop="
                                    item.showPicker = true
                                    ">

                                    {{
                                        !row[
                                            item.fieldName +
                                            'City'
                                        ]
                                            ? '请选择'
                                            : row[
                                            item.fieldName +
                                            'City'
                                            ]
                                    }}

                                </div>

                            </template>


                            <template #append>

                                <el-button :icon="AddLocation" @click.stop="
                                    item.showPicker = true
                                    " />

                            </template>

                        </el-input>


                        <YzAddress v-model:show="item.showPicker
                            " v-model:model-must="row[item.fieldName]
                                " v-model:model-address="row[
                                    item.fieldName +
                                    'Address'
                                ]
                                    " v-model:model-city="row[
                                    item.fieldName +
                                    'City'
                                ]
                                    " v-model:model-value="row[
                                    item.fieldName +
                                    'Data'
                                ]
                                    " />

                    </template>


                    <!-- ================= Upload One Image ================= -->

                    <YzUpload v-else-if="
                        item.formType ===
                        PageFormType.UploadOneImg
                    " :upload-type="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}" :files="row[item.fieldName]
                        " />


                    <!-- ================= Upload Multi Image ================= -->

                    <YzUpload v-else-if="
                        item.formType ===
                        PageFormType.UploadMultImg
                    " :upload-type="1" :limit="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}" :files="row[item.fieldName]
                        ? [].concat(
                            row[item.fieldName]
                        )
                        : []
                        " />


                    <!-- ================= Custom ================= -->

                    <slot v-else-if="
                        item.formType ===
                        PageFormType.Custom
                    " name="custom" :item="item" :row="row" />

                </el-form-item>
            </template>
        </el-table-column>


        <!-- ==================== 操作列 ==================== -->

        <el-table-column label="操作" width="200" fixed="right"  align="center">

            <template #default="{ $index }">

                <el-button type="danger"  @click="delItem($index)">
                    删除
                </el-button>

                <el-button  @click="copyItem($index)">
                    复制
                </el-button>
            </template>

        </el-table-column>

    </el-table>

</template>


<style scoped lang="less">
.required-star {
    color: #f56c6c;
}

:deep(.el-table__cell) {
    padding: 8px;
}


:deep(.el-table .cell) {
    overflow: visible;
}


.table-form-wrapper {
    width: 100%;
}

.table-form-item {
    margin-bottom: 0;
    width: 100%;
}

:deep(.table-form-item .el-form-item__content) {
    margin-left: 0 !important;
    width: 100%;
}

:deep(.table-form-item .el-form-item__error) {
    position: relative;
    padding-top: 2px;
    line-height: 18px;
}
</style>