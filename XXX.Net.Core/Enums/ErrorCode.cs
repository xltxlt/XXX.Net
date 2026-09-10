using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.Enums
{
    /// <summary>
    /// 100000 - 199999  系统模块
    /// 200000 - 299999  用户模块
    /// 300000 - 399999  权限模块
    /// 400000 - 499999  工作流模块
    /// 600000 - 699999  业务模块
    /// 
    /// </summary>
    public enum ErrorCode
    {
        #region 系统模块
        [Description("系统异常")]
        SystemError = 100001,

        [Description("数据库异常")]
        DatabaseError = 100002,

        [Description("参数错误")]
        ParamError = 100003,

        #endregion

        #region 用户模块
        [Description("用户不存在")]
        UserNotFound = 200001,


        [Description("密码错误")]
        PasswordError = 200002,

        #endregion

        #region 权限模块
        [Description("未认证")]
        NoAuth=300000,

        [Description("无访问权限")]
        NoPermission = 300001,
        #endregion

        #region 工作流模块
        [Description("工作流错误")]
        WorkflowError = 400000,

        [Description("流程不存在")]
        WorkflowNotFound = 400001,

        [Description("流程已结束")]
        WorkflowCompleted = 400002,
        #endregion


        #region 业务错误

        [Description("业务错误")]
        BusinessError=600000
        #endregion

    }
}
