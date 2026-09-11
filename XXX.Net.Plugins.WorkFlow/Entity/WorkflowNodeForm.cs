using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 节点表单设计（MongoDB 存储）。
    /// FormJson 保存表单结构，AttrDataJson 独立保存控件自定义属性。
    /// </summary>
    public class WorkflowNodeForm : WorkFlowMongoEntity
    {
        /// <summary>
        /// 流程定义 Id。
        /// </summary>
        public string WorkflowDeginitionId { get; set; } = string.Empty;

        /// <summary>
        /// 流程 Id。
        /// </summary>
        public string WorkflowId { get; set; } = string.Empty;

        /// <summary>
        /// 流程版本。
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 关联的节点 Id。
        /// </summary>
        public string NodeId { get; set; } = string.Empty;

        /// <summary>
        /// 表单组件树 JSON（TempEditForm[]）。
        /// </summary>
        public string FormJson { get; set; } = "[]";

        /// <summary>
        /// 控件自定义属性 JSON。
        /// 结构：Record&lt;string, Record&lt;string, any&gt;&gt;，外层 key 为控件 ident。
        /// </summary>
        public string AttrDataJson { get; set; } = "{}";

        /// <summary>
        /// 底部按钮列表 JSON。
        /// </summary>
        public string ButtonListJson { get; set; } = "[]";
    }
}
