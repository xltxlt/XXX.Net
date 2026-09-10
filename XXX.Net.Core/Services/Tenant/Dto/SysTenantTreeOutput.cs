using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.Services.Base.Dto;

namespace XXX.Net.Core.Services.Tenant.Dto
{
    public class SysTenantTreeOutput : IPagedTreeOutput<SysTenantTreeOutput>
    {
        public string Code { get; set; }
        public string Remark { get; set; }
        public int Enabled { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SysTenantTreeOutput> Children { get; set; } = new List<SysTenantTreeOutput>();
    }
    }
