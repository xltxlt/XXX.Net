<template>
    <div class="yz-matter-form" ref="YzMatterFormRef">
        <div class="yz-matter-form-group">
            <el-collapse :expand-icon-position="'left'" v-model="activeNames">
                <template v-for="(item, index) in groupList" :key="index">
                    <el-collapse-item :title="item.label" :name="index" :is-open="true">
                        <div class="yz-matter-form-items noselect">
                            <div class="yz-matter-form-item" draggable="true"
                                @dragstart.self.stop="(event) => pageFun.drag(event, m)"
                                v-for="(m, i) in item.children">
                                <img draggable="false" v-if="m.icon" :src="m.icon" alt="" />
                                {{ m.label }}
                            </div>
                        </div>
                    </el-collapse-item>
                </template>
            </el-collapse>

        </div>
        <div class="yz-matter-form-setup">
            {{ tempPageForm.form }}
            <div class="yz-matter-form-setup-content" @drop="(event) => pageFun.drop(event, true)"
                @dragover="(event) => pageFun.allowDrop && pageFun.allowDrop(event)">
                <slot name="content">
                    <div class="yz-matter-form-setup-form">

                        <page-form :temp-form="tempPageForm"></page-form>
                        <!-- <YzPageForm :temp-form="tempPageForm"  style="padding:0 25px 50px ;">
                            <template #customType="{ item }">
                                <slot name="customType" :item="item"></slot>
                            </template>
                        </YzPageForm> -->
                    </div>
                    <slot name="otherContent">
                    </slot>
                    <div class="yz-matter-form-setup-tools">
                        <el-button @click="pageFun.release" style=" text-align: center;" type="success" size="large"
                            plain>确认</el-button>
                    </div>
                </slot>

            </div>

        </div>

        <div class="yz-matter-form-attr" v-if="thisComponent != null && thisComponent.length > 0">
            <div class="yz-matter-form-attr-header">组件属性配置</div>
            <div class="yz-matter-form-attr-content">
                <div class="yz-matter-form-attr-items">
                    <div class="yz-matter-form-attr-item" :class="{
                        'yz-matter-form-attr-must': item.required
                    }" v-for="(item, index) in thisComponent.filter(m => m.show !== false) ?? []" :key="index">
                        <div class="yz-matter-form-attr-label">{{ item.label }}</div>
                        <div class="yz-matter-form-attr-value">
                            <template v-if="item.type === PageFormType.Input && item.name == 'title'">
                                <el-input :readonly="item.readonly === true" :disabled="item.readonly === true"
                                    v-model="item.value" @input="(val: string) => {
                                        thisFormItem && (thisFormItem.title = val);
                                        emits('changeTitle', thisComponentIdent ?? '', val);
                                    }" :placeholder="'请输入' + item.label" clearable />
                            </template>
                            <template v-else-if="item.type === PageFormType.Input && item.name == 'code'">
                                <el-input :readonly="item.readonly === true" :disabled="item.readonly === true"
                                    v-model="item.value" @change="(val: string) => console.log(val)" @input="(val: string) => {
                                        thisFormItem && (thisFormItem.code = val);
                                    }" :placeholder="'请输入' + item.label" clearable />
                            </template>
                            <template v-else-if="item.type === PageFormType.Input">
                                <el-input :readonly="item.readonly === true" :disabled="item.readonly === true" @input="(val: string) => {
                                    pageFun.changeAttrVal(thisComponentIdent ?? '', val, item)
                                }" v-model="item.value" :placeholder="'请输入' + item.label" clearable />
                            </template>
                            <template v-else-if="item.type === PageFormType.Amount">
                                <el-input :readonly="item.readonly === true" :disabled="item.readonly === true" @input="(val: string) => {
                                    pageFun.changeAttrVal(thisComponentIdent ?? '', val, item)
                                }" v-model="item.value" :placeholder="'请输入' + item.label" clearable />
                            </template>
                            <template v-else-if="item.type === PageFormType.Number">
                                <el-input :readonly="item.readonly === true" :disabled="item.readonly === true" @input="(val: string) => {
                                    pageFun.changeAttrVal(thisComponentIdent ?? '', val, item)
                                }" v-model="item.value" :type="'number'" :placeholder="'请输入' + item.label" clearable />
                            </template>
                            <template v-else-if="item.type === PageFormType.Radio">
                                <el-radio-group :disabled="item.readonly === true" v-model="item.value" size="large"
                                    fill="#6cf">
                                    <el-radio-button v-for="(m, i) in item.data" :label="m.title || m.label"
                                        :value="m.value" :key="i" />
                                </el-radio-group>
                            </template>
                            <template v-else-if="item.type === PageFormType.Switch">
                                <el-switch :disabled="item.readonly === true" v-model="item.value" />
                            </template>
                            <template v-else-if="item.type === PageFormType.TimeSelect">
                                <el-date-picker :readonly="item.readonly === true" v-model="item.value" type="datetime"
                                    :placeholder="'请选择' + item.label" />
                            </template>
                            <template v-else-if="item.type === PageFormType.DateSelect">
                                <el-date-picker :readonly="item.readonly === true" v-model="item.value" type="date"
                                    :placeholder="'请选择' + item.label" />
                            </template>
                            <template v-else-if="item.type === PageFormType.OneSelectSearch">
                                <el-select :disabled="item.readonly === true" v-model="item.value"
                                    :placeholder="'请选择' + item.label">
                                    <el-option v-for="(m, i) in item.data" :key="i" :label="m.title || m.label"
                                        :value="m.value" />
                                </el-select>
                            </template>
                            <template v-else-if="item.type === PageFormType.MultSelect">
                                <el-select :disabled="item.readonly === true" v-model="item.value" multiple
                                    :placeholder="'请选择' + item.label">
                                    <el-option v-for="(m, i) in item.data" :key="i" :label="m.title || m.label"
                                        :value="m.value" />
                                </el-select>
                            </template>
                            <template v-else>
                                <slot name="customCard" :item></slot>
                            </template>
                        </div>
                    </div>
                </div>
            </div>

            <div class="yz-matter-form-attr-footer">
                <el-button type="primary" @click="() => {
                    pageFun.moveProv(thisComponentIdent ?? '', thisFormItem?.pIdent ?? '')
                }">上移</el-button>
                <el-button type="success" @click="() => {
                    pageFun.moveNext(thisComponentIdent ?? '', thisFormItem?.pIdent ?? '')
                }">下移</el-button>
                <el-button>重置</el-button>
                <el-button type="danger" @click="() => {
                    pageFun.delComponentByIdent(thisComponentIdent ?? '')
                }">删除</el-button>

            </div>
        </div>

    </div>
