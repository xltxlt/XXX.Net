using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys
{
    public class FatherSonDto<TParentDto, TChildDto>
     where TParentDto : class, new()
     where TChildDto : class, new()
    {
        /// <summary>
        /// 父表
        /// </summary>
        public TParentDto Parent { get; set; }

        /// <summary>
        /// 子表
        /// </summary>
        public List<TChildDto> Children { get; set; } = new();
    }
}
