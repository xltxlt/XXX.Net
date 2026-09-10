using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Base.Dto
{
    public class BasePagedTreeOutput : IPagedTreeOutput<BasePagedTreeOutput>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<BasePagedTreeOutput> Children { get; set; } = new List<BasePagedTreeOutput>();
    }
}
