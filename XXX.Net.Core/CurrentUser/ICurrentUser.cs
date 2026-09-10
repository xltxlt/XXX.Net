using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Core.CurrentUser
{
    public interface ICurrentUser
    {
        long UserId { get; }

        string UserName { get; }

        long TenantId { get; }

        string RealName { get; }
    }
}
