import type { Component, Ref, ComputedRef } from 'vue';
import type { FormItemRule, FormRules } from 'element-plus'
import type { componentAttr, componentForm } from '../common/YzCustomForm';
import type { PagedOptions } from '@/api-services/generated';
/**
 * form 表单
 * submit 表单提交事件
 * on 表单相关的事件{
 *    submit	提交表单且验证通过后触发	values: object
 *    failed	提交表单且验证不通过后触发	errorInfo: { values: object, errors: object[] }
 * }
 * props 表单相关的属性
 * {
 * }
 * form 渲染表单的参数
 * hideBtn 是否隐藏确认按钮
 * disabledForm 禁用表单
 */
export type TempFormRule =
    FormItemRule[];

export interface TempFormRules {
    [fieldName: string]:
        | FormItemRule[]
        | Record<string, FormItemRule[]>;
}
interface TempEditPageData {
    submit?: ((...args: any[]) => void),
    cols?: number,
    on?: [] | {},
    design?:boolean,
    props?: string | {} | [],
    formData: any | {},
    form: TempEditForm[],
    formItems?: Record<string, TempEditForm>,
    loading?: boolean,
    // rules?: FormRules<any>,
    rules?:TempFormRules,
    disabledForm?: boolean,
    options: Record<string, TempFormTreeOption[] | TempFormItemOption[] | PagedOptions[] | null>,
    hideBtn?: boolean | Ref<boolean> | ComputedRef<boolean>,
    btnText?: string | Ref<string> | ComputedRef<string>,
}
interface TempFormTreeOption {
    label: string,
    value: any,
    disabled?: boolean,
    children?: TempFormItemOption[]
}
interface TempFormItemOption {
    label: string,
    value: any,
    disabled?: boolean
}

/**
 * type
 * {
 *     group
 * 
 *     input 
 *     textarea
 *     checkbox
 *     radio
 *     uploadImg
 *     uploadImgOne
 *     uploadFile
 *     select
 *     timeSelect
 *     treeSelect
 *     dateSelect
 *     stepper
 *     rate
 *     slider
 *     switch
 *     custom
 *     locationSelect
 * }
 * 
 * 
 * placeholder 提示
 * custom 是否传入自定义组件
 * name   字段对应name
 * title  标题
 * com    自定义组件 
 * props  van-filed 的属性
 * comProps 对应type相关组件的属性
 * comOn  对应type相关组件的事件
 * options 渲染参数
 * child  分组后的子集
 * hide 是否隐藏当前组件
 * showPicker 带popup的组件的显示隐藏 控制
 * val  组件对应的值
 * uploadPath 文件上传地址
 * ident 标识
 * pIdent 父级标识
 */
interface TempEditForm {
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
    com?: Component,
    defaultValue?: any;
    uploadPath?: string,
    componentAttr?: componentAttr[],
    must?: boolean,
    cb?: Function,
    props?: string | [] | {},
    on?: string | [] | {},
    comOn?: string | [] | {},
    comProps?: string | [] | {},
    option?: any,
    child?: TempEditForm[],
    hide?: boolean | Ref<boolean>,
    showPicker?: boolean,
}

/**
 * 地址
 */
interface LocationDto {
    address: string,
    city: string,
    province: string,
    region: string,
    code: string,
    lng: string,
    lat: string
}

/**
 * 组件分类
 */
