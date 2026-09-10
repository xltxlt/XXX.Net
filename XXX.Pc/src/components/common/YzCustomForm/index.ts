import type { PagedOptions } from "@/api-services/generated/models/paged-options";
import { PageFormType, type TempEditPageData, type TempFormItemOption, type TempFormTreeOption } from "@/components/PageForm";
import type { FormRules } from "element-plus";
/**
 * 组件类型
 */
// const componentType = {
//     text: 'input',
//     textarea: 'textarea',
//     radio: 'radio',
//     select: 'select',
//     multSelect: 'multSelect',
//     date: 'dateSelect',
//     time: 'timeSelect',
//     dateRange: 'dateRangeSelect',
//     uploadImg: 'uploadImg',
//     uploadFile: 'uploadFile',
//     amount: 'amount',
//     number: 'number',
//     switch: 'switch',
//     takeAddress: 'locationSelect',
//     treeSelect: 'treeSelect',
//     vechielDetail: 'vechielDetail',
//     oilCardDetail: 'oilCardDetail',
//     auditRecord: 'auditRecord',
//     previewGroup: 'previewGroup',
//     group: 'group',
//     multGroup: 'multGroup',
//     tableGroup:"tableGroup",
//     listGroup: 'listGroup',
//     relatedMatter:'relatedMatter',
//     selectPicker:'selectPicker'
// };
/**
 * 表单子项类型
 */
const formType = {
    text: 'input',
    select: 'select',
    multSelect: 'multSelect',
    radio: 'radio',
    switch: 'switch',
    textarea: 'textarea',
    number: 'number',
    date: 'date',
    time: 'time',
    amount: "amount",
    uploadImg: 'input',
    lazyTreeSelect: 'lazyTreeSelect',
    cascaderSelect: 'cascaderSelect'

}
/**
 * 组件分组
 */
interface componentGroup {
    label: string,
    code: string,
    children: componentItem[]
}
/**
 * 组件项
 */
interface componentItem {
    label: string,
    icon: string,
    type: number,
    code?: string,
    options?: formItemOption[]|any,
    isIndependent: boolean,
    isPreview?: boolean,
    isAddGroup: boolean,
    isButton: boolean,
    attr: componentAttr[]
}
/**
 * 组件属性
 */
interface componentAttr {
    label: string,
    code: string,
    value?: any,
    type: number,
    required: boolean,
    show?:boolean,
    readonly?:boolean,
    data?: formItemOption[] | undefined
}
/**
 * 组件选择项
 */
interface formItemOption {
    title: string,
    label?: string,
    value: string,
    disabled: boolean,
    isDefault: boolean,
    child: formItemOption[]
}


/**
 * 默认组件属性
 */
const defaultAttr: componentAttr[] = [{
    label: '组件标题',
    code: 'title',
    type: PageFormType.Input,
    show:true,
    required: true,
}, {
    label: '组件编码',
    code: 'code',
    type: PageFormType.Input,
    show:true,
    required: true,
}, {
    label: '是否必填',
    code: 'must',
    type: PageFormType.Switch,
    show:true,
    required: false,
}, {
    label: '验证规则',
    code: 'verifyRule',
    show:true,
    type: PageFormType.Input,
    required: false,
}, {
    label: '右侧文本',
    code: 'rightText',
    show:true,
    type: PageFormType.Input,
    required: false,
}]
/**
 * 下拉组件默认属性
 */
const defaultSelectAttr: componentAttr[] = [{
    label: '组件标题',
    code: 'title',
    show:true,
    type: PageFormType.Input,
    required: true,
}, {
    label: '组件编码',
    code: 'code',
    type: PageFormType.Input,
    show:true,
    required: true,
}, {
    label: '是否必填',
    code: 'must',
    type: PageFormType.Switch,
    show:true,
    required: true,
    value: false
},
// {
//     label: '数据来源',
//     code: 'dataSource',
//     type: formType.select,
//     required: false,
// },
{
    label: '其他来源',
    code: 'otherDataSource',
    type: PageFormType.Input,
    show:true,
    required: false,
},
{
    label: '来源参数',
    code: 'otherDataSource',
    type: PageFormType.Input,
    show:true,
    required: false,
}]

