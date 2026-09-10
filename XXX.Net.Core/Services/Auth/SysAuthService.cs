using Furion;
using Furion.DatabaseAccessor;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.EventBus;
using Furion.FriendlyException;
using XXX.Net.Core.Cache;
using XXX.Net.Core.Const;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.EventBus;
using XXX.Net.Core.Services.Auth.Dto;
using XXX.Net.Core.Services.Auth.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace XXX.Net.Core.Services.Auth
{
    /// <summary>
    /// 系统登录授权服务 
    /// </summary>
    [ApiDescriptionSettings(Order = 500)]
    public class SysAuthService : IDynamicApiController, ITransient
    {
        private readonly IMSRepository _msRepository;
        private readonly ICacheService _cacheService;
        private readonly IEventBus _eventBus;
        private readonly ICurrentUser _currentUser;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SysAuthService(ICurrentUser currentUser,IMSRepository msRepository, ICacheService cacheService, IEventBus eventBus, IHttpContextAccessor httpContextAccessor)
        {
            _msRepository = msRepository;
			_cacheService = cacheService;
			_eventBus = eventBus;
            _httpContextAccessor = httpContextAccessor;
            _currentUser = currentUser;
        }

        /// <summary>
        /// 账号密码登录 
        /// </summary>
        /// <param name="dto"></param>
        /// <remarks>用户名/密码：superadmin/123456</remarks>
        /// <returns></returns>
        [AllowAnonymous]
        [DisplayName("账号密码登录")]
        public virtual async Task<LoginVo> Login(LoginDto dto)
        {
            //用户登录
            var user=  await _msRepository.Master<SysUser>().Where(w => w.UserName == dto.UserName && w.Password == dto.PassWord).FirstOrDefaultAsync();
            if (user == null) {
                throw Oops.Oh("账号或密码错误");
            }
            // 密码校验
            return await CreateToken(user);
        }

        [DisplayName("退出登录")]
        public  async Task Logout()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null) return;

            // 1. 取当前 access-token（兼容 header 里 access-token / Authorization Bearer 两种传法）
            var accessToken = httpContext.Request.Headers["access-token"].ToString();
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                var auth = httpContext.Request.Headers["Authorization"].ToString();
                if (auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                    accessToken = auth["Bearer ".Length..].Trim();
            }

            // 2. 加入黑名单，TTL 设成和 token 剩余有效期一致
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(accessToken);
                    var ttl = jwt.ValidTo > DateTime.UtcNow
                        ? jwt.ValidTo - DateTime.UtcNow
                        : TimeSpan.FromMinutes(5);

                    await _cacheService.SetAsync($"jwt:blacklist:{accessToken}", "1", ttl);
                }
                catch
                {
                    // token 解析失败也不影响退出
                }
            }

            // 3. 清掉服务端存的 refresh-token
            if (_currentUser?.UserId > 0)
            {
                await _cacheService.RemoveAsync($"refresh_token:{_currentUser.UserId}");
            }

            // 4. 清响应头（告诉前端 token 作废）
            httpContext.Response.Headers.Remove("access-token");
            httpContext.Response.Headers.Remove("x-access-token");

            // 5. 发退出事件（可选）
            if (_currentUser?.UserId > 0)
            {
                await _eventBus.PublishAsync(SysUserEvents.UserLogout, new BaseEvent<UserLogoutEvent>
                {
                    EventName = SysUserEvents.UserLogout,
                    Data = new UserLogoutEvent
                    {
                        UserId = _currentUser.UserId,
                        UserName = _currentUser.UserName
                    }
                });
            }
        }

        /// <summary>
        /// 创建令牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        internal virtual async Task<LoginVo> CreateToken(SysUser user)
        {
            var mSysTenantUser = await _msRepository.Master<SysTenantUser>().AsQueryable().Where(w=>w.UserId==user.Id).SingleOrDefaultAsync();
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>()
            {
                {ClaimConst.UserId, user.Id.ToString()},
                {ClaimConst.UserName, user.UserName},
                {ClaimConst.RealName, user.RealName ?? ""},
                {ClaimConst.TenantId, mSysTenantUser.TenantId.ToString()},
                {ClaimConst.Avatar, user.Avatar??""},
                {ClaimConst.IsAdmin, user.IsAdmin.ToString().ToLower() },
            });
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 43200);
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = accessToken;
            _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;

 
			// 发布登录事件
			await _eventBus.PublishAsync("user.login", new BaseEvent<UserLoginEvent>()
			{
				EventName = "UserLogin",
				Data = new UserLoginEvent()
				{
					Mobile = user.Mobile,
					UserName = user.UserName,
					UserId = user.Id
				}
			});


			return new LoginVo()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Homepage = "",
                UserInfo = new LoginUserInfo()
                {
                    Id = user.Id,
                    //TenantId = user.TenantId,
                    UserName = user.UserName,
                    RealName = user.RealName,
                    Mobile = user.Mobile,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    IsAdmin = user.IsAdmin,
                }
            };
        }

    }
}