</template>
<script setup lang='ts'>
import { computed, ref, onUnmounted, nextTick } from 'vue'
import PageForm from '@/components/PageForm/PageForm.vue'
import { PageFormGroup, PageFormType } from '@/components/PageForm/index.ts'
import YzPageForm from '@/components/Common/YzPageForm/index.vue'
import type { componentGroup, componentItem, componentAttr, componentAttrData, ReleaseData, formItemOption, PageFun, matterEmits, matterExpose, componentForm, pageComponentFormData } from './index.ts'
import { defaultAttr, defaultGroupAttr, defaultSelectAttr, defaultTimeAttr, defaultUploadAttr, formType } from './index.ts'
import { ElMessage } from 'element-plus'
import { getUniqueValue } from '@/utils/common.ts'
import { isArray, isEmptyVal, isString } from '@/utils/is.ts'
const emits = defineEmits<matterEmits>()

const YzMatterFormRef = ref();
const draging = ref<boolean>(false);
const dragItem = ref<componentItem | null>();

const { componentGroupList, attrData, form } = defineProps<{ componentGroupList: componentGroup[], form: componentForm[], attrData: Record<string, componentAttrData[]> }>();
const tempPageForm = computed<pageComponentFormData>(() => {
    pageFun.setComOn(form);

    return {
        design: true,
        loading: false,
        hideBtn: true,
        cols: 1,
        form: form ?? [],
        rules: {
            input: [{ required: true, }],
        },
        formData: {},
        options: {},
    }
})
const groupList = computed(() => {
    return componentGroupList;
})
const activeNames = ref(Array.from({ length: componentGroupList.length - 1 }, (v, k) => k));
const componentAttrList = computed(() => {
    return attrData ?? [];
})
const thisComponent = computed(() => {
    return componentAttrList.value[thisComponentIdent.value ?? ''] ?? [];
});
const thisFormItem = computed(() => {
    // const thisItem = tempPageForm.value.form.find(m => m.ident == thisComponentIdent.value);
    // if (thisItem == null || thisItem == undefined) {
    //     // 优化查找当前表单项的逻辑
    //     return tempPageForm.value.form.flatMap(m => m.child ?? [])
    //         .find(item => item.ident === thisComponentIdent.value)
    //         ;
    // }
    const thisItem = pageFun.findParentComponent(thisComponentIdent.value ?? '', tempPageForm.value.form)
    return thisItem;
});
const thisComponentIdent = ref<string>();
// 存储事件处理器的引用
let mouseMoveHandler: ((event: MouseEvent) => void) | null = null;
let mouseUpHandler: (() => void) | null = null;
let contextMenuHandler: ((event: Event) => void) | null = null;
const pageFun: PageFun = {
    loadData: async () => {

    },
    allowDrop: (ev: any) => {
        ev.preventDefault();
    },
    drag: (ev: any, item: any = null) => {
        draging.value = true;
        dragItem.value = item;
        ev.dataTransfer.setData("Text", ev.target.id);
    },
    drop: (ev: any, root: boolean = false, ident: string = '', isPreview: boolean = false): void => {
        ev.preventDefault();
        const customAddItem = emits('addItem', root, dragItem.value, ev.target, ident, tempPageForm.value);
        if (customAddItem === false) {
            draging.value = false;
            dragItem.value = null;
            return;
        }
        if (root == true && dragItem.value != null && dragItem.value.isIndependent == false) {
            dragItem.value = null;
            ElMessage.error('请选择基础类型组件请放置在分组块中');
            return;
        }
        if (root == false && dragItem.value != null && dragItem.value.isPreview == true && isPreview) {
            ElMessage.error('预览分组块组件请放置在最外层或中');
            dragItem.value = null;
            return;
        }
        if ((root == false && dragItem.value != null && dragItem.value.isIndependent == true && !dragItem.value.isPreview) && isPreview != true) {
            ElMessage.error('请选择分组类型组件请放置在最外层或预览分组中');
            dragItem.value = null;
            return;
        }
        pageFun.moveChildByIdent(dragItem.value, ident);
        // pageFun.moveChildToParent(dragItem.value, ev.target, ident);
        draging.value = false;
        dragItem.value = null;
    },
    moveProv: (ident: string, pIdent: string) => {
        if (isEmptyVal(ident)) return;
        if (isEmptyVal(pIdent)) {
            var tItem = pageFun.findParentComponent(ident, tempPageForm.value.form);
            if (tempPageForm.value.form && tItem) {
                var i = tempPageForm.value.form.findIndex(m => m.ident == ident);
                if (i > -1 && tItem) {
                    tempPageForm.value.form.splice(i, 1);
                    tempPageForm.value.form.splice(i - 1, 0, tItem);
                }
            }

        }
        else {
            var pItem = pageFun.findParentComponent(pIdent, tempPageForm.value.form);
            if (pItem != null && pItem.child != null) {
                var index = pItem.child.findIndex(m => m.ident == ident);
                var item = pItem.child.find(m => m.ident == ident);
                if (index - 1 > -1 && item) {
                    pItem.child.splice(index, 1);
                    pItem.child.splice(index - 1, 0, item);
                }
            }
        }
    },
    moveNext: (ident: string, pIdent: string) => {
        if (isEmptyVal(ident)) return;
        if (isEmptyVal(pIdent)) {
            var tItem = pageFun.findParentComponent(ident, tempPageForm.value.form);
            if (tempPageForm.value.form && tItem) {
                var i = tempPageForm.value.form.findIndex(m => m.ident == ident);
                console.log(i, tItem);
                if (i > -1 && tItem) {
                    tempPageForm.value.form.splice(i, 1);
                    tempPageForm.value.form.splice(i + 1, 0, tItem);
                    console.log(tempPageForm.value.form);
                }
            }

        }
        else {
            var pItem = pageFun.findParentComponent(pIdent, tempPageForm.value.form);
            if (pItem != null && pItem.child != null) {
                var index = pItem.child.findIndex(m => m.ident == ident);
                var item = pItem.child.find(m => m.ident == ident);
                if (index > -1 && item) {
                    pItem.child.splice(index, 1);
                    pItem.child.splice(index + 1, 0, item);
                }
            }
        }
    },
    moveChildToParent: (item: componentItem | undefined | null, toEle: HTMLElement, toIdent: string = ''): void => {
        if (tempPageForm.value.form == null || tempPageForm.value.form == undefined) {
            tempPageForm.value.form = [];
        }
        if (!item) return;
        const ident = getUniqueValue();
        (componentAttrList.value ?? {})[ident] = item.attr.map(m => {
            if (isArray(m.data) || (m.data ?? []).length > 0) {
                const defaultList = (m.data ?? []).filter(m => m.isDefault).map(m => m.value);
                if (defaultList.length > 0 && m.type == PageFormType.OneSelectSearch) {
                    m.value = defaultList.pop()
                }
                if (defaultList.length > 0 && m.type == PageFormType.MultSelect) {
                    m.value = defaultList
                }
            }
            console.log(m, item)
            if (m.code == 'label') {
                m.value = item.label + '';
            }
            let obj = {
                ident: getUniqueValue(),
                pIdent: ident,
                label: m.label,
                name: m.code,
                value: m.value ?? '',
                type: m.type,
                data: m.data,
                show: m.show,
                readonly: m.readonly,
                required: m.required
            }
            return obj;
        });
        let title = item.label ?? '';
        if (item.isIndependent == true && item.isPreview != true) {
            const itemConfig = {
                formType: PageFormGroup.Group,
                fieldName: '',
                label: isString(title) ? title : '',
                child: [],
                ident: ident,
                comProps: {
                    ident: ident
                },
                comOn: {
                    drop: (event: any) => {
                        event.stopPropagation();
                        pageFun.drop(event, false, ident);
                    },
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = ident;
                    },
                    dragover: (event: any) => {
                        event.stopPropagation();  // 相当于 .stop
                        event.preventDefault();
                        // 检查事件是否在当前元素本身触发（相当于 .self）
                        if (event.srcElement === event.currentTarget) {
                            pageFun.allowDrop && pageFun.allowDrop(event);
                        }
                    }
                }
            }
            console.log(itemConfig)
            tempPageForm.value.form.push(itemConfig);
        }
        else if (item.isIndependent == true && item.isPreview == true) {
            const itemConfig = {
                formType: PageFormGroup.Group,
                fieldName: '',
                label: isString(title) ? title : '',
                child: [],
                ident: ident,
                comProps: {
                    ident: ident
                },
                comOn: {
                    drop: (event: any) => {
                        event.stopPropagation();
                        pageFun.drop(event, false, ident, true);
                    },
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = ident;
                    },
                    dragover: (event: any) => {
                        event.stopPropagation();  // 相当于 .stop
                        event.preventDefault();
                        // 检查事件是否在当前元素本身触发（相当于 .self）
                        if (event.srcElement === event.currentTarget) {
                            pageFun.allowDrop && pageFun.allowDrop(event);
                        }
                    }
                }
            }
            tempPageForm.value.form.push(itemConfig);
        }
        else if (toIdent) {
            tempPageForm.value.form.forEach(m => {
                if (m.ident == toIdent) {
                    const itemConfig = {
                        ident: ident,
                        pIdent: toIdent,
                        props: {
                            ident: ident
                        },
                        on: {
                            click: (event: any) => {
                                event.stopPropagation();
                                event.preventDefault();
                                thisComponentIdent.value = ident;
                            }
                        },
                        label: isString(title) ? title : '',
                        formType: item.type,
                        fieldName: ""
                    };
                    (m.child == null || m.child == undefined) ? m.child = [itemConfig] : m.child.push(itemConfig);
                }
            })
        }

    },
    moveChildByIdent: (item: componentItem | undefined | null, toIdent: string = ''): void => {
        if (tempPageForm.value.form == null || tempPageForm.value.form == undefined) {
            tempPageForm.value.form = [];
        }
        if (!item) return;
        const ident = getUniqueValue();
        let name = '';
        (componentAttrList.value ?? {})[ident] = item.attr.map(m => {
            if (isArray(m.data) || (m.data ?? []).length > 0) {
                const defaultList = (m.data ?? []).filter(m => m.isDefault).map(m => m.value);
                if (defaultList.length > 0 && m.type == PageFormType.OneSelectSearch) {
                    m.value = defaultList.pop()
                }
                if (defaultList.length > 0 && m.type == PageFormType.MultSelect) {
                    m.value = defaultList
                }
            }
            if (m.code == 'title') {
                m.value = item.label + '';
            }
            if (m.code === 'code' && !isEmptyVal(m.value)) {
                name = m.value ?? '';
            }
            let obj = {
                ident: getUniqueValue(),
                pIdent: ident,
                label: m.label,
                name: m.code,
                value: m.value ?? '',
                type: m.type,
                data: m.data,
                show: m.show,
                readonly: m.readonly,
                required: m.required
            }
            return obj;
        });
        let title = item.label ?? '';
        var child: any[] = [];

        if (isEmptyVal(toIdent)) {
            tempPageForm.value.form.push({
                formType: item.type,
                fieldName: '',
                label: isString(title) ? title : '',
                child: child || [],
                ident: ident,
                pIdent: toIdent,
                comProps: {
                    ident: ident
                },
                option: item.options,
                comOn: {
                    drop: (event: any) => {
                        event.stopPropagation();
                        pageFun.drop(event, false, ident, item.isPreview);
                    },
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = ident;
                    },
                    dragover: (event: any) => {
                        event.stopPropagation();  // 相当于 .stop
                        event.preventDefault();
                        // 检查事件是否在当前元素本身触发（相当于 .self）
                        if (event.srcElement === event.currentTarget) {
                            pageFun.allowDrop && pageFun.allowDrop(event);
                        }
                    }
                }
            });
        }
        else {
            const parentFormItem = pageFun.findParentComponent(toIdent, tempPageForm.value.form);
            if (parentFormItem == null) {
                ElMessage.error('未找到目标组件');
            }
            (parentFormItem?.child ?? []).push({
                formType: item.type,
                fieldName: name,
                title: isString(title) ? title : '',
                child: child || [],
                pIdent: toIdent,
                ident: ident,
                option: item.options,
                comProps: {
                    ident: ident
                },
                comOn: item.isIndependent ?
                    {
                        drop: (event: any) => {
                            event.stopPropagation();
                            pageFun.drop(event, false, ident, item.isPreview);
                        },
                        click: (event: any) => {
                            event.stopPropagation();
                            event.preventDefault();
                            thisComponentIdent.value = ident;
                        },
                        dragover: (event: any) => {
                            event.stopPropagation();  // 相当于 .stop
                            event.preventDefault();
                            // 检查事件是否在当前元素本身触发（相当于 .self）
                            if (event.srcElement === event.currentTarget) {
                                pageFun.allowDrop && pageFun.allowDrop(event);
                            }
                        }
                    } : {

                    },
                on: !item.isIndependent ? {
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = ident;
                    }
                } : {
                }
            });
            console.log(parentFormItem);
        }
    },
    findParentComponent: (toIdent: string, list: componentForm[]) => {
        let parentItem = null;
        list.forEach(m => {
            if (m.ident === toIdent) {
                parentItem = m;
            }
            else if (m.child && m.child.length > 0) {
                let childParent = pageFun.findParentComponent(toIdent, m.child);
                if (childParent) {
                    parentItem = childParent;
                    return parentItem;
                }
            }
        })
        return parentItem;
    },

    delComponentByIdent: (ident: string) => {
        if (isEmptyVal(ident)) return;
        nextTick(() => {
            delete componentAttrList.value[ident];
            let item = pageFun.findParentComponent(ident, tempPageForm.value.form);
            if (isEmptyVal(item?.pIdent)) {
                tempPageForm.value.form = tempPageForm.value.form.filter(m => m.ident !== ident);
            }
            else {
                let parentItem = pageFun.findParentComponent(item?.pIdent ?? '', tempPageForm.value.form);
                parentItem && (parentItem.child = (parentItem.child ?? []).filter(m => m.ident !== ident));

            }
        })

    },
    delComponent: (ident: string | null | undefined) => {
        if (!ident) return;
        delete componentAttrList.value[ident];
        const rootItem = tempPageForm.value.form.find(item => item.ident === ident);
        if (rootItem) {
            tempPageForm.value.form = tempPageForm.value.form.filter(m => m.ident !== ident);
        }
        else {
            const childItem = tempPageForm.value.form.flatMap(m => (m.child ?? []).map(item => ({ ...item, pIdent: m.ident })))
                .find(item => item.ident === thisComponentIdent.value)
                ;
            if (childItem) {
                let item = tempPageForm.value.form.find(m => m.ident === childItem.pIdent);
                item && (item.child = (item.child ?? []).filter(m => m.ident !== childItem.ident));
            }
        }
        thisComponentIdent.value = '';
        emits('delComponent', ident)
    }
    ,
    getData: (): ReleaseData => {
        const data = {
            form: tempPageForm.value.form,
            attrData: componentAttrList.value
        }
        return data;
    },
    release: (): void => {
        const verifyData = pageFun.verify();
        if (verifyData.componentItem) {
            ElMessage.error("请完善" + (verifyData.componentItem?.pTitle ?? (verifyData.formItem?.label ?? '')) + "的" + verifyData.componentItem.label + "信息");
            return;
        }
        emits('release', pageFun.getData());
    },
    verify: (): {
        formItem: componentForm | null,
        componentItem: componentAttrData | null
    } => {
        const entries = Object.entries(componentAttrList.value);
        let errorItem: componentAttrData | null = null;
        for (const [key, attrs] of entries) {
            const item = attrs.find(m => m.required && isEmptyVal(m.value));
            if (item) {
                errorItem = item;
                break;
            }
        }
        const item = pageFun.findParentComponent(errorItem?.pIdent ?? '', tempPageForm.value.form);
        return {
            formItem: item ?? null,
            componentItem: errorItem
        }
    },
    getDragItem: (): componentItem | null => {
        return dragItem.value ?? null;
    },
    clearDraging: (): void => {
        dragItem.value = null;
        draging.value = false;
    },
    setThisComponent: (ident: string) => {
        thisComponentIdent.value = ident;
    },
    setComponentAttr: (ident: string, attrData: componentAttrData[]) => {
        (componentAttrList.value ?? [])[ident] = attrData;
    }
    ,
    changeAttrVal: (ident: string, val: string | string[], item: componentAttrData) => {
        emits('changeAttrVal', ident, val, item);
    },
    setComOn: (tempFormList: componentForm[]) => {
        tempFormList.forEach(m => {
            if (m.formType === PageFormGroup.Group || m.formType === PageFormGroup.Table || m.formType === PageFormGroup.PreviewGroup || m.formType === PageFormGroup.List || m.formType === PageFormGroup.Table) {
                m.comOn = {
                    drop: (event: any) => {
                        const item = componentGroupList.flatMap(m => m.children).find(item => item.type === m.formType);
                        event.stopPropagation();
                        pageFun.drop(event, false, m.ident, item?.isPreview ?? false);
                    },
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = m.ident;
                    },
                    dragover: (event: any) => {
                        event.stopPropagation();  // 相当于 .stop
                        event.preventDefault();
                        // 检查事件是否在当前元素本身触发（相当于 .self）
                        if (event.srcElement === event.currentTarget) {
                            pageFun.allowDrop && pageFun.allowDrop(event);
                        }
                    }
                }
            }
            else {
                m.on = {
                    click: (event: any) => {
                        event.stopPropagation();
                        event.preventDefault();
                        thisComponentIdent.value = m.ident;
                    }
                }
            }
            if (m.child && m.child.length > 0) {
                pageFun.setComOn(m.child);
            }
        })
    }

}
// 清理所有事件监听器
const cleanupEventListeners = () => {
    if (contextMenuHandler) {
        document.removeEventListener('contextmenu', contextMenuHandler)
        contextMenuHandler = null
    }

    if (mouseMoveHandler) {
        document.removeEventListener('mousemove', mouseMoveHandler)
        mouseMoveHandler = null
    }

    if (mouseUpHandler) {
        document.removeEventListener('mouseup', mouseUpHandler)
        mouseUpHandler = null
    }

}

