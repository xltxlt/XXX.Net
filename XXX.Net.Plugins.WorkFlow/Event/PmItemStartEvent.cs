using System.Collections.Generic;
using XXX.Net.Plugins.WorkFlow.Entity;

namespace XXX.Net.Plugins.WorkFlow.Event
{
    /// <summary>
    /// 项目流程项发起事件。
    /// 除项目流程项本身外，携带开始节点表单数据，保证异步启动 WorkflowCore 时不丢失发起表单。
    /// </summary>
    public class PmItemStartEvent
    {
        public PmFlowItem Item { get; set; }

        public Dictionary<string, object> StartFormData { get; set; } = new Dictionary<string, object>();
    }
}
