import type { Ref, ComputedRef } from "vue";
import type { AxiosResponse } from "axios";
import type { PagedCustomWhere, PagedOptions } from "@/api-services/generated";
import type { SysMenuButtonDto, SysMenuTableButtonDto, SysMenuTableFieldDto } from "@/api-services/generated";
interface SearchWhere { }
interface TempListPageConfig {
  url: string | Function;
  optionUrl?: string | Function;
  renderUrl?: string | Function;
  where?: Record<string, any>;
  customWhere?: PagedCustomWhere[] | [];
  showTooltip?: boolean;
  hideSearch?: boolean | Ref<boolean> | ComputedRef<boolean>;
  showLeftSearch?:boolean|string;
  pageFun: Record<
    string,
    (data: any) =>
      | {
        comp?: any;
        width?: string;
        height?: string;
        pars?: Record<string, any>;
      }
      | void
      | any
  >;
  hideBtn?: boolean | Ref<boolean> | ComputedRef<boolean>;
  customData?: {
    total?: number;
    list?: any[];
  };
  successCb?: Function;
  defChecked?: boolean;
  customListPage?: {
    search: SearchItem[];
    btns: SysMenuTableButtonDto[];
    fields: TableField[];
    tableBtns: SysMenuTableButtonDto[];
  };
  treeProps?: any;
  maxBtn?: number;
  tableProps?: any;
  treeField?: string;
  tableOn?: any;
  checkStrictly?: boolean;
  expandAll?: boolean;
  rowKey?: string;
  isPage?: boolean;
  setRowTableBtns?: (tableBtns: any[], scope: any) => any[];
}
interface SearchItem {
  searchType: number;
  value: string | number | string[] | number[] | null;
  option: PagedOptions[] | null;
  label: string;
  serach?: boolean;
  fieldName: string;
}
interface TempListPageExpose {
  expandAll: Function;
  openDialog: Function;
  onRefresh: Function;
  getSelectionRows: Function;
  setCustomData: Function;
  toggleRowSelection: Function;

  toggleRowExpansion: Function;
  /**
   * 获取表格数据
   */
  getTableData: Function;
  /**
   * 重置表格数据
   */
  resetTableRowData: Function;
}
interface TableField extends SysMenuTableFieldDto{
  comProps?:any,
  comOn?:any,
  props?:any,
  on?:any,
  must?:boolean
}
/**
 * 页面搜索类型
 */
export const PagedSearchType = {
  //默认
  Input: 100,
  //数字
  Number: 101,

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

  //数范围
  NumberRange: 501,

  //区县
  AreaSelect: 401,

  //城市
  CitySelect: 402,

  //省份
  ProvinceSelect: 403,

  //自定义
  Custom: 99999,
};
/**
 * 搜索类型
 */
export const ConditionalType = {
  /// <summary>
  /// 等于（=）
  /// </summary>
  Equal: 0,

  /// <summary>
  ///  不等于
  /// </summary>
  NotEqual: 1,

  /// <summary>
  /// 大于
  /// </summary>
  GreaterThan: 2,

  /// <summary>
  /// 小于
  /// </summary>
  LessThan: 3,

  /// <summary>
  /// 大于等于
  /// </summary>
  GreaterThanOrEqual: 4,

  /// <summary>
  /// 小于等于
  /// </summary>
  LessThanOrEqual: 5,

  /// <summary>
  /// 模糊匹配
  /// </summary>
  Like: 6,

  /// <summary>
  /// 左匹配
  /// </summary>
  StartsWith: 7,

  /// <summary>
  /// IN 查询
  /// Value 必须是 IEnumerable
  /// </summary>
  In: 8,

  /// <summary>
  /// NOT IN 查询
  /// Value 必须是 IEnumerable
  /// </summary>
  NotIn: 9,
};
/**
 * 字段显示类型
 */
export const FieldType =
{

  /**
   * 默认
   */
  Default: 0,
  /**
   * 查看
   */
  Look: 1,
  /**
   * 颜色块
   */
  ColorBlock: 2,
  /**
   * 图标
   */
  Icon: 3,
  /**
   * 链接
   */
  Link: 4,
  /**
   * 审核状态
   */
  AuditStatus: 9,
  /**
   * 颜色按钮
   */
  ColorBtn: 10,
  /**
   * 颜色文本
   */
  ColorText: 11,
  /**
   * 审核文本
   */
  AuditText: 12,
  /**
   * 状态颜色
   */
  StatusColor: 13,

  /**
   * 表格
   */
  Table: 16,
  /**
   * 图片
   */
  Img: 17,
  /**
   * 文件
   */
  File: 18,
  /**
   * 进度条
   */
  Progress: 19,
  /**
   * 提示
   */
  Tip: 19,

  /**
   * 操作栏
   */
  RightTools: 98,

  /**
   * 默认
   */
  Input: 100,
  /**
   * 数字
   */
  Number: 101,

  /**
   * 选择框
   */
  Checkbox: 102,
  /**
   * radio选择
   */
  Radio: 103,

  /**
   * 多行文本
   */
  TextAreaInput: 104,

  /**
   * 两位小数
   */
  Decimal:105,
  /**
   * 步进器
   */
  Stepper: 106,
  /**
   * 比率
   */
  Rate: 107,
  /**
   * 开关
   */
  Switch: 108,


  /**
   * 手机号
   */
  Phone: 109,


  /**
   * 整数
   */
  NumberInput: 110,

  /**
   * 小数
   */
  DecimalInput: 111,

  /**
   * 金额
   */
  Amount: 112,



  /**
   * 单选
 */

  OneSelect: 200,

  /**
   * 单选带搜索
   */
  OneSelectSearch: 201,

  /**
   * 多选
   */
  MultSelect: 202,

  /**
   * 树形
   */
  TreeSelect: 203,

  /**
   * 树形多选
   */
  MultTreeSelect: 204,

  /**
   * 当前树形多选
   */
  MultSelfTreeSelect: 205,

  /**
   * 当前树形
   */
  SelfTreeSelect: 206,


  /**
   * 日期
   */
  DateSelect: 301,

  /**
   * 日期时间
   */
  DateTimeSelect: 302,

  /**
   * 时间
   */
  TimeSelect: 303,


  /**
   * 日期范围
   */
  DateRangeSelect: 304,

  /**
   * 年份选择
   */
  YaerSelect: 305,
  /**
   * 年份多选
  */

  MultYaerSelect: 306,
  /**
   * 月份选择
  */

  MonthSelect: 307,
  /**
   * 月份范围
 */

  MonthRangeSelect: 308,
  /**
   * 月份多选
  */

  MultMonthSelect: 309,

  /**
   * 日期多选
  */

  MultDateSelect: 310,
  /**
   * 年份范围
   */
  YaerRangeSelect: 311,



  /**
   * 区县
   */
  AreaSelect: 401,

  /**
   * 城市
   */
  CitySelect: 402,

  /**
   * 省份
   */
  ProvinceSelect: 403,


  /**
   * 自定义
   */
  Custom: 99999

};

/**
 * 浮动类型
 */
export const FloatType = {
  /**
   * 无浮动
   */
  None: 0,
  /**
   * 左浮动
   */
  Left: 1,
  /**
   * 右浮动
   */
  Right: 2,
}
/**
 * 对齐方式
 */
export const AlignTypeEnum =
{
  /**
   * 默认
   */
  Default: 0,
  /**
   * 左对齐
   */
  Left: 1,
  /**
   * 右对齐
   */
  Right: 2,
  /**
   * 居中对齐
   */
  Center: 3,
}
export type { TempListPageConfig, SearchItem,TableField };
