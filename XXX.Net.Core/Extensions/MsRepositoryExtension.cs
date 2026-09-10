using Furion.LinqBuilder;
using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.BaseEntitys.Enums;
using XXX.Net.Core.Entity.Sys;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace XXX.Net.Core.Extensions
{
    public static class MsRepositoryExtension
    {
        /// <summary>
        /// 构建where
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="msRepository"></param>
        /// <param name="pagedListDto"></param>
        /// <returns></returns>
        public static async Task<IQueryable<TEntity>> BuildListWhere<TEntity>(this IQueryable<TEntity> queryable, IMSRepository msRepository, PagedListDto pagedListDto) where TEntity : BaseEntity, new()
        {
            List<ConditionalModel> mlConitionalModel = new List<ConditionalModel>();
            if ((pagedListDto.MenuId != null || !string.IsNullOrEmpty(pagedListDto.MenuCode)) && pagedListDto.Where != null && pagedListDto.Where.Count() > 0)
            {
                var mSysMenu = await msRepository.Slave<SysMenu>()
                    .Where(pagedListDto.MenuId != null, w => w.Id == pagedListDto.MenuId)
                      .Where(pagedListDto.MenuId == null && !string.IsNullOrEmpty(pagedListDto.MenuCode), w => pagedListDto.MenuCode == w.Code)
                      .FirstOrDefaultAsync();
                var mlSysSearch = await msRepository.Slave<SysMenuField>().Where(w => w.FieldType == 1 && w.MenuId == mSysMenu.Id).ToListAsync();
                var conModels = await QueryWhereBySysMenuField(pagedListDto.Where, mlSysSearch);
                mlConitionalModel.AddRange(conModels);
            }
            if (pagedListDto.CustomWhere != null && pagedListDto.CustomWhere.Count() > 0)
            {
                var customConModels = GetCustomWhere(pagedListDto.CustomWhere);
                mlConitionalModel.AddRange(customConModels);

            }
            if (pagedListDto.SearchWhere != null)
            {
                var serachConModels = GetSearchTypeWhere(pagedListDto.SearchWhere);
                mlConitionalModel.AddRange(serachConModels);
            }
            mlConitionalModel = mlConitionalModel.Distinct().ToList();
            var queryableBuild = queryable.BuildWhere(mlConitionalModel);
            return queryableBuild;
        }
        /// <summary>
        /// 构建where
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pagedListDto"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> BuildListWhere<TEntity>(this IQueryable<TEntity> queryable, PagedListDto pagedListDto) where TEntity : BaseEntity, new()
        {
            return queryable.BuildListWhere<TEntity>(pagedListDto.CustomWhere,pagedListDto.SearchWhere);
        }
        /// <summary>
        /// 构建where
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="mlPagedCustomeWhere"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> BuildListWhere<TEntity>(this IQueryable<TEntity> queryable, List<PagedCustomWhere> mlPagedCustomeWhere) where TEntity : BaseEntity, new()
        {
            List<ConditionalModel> mlConitionalModel = new List<ConditionalModel>();
            if (mlPagedCustomeWhere != null && mlPagedCustomeWhere.Count() > 0)
            {
                var customConModels = GetCustomWhere(mlPagedCustomeWhere);
                mlConitionalModel.AddRange(customConModels);

            }
            mlConitionalModel = mlConitionalModel.Distinct().ToList();
            var queryableBuild = queryable.BuildWhere(mlConitionalModel);
            return queryableBuild;
        }
        /// <summary>
        /// 构建where
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="mlPagedCustomeWhere"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> BuildListWhere<TEntity>(this IQueryable<TEntity> queryable, List<PagedCustomWhere> mlPagedCustomeWhere,List<PagedSearchWhere> searchWheres) where TEntity : BaseEntity, new()
        {
            List<ConditionalModel> mlConitionalModel = new List<ConditionalModel>();
            if (mlPagedCustomeWhere != null && mlPagedCustomeWhere.Count() > 0)
            {
                var customConModels = GetCustomWhere(mlPagedCustomeWhere);
                mlConitionalModel.AddRange(customConModels);

            }
            if (searchWheres != null && searchWheres.Count() > 0)
            {
                var searchConModels = GetSearchTypeWhere(searchWheres);
                mlConitionalModel.AddRange(searchConModels);
            }
            
            mlConitionalModel = mlConitionalModel.Distinct().ToList();
            var queryableBuild = queryable.BuildWhere(mlConitionalModel);
            return queryableBuild;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="msRepository"></param>
        /// <param name="pagedListDto"></param>
        /// <returns></returns>
        public static async Task<PagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> queryable, IMSRepository msRepository, PagedPaginationListDto pagedListDto) where TEntity : BaseEntity, new()
        {
            List<ConditionalModel> mlConitionalModel = new List<ConditionalModel>();
            if ((pagedListDto.MenuId != null || !string.IsNullOrEmpty(pagedListDto.MenuCode)) && pagedListDto.Where != null && pagedListDto.Where.Count() > 0)
            {
                var mSysMenu = await msRepository.Slave<SysMenu>()
                    .Where(pagedListDto.MenuId != null, w => w.Id == pagedListDto.MenuId)
                      .Where(pagedListDto.MenuId == null && !string.IsNullOrEmpty(pagedListDto.MenuCode), w => pagedListDto.MenuCode == w.Code)
                      .FirstOrDefaultAsync();
                var mlSysSearch = await msRepository.Slave<SysMenuField>().Where(w => w.FieldType == 1 && w.MenuId == mSysMenu.Id).ToListAsync();
                var conModels = await QueryWhereBySysMenuField(pagedListDto.Where, mlSysSearch);
                mlConitionalModel.AddRange(conModels);
            }
            if (pagedListDto.CustomWhere != null && pagedListDto.CustomWhere.Count() > 0)
            {
                var customConModels = GetCustomWhere(pagedListDto.CustomWhere);
                mlConitionalModel.AddRange(customConModels);


            }
            if (pagedListDto.SearchWhere != null)
            {
                var serachConModels =  GetSearchTypeWhere(pagedListDto.SearchWhere);
                mlConitionalModel.AddRange(serachConModels);
            }
            mlConitionalModel = mlConitionalModel.Distinct().ToList();
            var queryableBuild = queryable.BuildWhere(mlConitionalModel);
            return await queryableBuild.ToPagedListAsync(pagedListDto.PageIndex, pagedListDto.PageSize);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="msRepository"></param>
        /// <param name="pagedListDto"></param>
        /// <returns></returns>
        public static async Task<List<TEntity>> ToListAsync<TEntity>(this IQueryable<TEntity> queryable, IMSRepository msRepository, PagedListDto pagedListDto) where TEntity : BaseEntity, new()
        {
            List<ConditionalModel> mlConitionalModel = new List<ConditionalModel>();
            if ((pagedListDto.MenuId != null || !string.IsNullOrEmpty(pagedListDto.MenuCode)) && pagedListDto.Where != null && pagedListDto.Where.Count() > 0)
            {
                var mSysMenu = await msRepository.Slave<SysMenu>()
                    .Where(pagedListDto.MenuId != null, w => w.Id == pagedListDto.MenuId)
                      .Where(pagedListDto.MenuId == null && !string.IsNullOrEmpty(pagedListDto.MenuCode), w => pagedListDto.MenuCode == w.Code)
                      .FirstOrDefaultAsync();
                var mlSysSearch = await msRepository.Slave<SysMenuField>().Where(w => w.FieldType == 1 && w.MenuId == mSysMenu.Id).ToListAsync();
                var conModels = await QueryWhereBySysMenuField(pagedListDto.Where, mlSysSearch);
                mlConitionalModel.AddRange(conModels);
            }
            if (pagedListDto.CustomWhere != null && pagedListDto.CustomWhere.Count() > 0)
            {
                var customConModels = GetCustomWhere(pagedListDto.CustomWhere);
                mlConitionalModel.AddRange(customConModels);

            }
            if (pagedListDto.SearchWhere != null)
            {
                var serachConModels =  GetSearchTypeWhere(pagedListDto.SearchWhere);
                mlConitionalModel.AddRange(serachConModels);
            }
            mlConitionalModel = mlConitionalModel.Distinct().ToList();
            var queryableBuild = queryable.BuildWhere(mlConitionalModel);
            return await queryableBuild.ToListAsync();
        }



        #region 获取查询参数
        /// <summary>
        /// 动态查询条件类型（类似 SqlSugar 的 ConditionalType）
        /// </summary>
        public enum ConditionalType
        {
            /// <summary>
            /// 等于（=）
            /// </summary>
            Equal = 0,

            /// <summary>
            ///  不等于
            /// </summary>
            NotEqual = 1,

            /// <summary>
            /// 大于
            /// </summary>
            GreaterThan = 2,

            /// <summary>
            /// 小于
            /// </summary>
            LessThan = 3,

            /// <summary>
            /// 大于等于
            /// </summary>
            GreaterThanOrEqual = 4,

            /// <summary>
            /// 小于等于
            /// </summary>
            LessThanOrEqual = 5,

            /// <summary>
            /// 模糊匹配
            /// </summary>
            Like = 6,

            /// <summary>
            /// 左匹配
            /// </summary>
            StartsWith = 7,

            /// <summary>
            /// IN 查询
            /// Value 必须是 IEnumerable
            /// </summary>
            In = 8,

            /// <summary>
            /// NOT IN 查询
            /// Value 必须是 IEnumerable
            /// </summary>
            NotIn = 9
        }
        public class ConditionalModel
        {
            /// <summary>
            /// 字段名
            /// </summary>
            public string FieldName { get; set; }
            /// <summary>
            /// 字段值
            /// </summary>
            public string FieldValue { get; set; }
            /// <summary>
            /// 搜索类型
            /// </summary>
            public ConditionalType ConditionalType { get; set; }
        }

        /// <summary>
        /// 构建查询参数
        /// </summary>
        /// <returns></returns>
        public static IQueryable<TEntity> BuildWhere<TEntity>(this IQueryable<TEntity> queryable, List<ConditionalModel> condits)
        {
            var param = Expression.Parameter(typeof(TEntity), "x");
            Expression body = null;
            foreach (var condit in condits)
            {
                var prop = Expression.Property(param, condit.FieldName);
                var val = CreateTypedConstant(condit.FieldValue, prop.Type);
                var underlyingType = Nullable.GetUnderlyingType(prop.Type) ?? prop.Type;
                Expression cond = condit.ConditionalType switch
                {
                    ConditionalType.Equal => Expression.Equal(prop, val),
                    ConditionalType.Like => Expression.Call(prop, "Contains", null, val),
                    ConditionalType.NotEqual => Expression.NotEqual(prop, (Expression)val),
                    ConditionalType.GreaterThan => Expression.GreaterThan(prop, val),
                    ConditionalType.LessThan => Expression.LessThan(prop, val),
                    ConditionalType.StartsWith =>
                    Expression.Call(
                        prop,
                        typeof(string).GetMethod(nameof(string.StartsWith), new[] { typeof(string) })!,
                        val),
                    ConditionalType.In => InExpression(prop, val, underlyingType),
                    ConditionalType.NotIn => Expression.Not(InExpression(prop, val, underlyingType)),
                    ConditionalType.GreaterThanOrEqual => Expression.GreaterThanOrEqual(prop, val),
                    ConditionalType.LessThanOrEqual => Expression.LessThanOrEqual(prop, val),
                    _ => throw new NotSupportedException()
                };
                body = body == null ? cond : Expression.AndAlso(body, cond);
            }
            if (body == null) return queryable;
            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, param);
            return queryable.Where(lambda);
        }
        private static Expression InExpression(Expression prop, object value, Type elementType)
        {
            if (value is not IEnumerable enumerable)
                throw new ArgumentException("In / NotIn 的 Value 必须是 IEnumerable");

            var list = enumerable.Cast<object>()
                .Select(v => ConvertValue(v, elementType))
                .ToList();

            var containsMethod = typeof(Enumerable)
                .GetMethods()
                .First(m => m.Name == nameof(Enumerable.Contains) && m.GetParameters().Length == 2)
                .MakeGenericMethod(elementType);

            var valuesExpr = Expression.Constant(list, list.GetType());
            return Expression.Call(containsMethod, valuesExpr, prop);
        }
        private static object ConvertValue(object value, Type targetType)
        {
            if (value == null) return null;
            if (value.GetType() == targetType) return value;
            return Convert.ChangeType(value, targetType);
        }
        /// <summary>
        /// 获取where 
        /// </summary>
        /// <param name="dic"></param>
        /// <param name="mlSysSearch"></param>
        /// <returns></returns>
        public static async Task<List<ConditionalModel>> QueryWhereBySysMenuField(Dictionary<string, string> dic, List<SysMenuField> mlSysSearch)
        {
            var conModels = new List<ConditionalModel>();

            if (dic == null) return conModels;
            foreach (var item in dic)
            {
                if (string.IsNullOrEmpty(item.Value)) break;
                if (item.Key.EndsWith("_custom")) break;
                var mSysSearch = mlSysSearch.Where(w => w.FieldName == item.Key).LastOrDefault();
                if (mSysSearch == null || mSysSearch.IsCustom) break;

                var conModel = new ConditionalModel();
                conModel.FieldName = mSysSearch.FieldName;
                conModel.FieldValue = item.Value;
                switch (mSysSearch.SearchType)
                {
                    case (int)PageSearchTypeEnum.Input:
                        conModel.ConditionalType = ConditionalType.Like;
                        break;

                    case (int)PageSearchTypeEnum.OneSelect:
                    case (int)PageSearchTypeEnum.DateSelect:
                    case (int)PageSearchTypeEnum.TimeSelect:
                    case (int)PageSearchTypeEnum.DateTimeSelect:
                    case (int)PageSearchTypeEnum.TreeSelect:
                    case (int)PageSearchTypeEnum.SelfTreeSelect:
                    case (int)PageSearchTypeEnum.ProvinceSelect:
                    case (int)PageSearchTypeEnum.AreaSelect:
                    case (int)PageSearchTypeEnum.CitySelect:
                        conModel.ConditionalType = ConditionalType.Equal;
                        break;
                    case (int)PageSearchTypeEnum.MultSelect:
                    case (int)PageSearchTypeEnum.MultTreeSelect:
                    case (int)PageSearchTypeEnum.MultSelfTreeSelect:
                        conModel.ConditionalType = ConditionalType.In;
                        break;
                    case (int)PageSearchTypeEnum.DateRangeSelect:
                        var splits = item.Value.Split(",");
                        conModels.Add(new ConditionalModel()
                        {
                            FieldName = mSysSearch.FieldName,
                            FieldValue = splits[splits.Length - 1],
                            ConditionalType = ConditionalType.GreaterThanOrEqual
                        });
                        conModel.ConditionalType = ConditionalType.LessThanOrEqual;
                        conModel.FieldValue = splits[0];
                        break;
                    default: break;
                }
                conModels.Add(conModel);
            }
            return conModels;
        }



        /// <summary>
        /// 获取where  根据前端页面搜索类型
        /// </summary>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public static List<ConditionalModel> GetSearchTypeWhere(List<PagedSearchWhere> wheres)
        {
            var conModels = new List<ConditionalModel>();

            if (wheres == null) return conModels;
            foreach (var item in wheres)
            {
                if (string.IsNullOrEmpty(item.FieldValue)) break;
                if (item.FieldName.EndsWith("_custom")) break;

                var conModel = new ConditionalModel();
                conModel.FieldName = item.FieldName;
                conModel.FieldValue = item.FieldValue;
                switch (item.SearchType)
                {
                    case (int)PageSearchTypeEnum.Input:
                        conModel.ConditionalType = ConditionalType.Like;
                        break;

                    case (int)PageSearchTypeEnum.OneSelect:
                    case (int)PageSearchTypeEnum.DateSelect:
                    case (int)PageSearchTypeEnum.TimeSelect:
                    case (int)PageSearchTypeEnum.DateTimeSelect:
                    case (int)PageSearchTypeEnum.TreeSelect:
                    case (int)PageSearchTypeEnum.SelfTreeSelect:
                    case (int)PageSearchTypeEnum.ProvinceSelect:
                    case (int)PageSearchTypeEnum.AreaSelect:
                    case (int)PageSearchTypeEnum.CitySelect:
                    case (int)PageSearchTypeEnum.Number:
                        conModel.ConditionalType = ConditionalType.Equal;
                        break;
                    case (int)PageSearchTypeEnum.MultSelect:
                    case (int)PageSearchTypeEnum.MultTreeSelect:
                    case (int)PageSearchTypeEnum.MultSelfTreeSelect:
                        conModel.ConditionalType = ConditionalType.In;
                        break;
                    case (int)PageSearchTypeEnum.DateRangeSelect:
                        var splits = item.FieldValue.Split(",");
                        conModels.Add(new ConditionalModel()
                        {
                            FieldName = item.FieldName,
                            FieldValue = splits[splits.Length - 1],
                            ConditionalType = ConditionalType.GreaterThanOrEqual
                        });
                        conModel.ConditionalType = ConditionalType.LessThanOrEqual;
                        conModel.FieldValue = splits[0];
                        break;
                    default: break;
                }
                conModels.Add(conModel);
            }
            return conModels;
        }

        /// <summary>
        /// 获取Customwhere 
        /// </summary>
        /// <param name="customWheres"></param>
        /// <returns></returns>
        public static List<ConditionalModel> GetCustomWhere(List<PagedCustomWhere> customWheres)
        {
            var conModels = new List<ConditionalModel>();

            if (customWheres == null || customWheres.Count() == 0) return conModels;
            foreach (var item in customWheres)
            {
                if (string.IsNullOrEmpty(item.FiledValue)) break;
                if (item.ConditionalType<0) break;
                if (item.FiledName.EndsWith("_custom")) break;

                var conModel = new ConditionalModel();
                conModel.FieldName = item.FiledName;
                conModel.FieldValue = item.FiledValue;

                ConditionalType type = (ConditionalType)item.ConditionalType ;
                conModel.ConditionalType = type;
                conModels.Add(conModel);
            }
            return conModels;
        }

       /// <summary>
       /// 类型转换
       /// </summary>
       /// <param name="fieldValue"></param>
       /// <param name="targetType"></param>
       /// <returns></returns>
        private static ConstantExpression CreateTypedConstant(object fieldValue, Type targetType)
        {
            var underlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (fieldValue == null || fieldValue is string s && string.IsNullOrEmpty(s))
            {
                return Expression.Constant(null, targetType);
            }

            // 处理枚举
            if (underlyingType.IsEnum)
            {
                var enumValue = Enum.Parse(underlyingType, fieldValue.ToString()!);
                return Expression.Constant(enumValue, targetType);
            }
            // ✅ 处理 bool / bool?
            if (underlyingType == typeof(bool))
            {
                var str = fieldValue.ToString()!.Trim();
                var boolValue = str switch
                {
                    "1" or "true" or "True" or "Y" or "y" or "yes" or "Yes" => true,
                    "0" or "false" or "False" or "N" or "n" or "no" or "No" => false,
                    _ => throw new FormatException($"Cannot convert '{fieldValue}' to Boolean.")
                };

                // 如果原始类型是 bool?，返回 (bool?)boolValue
                return targetType == typeof(bool)
                    ? Expression.Constant(boolValue, typeof(bool))
                    : Expression.Constant((bool?)boolValue, typeof(bool?));
            }
            // 处理 GUID
            if (underlyingType == typeof(Guid))
            {
                return Expression.Constant(Guid.Parse(fieldValue.ToString()!), targetType);
            }

            // 通用类型转换
            var convertedValue = Convert.ChangeType(fieldValue, underlyingType);
            return Expression.Constant(convertedValue, targetType);
        }
        #endregion
    }
}
