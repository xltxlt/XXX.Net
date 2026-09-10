using XXX.Net.Core.BaseEntitys.Admin;
using MiniExcelLibs;
using Z.EntityFramework.Extensions;
using System.IO;
using Z.BulkOperations;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;

namespace XXX.Net.Core.Services.Base
{
    /// <summary>
    /// 导入导出
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TImportDto"></typeparam>
    /// <typeparam name="TExportVo"></typeparam>
    public class BaseImportExportService<TEntity, TDto,TImportDto, TExportVo> : BaseService<TEntity, TDto> where TExportVo : class,new() where TImportDto:class, new()  where TEntity : BaseEntity, IPrivateEntity, new () where TDto :BaseUpdate
    {
        private readonly ICurrentUser _currentUser;
        private readonly IMSRepository _msRepository;

        public BaseImportExportService(IMSRepository msRepository, ICurrentUser currentUser)
            : base(msRepository, currentUser)
        {
            _currentUser = currentUser;
            _msRepository = msRepository;
        }


        #region 导出

        /// <summary>
        /// 导出数据 
        /// </summary>
        [DisplayName("导出数据")]
        [ApiDescriptionSettings(Name = "Export", Order = 700), HttpPost]
        [AllowAnonymous]
        public virtual async Task<IActionResult> Export(PagedListDto dto)
        {
            var list = await _msRepository
                .Slave<TEntity>()
                .AsQueryable()
                .BuildListWhere(dto)
                .Select(w => w.Adapt<TExportVo>())
                .ToListAsync();

            var stream = new MemoryStream();
            await MiniExcel.SaveAsAsync(stream, list, true);

            return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"{typeof(TEntity).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };
        }
        /// <summary>
        /// 导出数据 
        /// </summary>
        [DisplayName("导出数据")]
        [ApiDescriptionSettings(Name = "AllExport", Order = 710),  HttpGet]
        [AllowAnonymous]
        public virtual async Task<FileStreamResult> AllExport()
        {
            var list = await _msRepository
                .Slave<TEntity>()
                .AsQueryable()
                .Select(w => w.Adapt<TExportVo>())
                .ToListAsync();

            var stream = new MemoryStream();
            await MiniExcel.SaveAsAsync(stream, list, true);
            stream.Position = 0;
            return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"{typeof(TEntity).Name}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };
        }
        #endregion

        #region 导入

        /// <summary>
        /// 下载导入模板 
        /// </summary>
        [DisplayName("下载导入模板")]
        [ApiDescriptionSettings(Name = "DownloadTemplate", Order = 800), HttpGet]
        public virtual async Task<IActionResult> DownloadTemplate()
        {
            var stream = BaseImportTemplateService.GenerateWithEmptyRows<TImportDto>(10);
            stream.Position = 0;
            return new FileStreamResult(stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"{typeof(TEntity).Name}_{DateTime.Now:yyyyMMddHHmmss}模板.xlsx"
            };
        }
        /// <summary>
        /// 导入数据 
        /// </summary>
        [DisplayName("导入数据")]
        [ApiDescriptionSettings(Name = "Import", Order = 810), HttpPost]
        public virtual async Task<PagedImportResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw Oops.Oh("请上传文件");

            var result = new PagedImportResult();

            using var stream = file.OpenReadStream();

            var rows = MiniExcel.Query<TImportDto>(stream).ToList();

            var addList = new List<TEntity>();

            foreach (var dto in rows)
            {
                try
                {
                    var entity = dto.Adapt<TEntity>();
                    var now = DateTime.Now;

                    entity.CreatedTime = now;
                    entity.CreatedByName = _currentUser.UserName;
                    entity.CreatedBy = _currentUser.UserId;
                    entity.UpdatedTime = now;
                    entity.UpdatedBy = _currentUser.UserId;
                    entity.UpdatedByName = _currentUser.UserName;

                    addList.Add(entity);
                }
                catch (Exception ex)
                {
                    result.FailCount++;
                    result.ErrorMessages.Add($"第 {rows.IndexOf(dto) + 2} 行错误：{ex.Message}");
                }
            }

            if (addList.Any())
            {
                await _msRepository.Master<TEntity>().InsertNowAsync(addList);
                result.SuccessCount = addList.Count;
            }

            return result;
        }



