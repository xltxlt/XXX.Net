using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.EventBus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.CurrentUser;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Base;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using XXX.Net.Core.Services.Org;
using XXX.Net.Core.Services.User.Dto;
using static XXX.Net.Core.Extensions.MsRepositoryExtension;

namespace XXX.Net.Core.Services.User
{
    public class SysUserService : BaseImportExportService<SysUser, SysUserDto, SysUserImportDto, SysUserExportVo>, IDynamicApiController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;

        private readonly IEventBus _eventBus;
        public SysUserService(IEventBus eventBus, IMSRepository msRepository, ICurrentUser currentUser, IHttpContextAccessor httpContextAccessor)
            : base(msRepository, currentUser)
        {

            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
            _msRepository = msRepository;
            _eventBus = eventBus;
            OtherOptions = BuildOtherOptions();
        }

        #region
        private List<OtherOptionSource> BuildOtherOptions()
        {
            var tenantId = _currentUser.TenantId.ToString();

            return new List<OtherOptionSource>
        {

            new OtherOptionSource{
                FieldName="DepId_custom",
                OptionAttr = new OptionFunAttribute(
                    typeof(SysDepService),
                    nameof(SysDepService.TreeOptions)),
                Where = new List<PagedCustomWhere>
                {
                    new PagedCustomWhere
                    {
                        FiledName = "TenantId",
                        ConditionalType = (int)ConditionalType.Equal,
                        FiledValue = tenantId,
                    },
                }
            },

        };
        }
        protected override List<OtherOptionSource> OtherOptions { get; set; } = new();

        #endregion
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Add", Order = 400), HttpPost]
        [DisplayName("新增")]
        //[UnitOfWork]
        public override async Task<SysUser> Add(SysUserDto dto)
        {
            var entity = await base.Add(dto);
            var tenantId = dto.TenantId > 0 ? dto.TenantId : _currentUser.TenantId;
            if (await _msRepository.Master<SysTenantUser>().AsQueryable().AnyAsync(x => x.UserId == entity.Id && x.TenantId == tenantId))
            {
                return entity;
            }
            // 3. 创建用户-租户关系
            var now = DateTime.Now;
            var mUserTenant = new SysTenantUser
            {
                TenantId = tenantId,
                UserId = entity.Id,

                CreatedBy = _currentUser.UserId,
                CreatedByName = _currentUser.UserName,
                CreatedTime = now,

                UpdatedBy = _currentUser.UserId,
                UpdatedByName = _currentUser.UserName,
                UpdatedTime = now
            };

            // 4. 插入用户-租户关系
            await _msRepository
                .Master<SysTenantUser>()
                .InsertAsync(mUserTenant);

            await _eventBus.PublishAsync(EventBus.SysUserEvents.UserRegister, new BaseEvent<SysTenantUser>(tenantId, EventBus.SysUserEvents.UserRegister, mUserTenant));
            return entity;
        }
    }
}
