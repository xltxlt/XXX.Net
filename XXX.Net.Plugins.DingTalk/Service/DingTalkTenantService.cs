using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using XXX.Net.Core.Entity.Sys;

namespace XXX.NET.Plugin.DingTalk.Service;

/// <summary>
/// 面向租户的钉钉组织、消息和审批服务。所有钉钉外部标识均按租户隔离。
/// </summary>
public class DingTalkTenantService : IScoped
{
    private readonly IDingTalkApi _api;
    private readonly IMSRepository _repository;

    public DingTalkTenantService(IDingTalkApi api, IMSRepository repository)
    {
        _api = api;
        _repository = repository;
    }

    public async Task SyncOrganization(long tenantId)
    {
        var app = await GetAppAsync(tenantId);
        var token = await GetTokenAsync(app);
        await SyncDepartmentsAsync(tenantId, token);
        await SyncUsersAsync(tenantId, app, token);
        await SyncRolesAsync(tenantId, token);
        await SyncUserDepartmentRolesAsync(tenantId);
    }

    public async Task SendTextMessage(long tenantId, IEnumerable<long> sysUserIds, string content)
    {
        var userIds = sysUserIds.Distinct().ToList();
        if (userIds.Count == 0) return;
        var app = await GetAppAsync(tenantId);
        var recipients = await _repository.Master<DingTalkUser>().AsQueryable()
            .Where(x => x.TenantId == tenantId && userIds.Contains(x.SysUserId) && !x.Deleted && x.DingTalkUserId != null)
            .Select(x => x.DingTalkUserId!)
            .ToListAsync();
        if (recipients.Count == 0) return;

        var result = await _api.SendWorkMessage(await GetTokenAsync(app), new DingTalkWorkMessageInput
        {
            AgentId = long.TryParse(app.AgentId, out var agentId) ? agentId : 0,
            UserIdList = string.Join(',', recipients),
            Message = new DingTalkTextMessage { Text = new DingTalkTextMessageContent { Content = content } },
        });
        if (result.ErrorCode != 0) throw Oops.Oh($"钉钉消息发送失败：{result.ErrorMessage}");
    }

    public async Task<DingTalkWorkflowProcessInstancesOutput> StartApproval(long tenantId, DingTalkWorkflowProcessInstancesInput input)
    {
        var app = await GetAppAsync(tenantId);
        input.MicroappAgentId = long.TryParse(app.AgentId, out var agentId) ? agentId : input.MicroappAgentId;
        return await _api.DingTalkWorkflowProcessInstances(await GetTokenAsync(app), input);
    }

