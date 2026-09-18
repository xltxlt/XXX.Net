using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.Enums;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Plugins.WorkFlow.Entity;

namespace XXX.Net.Plugins.WorkFlow.Service.Dto
{
    public class PmFlowItemDto : BaseUpdate
    {
        [OptionEntity(typeof(PmFlowTemp))]
        public long PmFlowTempId { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime PlanStartTime { get; set; }

        /// <summary>
        /// 计划结束时间
        /// </summary>
        public DateTime PlanEndTime { get; set; }

        /// <summary>
        /// 开始节点表单数据。创建项目流程项时与基础参数一起提交。
        /// </summary>
        public Dictionary<string, object> StartFormData { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [OptionEnum(typeof(EnabledEnum))]
        public bool Enabled { get; set; } = true;
    }
}
