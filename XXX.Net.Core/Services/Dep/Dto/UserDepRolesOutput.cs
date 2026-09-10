using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Dto;


namespace XXX.Net.Core.Services.Dep.Dto
{
    public class UserDepRolesOutput : BasePrimaryKey, IPagedTreeOutput<UserDepRolesOutput>
    {
        public string Code { get; set; }

        public List<long> RoleIds { get; set; }

        public string RoleNames { get; set; }

        public string Name { get; set; }

        public int Sort { get; set; }
        public int Checked { get; set; }
        public List<UserDepRolesOutput> Children { get; set; } = new List<UserDepRolesOutput>();

    }
}
