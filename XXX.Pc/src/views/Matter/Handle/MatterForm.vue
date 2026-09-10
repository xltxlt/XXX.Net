<template>
    <div style="height: 100%;width: 100%;">
        <YzCustomForm @change-title="changeTitle" @del-component="delButton" :form="matterData.form"
            :attr-data="matterData.attrData" :component-group-list="componentGroupList" ref="yzCustomFormRef"
            @release="release">
            <template #customType="{ item }">
                <template v-if="item.type === componentType.amount">

                </template>
            </template>
            <template #otherContent>
                <div class="matter-bottom-tools">
                    <div class="matter-bottom-tools-content" @drop="(event) => drop(event)"
                        @dragover="(event) => event.preventDefault()">
                        <template v-for="item in buttonList">
                            <div class="matter-bottom-tools-item" @click="lookComponentAttr(item)">
                                <img :src="item.icon" alt="" srcset="">
                                {{ item.name }}
                            </div>
                        </template>
                    </div>
                </div>
            </template>
            <template #customCard="{ item }">
                <template v-if="item.type === formType.lazyTreeSelect && item.name === 'dataSource'">
                    <el-tree-select v-model="item.value" lazy :load="lazyLoadDataSource" :props="props"
                        :cache-data="cacheData" />
                </template>
                <template v-else-if="item.type === formType.cascaderSelect && item.name === 'dataSource'">
                    <el-cascader v-model="item.value" :props="cascaderProps" />
                </template>
                <!-- <template v-else-if="item.type===componentType.">

                </template> -->
            </template>
        </YzCustomForm>
    </div>
</template>
<script setup lang='ts'>
import { computed, onMounted, ref } from 'vue'
import YzCustomForm from '@/components/common/YzCustomForm/index.vue'
import { componentType, formType, defaultAttr, defaultGroupAttr, defaultSelectAttr, defaultTimeAttr, defaultUploadAttr, defaultButtonAttr } from '@/components/common/YzCustomForm/index'
import type { componentAttr, componentGroup, ReleaseData, componentItem, formItemOption, matterExpose } from '@/components/common/YzCustomForm/index'
import { getUniqueValue, handleSumbitResBox } from '@/utils/common'
import { isArray, isEmptyVal } from '@/utils/is'
import { saveMatterTemp, getMatterCustomOptions, getMatterTempFormDetail } from '@/api/common/matter'
import { getTable, getTableContent } from '@/api/field'
import { ElMessage } from 'element-plus'
const matterData = ref<ReleaseData>({
    form: [],
    attrData: {}
});
const dataSelectSource = ref<formItemOption[]>([]);
const relatedMatterForm: componentAttr[] = [{
    title: '组件标题',
    code: 'title',
    type: formType.text,
    required: true,
    show: true,
    readonly: true,
    value: '关联事项'
}, {
    title: '组件编码',
    code: 'code',
    type: formType.text,
    required: true,
    show: true,
    readonly: true,
    value: 'relatedMatter'
}, {
    title: '是否必填',
    code: 'must',
    type: formType.switch,
    required: true,
    value: true,
},
{
    title: '其他来源',
    code: 'otherDataSource',
    type: formType.text,
    required: false,
    show: true,
    readonly: true,
    value: '/audit-center/api/matter/manage/selectMatter'
},
{
    title: '来源参数',
    code: 'otherDataSourcePars',
    type: formType.text,
    required: false,
    show: true,
    readonly: true,
    value: 'parentMatterId'
}]
const cacheData = ref<{
    label: string,
    value: string
}[]>([]);
const cascaderProps = {
    lazy: true,
    lazyLoad(node: any, resolve: any) {
        const { level } = node
        if (node.level === 0) {
            getTable().then((res) => {
                if (res.code == 200) {
                    const data = res.data.map((item: any) => ({
                        label: item.label,
                        value: item.value
                    }));
                    resolve(data);
                    return;
                }
                resolve([]);
            }).catch(() => {
                resolve([]);
            });
        } else {
            getTableContent(node.data.value).then((res) => {
                if (res.code != 200) {
                    ElMessage({
                        message: res.message,
                        type: 'error',
                        plain: true,
                    })
                    resolve([]);
                    return;
                }
                resolve(res.data.map((item: any) => ({
                    label: item.label,
                    value: item.value,
                    leaf: true
                })));
            }).catch(() => {
                resolve([]);
            });
        }
    },
}
const props = {
    label: 'label',
    children: 'children',
    isLeaf: 'isLeaf',
}