const tempFormType = {
    /**
     * 表单分组
     */
    group: "group",
    /**
     * 输入框
     */
    input: "input",
    /**
     * 数字输入框
     */
    number: 'number',
    /**
     * 多行文本
     */
    textarea: 'textarea',
    /**
     * 多选框
     */
    checkbox: "checkbox",
    /**
     * 单选框
     */
    radio: "radio",
    /**
     * 上传图片
     */
    uploadImg: "uploadImg",
    /**
     * 上传图片（单张）
     */
    uploadImgOne: "uploadImgOne",
    /**
     * 上传文件
     */
    uploadFile: "uploadFile",
    /**
     * 文件详情
     */
    fileDetail: "fileDetail",
    /**
     * 下拉框
     */
    select: "select",
    /**
     * 多选框
     */
    multSelect: "multSelect",
    /**
     * 时间选择
     */
    timeSelect: "timeSelect",
    /**
     * 树形选择
     */
    treeSelect: "treeSelect",
    /**
     * 日期选择
     */
    dateSelect: "dateSelect",
    /**
     * 时间日期选择
     */
    dateTimeSelect: "dateTimeSelect",
    /**
     * 数字输入框
     */
    stepper: "stepper",
    /**
     * 级联选择
     */
    rate: "rate",
    /**
     * 滑块
     */
    slider: "slider",
    /**
     * 开关
     */
    switch: "switch",
    /**
     * 自定义
     */
    custom: "custom",
    /**
     * 位置选择
     * 已弃用
     */
    locationSelect: "locationSelect",
    /**
     * 地址选择
     */
    address: "address",
    /**
     * 颜色选择
     */
    color: "color",
}
export const PageFormGroup =
{
    /// <summary>
    /// 分组
    /// </summary>
    Group: 0,

    /// <summary>
    /// 预览分组
    /// </summary>
    PreviewGroup: 1,

    /// <summary>
    /// 表格
    /// </summary>
    Table: 2,

    /// <summary>
    /// 列表
    /// </summary>
    List: 3,

}
const PageFormType = {
    //默认
    Input: 100,
    //数字
    Number: 101,
    //选择框
    Checkbox: 102,
    //radio选择
    Radio: 103,
    //多行文本
    TextAreaInput: 104,
    //步进器
    Stepper: 106,
    //比率
    Rate: 107,
    //开关
    Switch: 108,
    //手机号
    Phone: 109,
    //整数
    NumberInput: 110,
    //小数
    DecimalInput: 111,
    //金额
    Amount: 112,
    //颜色选择
    Color: 113,
    //滑块
    Slider: 114,
    //图标选择
    Icon: 115,
    //单选
    OneSelect: 200,
    //单选带搜索
    OneSelectSearch: 201,
    //多选
    MultSelect: 202,
    //树形
    TreeSelect: 203,
    //树形多选
    MultTreeSelect: 204,
    //当前树形多选
    MultSelfTreeSelect: 205,
    //当前树形
    SelfTreeSelect: 206,
    //懒加载树形
    LazyTreeSelect: 207,
    //级联
    CascaderSelect: 208,
    //自定义选项
    CustomOptions: 209,
    //树形 获取最后一级
    TreeSelectLast:210,
    //日期
    DateSelect: 301,
    //日期时间
    DateTimeSelect: 302,
    //时间
    TimeSelect: 303,
    //日期范围
    DateRangeSelect: 304,
    //年份选择
    YaerSelect: 305,
    //年份多选
    MultYaerSelect: 306,
    //月份选择
    MonthSelect: 307,
    //月份范围
    MonthRangeSelect: 308,
    //月份多选
    MultMonthSelect: 309,
    //日期多选
    MultDateSelect: 310,
    //年份范围
    YaerRangeSelect: 311,


    //区县
    AreaSelect: 401,
    //城市
    CitySelect: 402,
    //省份
    ProvinceSelect: 403,

    //文件详情
    FileDetail: 500,
    //单图片上传
    UploadOneImg: 1000,
    //多图片上传
    UploadMultImg: 1001,
    //单文件上传
    UploadOneFile: 1002,
    //多文件上传
    UploadMultFile: 1003,


    //地图选点
    MapSelect: 1101,
    //地址选择
    LocationSelect: 1102,
    //自定义
    Custom: 999

}
export type { TempEditForm, TempEditPageData, LocationDto, TempFormItemOption, TempFormTreeOption }
export { tempFormType, PageFormType }
