using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Option.Attribute;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XXX.Net.Core.BaseEntitys.Dto
{
    public class BaseUpdateTree<TTreeEntiy>:BaseUpdate where TTreeEntiy:BaseTreeEntity,new()
    {
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// /1/2/3/ TODO 待排除自动映射
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.WriteAsString)]
        [OptionEntity]
        public List<long> Path { get; set; }

    }
}
