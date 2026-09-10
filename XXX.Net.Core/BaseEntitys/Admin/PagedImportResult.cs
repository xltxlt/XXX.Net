using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedImportResult
    {
        public PagedImportResult() { }
        [Description("成功条数")]
        public int SuccessCount { get; set; }
        [Description("失败条数")]
        public int FailCount { get; set; }

        [Description("失败详情")]
        public List<string> ErrorMessages { get; set; } = new();
    }
}