    private async Task SyncDepartmentsAsync(long tenantId, string token, long parentId = 1)
    {
        var response = await _api.GetDingTalkDept(token, new GetDingTalkDeptInput { dept_id = parentId });
        if (!response.Success) throw Oops.Oh(response.ErrMsg);
        foreach (var remote in response.Result ?? new List<DingTalkDeptOutput>())
        {
            var entity = await _repository.Master<DingTalkDept>().AsQueryable()
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DeptId == remote.dept_id);
            if (entity == null)
            {
                entity = new DingTalkDept { TenantId = tenantId, DeptId = remote.dept_id };
                await _repository.Master<DingTalkDept>().InsertNowAsync(entity);
            }
            entity.ParentId = remote.parent_id;
            entity.Name = remote.name;
            entity.UpdateTime = DateTime.Now;
            await _repository.Master<DingTalkDept>().UpdateNowAsync(entity);
            var parent = await _repository.Master<SysDepartment>().AsQueryable()
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DingTalkDeptId == remote.parent_id && !x.Deleted);
            var systemDepartment = await _repository.Master<SysDepartment>().AsQueryable()
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DingTalkDeptId == remote.dept_id && !x.Deleted);
            if (systemDepartment == null)
            {
                systemDepartment = new SysDepartment
                {
                    TenantId = tenantId, DingTalkDeptId = remote.dept_id, Name = remote.name,
                    ShortName = remote.name, Code = remote.dept_id.ToString(), ParentId = parent?.Id ?? 0,
                };
                await _repository.Master<SysDepartment>().InsertNowAsync(systemDepartment);
            }
            else
            {
                systemDepartment.Name = remote.name;
                systemDepartment.ShortName = remote.name;
                systemDepartment.ParentId = parent?.Id ?? 0;
                await _repository.Master<SysDepartment>().UpdateNowAsync(systemDepartment);
            }
            entity.SysDepartmentId = systemDepartment.Id;
            await _repository.Master<DingTalkDept>().UpdateNowAsync(entity);
            await SyncDepartmentsAsync(tenantId, token, remote.dept_id);
        }
    }

    private async Task SyncUsersAsync(long tenantId, DingTalkTenantApp app, string token)
    {
        var cursor = 0;
        do
        {
            var page = await _api.GetDingTalkCurrentEmployeesList(token, new GetDingTalkCurrentEmployeesListInput { Offset = cursor, Size = 50, StatusList = "2,3,5,-1" });
            if (!page.Success) throw Oops.Oh(page.ErrMsg);
            var ids = page.Result?.DataList ?? new List<string>();
            foreach (var group in ids.Chunk(100))
            {
                var details = await _api.GetDingTalkCurrentEmployeesRosterList(token, new GetDingTalkCurrentEmployeesRosterListInput
                {
                    UserIdList = string.Join(',', group), AgentId = app.AgentId,
                    FieldFilterList = string.Join(',', new[] { DingTalkConst.NameField, DingTalkConst.MobileField, DingTalkConst.JobNumberField, DingTalkConst.DeptId, DingTalkConst.Dept, DingTalkConst.Position }),
                });
                if (!details.Success) throw Oops.Oh(details.ErrMsg);
                foreach (var remote in details.Result ?? new List<DingTalkEmpRosterFieldVo>()) await UpsertUserAsync(tenantId, remote);
            }
            cursor = page.Result?.NextCursor ?? -1;
        } while (cursor >= 0);
    }

    private async Task UpsertUserAsync(long tenantId, DingTalkEmpRosterFieldVo remote)
    {
        var values = remote.FieldDataList?
            .Where(x => !string.IsNullOrWhiteSpace(x.FieldCode))
            .GroupBy(x => x.FieldCode)
            .ToDictionary(x => x.Key, x => x.Last().FieldValueList?.FirstOrDefault()?.Value ?? string.Empty)
            ?? new Dictionary<string, string>();
        var mobile = values.GetValueOrDefault(DingTalkConst.MobileField);
        var user = await _repository.Master<DingTalkUser>().AsQueryable().FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DingTalkUserId == remote.UserId);
        if (user == null)
        {
            user = new DingTalkUser { TenantId = tenantId, DingTalkUserId = remote.UserId };
            var sysUser = !string.IsNullOrWhiteSpace(mobile)
                ? await _repository.Master<SysUser>().AsQueryable().FirstOrDefaultAsync(x => x.Mobile == mobile && !x.Deleted) : null;
            user.SysUserId = sysUser?.Id ?? 0;
            await _repository.Master<DingTalkUser>().InsertNowAsync(user);
        }
        user.Name = values.GetValueOrDefault(DingTalkConst.NameField);
        user.Mobile = mobile;
        user.JobNumber = values.GetValueOrDefault(DingTalkConst.JobNumberField);
        user.DeptId = values.GetValueOrDefault(DingTalkConst.DeptId);
        user.Dept = values.GetValueOrDefault(DingTalkConst.Dept);
        user.Position = values.GetValueOrDefault(DingTalkConst.Position);
        if (!string.IsNullOrWhiteSpace(user.Position))
        {
            var position = await _repository.Master<SysPosition>().AsQueryable()
                .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.Name == user.Position && !x.Deleted);
            if (position == null)
            {
                position = new SysPosition { TenantId = tenantId, Name = user.Position, Code = user.Position };
                await _repository.Master<SysPosition>().InsertNowAsync(position);
            }
            user.SysPositionId = position.Id;
        }
        await _repository.Master<DingTalkUser>().UpdateNowAsync(user);
    }

    private async Task SyncRolesAsync(long tenantId, string token)
    {
        var roles = await _api.GetDingTalkRoleList(token, new GetDingTalkCurrentRoleListInput());
        if (!roles.Success) throw Oops.Oh(roles.ErrMsg);
        foreach (var group in roles.Result?.list ?? new List<DingTalkRoleListResult>()) foreach (var role in group.roles ?? new List<DingTalkRoleResult>())
        {
            var members = await _api.GetDingTalkRoleSimplelist(token, new GetDingTalkCurrentRoleSimplelistInput { role_id = role.id });
            if (!members.Success) throw Oops.Oh(members.ErrMsg);
            foreach (var member in members.Result?.list ?? new List<DingTalkRoleSimplelistResult>())
            {
                var existing = await _repository.Master<DingTalkRoleUser>().AsQueryable().FirstOrDefaultAsync(x => x.TenantId == tenantId && x.DingTalkUserId == member.userid && x.roleId == role.id);
                if (existing == null) { existing = new DingTalkRoleUser { TenantId = tenantId, DingTalkUserId = member.userid, roleId = role.id }; await _repository.Master<DingTalkRoleUser>().InsertNowAsync(existing); }
                existing.groupId = group.groupId; existing.groupName = group.name; existing.roleName = role.name;
                var systemRole = await _repository.Master<SysRole>().AsQueryable()
                    .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.Name == role.name && !x.Deleted);
                existing.SysRoleId = systemRole?.Id;
                await _repository.Master<DingTalkRoleUser>().UpdateNowAsync(existing);
            }
        }
    }

    private async Task SyncUserDepartmentRolesAsync(long tenantId)
    {
        var users = await _repository.Master<DingTalkUser>().AsQueryable()
            .Where(x => x.TenantId == tenantId && x.SysUserId > 0 && !x.Deleted)
            .ToListAsync();
        foreach (var user in users)
        {
            var departmentIds = (user.DeptId ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.TryParse(x, out var id) ? id : 0).Where(x => x > 0).ToList();
            var departments = await _repository.Master<DingTalkDept>().AsQueryable()
                .Where(x => x.TenantId == tenantId && departmentIds.Contains(x.DeptId) && x.SysDepartmentId != null)
                .ToListAsync();
            var roles = await _repository.Master<DingTalkRoleUser>().AsQueryable()
                .Where(x => x.TenantId == tenantId && x.DingTalkUserId == user.DingTalkUserId && x.SysRoleId != null && !x.Deleted)
                .ToListAsync();
            foreach (var department in departments) foreach (var role in roles)
            {
                var exists = await _repository.Master<SysUserDepRole>().AsQueryable().AnyAsync(x => x.UserId == user.SysUserId
                    && x.DepartmentId == department.SysDepartmentId && x.RoleId == role.SysRoleId && !x.Deleted);
                if (!exists) await _repository.Master<SysUserDepRole>().InsertNowAsync(new SysUserDepRole
                {
                    TenantId = tenantId, UserId = user.SysUserId, DepartmentId = department.SysDepartmentId!.Value, RoleId = role.SysRoleId!.Value,
                });
            }
        }
    }

    private async Task<DingTalkTenantApp> GetAppAsync(long tenantId) => await _repository.Master<DingTalkTenantApp>().AsQueryable()
        .FirstOrDefaultAsync(x => x.TenantId == tenantId && x.Enabled && !x.Deleted) ?? throw Oops.Oh("未配置当前租户的钉钉企业应用");

    private async Task<string> GetTokenAsync(DingTalkTenantApp app)
    {
        var token = await _api.GetDingTalkToken(app.ClientId, app.ClientSecret);
        if (token.ErrCode != 0) throw Oops.Oh(token.ErrMsg);
        return token.AccessToken;
    }
}
