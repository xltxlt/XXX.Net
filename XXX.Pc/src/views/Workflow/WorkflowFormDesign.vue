<template>
  <div style="height: 100%;width: 100%;">
    <YzCustomForm @change-title="changeTitle" @del-component="delButton" :form="matterData.form"
      :attr-data="matterData.attrData" :component-group-list="componentGroupList" ref="yzCustomFormRef"
      @release="release">
      <template #customType="{ item }">
      </template>
      <template #otherContent>
        <div class="pm-bottom-tools">
          <div class="pm-bottom-tools-content" @drop="(event) => drop(event)"
            @dragover="(event) => event.preventDefault()">
            <template v-for="item in buttonList">
              <div class="pm-bottom-tools-item" @click="lookComponentAttr(item)">
                <img :src="item.icon" alt="" srcset="">
                {{ item.name }}
              </div>
            </template>
          </div>
        </div>
      </template>
      <template #customCard="{ item }">
        <template v-if="item.type === PageFormType.LazyTreeSelect  && item.name === 'dataSource'">
          <el-tree-select v-model="item.value" lazy :load="lazyLoadDataSource" :props="props" :cache-data="cacheData" />
        </template>
        <template v-else-if="item.type === PageFormType.CascaderSelect && item.name === 'dataSource'">
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
import {  defaultAttr, defaultGroupAttr, defaultSelectAttr, defaultTimeAttr, defaultUploadAttr, defaultButtonAttr } from '@/components/common/YzCustomForm/index'
import type { componentAttr, componentGroup, ReleaseData, componentItem, formItemOption, matterExpose } from '@/components/common/YzCustomForm/index'
import { getUniqueValue, handleSumbitResBox } from '@/utils/common'
import { isArray, isEmptyVal } from '@/utils/is'
import {  PageFormGroup, PageFormType } from '@/components/PageForm'
import type { WorkflowNodeForm } from '@/api-services/generated'
import { workflowNodeFormService } from '@/api/workflow'
const matterData = ref<ReleaseData>({
  form: [],
  attrData: {},
});
const dataSelectSource = ref<formItemOption[]>([]);
const relatedMatterForm: componentAttr[] = [{
  label: '组件标题',
  code: 'label',
  type: PageFormType.Input,
  required: true,
  show: true,
  readonly: true,
  value: '关联事项'
}, {
  label: '组件编码',
  code: 'fieldName',
  type: PageFormType.Input,
  required: true,
  show: true,
  readonly: true,
  value: 'relatedMatter'
}, {
  label: '是否必填',
  code: 'must',
  type: PageFormType.Switch,
  required: true,
  value: true,
},
{
  label: '其他来源',
  code: 'otherDataSource',
  type: PageFormType.Input,
  required: false,
  show: true,
  readonly: true,
  value: '/audit-center/api/matter/manage/selectMatter'
},
{
  label: '来源参数',
  code: 'otherDataSourcePars',
  type: PageFormType.Input,
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
    // const { level } = node
    // if (node.level === 0) {
    //     getTable().then((res) => {
    //         if (res.code == 200) {
    //             const data = res.data.map((item: any) => ({
    //                 label: item.label,
    //                 value: item.value
    //             }));
    //             resolve(data);
    //             return;
    //         }
    //         resolve([]);
    //     }).catch(() => {
    //         resolve([]);
    //     });
    // } else {
    //     getTableContent(node.data.value).then((res) => {
    //         if (res.code != 200) {
    //             ElMessage({
    //                 message: res.msg,
    //                 type: 'error',
    //                 plain: true,
    //             })
    //             resolve([]);
    //             return;
    //         }
    //         resolve(res.data.map((item: any) => ({
    //             label: item.label,
    //             value: item.value,
    //             leaf: true
    //         })));
    //     }).catch(() => {
    //         resolve([]);
    //     });
    // }
  },
}
const props = {
  label: 'label',
  children: 'children',
  isLeaf: 'isLeaf',
}

const lazyLoadDataSource = async (node: any, resolve: any) => {
  if (node.level === 0) {
    // await getTable().then((res) => {
    //     if (res.code == 200) {
    //         const data = res.data.map((item: any) => ({
    //             label: item.label,
    //             value: item.value
    //         }));
    //         resolve(data);
    //     }
    // });
  } else {
    // getTableContent(node.data.value).then((res) => {
    //     if (res.code != 200) {
    //         ElMessage({
    //             message: res.msg,
    //             type: 'error',
    //             plain: true,
    //         })
    //         return;
    //     }
    //     resolve(res.data.map((item: any) => ({
    //         label: item.label,
    //         value: item.value,
    //         isLeaf: true
    //     })));
    // })
  }
}
const baseSelectAttr = computed(() => {
  return [
    ...defaultSelectAttr,
    {
      title: '数据来源',
      code: 'dataSource',
      type: PageFormType.CascaderSelect,
      required: false,
      show: true,
      data: dataSelectSource.value
    }

  ]
})
const { nodeId,workflowDeginitionId } = defineProps<{ nodeId:string,workflowId:string,nodeType:string,workflowDeginitionId:string}>();
const emit = defineEmits(['closeDialog', 'refreshList','release'])


