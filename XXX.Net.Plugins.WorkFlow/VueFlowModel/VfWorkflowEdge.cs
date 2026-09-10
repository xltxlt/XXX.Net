using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.VueFlowModel
{
    public class VfWorkflowEdge
    {
        public string Source { get; set; }

        public string Target { get; set; }

        public string? Condition { get; set; }

        public string EdgeJson { get; set; } = string.Empty;

    }
}
