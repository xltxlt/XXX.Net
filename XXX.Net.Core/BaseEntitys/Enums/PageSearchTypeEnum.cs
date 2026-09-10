using XXX.Net.Core.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.BaseEntitys.Enums
{
    [EnumCache("PageSearchType")]
    public enum PageSearchTypeEnum
    {
        [Description("默认")]
        Default = 0,
        [Description("文本")]
        Input = 100,
        [Description("数字")]
        Number = 101,
   
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
        Custom = 99999


    }
}