const componentGroupList = computed<componentGroup[]>(() => {
  return [
    {
      label: '表单分组',
      code: 'group',
      children: [
        {
          label: '预览分组',
          icon: '/imgs/matter/amount.png',
          type: PageFormGroup.PreviewGroup,
          isIndependent: true,
          isButton: false,
          isPreview: true,
          isAddGroup: false,
          attr: [
            ...defaultGroupAttr
          ]
        },
        {
          label: '分组块',
          icon: '/imgs/matter/amount.png',
          type: PageFormGroup.Group,
          isIndependent: true,
          isButton: false,
          isPreview: true,
          isAddGroup: false,
          attr: [
            ...defaultGroupAttr
          ]
        },
        {
          label: '表格分组',
          icon: '/imgs/matter/amount.png',
          type: PageFormGroup.Table,
          isIndependent: true,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultGroupAttr,
          ]
        },
        {
         label: '列表分组',
          icon: '/imgs/matter/amount.png',
          type: PageFormGroup.List,
          isIndependent: true,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultGroupAttr,
          ]
        }
      ]
    },
    {
     label: '基础组件',
      code: 'base',
      children: [
        {
         label: '单行文本',
          icon: '/imgs/matter/input.svg',
          type: PageFormType.Input,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '多行文本',
          icon: '/imgs/matter/textarea.svg',
          type: PageFormType.TextAreaInput,
          isIndependent: false,
          isButton: false, isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '单选框',
          icon: '/imgs/matter/radio.svg',
          type: PageFormType.Radio,
          isIndependent: false,
          isButton: false, isAddGroup: false,
          attr: [
            ...baseSelectAttr.value
          ]
        },
        {
         label: '下拉框',
          icon: '/imgs/matter/multSelect.png',
          type: PageFormType.OneSelectSearch,
          isIndependent: false,
          isButton: false, isAddGroup: false,
          attr: [
            ...baseSelectAttr.value
          ]
        },
        {
         label: '多选下拉',
          icon: '/imgs/matter/multSelect.png',
          type: PageFormType.MultSelect,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...baseSelectAttr.value
          ]
        },
        {
         label: '树形下拉',
          icon: '/imgs/matter/treeSelect.png',
          type: PageFormType.TreeSelect,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...baseSelectAttr.value
          ]
        },
        {
         label: '日期选择',
          icon: '/imgs/matter/date.png',
          type: PageFormType.DateSelect,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr,

          ]
        },
        {
         label: '时间选择',
          icon: '/imgs/matter/time.png',
          type: PageFormType.TimeSelect,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '地址选择',
          icon: '/imgs/matter/takeAddress.png',
          type: PageFormType.LocationSelect,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '图片上传',
          icon: '/imgs/matter/uploadImg.png',
          type: PageFormType.UploadOneImg,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '文件上传',
          icon: '/imgs/matter/uploadFile.png',
          type: PageFormType.UploadOneFile,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '金额输入',
          icon: '/imgs/matter/amount.png',
          type: PageFormType.Amount,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        },
        {
         label: '数字输入',
          icon: '/imgs/matter/amount.png',
          type: PageFormType.Number,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultAttr
          ]
        }]
    },
    {
     label: '其他组件',
      code: 'group',
      children: [
        {
         label: '审核记录',
          icon: '/imgs/matter/amount.png',
          type: PageFormGroup.Group,
          isIndependent: false,
          isButton: false,
          isAddGroup: false,
          attr: [
            ...defaultGroupAttr
          ]
        },
      ]
    },
    {
     label: '底部按钮',
      code: 'group',
      children: [
        {
         label: '审批',
          icon: '/imgs/matter/approval.png',
          type: PageFormGroup.Group,
          code: 'audit',
          isButton: true,
          isIndependent:false,
          isAddGroup: false,
          attr: [
            {
             label: '组件标题',
              code: 'label',
              type: PageFormType.Input,
              value: "审批",
              required: false,
            }, {
             label: '组件编码',
              code: 'code',
              type: PageFormType.Input,
              value: 'audit',
              required: false,
            },
            {
             label: '组件图标',
              code: 'icon',
              type: PageFormType.UploadOneImg,
              required: false,
              value: '/imgs/matter/approval.png'
            }
          ]
        },
        {
         label: '发表评论',
          icon: '/imgs/matter/group.png',
          type: PageFormGroup.Group,
          isIndependent: false,
          code: 'toGroup',
          isButton: true,
          isAddGroup: false,
          attr: [
            {
             label: '组件标题',
              code: 'title',
              type: PageFormType.Input,
              value: "发表评论",
              required: false,
            }, {
             label: '组件编码',
              code: 'code',
              type: PageFormType.Input,
              value: 'comment',
              required: false,
            },
            {
             label: '组件图标',
              code: 'icon',
              type: PageFormType.UploadOneImg,
              required: false,
              value: '/imgs/matter/group.png'
            }
          ]
        },
        {
         label: '上传发票',
          icon: '/imgs/matter/invoice.png',
          type: PageFormGroup.Group,
          code: 'invoice',
          isIndependent: false,
          isButton: true,
          isAddGroup: false,
          attr: [
            {
             label: '组件标题',
              code: 'title',
              type: PageFormType.Input,
              value: "上传发票",
              required: false,
            }, {
             label: '组件编码',
              code: 'code',
              type: PageFormType.Input,
              value: 'invoice',
              required: false,
            },
            {
             label: '组件图标',
              code: 'icon',
              type: PageFormType.UploadOneImg,
              required: false,
              value: '/imgs/matter/invoice.png'
            }
          ]
        },
        {
         label: '申请付款',
          icon: '/imgs/matter/applyPayment.png',
          type: PageFormGroup.Group,
          code: 'applyPayment',
          isIndependent: false,
          isButton: true,
          isAddGroup: false,
          attr: [
            {
             label: '组件标题',
              code: 'title',
              type: PageFormType.Input,
              value: "申请付款",
              required: false,
            }, {
             label: '组件编码',
              code: 'code',
              type: PageFormType.Input,
              value: 'applyPayment',
              required: false,
            },
            {
             label: '组件图标',
              code: 'icon',
              type: PageFormType.UploadOneImg,
              required: false,
              value: '/imgs/matter/applyPayment.png'
            }
          ]
        },
        {
         label: '确认付款',
          icon: '/imgs/matter/applyPayment.png',
          type: PageFormGroup.Group,
          code: 'surePayment',
          isIndependent: false,
          isButton: true,
          isAddGroup: false,
          attr: [
            {
             label: '组件标题',
              code: 'title',
              type: PageFormType.Input,
              value: "确认付款",
              required: false,
            }, {
             label: '组件编码',
              code: 'code',
              type: PageFormType.Input,
              value: 'surePayment',
              required: false,
            },
            {
             label: '组件图标',
              code: 'icon',
              type: PageFormType.UploadOneImg,
              required: false,
              value: '/imgs/matter/applyPayment.png'
            }
          ]
        },
        {
         label: '按钮',
          icon: '/imgs/matter/applyPayment.png',
          type: PageFormGroup.Group,
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
    name: item?.label ?? '',
    type: item?.code ?? '',
    icon: item?.icon ?? '',
    ident: ident
  });
  const attrData = item?.attr.map(m => {
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
    let obj = {
      ident: getUniqueValue(),
      pTitle: item.label,
      pIdent: ident,
      title: m.label,
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
export interface FormReleaseData extends ReleaseData {
  buttonList: buttonItem[];
  nodeId:string;
}
const release = async (data: ReleaseData) => {
  const pushData :WorkflowNodeForm= {
    nodeId:nodeId?? '',
    buttonListJson: JSON.stringify(buttonList.value),
    formJson: JSON.stringify(data.form),
    attrDataJson: JSON.stringify(data.attrData),
  }
  emit('release', pushData);
}
onMounted(async () => {
  // const res = await getMatterCustomOptions();
  // if (res.code == 200) {
  //     dataSelectSource.value = res.data;
  // }
  const res = await workflowNodeFormService.apiWorkflowNodeFormWorkflowdeginitionidNodeidGet(workflowDeginitionId ?? '', nodeId ?? '');
  if (res.data.statusCode==200) {
    var data=res.data.data||{};
    buttonList.value =JSON.parse(data.buttonListJson??"") ?? [];
    matterData.value.attrData = JSON.parse(data.attrDataJson??"") ?? {};
    matterData.value.form = JSON.parse(data.formJson??"") ?? [];
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