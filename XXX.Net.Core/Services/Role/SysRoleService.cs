using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Role.Dto;
using XXX.Net.Core.Services.User.Dto;

namespace XXX.Net.Core.Services.Role
{
    public class SysRoleService : BaseService<SysRole, RoleDto>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysRoleService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }

        #region 角色权限
        [DisplayName("获取角色权限")]
        [ApiDescriptionSettings(Name = "RolePermission", Order = 1100)]
        [HttpGet]
        public async Task<RolePermissionDto> RolePermission(long id)
        {
            // 2. 查询角色菜单权限
            var roleMenus = await _msRepository
                .Slave<SysRoleMenu>()
                .AsQueryable()
                .Include(x=>x.Menu)
                .Where(x => x.RoleId == id)
                .ToListAsync();


            // 3. 查询角色按钮权限
            var roleButtons = await _msRepository
                .Slave<SysRoleMenuButton>()
                .AsQueryable()
                .Include(x => x.MenuButton)
                .Where(x => x.RoleId == id)
                .ToListAsync();

            // 4. 查询角色字段权限
            var roleFields = await _msRepository
                .Slave<SysRoleMenuField>()
                .AsQueryable()
                .Include(x => x.MenuField)
                .Where(x => x.RoleId == id)
                .ToListAsync();


            var buttonIds = roleButtons
                .Select(x => x.MenuButtonId)
                .ToHashSet();

            var fieldPermissions = roleFields
                .ToDictionary(x => x.MenuFieldId);


            // 7. 组装
            var result = new RolePermissionDto
            {
                RoleId = id,
                Menus = roleMenus.Select(roleMenu => new RoleMenuPermissionOutput
                {
                    Id = roleMenu.MenuId,
                    Name=roleMenu.Menu.Name,
                    Checked = true,
                    MenuButtons = roleButtons
                        .Where(x => x.MenuButton.MenuId == roleMenu.MenuId)
                        .Select(button =>
                        new SysMenuCompose()
                        {
                            Name = button.MenuButton.Name,
                            Label = button.MenuButton.Label,
                            Id = button.MenuButtonId
                        })
                        .ToList(),

                    MenuFields = roleFields
                        .Where(x => x.MenuField.MenuId == roleMenu.MenuId)
                        .Select(field => new SysMenuCompose()
                        {
                            Name = field.MenuField.Name,
                            Label = field.MenuField.Label,
                            Id = field.MenuFieldId
                        })
                        .ToList()

                }).ToList()
            };

            return result;
        }

        [DisplayName("设置角色权限")]
        [ApiDescriptionSettings(Name = "SetRolePermission", Order = 1100)]
        [HttpPost]
        [UnitOfWork]
        public async Task SetRolePermission(SetRolePermissionDto dto)
        {
            // 1. 删除原来的菜单权限
            var roleMenus = await _msRepository
                .Master<SysRoleMenu>()
                .Where(x => x.RoleId == dto.RoleId)
                .ToListAsync();

            if (roleMenus.Count > 0)
            {
                await _msRepository.Master<SysRoleMenu>()
                     .DeleteAsync(roleMenus);
            }

            // 2. 删除原来的按钮权限
            var roleButtons = await _msRepository
                .Master<SysRoleMenuButton>()
                .Where(x => x.RoleId == dto.RoleId)
                .ToListAsync();

            if (roleButtons.Count > 0)
            {
                await _msRepository.Master<SysRoleMenuButton>()
                     .DeleteAsync(roleButtons);
            }

            // 3. 删除原来的字段权限
            var roleFields = await _msRepository
                .Master<SysRoleMenuField>()
                .Where(x => x.RoleId == dto.RoleId)
                .ToListAsync();

            if (roleFields.Count > 0)
            {
                await _msRepository.Master<SysRoleMenuField>()
                    .DeleteAsync(roleFields);
            }

            // 4. 新增菜单权限
            var newMenus = dto.MenuIds
                .Distinct()
                .Select(menuId => new SysRoleMenu
                {
                    RoleId = dto.RoleId,
                    MenuId = menuId
                })
                .ToList();

            if (newMenus.Count > 0)
            {
                await _msRepository
                    .Master<SysRoleMenu>()
                    .InsertAsync(newMenus);
            }

            // 5. 新增按钮权限
            var newButtons = dto.MenuButtonIds
                .Distinct()
                .Select(buttonId => new SysRoleMenuButton
                {
                    RoleId = dto.RoleId,
                    MenuButtonId = buttonId
                })
                .ToList();

            if (newButtons.Count > 0)
            {
                await _msRepository
                    .Master<SysRoleMenuButton>()
                    .InsertAsync(newButtons);
            }

            // 6. 新增字段权限

            var newFields = dto.MenuFieldIds
               .Distinct()
               .Select(fieldId => new SysRoleMenuField
               {
                   RoleId = dto.RoleId,
                   MenuFieldId = fieldId
               })
               .ToList();
            if (newFields.Count > 0)
            {
                await _msRepository
                    .Master<SysRoleMenuField>()
                    .InsertAsync(newFields);
            }

        }
        #endregion

    }
}