const lazyLoadDataSource = async (node: any, resolve: any) => {
    if (node.level === 0) {
        await getTable().then((res) => {
            if (res.code == 200) {
                const data = res.data.map((item: any) => ({
                    label: item.label,
                    value: item.value
                }));
                resolve(data);
            }
        });
    } else {
        getTableContent(node.data.value).then((res) => {
            if (res.code != 200) {
                ElMessage({
                    message: res.message,
                    type: 'error',
                    plain: true,
                })
                return;
            }
            resolve(res.data.map((item: any) => ({
                label: item.label,
                value: item.value,
                isLeaf: true
            })));
        })
    }
}
const baseSelectAttr = computed(() => {
    return [
        ...defaultSelectAttr,
        {
            title: '数据来源',
            code: 'dataSource',
            type: formType.cascaderSelect,
            required: false,
            show: true,
            data: dataSelectSource.value
        }

    ]
})
const { pars } = defineProps<{ pars?: Record<string, any> }>();
const emit = defineEmits(['closeDialog', 'refreshList'])
const matterOptions: formItemOption[] = [{
    title: "事前",
    value: "1",
    disabled: false,
    isDefault: true,
    child: []
}, {
    title: "事中",
    value: "2",
    disabled: false,
    isDefault: false,
    child: []
}, {
    title: "事后",
    value: "3",
    disabled: false,
    isDefault: false,
    child: []
}]
const baseAttr: componentAttr[] = [{
    title: '编辑位置',
    code: 'editLocation',
    type: formType.multSelect,
    required: false,
    show: true,
    data: matterOptions
}, {
    title: '显示位置',
    code: 'showLocation',
    type: formType.multSelect,
    required: true,
    show: true,
    data: matterOptions,
}]
const componentGroupList = computed<componentGroup[]>(() => {
    return [
        {
            title: '表单分组',
            code: 'group',
            children: [
                {
                    title: '预览分组',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.previewGroup,
                    isIndependent: true,
                    isButton: false,
                    isPreview: true,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr,
                        ...defaultGroupAttr
                    ]
                },
                {
                    title: '分组块',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.group,
                    isIndependent: true,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr,
                        ...defaultGroupAttr
                    ]
                },
                {
                    title: '批量分组',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.multGroup,
                    isIndependent: true,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultGroupAttr,
                    ]
                }
            ]
        },
        {
            title: '基础组件',
            code: 'base',
            children: [
                {
                    title: '单行文本',
                    icon: '/imgs/matter/input.svg',
                    type: componentType.text,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '多行文本',
                    icon: '/imgs/matter/textarea.svg',
                    type: componentType.textarea,
                    isIndependent: false,
                    isButton: false, isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '单选框',
                    icon: '/imgs/matter/radio.svg',
                    type: componentType.radio,
                    isIndependent: false,
                    isButton: false, isAddGroup: false,
                    attr: [
                        ...baseAttr, ...baseSelectAttr.value
                    ]
                },
                {
                    title: '下拉框',
                    icon: '/imgs/matter/multSelect.png',
                    type: componentType.select,
                    isIndependent: false,
                    isButton: false, isAddGroup: false,
                    attr: [
                        ...baseAttr, ...baseSelectAttr.value
                    ]
                },
                {
                    title: '多选下拉',
                    icon: '/imgs/matter/multSelect.png',
                    type: componentType.multSelect,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...baseSelectAttr.value
                    ]
                },
                {
                    title: '树形下拉',
                    icon: '/imgs/matter/treeSelect.png',
                    type: componentType.treeSelect,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...baseSelectAttr.value
                    ]
                },
                {
                    title: '日期选择',
                    icon: '/imgs/matter/date.png',
                    type: componentType.date,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr,

                    ]
                },
                {
                    title: '时间选择',
                    icon: '/imgs/matter/time.png',
                    type: componentType.time,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '地址选择',
                    icon: '/imgs/matter/takeAddress.png',
                    type: componentType.takeAddress,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '图片上传',
                    icon: '/imgs/matter/uploadImg.png',
                    type: componentType.uploadImg,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '文件上传',
                    icon: '/imgs/matter/uploadFile.png',
                    type: componentType.uploadFile,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '金额输入',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.amount,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                },
                {
                    title: '数字输入',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.number,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultAttr
                    ]
                }]
        },
        {
            title: '业务组件',
            code: 'group',
            children: [
                {
                    title: '车辆详情',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.group,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultGroupAttr
                    ]
                },
                {
                    title: '油卡详情',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.group,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultGroupAttr
                    ]
                },
                {
                    title: '关联事项',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.selectPicker,

                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...relatedMatterForm
                    ]
                },
            ]
        },
        {
            title: '其他组件',
            code: 'group',
            children: [
                {
                    title: '审核记录',
                    icon: '/imgs/matter/amount.png',
                    type: componentType.group,
                    isIndependent: false,
                    isButton: false,
                    isAddGroup: false,
                    attr: [
                        ...baseAttr, ...defaultGroupAttr
                    ]
                },
            ]
        },
        {
            title: '底部按钮',
            code: 'group',
            children: [
                {
                    title: '审批',
                    icon: '/imgs/matter/approval.png',
                    type: componentType.group,
                    isIndependent: false,
                    code: 'audit',
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        {
                            title: '组件标题',
                            code: 'title',
                            type: formType.text,
                            value: "审批",
                            required: false,
                        }, {
                            title: '组件编码',
                            code: 'code',
                            type: formType.text,
                            value: 'audit',
                            required: false,
                        },
                        {
                            title: '组件图标',
                            code: 'icon',
                            type: formType.uploadImg,
                            required: false,
                            value: '/imgs/matter/approval.png'
                        }
                    ]
                },
                {
                    title: '发表评论',
                    icon: '/imgs/matter/group.png',
                    type: componentType.group,
                    isIndependent: false,
                    code: 'toGroup',
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        {
                            title: '组件标题',
                            code: 'title',
                            type: formType.text,
                            value: "发表评论",
                            required: false,
                        }, {
                            title: '组件编码',
                            code: 'code',
                            type: formType.text,
                            value: 'comment',
                            required: false,
                        },
                        {
                            title: '组件图标',
                            code: 'icon',
                            type: formType.uploadImg,
                            required: false,
                            value: '/imgs/matter/group.png'
                        }
                    ]
                },
                {
                    title: '上传发票',
                    icon: '/imgs/matter/invoice.png',
                    type: componentType.group,
                    code: 'invoice',
                    isIndependent: false,
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        {
                            title: '组件标题',
                            code: 'title',
                            type: formType.text,
                            value: "上传发票",
                            required: false,
                        }, {
                            title: '组件编码',
                            code: 'code',
                            type: formType.text,
                            value: 'invoice',
                            required: false,
                        },
                        {
                            title: '组件图标',
                            code: 'icon',
                            type: formType.uploadImg,
                            required: false,
                            value: '/imgs/matter/invoice.png'
                        }
                    ]
                },
                {
                    title: '申请付款',
                    icon: '/imgs/matter/applyPayment.png',
                    type: componentType.group,
                    code: 'applyPayment',
                    isIndependent: false,
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        {
                            title: '组件标题',
                            code: 'title',
                            type: formType.text,
                            value: "申请付款",
                            required: false,
                        }, {
                            title: '组件编码',
                            code: 'code',
                            type: formType.text,
                            value: 'applyPayment',
                            required: false,
                        },
                        {
                            title: '组件图标',
                            code: 'icon',
                            type: formType.uploadImg,
                            required: false,
                            value: '/imgs/matter/applyPayment.png'
                        }
                    ]
                },
                {
                    title: '确认付款',
                    icon: '/imgs/matter/applyPayment.png',
                    type: componentType.group,
                    code: 'surePayment',
                    isIndependent: false,
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        {
                            title: '组件标题',
                            code: 'title',
                            type: formType.text,
                            value: "确认付款",
                            required: false,
                        }, {
                            title: '组件编码',
                            code: 'code',
                            type: formType.text,
                            value: 'surePayment',
                            required: false,
                        },
                        {
                            title: '组件图标',
                            code: 'icon',
                            type: formType.uploadImg,
                            required: false,
                            value: '/imgs/matter/applyPayment.png'
                        }
                    ]
                },
                {
                    title: '按钮',
                    icon: '/imgs/matter/applyPayment.png',
                    type: componentType.group,
                    isIndependent: false,
                    isButton: true,
                    isAddGroup: false,
                    attr: [
                        ...defaultButtonAttr
                    ]
                },
            ]
        },
    ]
})