const defaultGroupAttr: componentAttr[] = [{
    label: '组件标题',
    code: 'title',
    type: PageFormType.Input,

    required: false,
    show:true,
}, {
    label: '组件编码',
    code: 'code',
    type: PageFormType.Input,
    required: false,
    show:true,
}, {
    label: '左侧蓝条',
    code: 'leftIcon',
    type: PageFormType.Switch,
    required: false,
    show:true,
}, {
    label: '右侧文本',
    code: 'rightText',
    type: PageFormType.Input,
    required: false,
    show:true,
}]
const defaultButtonAttr: componentAttr[] = [{
    label: '组件标题',
    code: 'title',
    type: PageFormType.Input,
    required: false,
    show:true,
}, {
    label: '组件编码',
    code: 'code',
    type: PageFormType.Input,
    required: false,
    show:true,
}, {
    label: '组件图标',
    code: 'icon',
    type: PageFormType.UploadOneImg,
    required: true,
    show:true,
}]
/**
 * 时间组件默认属性
 */
const defaultTimeAttr: componentAttr[] = []
/**
 * 上传组件默认属性
 */
const defaultUploadAttr: componentAttr[] = []

interface componentAttrData {
    ident: string,
    pTitle?: string,
    pIdent: string,
    label: string,
    name: string,
    value: string | string[],
    type: number,
    required: boolean,
    show?:boolean,
    readonly?:boolean,
    data: formItemOption[] | undefined | null
}
interface ReleaseData {
    form: componentForm[],
    attrData: Record<string, componentAttrData[]>,
}
interface componentForm {
    formType: number,
    rules?: any,
    placeholder?: string,
    custom?: boolean,
    code?: string,
    pIdent?: string,
    ident?: string,
    fieldName: string,
    title?: string,
    label?: string,
    uploadPath?: string,
    componentAttr?: componentAttr[],
    must?: boolean,
    cb?: Function,
    props?: string | [] | {},
    on?: string | [] | {},
    comOn?: string | [] | {},
    comProps?: string | [] | {},
    option?: any,
    child?: componentForm[],
    hide?: boolean ,
    showPicker?: boolean,
}
interface PageFun {
    loadData: () => Promise<void>;
    allowDrop: (ev: DragEvent) => void;
    drag: (ev: DragEvent, item?: any) => void;
    drop: (ev: DragEvent, root?: boolean, ident?: string, isPreview?: boolean) => void;
    moveChildToParent: (item: componentItem | undefined | null, toEle: HTMLElement, toIdent?: string) => void;
    moveChildByIdent: (item: componentItem | undefined | null, toIdent?: string) => void;
    findParentComponent: (toIdent: string, list: componentForm[]) => componentForm | null;
    delComponent: (ident: string | null | undefined) => void;
    delComponentByIdent: (ident: string) => void;
    moveProv:(ident: string, pIdent:string)=> void;
    moveNext:(ident: string, pIdent:string)=> void;
    getData: () => ReleaseData;
    release: () => void;
    verify: () => {
        formItem: componentForm | null,
        componentItem: componentAttrData | null
    };
    getDragItem: () => componentItem | null;
    clearDraging: () => void;
    setThisComponent: (ident: string) => void;
    setComponentAttr: (ident: string, attrData: componentAttrData[]) => void;
    changeAttrVal: (ident: string, val: string | string[], item: componentAttrData) => void;
    setComOn: (tempFormList: componentForm[]) => void;
}
interface matterEmits {
    (e: 'release', data: ReleaseData): void;
    (e: 'reload'): void;
    (e: 'addItem', root: boolean, item: componentItem | undefined | null, toEle: HTMLElement, toIdent: string, TempEditPageData: TempEditPageData): boolean;
    (e: 'changeTitle', ident: string, val: string): void;
    (e: 'changeAttrVal', ident: string, val: string | string[], item: componentAttrData): void;
    (e: 'delComponent', ident: string): void;
}
interface matterExpose {
    release: () => void;
    getData: () => ReleaseData;
    verify: () => void;
    getDragItem: () => componentItem | null;
    clearDraging: () => void;
    setThisComponent: (ident: string) => void;
    setComponentAttr: (ident: string, attrData: componentAttrData[]) => void;
}
interface pageComponentFormData {
    submit?: ((...args: any[]) => void),
    cols?: number,
    on?: [] | {},
    props?: string | {} | [],
    formData: any | {},
    form: componentForm[],
    formItems?: Record<string, componentForm>,
    loading?: boolean,
    rules?: FormRules<any>,
    disabledForm?: boolean,
    comOn?: string | [] | {},
    comProps?: string | [] | {},
    options: Record<string, TempFormTreeOption[] | TempFormItemOption[] | PagedOptions[] | null>,
    hideBtn?: boolean,
    btnText?: string,
}
export {  formType, defaultAttr, defaultSelectAttr, defaultGroupAttr, defaultTimeAttr, defaultUploadAttr, defaultButtonAttr }
export type { componentGroup,pageComponentFormData,componentForm, componentItem, componentAttr, ReleaseData, componentAttrData, formItemOption, matterEmits, matterExpose, PageFun }