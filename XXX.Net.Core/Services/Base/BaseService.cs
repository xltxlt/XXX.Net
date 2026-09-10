using System.Collections;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Option;
using XXX.Net.Core.Services.Option.Attribute;
using XXX.Net.Core.Services.Option.Attributes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XXX.Net.Core.Services.Base
{

    public class BaseService<TEntity,TDto>:IDynamicApiController where TEntity :  BaseEntity, IPrivateEntity, new () where TDto:BaseUpdate
    {
        private readonly IMSRepository _msRepository;
        private readonly ICurrentUser _currentUser;
   

        public BaseService(IMSRepository msRepository, ICurrentUser currentUser)
        {
            _msRepository = msRepository;
            _currentUser = currentUser;
        }
        #region 选择重写
        /// <summary>
        /// 模型到实体的转换
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="oldEntity">原实体类型</param>
        /// <returns></returns>
        public virtual async Task<TEntity> ToEntity(TDto dto, TEntity oldEntity=null)
        {
            if (oldEntity!=null)
            {
                return dto.Adapt(oldEntity);
            }
            return dto.Adapt<TEntity>();
        }
        protected virtual List<OtherOptionSource> OtherOptions { get; set; } = new List<OtherOptionSource>()
        {
           
        };
        
        /// <summary>
        /// 模型到实体的批量转换
        /// </summary>
        /// <param name="mlDto"></param>
        /// <param name="oldEntitys"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>>  ToListEntity(List<TDto> mlDto, List<TEntity> oldEntitys =null )
        {
            var entitys = new List<TEntity>();
            var now = DateTime.Now;
            mlDto.ForEach(item =>
            {
                if (oldEntitys != null && oldEntitys.Count() > 0)
                {
                    var oldEntity = oldEntitys.Where(w=>w.Id==item.Id).LastOrDefault();
                    var entity = item.Adapt(oldEntity);
                    entity.UpdatedBy = _currentUser.UserId;
                    entity.UpdatedTime = now;
                    entity.UpdatedByName = _currentUser.UserName;
                    entitys.Add(entity);
                }
                else {
                    var entity = item.Adapt<TEntity>();
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

        #region 基础接口

        /// <summary>
        /// 获取详情 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DisplayName("获取详情")]
        [ApiDescriptionSettings(Name = "Detail",Order =100), HttpGet]
        public virtual async Task<TEntity> Detail(long id)
        {
            return await _msRepository.Slave<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// 获取新增修改页面选项 
        /// </summary>
        /// <param name="optionService"></param>
        /// <returns></returns>
        [DisplayName("获取新增修改页面选项")]
        [ApiDescriptionSettings(Name = "PageOption", Order = 110), HttpGet]
        public virtual async Task<Dictionary<string,List<PagedOptions>>> PageOption(
            [FromServices] OptionService optionService,
            [FromQuery] List<PagedCustomWhere> where = null)
        {
            var options = new Dictionary<string, List<PagedOptions>>();
            var dtoOptions = await optionService.GetOptions<TDto>();
            if (OtherOptions != null && OtherOptions.Count() > 0)
            {
                var otherOptions = await optionService.GetOptions(OtherOptions, where);
                if (otherOptions != null && otherOptions.Count() > 0)
                {
                    options = otherOptions.Union(dtoOptions).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);

                }
            }
            else {
                options = dtoOptions;
            }
            return options;
        }
        /// <summary>
        /// 获取详情 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="optionService"></param>
        /// <returns></returns>
        [DisplayName("获取详情和选项")]
        [ApiDescriptionSettings(Name = "DetailOption", Order = 120), HttpGet]
        public virtual async Task<PageDetailOption<TDto>> DetailOption([FromServices] OptionService optionService, [FromQuery] long? id)
        {
            //var options= await optionService.GetOptions<TDto>();
            //if (OtherOptions != null && OtherOptions.Count() > 0)
            //{
            //    var otherOptions = await optionService.GetOptions(OtherOptions);
            //    if (otherOptions != null && otherOptions.Count() > 0)
            //    {
            //        options = otherOptions.Union(options).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.First().Value);

            //    }
            //}
            var options= await PageOption(optionService,null);
            var res=new PageDetailOption<TDto>()
            {
                Options= options
            };
            if (id != null) {
                var entity = await Detail(id??0);
               //var entity= await _msRepository.Slave<TEntity>().FindAsync(id);
                res.Detail = entity.Adapt<TDto>();
            }
            return res;
        }

        /// <summary>
        /// 获取下拉搜索选项
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        [DisplayName("获取下拉搜索选项")]
        [ApiDescriptionSettings(Name = "Options", Order = 200), HttpPost]
        public virtual async Task<List<PagedOptions>> Options(List<PagedCustomWhere> where)
        {
            return await _msRepository.Slave<TEntity>().AsQueryable().BuildListWhere(where)
                .Select(s=>new PagedOptions() { 
                    Value= s.Id,
                    Label= s.Name,
                })
                .ToListAsync();
        }

       
        /// <summary>
        /// 获取集合 
        /// </summary>
        /// <returns></returns>
        [DisplayName("获取集合")]
        [ApiDescriptionSettings(Name = "List", Order = 300), HttpPost]
        public virtual async Task<List<TEntity>> List(PagedListDto pagedListBaseDto)
        {
            return await _msRepository.Slave<TEntity>().AsQueryable().ToListAsync(_msRepository,pagedListBaseDto);
        }
        /// <summary>
        /// 获取分页集合 
        /// </summary>
        /// <returns></returns>
        [DisplayName("获取分页集合")]
        [ApiDescriptionSettings(Name = "PageList", Order = 310), HttpPost]
        public virtual async Task<PagedList<TEntity>> PageList(PagedPaginationListDto pagedListDto)
        {
            return await _msRepository.Slave<TEntity>().AsQueryable().BuildListWhere(pagedListDto).ToPagedListAsync(pagedListDto.PageIndex, pagedListDto.PageSize);
        }
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "AddOrUpdate", Order = 400), HttpPost]
        [DisplayName("新增或修改")]
        public virtual async Task<TEntity> AddOrUpdate(TDto dto)
        {
            if (dto.Id > 0)
            {
                return await Update(dto);
            }
            return await Add(dto);
        }
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Add", Order = 400), HttpPost]
        [DisplayName("新增")]
        [UnitOfWork]
        public virtual async Task<TEntity> Add(TDto dto)
        {

            var entity =await ToEntity(dto);
            var now = DateTime.Now;
            entity.CreatedByName = _currentUser.UserName;
            entity.CreatedTime = now;
            entity.CreatedBy = _currentUser.UserId;
            entity.UpdatedBy = _currentUser.UserId;
            entity.UpdatedTime = now;
            entity.UpdatedByName = _currentUser.UserName;
            entity= (await _msRepository.Master<TEntity>().InsertAsync(entity)).Entity;
            return entity;
        }
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="mlList"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchAdd", Order = 410), HttpPost]
        [DisplayName("批量新增")]
        public virtual async Task<int> BatchAdd(List<TDto> mlList)
        {
            var addList = new List<TEntity>();
            addList =await ToListEntity(mlList);

           return  await _msRepository.Master<TEntity>().InsertNowAsync(addList);

        }

       
        /// <summary>
        /// 更新 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Update", Order = 500), HttpPost]
        [DisplayName("更新")]
        [UnitOfWork]
        public virtual async Task<TEntity> Update(TDto dto) 
        {
            var now = DateTime.Now;
            var entity = await ToEntity(dto);
            entity.UpdatedBy = _currentUser.UserId;
            entity.UpdatedTime = now;
            entity.UpdatedByName = _currentUser.UserName;
            entity= (await _msRepository.Master<TEntity>().UpdateNowAsync(entity, true, true)).Entity;
            return entity;
        }
        /// <summary>
        /// 新增 
        /// </summary>
        /// <param name="mlList"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchUpdate", Order = 410), HttpPost]
        [DisplayName("批量更新")]
        public virtual async Task<int> BatchUpdate(List<TDto> mlList)
        {
            var handleList = new List<TEntity>();
            var now = DateTime.Now;
            handleList=await ToListEntity(mlList);
            return (await _msRepository.Master<TEntity>().UpdateNowAsync(handleList,true,default,null,new string[] { 
                "CreateBy","CreateByTime","CreatedByName"
            }));
        }
        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "Delete", Order = 600), HttpPost]
        [DisplayName("删除")]
        public virtual async Task Delete(long id)
        {
            await _msRepository.Master<TEntity>().DeleteNowAsync(id);
            return;
        }
        /// <summary>
        /// 删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchDelete", Order = 600), HttpPost]
        [DisplayName("批量删除")]
        public virtual async Task BatchDelete(List<long> ids)
        {
            await _msRepository.Master<TEntity>().DeleteNowAsync(ids);
            return;
        }
        /// <summary>
        /// 逻辑删除 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "LogicDelete", Order = 610), HttpPost]
        [DisplayName("逻辑删除")]
        public virtual async Task LogicDelete(long id)
        {
            var mOldEntity= await _msRepository.Master<TEntity>().FindOrDefaultAsync(id);
            if (mOldEntity == null) throw Oops.Oh("无对应数据");
            mOldEntity.Deleted = true;
            await _msRepository.Master<TEntity>().UpdateIncludeNowAsync(mOldEntity, new[] { 
               "Deleted"
            } );
            return;
        }
        /// <summary>
        /// 逻辑删除 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [ApiDescriptionSettings(Name = "BatchLogicDelete", Order = 620), HttpPost]
        [DisplayName("逻辑删除")]
        public virtual async Task BatchLogicDelete(List<long> ids)
        {
            var mlOldEntity = await _msRepository.Master<TEntity>().Where(w=> ids.Contains(w.Id) ).ToListAsync();
            if (mlOldEntity == null|| mlOldEntity.Count()==0) throw Oops.Oh("无对应数据");
            foreach (var item in mlOldEntity)
            {
                item.Deleted = true;
            }
            await _msRepository.Master<TEntity>().UpdateNowAsync(mlOldEntity);
            return;
        }
        #endregion
    }
}
