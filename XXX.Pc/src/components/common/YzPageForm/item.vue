<template>
    <template v-for="(item, index) in formItems" :key="index">
        <template v-if="(item?.hide ?? false) !== true">
            <slot name="customType" :item="item">
                <slot :item="item"></slot>
                <template v-if="item.formType == PageFormGroup.Group || item.formType == PageFormGroup.Table|| item.formType == PageFormGroup.List|| item.formType == PageFormGroup.Table">
                    <div class="temp-page-form-group" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                        <div class="temp-page-form-group-title">
                            <slot name="groupTitle" :item="item">
                                <span>{{ item.title ?? item.label }}</span>
                            </slot>
                        </div>
                        <slot name="group" :item="item">
                            <el-row :gutter="0">
                                <template v-if="(item?.child?.length ?? 0 > 0)" v-for="(m, i) in item.child" :key="'item_'+i">
                                    <template v-if="(m?.hide ?? false) !== true">
                                        <YzPageFormItem :form-items="[m]" :page-data="pageData" :col="col"
                                            :options="options"></YzPageFormItem>
                                    </template>
                                </template>
                            </el-row>
                        </slot>
                    </div>
                </template>
                <template v-else-if="item.formType == PageFormGroup.PreviewGroup">
                    <div class="temp-page-form-group" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                        <div class="temp-page-form-group-title">
                            <slot name="groupTitle" :item="item">
                                <span>{{ item.title ?? item.label }}</span>
                            </slot>
                        </div>
                        <slot name="group" :item="item">
                            <el-row :gutter="0">
                                <template v-if="(item?.child?.length ?? 0 > 0)" v-for="(m, i) in item.child" :key="'group_item_'+i">
                                    <template v-if="(m?.hide ?? false) !== true">
                                        <YzPageFormItem :form-items="[m]" :page-data="pageData" :col="col"
                                            :options="options"></YzPageFormItem>
                                    </template>
                                </template>
                            </el-row>
                        </slot>
                    </div>
                </template>
                <template v-else-if="item.formType == PageFormType.Input">
                    <el-col :span="cols">
                        <el-form-item  :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-input v-model="pageData[item.fieldName]"  :disabled="true"
                                :placeholder="item?.placeholder ?? '请输入' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType == PageFormType.Amount">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label"  :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-input :type="'number'" v-model="pageData[item.fieldName]" :disabled="true"
                                :placeholder="item?.placeholder ?? '请输入' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType == PageFormType.NumberInput">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-input :disabled="true" :type="'number'" v-model="pageData[item.fieldName]"
                                :placeholder="item?.placeholder ?? '请输入' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType == PageFormType.TextAreaInput">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-input :disabled="true" v-model="pageData[item.fieldName]" type="textarea" :rows="4"
                                :placeholder="item?.placeholder ?? '请输入' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Checkbox">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-checkbox-group :disabled="true" v-model="pageData[item.fieldName]" v-bind="item?.comProps ?? {}"
                                v-on="item?.comOn ?? {}">
                                <el-checkbox v-for="(optItem, optIndex) in options[item.fieldName]" :key="optIndex"
                                    :value="optItem.value" :name="item.fieldName">
                                    {{ optItem.label }}
                                </el-checkbox>njn
                            </el-checkbox-group>
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Radio">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-radio-group :disabled="true" v-model="pageData[item.fieldName]" v-bind="item?.comProps ?? {}"
                                v-on="item?.comOn ?? {}">
                                <el-radio v-for="(optItem, optIndex) in (options[item.fieldName] || item.option)"
                                    :key="optIndex" :value="optItem.value">{{
                                        optItem.label
                                    }}</el-radio>
                            </el-radio-group>
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.UploadMultImg">
                    <el-col :span="24">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <yz-upload :disabled="true" :upload-type="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}"
                                :files="pageData[item.fieldName]"></yz-upload>
                        </el-form-item>
                    </el-col>

                </template>
                <template v-else-if="item.formType== PageFormType.UploadOneImg">

                    <el-col :span="24">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <yz-upload :disabled="true" :upload-type="1" :limit="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}"
                                :files="(pageData[item.fieldName] == undefined || pageData[item.fieldName].length == 0) ? [] : [].concat(pageData[item.fieldName]) ?? []"></yz-upload>
                        </el-form-item>
                    </el-col>

                </template>
                <template v-else-if="item.formType== PageFormType.UploadMultFile">
                    <el-col :span="24">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <yz-upload-file :disabled="true" :upload-type="2" v-on="item.comOn ?? {}"
                                v-bind="{ drag: true, multiple: true, ...item.comProps ?? {} }"
                                v-model:list-data="pageData[item.fieldName]">
                            </yz-upload-file>
                        </el-form-item>
                    </el-col>
                </template>
                <!-- <template v-else-if="item.formType== tempFormType.fileDetail">
                    <el-col :span="24">
                        <el-form-item :label="item.title ?? item.label" label-width="200px" class="file-detail-item"
                            :prop="item.fieldName" v-on="item?.on ?? {}">
                            <div class="file-detail" @click.stop="filePreview(pageData[item.fieldName])">
                                <img :src="fileIcon(pageData[item.fieldName])" class="upload-file-icon">
                                {{ pageData[item.fieldName] }}
                            </div>
                        </el-form-item>
                    </el-col>
                </template> -->
                <template v-else-if="item.formType== PageFormType.OneSelect || item.formType== PageFormType.OneSelectSearch">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-select :disabled="true" v-model="pageData[item.fieldName]" filterable @change="(value: any) => {
                                if (item.fieldName.lastIndexOf('Code') == item.fieldName.length - 4) {
                                    if (value) {
                                        pageData[item.fieldName.replace('Code', '')] = options[item.fieldName].filter((m: any) => m.value == value).map((m: any) => m.label).join()
                                    }
                                    else {
                                        pageData[item.fieldName.replace('Code', '')] = ''
                                    }
                                } else {
                                    if (value) {
                                        pageData[item.fieldName + 'Value'] = options[item.fieldName].filter((m: any) => m.value == value).map((m: any) => m.label).join()
                                    }
                                    else {
                                        pageData[item.fieldName + 'Value'] = ''
                                    }
                                }

                            }" suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                                <el-option v-for="(optItem, optIndex) in options[item.fieldName]" :key="optIndex"
                                    :label="optItem.label" :value="optItem.value" />
                            </el-select>
                        </el-form-item>
                    </el-col>

                </template>
                <template v-else-if="item.formType== PageFormType.MultSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-select :disabled="true" v-model="pageData[item.fieldName]" filterable multiple collapseTags @change="(value: any) => {
                                if (item.fieldName.lastIndexOf('Code') == item.fieldName.length - 4) {
                                    if (value) {
                                        pageData[item.fieldName.replace('Code', '')] = options[item.fieldName].filter((m: any) => value.indexOf(m.value) > -1).map((m: any) => m.label)
                                    }
                                    else {
                                        pageData[item.fieldName.replace('Code', '')] = ''
                                    }
                                } else {
                                    if (value) {
                                        pageData[item.fieldName + 'Value'] = options[item.fieldName].filter((m: any) => value.indexOf(m.value) > -1).map((m: any) => m.label)
                                    }
                                    else {
                                        pageData[item.fieldName + 'Value'] = ''
                                    }
                                }

                            }" suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                                <el-option v-for="(optItem, optIndex) in options[item.fieldName]" :key="optIndex"
                                    :label="optItem.label" :value="optItem.value" />
                            </el-select>
                        </el-form-item>
                    </el-col>

                </template>
                <template v-else-if="item.formType== PageFormType.TimeSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-time-picker  :disabled="true"  v-model="pageData[item.fieldName]" suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.TreeSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-cascader :disabled="true" v-model="pageData[item.fieldName]" style="flex:1" suffix-icon="CaretBottom"
                                :options="options[item.fieldName]"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>

                </template>

                <template v-else-if="item.formType== PageFormType.DateSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-date-picker :disabled="true" :format="'YYYY-MM-DD'" :value-format="'YYYY-MM-DD'"
                                @change="(val: any) => console.log(pageData[item.fieldName])" v-model="pageData[item.fieldName]"
                                suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.DateRangeSelect">
                    <el-col :span="cols">
                        <el-form-item  :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}" >
                            <el-date-picker :disabled="true" :format="'YYYY-MM-DD'" :value-format="'YYYY-MM-DD'"
                                @change="(val: any) => {}" v-model="pageData[item.fieldName+'Start']"
                                suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                            至
                            <el-date-picker :disabled="true" :format="'YYYY-MM-DD'" :value-format="'YYYY-MM-DD'"
                                @change="(val: any) =>{} " v-model="pageData[item.fieldName+'End']"
                                suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.DateTimeSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-date-picker :disabled="true" :format="'YYYY-MM-DD HH:mm'" :value-format="'YYYY-MM-DD HH:mm'"
                                type="datetime" @change="(val: any) => console.log(pageData[item.fieldName])"
                                v-model="pageData[item.fieldName]" suffix-icon="CaretBottom"
                                :placeholder="item?.placeholder ?? '请选择' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Stepper">
                </template>
                <template v-else-if="item.formType== PageFormType.Rate">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-rate :disabled="true" v-model="pageData[item.fieldName]" v-bind="item?.comProps ?? {}"
                                v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Slider">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-slider :disabled="true" v-model="pageData[item.fieldName]" v-bind="item?.comProps ?? {}"
                                v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Switch">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-switch :disabled="true" v-model="pageData[item.fieldName]" type="textarea" v-bind="item?.comProps ?? {}"
                                v-on="item?.comOn ?? {}" />
                        </el-form-item>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.Custom">
                    <el-col :span="cols">
                        <slot name="custom" :item="item">
                        </slot>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.LocationSelect">
                    <el-col :span="cols">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName"
                            @click="item.showPicker = true" v-on="item?.on ?? {}">
                            <el-input :disabled="true" v-model="pageData[item.fieldName]" reanonly
                                :placeholder="item?.placeholder ?? '请输入' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                                <template #append>
                                    <el-button :icon="AddLocation" />
                                </template>
                            </el-input>
                        </el-form-item>
                        <location-select v-model:show="item.showPicker"
                            @confirm="(data: any) => locationSelectConfirm(data, item)"></location-select>
                    </el-col>
                </template>
                <template v-else-if="item.formType== PageFormType.AreaSelect">
                    <el-col :span="24">
                        <el-form-item :label="item.title ?? item.label" :prop="item.fieldName" v-on="item?.on ?? {}">
                            <el-input :disabled="true" v-model="pageData[item.fieldName + 'Address']" reanonly
                                :placeholder="item?.placeholder ?? '请输入详细地址' + (item?.title ?? item.label ?? '')"
                                v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                                <template #prepend>
                                    <div @click.stop="item.showPicker = true" style="cursor: pointer;">
                                        {{ !pageData[item.fieldName +
                                            'City'] ? '请选择' : pageData[item.fieldName +
                                            'City'] }}
                                    </div>
                                </template>
                                <template #append>
                                    <el-button @click.stop="item.showPicker = true" :icon="AddLocation" />
                                </template>
                            </el-input>
                        </el-form-item>
                        <yz-address v-model:show="item.showPicker" v-model:model-must="pageData[item.fieldName]"
                            v-model:model-address="pageData[item.fieldName + 'Address']"
                            v-model:model-city="pageData[item.fieldName + 'City']"
                            v-model:model-value="pageData[item.fieldName + 'Data']"></yz-address>
                    </el-col>
                </template>
            </slot>
        </template>
    </template>
