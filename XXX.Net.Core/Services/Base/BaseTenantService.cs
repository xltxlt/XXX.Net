using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Option.Attributes;

namespace XXX.Net.Core.Services.Base
{
    public class BaseTenantService<TEntity, TDto> :BaseService<TEntity, TDto>, IDynamicApiController where TEntity : BaseTenantEntity, IPrivateEntity, new() where TDto : BaseUpdate
    {
        private readonly IMSRepository _msRepository;
        private readonly ICurrentUser _currentUser;


        public BaseTenantService(IMSRepository msRepository, ICurrentUser currentUser)
            :base(msRepository, currentUser)
        {
            _msRepository = msRepository;
            _currentUser = currentUser;
        }
        #region 重写
        /// <summary>
        /// 模型到实体的转换
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="oldEntity">原实体类型</param>
        /// <returns></returns>
        public override  async Task<TEntity> ToEntity(TDto dto, TEntity oldEntity = null)
        {
            var tenantId = _currentUser.TenantId;

            var entity = new TEntity();
            if (oldEntity != null)
            {

                entity = dto.Adapt(oldEntity);
            }
            else { 
                entity= dto.Adapt<TEntity>();
            }
            if (entity.TenantId == 0)
            {
                entity.TenantId = tenantId;
            }
            return entity;
        }
      
        /// <summary>
        /// 模型到实体的批量转换
        /// </summary>
        /// <param name="mlDto"></param>
        /// <param name="oldEntitys"></param>
        /// <returns></returns>
        public override async Task<List<TEntity>> ToListEntity(List<TDto> mlDto, List<TEntity> oldEntitys = null)
        {
            var entitys = new List<TEntity>();
            var now = DateTime.Now;
            var tenantId = _currentUser.TenantId;
            mlDto.ForEach(item =>
            {
                if (oldEntitys != null && oldEntitys.Count() > 0)
                {
                    var oldEntity = oldEntitys.Where(w => w.Id == item.Id).LastOrDefault();
                    var entity = item.Adapt(oldEntity);
                    if (entity.TenantId == 0) {
                        entity.TenantId = tenantId;
                    }
                    entity.UpdatedBy = _currentUser.UserId;
                    entity.UpdatedTime = now;
                    entity.UpdatedByName = _currentUser.UserName;
                    entitys.Add(entity);
                }
                else
                {
                    var entity = item.Adapt<TEntity>();
                    if (entity.TenantId == 0)
                    {
                        entity.TenantId = tenantId;
                    }
                    entity.CreatedByName = _currentUser.UserName;
                    entity.CreatedTime = now;
                    entity.CreatedBy = _currentUser.UserId;
                    entity.UpdatedBy = _currentUser.UserId;
                    entity.UpdatedTime = now;
                    entity.UpdatedByName = _currentUser.UserName;
                    entitys.Add(entity);
                }

            });
            return entitys;
        }
        #endregion

    }
}