// 组件卸载时清理事件监听器
onUnmounted(() => {
    cleanupEventListeners()
})
defineExpose<matterExpose>({
    release: pageFun.release,
    getData: pageFun.getData,
    verify: pageFun.verify,
    getDragItem: pageFun.getDragItem,
    clearDraging: pageFun.clearDraging,
    setThisComponent: pageFun.setThisComponent,
    setComponentAttr: pageFun.setComponentAttr
})
</script>
<style lang='less' scoped>
.yz-matter-form {
    height: 100%;
    width: 100%;
    background-color: #EAECF0;
    display: flex;

    &-group {
        width: 300px;
        min-width: 300px;
        background-color: #ffffff;
        overflow-y: auto;

        // 隐藏滚动条但保持滚动功能
        &::-webkit-scrollbar {
            /* Chrome Safari */
            display: none;
        }

        /* Firefox */
        scrollbar-width: none;
        /* IE 10+ */
        -ms-overflow-style: none;
    }

    &-items {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        justify-content: flex-start;
    }

    &-item {
        width: 60px;
        height: 60px;
        background-color: #f8f8f8;
        margin-bottom: 15px;
        margin-right: 15px;
        cursor: pointer;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: space-around;
        border-radius: 2px;
        padding: 10px;

        img {
            width: 20px;
        }
    }

    .yz-matter-form-items .yz-matter-form-item:nth-child(3n) {
        margin-right: 0 !important;
    }

    &-setup {
        flex: 1;
        padding: 15px;

        &-content {
            background-color: #ffffff;
            border-radius: 5px;
            height: 100%;
            width: 1000px;
            margin: 0 auto;
            display: flex;
            flex-direction: column;
        }

        &-group {
            border: 1px solid #EFEFEF;
        }

        &-form {
            overflow-y: auto;

            // 隐藏滚动条但保持滚动功能
            &::-webkit-scrollbar {
                /* Chrome Safari */
                display: none;
            }

            /* Firefox */
            scrollbar-width: none;
            /* IE 10+ */
            -ms-overflow-style: none;
            flex: 1;
        }

        &-tools {
            width: 100%;
            height: 40px;
            min-height: 40px;
            background-color: #EAECF0;
            padding-top: 15px;
        }
    }

    &-attr {
        width: 280px;
        min-width: 280px;
        background-color: #ffffff;
        padding: 15px;
        display: flex;
        flex-direction: column;
        flex-wrap: wrap;

        &-header {
            color: #101010;
            line-height: 30px;
            position: relative;
            text-align: left;
            padding-left: 15px;

            &::before {
                content: "";
                background-color: #226AFF;
                height: 15px;
                width: 4px;
                border-radius: 4px;
                position: absolute;
                top: 50%;
                left: 0;
                transform: translateY(-50%);
            }
        }

        &-content {
            height: calc(100% - 70px);
        }

        &-items {

            margin-top: 10px;
            display: flex;
            flex-direction: column;


        }

        &-item {
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 10px;
            width: 100%;
            flex: 1;
            overflow: hidden;
        }

        &-must {
            .yz-matter-form-attr-label::before {
                content: "*";
                color: #f56c6c;
            }
        }

        &-label {
            width: 80px;
            color: #101010;
            font-size: 14px;
            line-height: 20px;
            text-align: right;

            &::after {
                content: "：";
            }

        }

        &-value {
            text-align: left;
            width: calc(100% - 80px);
        }

        &-footer {
            height: 40px;
        }
    }


}
</style>
<style lang='less'>
.yz-matter-form {
    .el-collapse-item {
        padding: 0 15px;
        border: unset;

        .el-collapse-item__header {
            border: unset;
        }

        .el-collapse-item__wrap {

            border: unset;
        }

        .el-collapse-item__content {
            padding-top: 10px;
            padding-bottom: 10px;
        }
    }

}
</style>