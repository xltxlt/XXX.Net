
using XXX.Net.Core.BaseEntitys;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Tree;
using XXX.Net.Core.Services.Menu.Dto;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel;
using System.Xml;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using System.Linq.Dynamic.Core;

namespace XXX.Net.Core.Services.Menu
{
    public class SysMenuService : BaseTreeService<SysMenu, SysMenuDto, SysMenuTreeOutput>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysMenuService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
        [ApiDescriptionSettings(Name = "MenuRender", Order = 1000), HttpPost]
        [DisplayName("获取菜单渲染数据")]
        public virtual async Task<SysMenuOutputDto> MenuRender(SysMenuRenderDto dto)
        {
            var entity = await _msRepository.Slave<SysMenu>().AsQueryable().AsNoTracking()
                .Where(dto.MenuId != null ,w => w.Id == dto.MenuId)
                .Where(dto.MenuId == null, w => w.Code == dto.MenuCode)
                .Include(w=>w.MenuFields)
                .Include(w=>w.MenuButtons)
                .OrderBy(w => w.Sort).ThenBy(w => w.Id)
                .FirstOrDefaultAsync();
           
            return entity.Adapt<SysMenuOutputDto>();
        }

        /// <summary>
        /// 获取当前用户左侧菜单
        /// </summary>
        [ApiDescriptionSettings(Name = "LeftMenu", Order = 1100), HttpPost]
        [DisplayName("获取左侧菜单")]
        public virtual async Task<List<SysMenuTreeOutput>> LeftMenu()
        {
            var userId = _currentUser.UserId;
            var tenantId = _currentUser.TenantId;
            var menus = new List<SysMenu>();
            var mUser = await _msRepository.Slave<SysUser>().AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
            if (mUser.IsAdmin)
            {
                menus =await GetSysManagerMenu(tenantId);
            }
            else {
                menus = await GetUserMenu(userId, tenantId);
            }
            
            // 5. 构建菜单树
            return TreeHelper.BuildTree<SysMenu, SysMenuTreeOutput>(
                menus,
                (menu, children) => new SysMenuTreeOutput
                {
                    Id = menu.Id,
                    Code = menu.Code,
                    Icon = menu.Icon,
                    Alias = menu.Alias,
                    Name = menu.Name,
                    Description = menu.Description,
                    Route = menu.Route,
                    Children = children
                },
                0);
        }
        public async Task<List<SysMenu>> GetUserMenu(long userId,long tenantId) {
            // 1. 获取当前用户拥有的角色
            var roleIds = await _msRepository
                .Slave<SysUserDepRole>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x =>

                x.Deleted==false&&
                    x.UserId == userId &&
                    x.TenantId == tenantId)
                .Select(x => x.RoleId)
                .Distinct()
                .ToListAsync();

            if (roleIds.Count == 0)
                return [];

            // 2. 获取角色对应的菜单
            var menuIds = await _msRepository
                .Slave<SysRoleMenu>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => roleIds.Contains(x.RoleId))
                .Select(x => x.MenuId)
                .Distinct()
                .ToListAsync();

            if (menuIds.Count == 0)
                return [];

            // 3. 查询用户有权限的二级菜单
            var menus = await _msRepository
                .Slave<SysMenu>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x =>
                        x.Enabled &&
                    x.MenuType == 2 &&
                    x.ClassLevel == 2 &&
                    menuIds.Contains(x.Id))
                .OrderBy(x => x.Sort)
                .ThenBy(x => x.Id)
                .ToListAsync();

            if (menus.Count == 0)
                return [];

            // 4. 获取二级菜单对应的一级父菜单
            var parentIds = menus
                .Select(x => x.ParentId)
                .Where(x => x > 0)
                .Distinct()
                .ToList();

            if (parentIds.Count > 0)
            {
                var parentMenus = await _msRepository
                    .Slave<SysMenu>()
                    .AsQueryable()
                    .AsNoTracking()
                    .Where(x =>
                        x.Enabled &&


                        x.MenuType == 1 &&
                        x.ClassLevel == 1 &&
                        parentIds.Contains(x.Id))
                    .OrderBy(x => x.Sort)
                    .ThenBy(x => x.Id)
                    .ToListAsync();

                menus.AddRange(parentMenus);
            }
            return menus;
        }
        public async Task<List<SysMenu>> GetSysManagerMenu(long tenantId)
        {
           
            // 3. 查询用户有权限的二级菜单
            var menus = await _msRepository
                .Slave<SysMenu>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x =>
                        x.Enabled &&
                    x.MenuType == 2 &&
                    x.ClassLevel == 2 &&
                    x.TenantId==tenantId)
                .OrderBy(x => x.Sort)
                .ThenBy(x => x.Id)
                .ToListAsync();

            if (menus.Count == 0)
                return [];

            // 4. 获取二级菜单对应的一级父菜单
            var parentIds = menus
                .Select(x => x.ParentId)
                .Where(x => x > 0)
                .Distinct()
                .ToList();

            if (parentIds.Count > 0)
            {
                var parentMenus = await _msRepository
                    .Slave<SysMenu>()
                    .AsQueryable()
                    .AsNoTracking()
                    .Where(x =>
                        x.Enabled&&
                        x.MenuType == 1 &&
                        x.ClassLevel == 1 &&
                        parentIds.Contains(x.Id))
                    .OrderBy(x => x.Sort)
                    .ThenBy(x => x.Id)
                    .ToListAsync();

                menus.AddRange(parentMenus);
            }
            return menus;
        }
        [ApiDescriptionSettings(Name = "AllMenuCompose", Order = 1100), HttpPost]
        [DisplayName("获取所有菜单、按钮、表头")]
        public virtual async Task<List<SysMenuComposeTreeOutput>> AllMenuCompose()
        {
            var mlEntity = await _msRepository.Slave<SysMenu>().AsQueryable().AsNoTracking()
                .Where(w => w.MenuType <= 2 && w.ClassLevel <= 2)
                //.Where(w=>w.TenantId==_currentUser.TenantId)
                .Include(x=>x.MenuFields)
                .Include(x => x.MenuButtons)
                .OrderBy(w => w.Sort).ThenBy(w => w.Id)
                .ToListAsync();
            return TreeHelper.BuildTree<SysMenu, SysMenuComposeTreeOutput>(mlEntity, (SysMenu menu, List<SysMenuComposeTreeOutput> children) => {
                return new SysMenuComposeTreeOutput()
                {
                    Id = menu.Id,
                    Code = menu.Code,
                    Icon = menu.Icon,
                    Alias = menu.Alias,
                    Name = menu.Name,
                    Description = menu.Description,
                    Route = menu.Route,
                    Children = children,
                    MenuButtons=menu.MenuButtons.Adapt<List<SysMenuCompose>>(),
                    MenuFields=menu.MenuFields.Adapt<List<SysMenuCompose>>(),
                };
            }, 0);
        }
    }
}
