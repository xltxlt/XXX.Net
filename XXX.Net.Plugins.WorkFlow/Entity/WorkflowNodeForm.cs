using System;
using System.Collections.Generic;
using System.Text;


namespace XXX.Net.Plugins.WorkFlow.Entity
{
    /// <summary>
    /// 节点表单设计（MongoDB 存储），保存 YzCustomForm 的表单 JSON
    /// </summary>
    public class WorkflowNodeForm : WorkFlowMongoEntity
    {
        /// <summary>
         /// 
         /// </summary>
        public string WorkflowDeginitionId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string WorkflowId { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// 关联的节点 Id
        /// </summary>
        public string NodeId { get; set; } = string.Empty;

        /// <summary>
        /// 表单组件树 JSON（TempEditForm[]）
        /// </summary>
        public string FormJson { get; set; } = "[]";

        /// <summary>
        /// 组件属性 JSON（Record&lt;string, componentAttrData[]&gt;）
        /// </summary>
        public string AttrDataJson { get; set; } = "{}";

        /// <summary>
        /// 底部按钮列表 JSON
        /// </summary>
        public string ButtonListJson { get; set; } = "[]";
    }
}
