using System;
using System.Collections.Generic;
using System.Text;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    /// <summary>
    /// 节点表单设计保存 DTO（前端 YzCustomForm 序列化后的 JSON）
    /// </summary>
    public class WorkflowFormDto
    {
        public string WorkflowId { get; set; } = string.Empty;

        public string NodeId { get; set; } = string.Empty;

        /// <summary>
        /// 表单组件树 JSON（TempEditForm[]）
        /// </summary>
        public string FormJson { get; set; } = "[]";

        /// <summary>
        /// 组件属性 JSON
        /// </summary>
        public string AttrDataJson { get; set; } = "{}";

        /// <summary>
        /// 底部按钮列表 JSON
        /// </summary>
        public string ButtonListJson { get; set; } = "[]";
    }
}
