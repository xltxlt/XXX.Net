using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.BaseEntitys.Enums
{
    [EnumCache("PageFormType")]
    public enum PageFormTypeEnum
    {
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
        [Description("多文件预览")]
        MultFileDetail = 105,
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
        [Description("颜色")]
        Color = 113,
        [Description("滑块")]
        Slider = 114,
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

        [Description("懒加载树形")]
        LazyTreeSelect=207,

        [Description("级联")]

        CascaderSelect = 208,
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

        [Description("文件详情")]
        FileDetail = 500,



        [Description("单图片上传")]
        UploadOneImg = 1000,
        [Description("多图片上传")]
        UploadMultImg = 1001,
        [Description("单文件上传")]
        UploadOneFile = 1002,
        [Description("多文件上传")]
        UploadMultFile = 1003,




        [Description("地图选点")]
        MapSelect = 1101,

        [Description("地址选择")]
        LocationSelect = 1102,

        [Description("自定义")]
        Custom = 99999
    }
}
