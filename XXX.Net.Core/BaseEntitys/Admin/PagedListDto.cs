using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Admin
{
    public class PagedListDto
    {
        /// <summary>
        /// 页面Id
        /// </summary>
        public long? MenuId { get; set; }

        /// <summary>
        /// 页面编码
        /// </summary>
        public string MenuCode { get; set; } = string.Empty;

        /// <summary>
        /// 指定某租户下
        /// </summary>
        public long TenantId { get; set; }

        /// <summary>
        /// 查询(根据配置字段)
        /// </summary>

        public Dictionary<string, string> Where { get; set; } = null;

        /// <summary>
        /// 自定义高级查询
        /// </summary>
        public List<PagedCustomWhere> CustomWhere { get; set; } = null;


        /// <summary>
        /// 根据搜索类型
        /// </summary>
        public List<PagedSearchWhere> SearchWhere { get; set; } = null;

        public string GetSearchWhere(string name) {

            return this.SearchWhere.Where(w => w.FieldName == name).LastOrDefault()?.FieldValue;
        }
        public long GetIdSearchWhere(string name)
        {

            return Convert.ToInt64(this.SearchWhere.Where(w => w.FieldName == name).LastOrDefault()?.FieldValue??"0") ;
        }


        public string GetWhere(string name)
        {
            this.Where.TryGetValue(name, out string val);
            return val;
        }
        public long GetIdWhere(string name)
        {
            var val = GetWhere(name);
            if (string.IsNullOrEmpty(GetWhere(name))) {
                return 0;
            }
            return Convert.ToInt64(GetWhere(name)??"0");
        }
    }
   
}