interface buttonItem {
    name: string,
    type: string,
    icon: string,
    ident: string,
}
const yzCustomFormRef = ref<matterExpose>()
const buttonList = ref<buttonItem[]>([])
const drop = (event: any) => {
    const item = yzCustomFormRef.value?.getDragItem();
    const ident = getUniqueValue()
    buttonList.value?.push({
        name: item?.title ?? '',
        type: item?.code ?? '',
        icon: item?.icon ?? '',
        ident: ident
    });
    const attrData = item?.attr.map(m => {
        if (isArray(m.data) || (m.data ?? []).length > 0) {
            const defaultList = (m.data ?? []).filter(m => m.isDefault).map(m => m.value);
            if (defaultList.length > 0 && m.type == formType.select) {
                m.value = defaultList.pop()
            }
            if (defaultList.length > 0 && m.type == formType.multSelect) {
                m.value = defaultList
            }
        }
        if (m.code == 'title') {
            m.value = item.title + '';
        }
        let obj = {
            ident: getUniqueValue(),
            pTitle: item.title,
            pIdent: ident,
            title: m.title,
            name: m.code,
            value: m.value ?? '',
            type: m.type,
            data: m.data,
            required: m.required
        }
        return obj;
    }) ?? [];
    yzCustomFormRef.value?.setComponentAttr(ident, attrData);
    yzCustomFormRef.value?.clearDraging();
}
const changeTitle = (ident: string, val: string) => {
    let item = buttonList.value.find(m => m.ident === ident);
    item && (item.name = val);
}
const lookComponentAttr = (buttonList: buttonItem) => {
    yzCustomFormRef.value?.setThisComponent(buttonList.ident);
}
const delButton = (ident: string) => {
    buttonList.value = buttonList.value.filter(m => m.ident !== ident);
}
const release = async (data: ReleaseData) => {
    const pushData = {
        buttonList: buttonList.value,
        ...data
    }
    const res = await saveMatterTemp(pars?.id ?? '', pushData);
    handleSumbitResBox(res, isEmptyVal(pars?.id) ? '事项模板保存成功' : '事项模板修改成功', () => {
        emit('closeDialog')
        emit('refreshList')
    })
}
onMounted(async () => {
    // const res = await getMatterCustomOptions();
    // if (res.code == 200) {
    //     dataSelectSource.value = res.data;
    // }
    const matterTempFormData = await getMatterTempFormDetail(pars?.id ?? '');
    if (matterTempFormData.setMatterFormCmd) {
        buttonList.value = matterTempFormData.setMatterFormCmd.buttonList ?? [];
        matterData.value.attrData = matterTempFormData.setMatterFormCmd.attrData ?? {};
        matterData.value.form = matterTempFormData.setMatterFormCmd.form ?? [];
    }
})
</script>
<style lang='less' scoped>
.matter-bottom-tools {

    background-color: #EAECF0;
    height: 100px;
    padding-top: 10px;
    width: 100%;

    &-content {
        display: flex;
        align-items: center;
        background-color: #ffffff;
        height: 100%;
        padding: 0 15px;
        overflow-y: auto;


    }

    &-item {
        display: flex;
        flex-direction: column;
        justify-content: space-evenly;
        align-items: center;
        background-color: #f8f8f8;
        width: 60px;
        height: 60px;
        min-width: 60px;
        padding: 10px;
        margin-right: 15px;

        img {
            width: 20px;
        }

    }

    .matter-bottom-tools-item:last-child {
        margin-right: 0;
    }



}
</style>