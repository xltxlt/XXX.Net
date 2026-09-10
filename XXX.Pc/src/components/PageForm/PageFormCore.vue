<script setup lang='ts'>
import type { TempEditForm } from '.';
import { tempFormType, PageFormType } from '.';
import type { TempEditPageData } from '.';
import type { LocationDto } from '.';
import { computed, ref } from 'vue';
import YzUpload from '../common/YzUpload/YzUpload.vue';
import YzUploadFile from '../common/YzUploadFile/YzUploadFile.vue';
import YzAddress from '../common/YzAddress/YzAddress.vue';
import LocationSelect from '../common/LocationSelect/LocationSelect.vue';
import { ElColorPicker } from 'element-plus'
import { AddLocation } from '@element-plus/icons-vue'
import { ElDialog } from 'element-plus';
import SelectIcon from '@/components/common/SelectIcon/SelectIcon.vue';
import OptionEditor from '../common/OptionEditor/OptionEditor.vue';
import { isEmptyVal } from '@/utils/is.ts';

const props = defineProps<{
    item: TempEditForm;
    tempForm: TempEditPageData;
    tempFormData: any;
    cols?: number;
    index?:number|string|undefined;
    fieldName?:string;
}>()
const predefineColors = ref([
    '#FA5151', '#FA9D3B', '#FFC300',
    '#91D300', '#95EC69', '#07C160',
    '#10AEFF', '#1485EE', '#6467F0',
    '#576B95', '#ff4500',
    '#ff8c00',
    '#ffd700',
    '#90ee90',
    '#00ced1',
    '#1e90ff',
    '#c71585',
    'rgba(255, 69, 0, 0.68)',
    'rgb(255, 120, 0)',
    'hsv(51, 100, 98)',
    'hsva(120, 40, 94, 0.5)',
    'hsl(181, 100%, 37%)',
    'hsla(209, 100%, 56%, 0.73)',
    '#c7158577',
]);
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
const filePreview = async (url: any) => {

}

