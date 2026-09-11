using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Xml;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Dep.Dto;
using XXX.Net.Core.Services.Menu.Dto;

namespace XXX.Net.Core.Services.Dep
{
    public class SysUserDepRoleService : IDynamicApiController
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
        public async Task<PagedList<SysUser>> DepUsers(PagedPaginationListDto pagedListDto)
        {
            var depId = pagedListDto.GetIdSearchWhere("depId_custom");
            return await _msRepository.Slave<SysUser>().AsQueryable()
                 .BuildListWhere(pagedListDto)
                 .Where(depId != 0, x => x.UserDepRoles.Any(d => d.Deleted == false && d.DepartmentId == depId))
                 .ToPagedListAsync(pagedListDto.PageIndex, pagedListDto.PageSize);

        }
        [DisplayName("租户部门用户汇总")]
        [ApiDescriptionSettings(Name = "DepUserSummary", Order = 100), HttpPost]
        public async Task<List<DepUserSummaryOutput>> DepUserSummary(PagedListDto pagedListDto)
        {
            var tenantId = pagedListDto.GetIdWhere("tenantId");


            // 1. 查询租户所有部门
            var departments = await _msRepository
                .Slave<SysDepartment>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.TenantId == tenantId)
                .Select(x => new DepUserSummaryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    Code = x.Code,
                    ParentId = x.ParentId,
                    LeaderUserId = x.LeaderUserId,
                    Sort = x.Sort,

                    UserIds = x.UserDepRoles
                        .Where(g => !g.Deleted)
                        .Select(g => g.UserId)
                        .Distinct()
                        .ToHashSet()
                })
                .OrderBy(x => x.Sort)
                .ToListAsync();


            // 2. 部门字典
            var departmentMap = departments.ToDictionary(
                x => x.Id
            );


            // 3. 父子关系
            var childrenMap = departments
                .GroupBy(x => x.ParentId)
                .ToDictionary(
                    x => x.Key,
                    x => x
                        .OrderBy(d => d.Sort)
                        .ToList()
                );


            // 4. 递归计算部门汇总
            DepUserSummaryDto BuildSummary(
                DepUserSummaryDto department)
            {
                var userIds = new HashSet<long>(
                    department.UserIds
                );


                if (childrenMap.TryGetValue(
                    department.Id,
                    out var children))
                {
                    foreach (var child in children)
                    {
                        BuildSummary(child);

                        // 子部门用户合并并去重
                        userIds.UnionWith(
                            child.UserIds
                        );
                    }
                }


                department.UserIds = userIds;

                // 当前部门 + 所有子部门的用户
                department.UserCount =
                    userIds.Count;


                // 所有后代部门数量
                department.DepCount =
                    children?.Sum(x =>
                        x.DepCount + 1
                    ) ?? 0;


                return department;
            }


            // 5. 找到真正的根部门
            var rootDepartments = departments
                .Where(x =>
                    x.ParentId <= 0 ||
                    !departmentMap.ContainsKey(
                        x.ParentId
                    )
                )
                .OrderBy(x => x.Sort)
                .ToList();


            // 6. 计算所有根部门
            foreach (var root in rootDepartments)
            {
                BuildSummary(root);
            }


            // 7. 查询租户
            var sysTenant = await _msRepository
                .Slave<SysTenant>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == tenantId)
                .FirstOrDefaultAsync();


            if (sysTenant == null)
            {
                return new List<DepUserSummaryOutput>();
            }


            // 8. 创建租户虚拟根节点
            var tenantUserIds = new HashSet<long>();


            foreach (var department in rootDepartments)
            {
                tenantUserIds.UnionWith(
                    department.UserIds
                );
            }


            var tenantNode = new DepUserSummaryDto
            {
                Id = sysTenant.Id,

                Name = sysTenant.Name,

                Code = sysTenant.Code,

                ParentId = 0,

                UserIds = tenantUserIds,

                UserCount = tenantUserIds.Count,

                // 根部门数量 + 所有子部门
                DepCount = rootDepartments.Sum(
                    x => x.DepCount + 1
                )
            };


            // 9. 租户作为整个部门树的根节点
            var result = new List<DepUserSummaryOutput>
    {
        new DepUserSummaryOutput
        {
            Id = tenantNode.Id,

            Code = tenantNode.Code,

            Name = tenantNode.Name,

            UserCount =
                tenantNode.UserCount,

            DepCount =
                tenantNode.DepCount,

            Children =
                TreeHelper.BuildTree<
                    DepUserSummaryDto,
                    DepUserSummaryOutput
                >(
                    departments,
                    (
                        DepUserSummaryDto item,
                        List<DepUserSummaryOutput> children
                    ) =>
                    {
                        return new DepUserSummaryOutput
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Name = item.Name,
                            UserCount = item.UserCount,
                            DepCount = item.DepCount,
                            Children = children
                        };
                    }
                )
        }
    };
            return result;
        }

        [DisplayName("获取部门及子部门用户")]
        [ApiDescriptionSettings(Name = "DepUserTree", Order = 101), HttpPost]
        public async Task<List<DepUserTreeOutput>> DepUserTree(PagedListDto pagedListDto)
        {
            var tenantId = pagedListDto.GetIdWhere("tenantId");

            var departmentId = pagedListDto.GetIdWhere("departmentId");


            // =========================================================
            // 1. 查询租户所有部门
            // =========================================================

            var departments = await _msRepository
                .Slave<SysDepartment>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.TenantId == tenantId)
                .Select(x => new DepUserTreeDepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ShortName = x.ShortName,
                    Code = x.Code,
                    ParentId = x.ParentId,
                    Sort = x.Sort
                })
                .OrderBy(x => x.Sort)
                .ToListAsync();


            // =========================================================
            // 2. 找到当前部门
            // =========================================================

            var rootDepartment = departments
                .FirstOrDefault(x => x.Id == departmentId);


            if (rootDepartment == null)
            {
                return new List<DepUserTreeOutput>();
            }


            // =========================================================
            // 3. 建立部门字典
            // =========================================================

            var departmentMap = departments
                .ToDictionary(x => x.Id);


            // =========================================================
            // 4. 建立父子部门关系
            // =========================================================

            var childrenMap = departments
                .GroupBy(x => x.ParentId)
                .ToDictionary(
                    x => x.Key,
                    x => x
                        .OrderBy(d => d.Sort)
                        .ToList()
                );


            // =========================================================
            // 5. 找出当前部门 + 所有子部门
            // =========================================================

            var departmentIds = new HashSet<long>();


            void CollectDepartment(long id)
            {
                if (!departmentIds.Add(id))
                {
                    return;
                }

                if (childrenMap.TryGetValue(
                    id,
                    out var children))
                {
                    foreach (var child in children)
                    {
                        CollectDepartment(child.Id);
                    }
                }
            }


            CollectDepartment(departmentId);


            // =========================================================
            // 6. 查询部门用户关系
            // =========================================================

            var depUsers = await _msRepository
                .Slave<SysDepartment>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x =>
                    x.TenantId == tenantId &&
                    departmentIds.Contains(x.Id))
                .SelectMany(x =>
                    x.UserDepRoles
                        .Where(g => !g.Deleted)
                        .Select(g => new
                        {
                            DepartmentId = x.Id,
                            UserId = g.UserId
                        }))
                .Distinct()
                .ToListAsync();


            // =========================================================
            // 7. 查询用户
            // =========================================================

            var userIds = depUsers
                .Select(x => x.UserId)
                .Distinct()
                .ToList();


            var users = await _msRepository
                .Slave<SysUser>()
                .AsQueryable()
                .AsNoTracking()
                .Where(x => userIds.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    x.Name
                })
                .ToListAsync();


            var userMap = users.ToDictionary(
                x => x.Id
            );


            // =========================================================
            // 8. 部门 -> 用户
            // =========================================================

            var userMapByDepartment = depUsers
                .GroupBy(x => x.DepartmentId)
                .ToDictionary(
                    x => x.Key,
                    x => x
                        .Select(g => g.UserId)
                        .Distinct()
                        .ToList()
                );


            // =========================================================
            // 9. 递归构建部门 + 用户树
            // =========================================================

            DepUserTreeOutput BuildDepartment(
                DepUserTreeDepartmentDto department)
            {
                var result = new DepUserTreeOutput
                {
                    Id = department.Id,
                    Type = 1,
                    Name = department.Name,
                    Code = department.Code,
                    ParentId = department.ParentId,
                    Children = new List<DepUserTreeOutput>()
                };


                // =====================================================
                // 当前部门的用户
                // =====================================================

                if (userMapByDepartment.TryGetValue(
                    department.Id,
                    out var currentUserIds))
                {
                    foreach (var userId in currentUserIds)
                    {
                        if (!userMap.TryGetValue(
                            userId,
                            out var user))
                        {
                            continue;
                        }


                        result.Children.Add(
                            new DepUserTreeOutput
                            {
                                Id = user.Id,
                                Type = 2,
                                Name = user.Name,
                                ParentId = department.Id,
                                Children = new List<DepUserTreeOutput>()
                            }
                        );
                    }
                }


                // =====================================================
                // 当前部门的子部门
                // =====================================================

                if (childrenMap.TryGetValue(
                    department.Id,
                    out var children))
                {
                    foreach (var child in children)
                    {
                        result.Children.Add(
                            BuildDepartment(child)
                        );
                    }
                }


                return result;
            }


            // =========================================================
            // 10. 返回当前部门
            // =========================================================

            return new List<DepUserTreeOutput>
    {
        BuildDepartment(rootDepartment)
    };
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
            var userId = pagedListDto.GetIdWhere("userId");
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
                    output.Checked = (output.RoleIds != null && output.RoleIds.Count() > 0) ? 1 : 0;
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
                x.TenantId == tenantId &&
                    x.Department.TenantId == tenantId && x.UserId == _userId
                    )
                .DeleteFromQueryAsync();

            // 重新生成角色关系
            var entitys = dto.DepRoles
                .SelectMany(item => item.Value
                    .Distinct()
                    .Select(roleId => new SysUserDepRole
                    {
                        TenantId = tenantId,
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
