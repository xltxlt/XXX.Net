using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedPaginationListDto:PagedListDto
    {
       
        /// <summary>
        /// 页面下标
        /// </summary>
        [Required(ErrorMessage ="必填"),Min(1)]
        public int PageIndex { get; set; }
        /// <summary>
        /// 页面条数
        /// </summary>
        [Required(ErrorMessage ="必填"), Min(1), Max(1000)]
        public int PageSize { get; set; }

    }

}