using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.BaseEntitys.Enums
{
    /// <summary>
    /// 表头字段类型
    /// </summary>
    [EnumCache("PageFieldType")]

    public enum PageTableFieldTypeEnum
    {
        [Description("默认")]
        Default=0,

        [Description("查看")]
        Look =1,

        [Description("颜色块")]
        ColorBlock = 2,

        [Description("图标")]
        Icon= 3,

        [Description("链接")]
        Link = 4,

        [Description("审核状态")]
        AuditStatus =9,

        [Description("颜色按钮")]
        ColorBtn =10,

        [Description("颜色文本")]
        ColorText = 11,

        [Description("审核文本")]
        AuditText = 12,

        [Description("状态颜色")]
        StatusColor = 13,
   
        [Description("表格")]
        Table = 16,

        [Description("图片")]
        Img = 17,

        [Description("文件")]
        File = 18,

        [Description("进度条")]
        Progress=19,

        [Description("提示")]
        Tip= 19,

        [Description("操作栏")]
        RightTools = 98,

        [Description("默认")]
        Input = 100,

        [Description("数字")]
        Number = 101,

        [Description("选择框")]
        Checkbox = 102,

        [Description("radio选择")]
        Radio = 103,

        [Description("多行文本")]
        TextAreaInput = 104,

        [Description("两位小数")]
        Decimal = 101,

        [Description("步进器")]
        Stepper = 106,

        [Description("比率")]
        Rate = 107,

        [Description("开关")]
        Switch = 108,

        [Description("手机号")]
        Phone = 109,

        [Description("整数")]
        NumberInput = 110,

        [Description("小数")]
        DecimalInput = 111,

        [Description("金额")]
        Amount = 112,

        [Description("单选")]
        OneSelect = 200,

        [Description("单选带搜索")]
        OneSelectSearch = 201,

        [Description("多选")]
        MultSelect = 202,

        [Description("树形")]
        TreeSelect = 203,

        [Description("树形多选")]
        MultTreeSelect = 204,

        [Description("当前树形多选")]
        MultSelfTreeSelect = 205,

        [Description("当前树形")]
        SelfTreeSelect = 206,

        [Description("日期")]
        DateSelect = 301,

        [Description("日期时间")]
        DateTimeSelect = 302,

        [Description("时间")]
        TimeSelect = 303,

        [Description("日期范围")]
        DateRangeSelect = 304,

        [Description("年份选择")]
        YaerSelect = 305,
        [Description("年份多选")]

        MultYaerSelect = 306,
        [Description("月份选择")]

        MonthSelect = 307,
        [Description("月份范围")]

        MonthRangeSelect = 308,
        [Description("月份多选")]

        MultMonthSelect = 309,

        [Description("日期多选")]

        MultDateSelect = 310,
        [Description("年份范围")]
        YaerRangeSelect = 311,

        [Description("区县")]
        AreaSelect = 401,

        [Description("城市")]
        CitySelect = 402,

        [Description("省份")]
        ProvinceSelect = 403,

        [Description("自定义")]
        Custom =99999
    }
}
