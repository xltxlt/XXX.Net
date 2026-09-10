using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Option.Attribute;

namespace XXX.Net.Core.Services.Org.Dto
{
    public class SysDepDto: BaseTenantUpdateTree<SysDepartment>
    {
        /// <summary>编码</summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>简称</summary>
        public string ShortName { get; set; } = null;


        /// <summary>顶级组织</summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool IsTopOrg { get; set; }

        /// <summary>域名</summary>
        public string DomainName { get; set; } = null;

        /// <summary>企业信用代码</summary>
        public string CompanyCode { get; set; } = null;

        /// <summary>联系人</summary>
        public string Contacts { get; set; } = null;

        /// <summary>联系人手机</summary>
        public string ContactsPhone { get; set; } = null;

        /// <summary>地址</summary>
        public string ContactsAddress { get; set; } = null;

        /// <summary>
        /// 状态
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
    }
}