        #endregion
        #region 未建立唯一键
        /// <summary>
        /// 导入数据 
        /// </summary>
        [DisplayName("导入或更新数据")]
        [ApiDescriptionSettings(Name = "ImportUpdate", Order = 810), HttpPost]
        public virtual async Task<PagedImportResult> ImportUpdateByCustomKey(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw Oops.Oh("请上传文件");

            var result = new PagedImportResult();

            using var stream = file.OpenReadStream();

            var rows = MiniExcel
                .Query<TImportDto>(stream)
                .ToList();

            if (!rows.Any())
                return result;

            // Excel内部去重
            var dtoDict = new Dictionary<string, TImportDto>();

            for (int i = 0; i < rows.Count; i++)
            {
                var dto = rows[i];

                try
                {
                    var key = GetImportKey(dto);

                    if (string.IsNullOrWhiteSpace(key))
                        throw new Exception("业务唯一标识不能为空");

                    // 后面的覆盖前面的
                    dtoDict[key] = dto;
                }
                catch (Exception ex)
                {
                    result.FailCount++;

                    result.ErrorMessages.Add(
                        $"第 {i + 2} 行错误：{ex.Message}");
                }
            }

            var validDtos = dtoDict.Values.ToList();

            if (!validDtos.Any())
                return result;

            // 批量查询数据库
            var existingList = await GetExistingListAsync(validDtos);

            // 数据库已有数据
            var existingDict = existingList
                .ToDictionary(
                    GetEntityKey,
                    StringComparer.OrdinalIgnoreCase);

            var addList = new List<TEntity>();
            var updateList = new List<TEntity>();

            foreach (var dto in validDtos)
            {
                try
                {
                    var key = GetImportKey(dto);

                    if (existingDict.TryGetValue(key, out var entity))
                    {
                        // 更新
                        UpdateEntity(entity, dto);

                        var now = DateTime.Now;

                        entity.UpdatedTime = now;
                        entity.UpdatedBy = _currentUser.UserId;
                        entity.UpdatedByName = _currentUser.UserName;

                        updateList.Add(entity);
                    }
                    else
                    {
                        // 新增
                        var addEntity = dto.Adapt<TEntity>();

                        var now = DateTime.Now;

                        entity.CreatedTime = now;
                        entity.CreatedByName = _currentUser.UserName;
                        entity.CreatedBy = _currentUser.UserId;

                        entity.UpdatedTime = now;
                        entity.UpdatedBy = _currentUser.UserId;
                        entity.UpdatedByName = _currentUser.UserName;

                        addList.Add(addEntity);
                    }

                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailCount++;

                    result.ErrorMessages.Add(
                        $"数据处理失败：{ex.Message}");
                }
            }

            // 新增
            if (addList.Any())
            {
                await _msRepository
                    .Master<TEntity>()
                    .InsertNowAsync(addList);
            }

            // 更新
            if (updateList.Any())
            {
                await _msRepository
                    .Master<TEntity>()
                    .UpdateNowAsync(updateList);
            }
            return result;
        }

        /// <summary>
        /// 获取数据库实体业务Key
        /// 
        /// </summary>
        protected virtual string GetEntityKey(TEntity entity)
        {
            throw new NotImplementedException(
              $"请在 {GetType().Name} 中重写 GetEntityKey 方法");
        }
        /// <summary>
        /// 获取导入数据的业务唯一Key
        /// return dto.name+dto.mobilPhone
        /// </summary>
        protected virtual string GetImportKey(TImportDto dto)
        {
            throw new NotImplementedException(
                $"请在 {GetType().Name} 中重写 GetImportKey 方法");
        }

        /// <summary>
        /// 批量查询数据库已有数据
        /// </summary>
        protected virtual async Task<List<TEntity>> GetExistingListAsync(
            List<TImportDto> dtoList)
        {
            return new List<TEntity>();
        }

        /// <summary>
        /// 更新已有实体
        /// </summary>
        protected virtual void UpdateEntity(
            TEntity entity,
            TImportDto dto)
        {
            dto.Adapt(entity);
        }

        #endregion

        #region 根据唯一键更新或新增
       
        public virtual async Task<PagedImportResult> ImportUpdate(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw Oops.Oh("请上传文件");

            var result = new PagedImportResult();

            using var stream = file.OpenReadStream();

            var rows = MiniExcel
                .Query<TImportDto>(stream)
                .ToList();

            if (!rows.Any())
                return result;

            var entities = new List<TEntity>();

            for (int i = 0; i < rows.Count; i++)
            {
                try
                {
                    var entity = rows[i].Adapt<TEntity>();

                    SetAudit(entity);

                    entities.Add(entity);

                    result.SuccessCount++;
                }
                catch (Exception ex)
                {
                    result.FailCount++;

                    result.ErrorMessages.Add(
                        $"第 {i + 2} 行错误：{ex.Message}");
                }
            }

            if (!entities.Any())
                return result;

            await BulkMergeAsync(entities);

            return result;
        }

        protected virtual async Task BulkMergeAsync(List<TEntity> entities)
        {
            await _msRepository.Master<TEntity>().Context.BulkMergeAsync(
                entities,
                options =>
                {
                    ConfigureBulkMerge(options);
                });
        }

        ///// <summary>
        ///// 在调用services中重写ConfiguareBulkMerge 调用示例
        ///// </summary>
        ///// <param name="options"></param>
        //protected override void ConfigureBulkMerge(BulkOperation<SysMenu> options)
        //{
        //    options.ColumnPrimaryKeyExpression =
        //        x => new
        //        {
        //            x.Code,
        //            x.Name,
        //            x.Route,
        //        };

        //    options.IgnoreOnMergeUpdateExpression =
        //        x => new
        //        {
        //            x.Id,
        //            x.CreatedTime,
        //            x.CreatedBy,
        //            x.CreatedByName
        //        };
        //}
        protected virtual void ConfigureBulkMerge(BulkOperation<TEntity> options)
        {
            
            throw new NotImplementedException(
              $"请在 {GetType().Name} 中重写 ConfigureBulkMerge 方法");
        }
        protected void SetAudit(TEntity entity)
        {
            var now = DateTime.Now;

            entity.CreatedTime = now;
            entity.CreatedBy = _currentUser.UserId;
            entity.CreatedByName = _currentUser.UserName;

            entity.UpdatedTime = now;
            entity.UpdatedBy = _currentUser.UserId;
            entity.UpdatedByName = _currentUser.UserName;
        }
        #endregion
    }
}