using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.IdGenerator
{
    public class IdGenOptions
    {
        public int GeneratorId { get; set; }
        public DateTime Epoch { get; set; } = new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
