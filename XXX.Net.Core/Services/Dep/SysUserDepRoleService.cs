using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Xml;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Dep.Dto;

namespace XXX.Net.Core.Services.Dep
{
    public class SysUserDepRoleService:IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;
        public SysUserDepRoleService(IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
        /// <summary>
        /// 部门用户
        /// </summary>
        /// <returns></returns>
        [DisplayName("部门用户")]
        [ApiDescriptionSettings(Name = "DepUsers", Order = 100), HttpPost]
        public async Task<PagedList<SysUser>> DepUsers(PagedPaginationListDto pagedListDto) {
            var depId = pagedListDto.GetIdSearchWhere("depId_custom");
           return await _msRepository.Slave<SysUser>().AsQueryable()
                .BuildListWhere(pagedListDto)
                .Where(depId!=0, x=> x.UserDepRoles.Any(d=>d.Deleted==false&& d.DepartmentId==depId))
                .ToPagedListAsync(pagedListDto.PageIndex, pagedListDto.PageSize);

        }
        /// <summary>
        /// 部门用户角色
        /// </summary>
        /// <returns></returns>
        [DisplayName("部门用户角色")]
        [ApiDescriptionSettings(Name = "DepUserRoles", Order = 100), HttpPost]
        public async Task<List<UserDepRolesOutput>> DepUserRoles(PagedPaginationListDto pagedListDto)
        {
            var tenantId = _currentUser.TenantId;
            var userId= pagedListDto.GetIdWhere("userId");
            var departments = await _msRepository
                .Slave<SysDepartment>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.TenantId == tenantId)
                .Include(x => x.UserDepRoles.Where(w => w.UserId == userId))
                    .ThenInclude(x => x.Role)
                .ToListAsync();

            return TreeHelper.BuildTree<SysDepartment, UserDepRolesOutput>(
                departments,
                (department, children) =>
                {
                    var output = department.Adapt<UserDepRolesOutput>();

                    output.RoleIds = department.UserDepRoles
                        .Select(x => x.RoleId)
                        .Distinct()
                        .ToList();

                    output.RoleNames = string.Join(",",
                        department.UserDepRoles
                            .Where(x => x.Role != null)
                            .Select(x => x.Role.Name)
                            .Distinct()
                    );
                    output.Checked = (output.RoleIds !=null&& output.RoleIds.Count() > 0)?1:0;
                    output.Children = children;

                    return output;
                },
                0
            );
        }

        /// <summary>
        /// 设置部门用户角色
        /// </summary>
        [DisplayName("设置部门用户角色")]
        [ApiDescriptionSettings(Name = "SetDepUserRoles", Order = 100), HttpPost]
        [UnitOfWork]
        public async Task SetDepUserRoles(UserDepRolesDto dto)
        {

            var tenantId = _currentUser.TenantId;
            var userId = _currentUser.UserId;
            var userName = _currentUser.UserName;
            var now = DateTime.Now;

            // 防止同一个用户、同一个部门重复提交
            var _userId = dto.UserId;

            // 删除本次提交涉及的用户-部门的旧角色
            await _msRepository
                .Master<SysUserDepRole>()
                .Where(x =>
                x.TenantId== tenantId&&
                    x.Department.TenantId == tenantId &&x.UserId== _userId
                    )
                .DeleteFromQueryAsync();

            // 重新生成角色关系
            var entitys = dto.DepRoles
                .SelectMany(item =>item.Value
                    .Distinct()
                    .Select(roleId => new SysUserDepRole
                    {
                        TenantId=tenantId,
                        UserId = dto.UserId,
                        DepartmentId = item.Key,
                        RoleId = roleId,

                        CreatedBy = userId,
                        CreatedByName = userName,
                        CreatedTime = now,

                        UpdatedBy = userId,
                        UpdatedByName = userName,
                        UpdatedTime = now
                    }))
                .ToList();

            if (entitys.Count > 0)
            {
                await _msRepository
                    .Master<SysUserDepRole>()
                    .InsertAsync(entitys);
            }
        }
    }
}