</template>
<script setup lang='ts'>
import { computed } from 'vue';
import { PageFormGroup, PageFormType, type TempEditForm, type TempFormItemOption, type TempFormTreeOption } from '@/components/PageForm';
import { tempFormType } from '.';
import { AddLocation } from '@element-plus/icons-vue'
import YzPageFormItem from '@/components/common/YzPageForm/item.vue';
import YzUpload from '@/components/common/YzUpload/YzUpload.vue';
import YzUploadFile from '@/components/common/YzUploadFile/YzUploadFile.vue';
import LocationSelect from '@/components/common/LocationSelect/LocationSelect.vue';
import YzAddress from '@/components/common/YzAddress/YzAddress.vue';

interface LocationDto {
    address: string;
    city: string;
    province: string;
    region: string;
    code: string;
    lng: string;
    lat: string;
}

const filePreview = async (url: any) => {
    // await perviewOssFile(url)
}
const locationSelectConfirm = (val: any, item: any) => {
    item.showPicker = false;
    const city = (val.other.province ?? '') + (val.other.city ?? '') + (val.other.district ?? '');
    pageData[item.fieldName + '_City'] = city;
    pageData[item.fieldName + '_Address'] = val.address;
    pageData[item.fieldName] = val.address;
    const location: LocationDto = {
        address: (val.address ?? '').replace(city, ''),
        city: val.other.city ?? '',
        province: val.other.province ?? '',
        region: val.other.district ?? '',
        code: val.other.adcode ?? '',
        lng: String(val.lng ?? ''),
        lat: String(val.lat ?? '')
    }
    pageData[item.fieldName + '_Data'] = location;
}
const fileIcon = (fileName: string) => {
    if (!fileName) return '';
    const ext = fileName.split('.').pop()?.toLowerCase();
    const filePath = '/imgs/common/';
    switch (ext) {
        case 'doc':
        case 'docx':
            return filePath + 'word.png';
        case 'xls':
        case 'xlsx':
            return filePath + 'excel.png';
        case 'ppt':
        case 'pptx':
            return filePath + 'ppt.png';
        case 'pdf':
            return filePath + 'pdf.png';
        case 'jpg':
        case 'jpeg':
        case 'png':
        case 'gif':
            return filePath + 'img.png';
        case 'zip':
        case '7z':
        case 'rar':
        case 'tgz':
            return filePath + 'compress.png';
        case 'txt':
            return filePath + 'def.png';
        default:
            return filePath + 'def.png';
    }
};
const cols = computed(() => {
    return 24 / (col ?? 1);
})
const { formItems, col, pageData, options } = defineProps<{
    formItems: TempEditForm[];
    pageData: Record<string, any>;
    col: number;
    options: Record<string, TempFormItemOption[] | TempFormTreeOption[]>;
}>()
</script>
<style lang='less' scoped></style>