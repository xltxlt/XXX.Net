using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.BaseEntitys.Dto
{
    public class BaseParentUpdate<TSon>:BaseUpdate
    {
        public List<TSon> Children { get; set; } = new List<TSon>();
    }
}
