using System;
using System.Collections.Generic;
using System.Text;
using XXX.Net.Core.BaseEntitys.Entity;

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


    }
}
