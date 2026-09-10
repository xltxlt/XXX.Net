using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace XXX.Net.Core.Services.Menu.Dto
{
    public class SysMenuRenderDto : IValidatableObject
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public long? MenuId { get; set; } = null;

        /// <summary>
        /// 菜单编码
        /// </summary>
        public string MenuCode { get; set; } = string.Empty;

        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {
            if (MenuId == null &&
                string.IsNullOrWhiteSpace(MenuCode))
            {
                yield return new ValidationResult(
                    "MenuId 和 MenuCode 必须填写一个。",
                    new[]
                    {
                    nameof(MenuId)
                    });
            }
        }
    }
}
