using Consul;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Dto;
using XXX.Net.Core.Services.Option;

namespace XXX.Net.Core.Services.Base.Tree
{
    public class BaseTreeService<TTreeEntity, TDto, TTreeOutput> : BaseService<TTreeEntity, TDto>
        where TTreeEntity : BaseTreeEntity, IPrivateEntity, new()
        where TDto : BaseUpdateTree<TTreeEntity>
        where TTreeOutput : IPagedTreeOutput<TTreeOutput>, new()
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;

        #region 选择重写
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public virtual TTreeOutput ToTreeOutput(TTreeEntity entity, List<TTreeOutput> children)
        {
            var item = entity.Adapt<TTreeOutput>();
            item.Children = children;
            return item;
        }

        /// <summary>
        /// 处理树形层级
        /// </summary>
        /// <param name="treeEntity"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual async  Task<TTreeEntity> HandlePath(TTreeEntity treeEntity,TDto dto) {
            if (dto.Path == null || dto.Path.Count() == 0)
            {
                treeEntity.ClassLevel = 1;
                treeEntity.Path = "";
                treeEntity.ParentId = 0;
            }
            else
            {
                treeEntity.Path = string.Join("/", dto.Path);
                if (!string.IsNullOrEmpty(treeEntity.Path))
                {
                    treeEntity.Path = "/" + treeEntity.Path + "/";
                }
                treeEntity.ClassLevel = dto.Path.Count() + 1;
                treeEntity.ParentId = dto.Path.LastOrDefault();
            }
            return treeEntity;
        }
        #endregion

        public BaseTreeService(IMSRepository msRepository, ICurrentUser currentUser)
            : base(msRepository, currentUser)
        {
            _currentUser = currentUser;
            _msRepository = msRepository;
        }
        #region
        [DisplayName("获取树形页面数据 带筛选")]
        [ApiDescriptionSettings(Name = "TreeList", Order = 320), HttpPost]
        public virtual async Task<List<TTreeOutput>> TreeList(PagedListDto pagedListDto)
        {
            var mlEntity = await _msRepository.Slave<TTreeEntity>()
                .AsQueryable().AsNoTracking().OrderBy(m => m.Sort).BuildListWhere(pagedListDto).ToListAsync();
            return BaseEntitys.TreeHelper.BuildTree<TTreeEntity, TTreeOutput>(mlEntity, ToTreeOutput, 0);
        }


        [ApiDescriptionSettings(Name = "AllTree", Order = 350), HttpPost]
        [DisplayName("获取所有数据树形")]
        public virtual async Task<List<PagedTreeOptions>> AllTree()
        {
            var mlEntity = await _msRepository.Slave<TTreeEntity>().AsQueryable().AsNoTracking().OrderBy(m => m.Sort).ToListAsync();
            return BaseEntitys.TreeHelper.BuildTree<TTreeEntity>(mlEntity, 0);
        }


        [ApiDescriptionSettings(Name = "TreeChildren", Order = 360), HttpPost]
        [DisplayName("获取树形子节点")]
        public virtual async Task<List<TTreeEntity>> TreeChildren(TreeChildrenDto treeChildrenDto)
        {
            var mlEntity = await _msRepository.Slave<TTreeEntity>().AsQueryable().AsNoTracking()
                .Where(w => w.ParentId == treeChildrenDto.ParentId)
                .OrderBy(m => m.Sort).ThenBy(m => m.Id)
                .ToListAsync();

            return mlEntity;
        }

        /// <summary>
        /// 获取树形下拉搜索选项
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "TreeOptions", Order = 210), HttpPost]
        [DisplayName("获取树形下拉搜索选项")]

        public virtual async Task<List<PagedTreeOptions>> TreeOptions(List<PagedCustomWhere> where)
        {
            var mlEntity = await _msRepository.Slave<TTreeEntity>().AsQueryable().BuildListWhere(where).ToListAsync();
            return TreeHelper.BuildTree(mlEntity);
        }
        /// <summary>
        /// 增加 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Add", Order = 410), HttpPost]
        [DisplayName("增加")]
        public override async Task<TTreeEntity> Add(TDto dto)
        {
            var entity =await ToEntity(dto);
            var now = DateTime.Now;
            entity.CreatedByName = _currentUser.UserName;
            entity.CreatedTime = now;
            entity.CreatedBy = _currentUser.UserId;
            entity.UpdatedBy = _currentUser.UserId;
            entity.UpdatedTime = now;
            entity.UpdatedByName = _currentUser.UserName;

            entity=await HandlePath(entity, dto);
            //if (dto.Path == null || dto.Path.Count() == 0)
            //{
            //    entity.ClassLevel = 1;
            //    entity.Path = "";

            //}
            //else
            //{
            //    entity.Path = string.Join("/", dto.Path);
            //    if (!string.IsNullOrEmpty(entity.Path))
            //    {
            //        entity.Path = "/" + entity.Path + "/";
            //    }
            //    entity.ClassLevel = dto.Path.Count() + 1;
            //    entity.ParentId = dto.Path.LastOrDefault();
            //}

            return (await _msRepository.Master<TTreeEntity>().InsertNowAsync(entity)).Entity;
        }

        [ApiDescriptionSettings(Name = "Update", Order = 510), HttpPost]
        [DisplayName("更新")]
        public override async Task<TTreeEntity> Update(TDto dto)
        {

            var oldEntity = await _msRepository.Master<TTreeEntity>().AsQueryable().AsNoTracking().Where(w => w.Id == dto.Id).FirstOrDefaultAsync();
            if (oldEntity == null)
            {
                throw Oops.Oh("更新失败，无对应数据", ErrorCode.ParamError);
            }
            var entity =await ToEntity(dto,oldEntity);
            var now = DateTime.Now;
            entity.UpdatedBy = _currentUser.UserId;
            entity.UpdatedTime = now;
            entity.UpdatedByName = _currentUser.UserName;

            entity= await HandlePath(entity, dto);
            //if (dto.Path == null || dto.Path.Count() == 0)
            //{
            //    entity.ClassLevel = 1;
            //    entity.ParentId = 0;
            //}
            //else
            //{
            //    entity.Path = string.Join("/", dto.Path);
            //    if (!string.IsNullOrEmpty(entity.Path))
            //    {
            //        entity.Path = "/" + entity.Path + "/";
            //    }
            //    entity.ClassLevel = dto.Path.Count() + 1;
            //    entity.ParentId = dto.Path.LastOrDefault();
            //}

            if (entity.ParentId == dto.Id) {
                throw Oops.Oh("更新失败，层级不能选择本身",ErrorCode.ParamError);
            }

            var diffClassLevel = oldEntity.ClassLevel - entity.ClassLevel;

            var newEntity = (await _msRepository.Master<TTreeEntity>().UpdateAsync(entity, ignoreNullValues: true)).Entity;
            //更新所有后代元素层级
            await _msRepository.Master<TTreeEntity>().Where(w => w.Path.Contains("/" + entity.Id + "/") && w.Id != entity.Id && w.Path.StartsWith(oldEntity.Path))
                .ExecuteUpdateAsync(set =>
                 set.SetProperty(x => x.Path, x => x.Path.Replace(oldEntity.Path, entity.Path))
                    .SetProperty(x => x.ClassLevel, x => x.ClassLevel - diffClassLevel)
                );
            return newEntity;
        }

        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Delete", Order = 630), HttpPost]
        [DisplayName("删除")]
        public override async Task Delete(long id)
        {
            var existsChild = await _msRepository.Master<TTreeEntity>().Where(w => w.ParentId == id).AnyAsync();
            if (existsChild)
            {
                throw Oops.Oh("存在子节点无法删除，请先删除子节点", ErrorCode.BusinessError);
            }
            await _msRepository.Master<TTreeEntity>().DeleteNowAsync(id);
            return;
        }

        /// <summary>
        /// 逻辑删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "LogicDelete", Order = 640), HttpPost]
        [DisplayName("逻辑删除")]
        public override async Task LogicDelete(long id)
        {
            var existsChild = await _msRepository.Master<TTreeEntity>().Where(w => w.ParentId == id).AnyAsync();
            if (existsChild)
            {
                throw Oops.Oh("存在子节点无法删除，请先删除子节点", ErrorCode.BusinessError);
            }
            var mOldEntity = await _msRepository.Master<TTreeEntity>().FindOrDefaultAsync(id);
            if (mOldEntity == null) throw Oops.Oh("无对应数据");
            mOldEntity.Deleted = true;
            await _msRepository.Master<TTreeEntity>().UpdateIncludeNowAsync(mOldEntity, new[] {
               "Deleted"
            });
            return;
        }
        #endregion
        #region 重新父类方法
        /// <summary>
        /// 获取详情 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="optionService"></param>
        /// <returns></returns>
        [DisplayName("获取详情和选项")]
        [ApiDescriptionSettings(Name = "DetailOption", Order = 120), HttpGet]
        public override  async Task<PageDetailOption<TDto>> DetailOption([FromServices] OptionService optionService, [FromQuery] long? id)
        {
            var options = await optionService.GetOptions<TDto>();
            var res = new PageDetailOption<TDto>()
            {
                Options = options
            };
            if (id != null)
            {
                var entity = await _msRepository.Slave<TTreeEntity>().FindAsync(id);
                res.Detail = entity.Adapt<TDto>();
                res.Detail.Path = string.IsNullOrWhiteSpace(entity.Path)
                  ? new List<long>()
                  : entity.Path
                      .Split('/', StringSplitOptions.RemoveEmptyEntries)
                      .Select(long.Parse)
                      .ToList();
            }
            return res;
        }
        #endregion
    }
}
