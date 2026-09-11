using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.Services.Dep.Dto
{
    public class DepUserTreeDepartmentDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Code { get; set; }

        public long? ParentId { get; set; }

        public int Sort { get; set; }
    }
}