const locationSelectConfirm = (val: any, item: any) => {
    item.showPicker = false;
    const city = (val.other.province ?? '') + (val.other.city ?? '') + (val.other.district ?? '');
    props.tempFormData[item.fieldName + '_City'] = city;
    props.tempFormData[item.fieldName + '_Address'] = val.address;
    props.tempFormData[item.fieldName] = val.address;
    const location: LocationDto = {
        address: (val.address ?? '').replace(city, ''),
        city: val.other.city ?? '',
        province: val.other.province ?? '',
        region: val.other.district ?? '',
        code: val.other.adcode ?? '',
        lng: String(val.lng ?? ''),
        lat: String(val.lat ?? '')
    }
    props.tempFormData[item.fieldName + '_Data'] = location;
}
const getPropName=computed(()=>{
    if(isEmptyVal(props.fieldName) )
        return props.item.fieldName;
    else
        return  `${props.fieldName}.${props.index}.${props.item.fieldName}`;
});
</script>
<template>
    <template v-if="item.formType == PageFormType.Input">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName" v-on="item?.on ?? {}">
                <el-input v-model="tempFormData[item.fieldName]"
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Number">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName" v-on="item?.on ?? {}">
                <!-- <el-input :type="'number'" v-model="tempFormData[item.fieldName]" -->
                <el-input :type="'number'" v-model="tempFormData[item.fieldName]"
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.DecimalInput">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName" v-on="item?.on ?? {}">
                <el-input :type="'number'" v-model="tempFormData[item.fieldName]" :precision="2" :step="0.1"
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.TextAreaInput">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-input v-model="tempFormData[item.fieldName]" :rows="4" type="textarea"
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Checkbox">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-checkbox-group v-model="tempFormData[item.fieldName]" v-bind="item?.comProps ?? {}"
                    v-on="item?.comOn ?? {}">
                    <el-checkbox v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :value="optItem.value" :name="item.fieldName">
                        {{ optItem.label }}
                    </el-checkbox>
                </el-checkbox-group>
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Radio">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-radio-group v-model="tempFormData[item.fieldName]" v-bind="item?.comProps ?? {}"
                    v-on="item?.comOn ?? {}">
                    <el-radio v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :value="optItem.value" border>{{ optItem.label }}</el-radio>
                </el-radio-group>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.Color">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-color-picker v-model="tempFormData[item.fieldName]" show-alpha :predefine="predefineColors" />
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.UploadOneImg">
        <el-col :span="24">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <yz-upload :upload-type="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}"
                    :files="tempFormData[item.fieldName]"></yz-upload>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.UploadMultImg">

        <el-col :span="24">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">

                <yz-upload :upload-type="1" :limit="1" v-on="item.comOn ?? {}" v-bind="item.comProps ?? {}"
                    :files="(tempFormData[item.fieldName]) ? ([].concat(tempFormData[item.fieldName]) ?? []) : []"></yz-upload>
            </el-form-item>
        </el-col>

    </template>


    <template v-else-if="item.formType == PageFormType.UploadMultFile">
        <el-col :span="24">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-upload class="upload-demo" drag multiple v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <el-icon class="el-icon--upload"><upload-filled /></el-icon>
                    <div class="el-upload__text">
                        拖动文件到此处或 <em>点击上传</em>
                    </div>
                    <template #tip v-if="item.placeholder">
                        <div class="el-upload__tip">
                            {{ item.placeholder }}
                        </div>
                    </template>
                </el-upload>
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.OneSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-select v-model="tempFormData[item.fieldName]" suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <el-option v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :label="optItem.label" :value="optItem.value" />
                </el-select>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.OneSelectSearch">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-select v-model="tempFormData[item.fieldName]" filterable suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <el-option v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :label="optItem.label" :value="optItem.value" />
                </el-select>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.CustomOptions">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <OptionEditor v-model="tempFormData[item.fieldName]"></OptionEditor>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.MultSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-select v-model="tempFormData[item.fieldName]" filterable multiple collapseTags
                    suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <el-option v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :label="optItem.label" :value="optItem.value" />
                </el-select>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.MultSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-select v-model="tempFormData[item.fieldName]" filterable multiple collapseTags
                    suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <el-option v-for="(optItem, optIndex) in tempForm.options[item.fieldName]" :key="optIndex"
                        :label="optItem.label" :value="optItem.value" />
                </el-select>
            </el-form-item>
        </el-col>

    </template>
    <template v-else-if="item.formType == PageFormType.TimeSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-time-picker v-model="tempFormData[item.fieldName]" suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.TreeSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-cascader v-model="tempFormData[item.fieldName]" :checkStrictly ='true'  :options="tempForm.options[item.fieldName]"
                    style="flex:1" :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    :props="{
                        checkStrictly: true,
                    }"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.TreeSelectLast">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-tree-select v-model="tempFormData[item.fieldName]" :data="tempForm.options[item.fieldName]" :render-after-expand="false"  :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}"  />
            </el-form-item>
        </el-col>
    </template>

    <template v-else-if="item.formType == PageFormType.DateSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-date-picker :format="'YYYY-MM-DD'" :value-format="'YYYY-MM-DD'" suffix-icon="CaretBottom"
                    v-model="tempFormData[item.fieldName]"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.DateTimeSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-date-picker :format="'YYYY-MM-DD HH:mm'" :value-format="'YYYY-MM-DD HH:mm'" type="datetime"
                    @change="(val: any) => console.log(tempFormData[item.fieldName])"
                    v-model="tempFormData[item.fieldName]" suffix-icon="CaretBottom"
                    :placeholder="item?.placeholder ?? '请选择' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.MapSelect">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName" @click="item.showPicker = true">
                <el-input v-model="tempFormData[item.fieldName]" reanonly
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
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
    <template v-else-if="item.formType == PageFormType.Stepper">
    </template>
    <template v-else-if="item.formType == PageFormType.Rate">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-rate v-model="tempFormData[item.fieldName]" v-bind="item?.comProps ?? {}"
                    v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Slider">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-slider v-model="tempFormData[item.fieldName]" v-bind="item?.comProps ?? {}"
                    v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Switch">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-switch v-model="tempFormData[item.fieldName]" type="textarea" v-bind="item?.comProps ?? {}"
                    v-on="item?.comOn ?? {}" />
            </el-form-item>
        </el-col>
    </template>
    <template v-else-if="item.formType == PageFormType.Icon">
        <el-col :span="cols">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-input v-model="tempFormData[item.fieldName]"
                    :placeholder="item?.placeholder ?? '请输入' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" @click="item.showPicker = true" />

                <el-dialog v-model="item.showPicker" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}" draggable
                    width="700px">
                    <template #header>
                        选择图标
                    </template>
                    <SelectIcon v-on:select-icon="(val: string) => {
                        tempFormData[item.fieldName] = val;
                        item.showPicker = false;
                    }
                    "></SelectIcon>
                </el-dialog>
            </el-form-item>
        </el-col>
    </template>

    <template v-else-if="item.formType == PageFormType.LocationSelect">
        <el-col :span="24">
            <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                <el-input v-model="tempFormData[item.fieldName + 'Address']" style="min-width: 30%;"
                    :placeholder="item?.placeholder ?? '请输入详细地址' + (item.label ?? item?.title ?? '')"
                    v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                    <template #prepend>
                        <div @click.stop="item.showPicker = true" style="cursor: pointer;">
                            {{ !tempFormData[item.fieldName + 'City'] ? '请选择' :
                                tempFormData[item.fieldName +
                                'City'] }}
                        </div>
                    </template>
                    <template #append>
                        <el-button @click.stop="item.showPicker = true" :icon="AddLocation" />
                    </template>
                </el-input>
            </el-form-item>
            <yz-address v-model:show="item.showPicker" v-model:model-must="tempFormData[item.fieldName]"
                v-model:model-address="tempFormData[item.fieldName + 'Address']"
                v-model:model-city="tempFormData[item.fieldName + 'City']"
                v-model:model-value="tempFormData[item.fieldName + 'Data']"></yz-address>
        </el-col>
    </template>

    <template v-else-if="item.formType == PageFormType.Custom">
        <el-col :span="cols">
            <!-- <el-form-item :label="item.title ?? item.label" :prop="getPropName">
                                    <component :is="m.com" v-bind="item?.comProps ?? {}" v-on="item?.comOn ?? {}">
                                    </component>
                                </el-form-item> -->
            <slot name="custom" :item="item"></slot>
        </el-col>
    </template>
</template>
<style lang='less' scoped></style>