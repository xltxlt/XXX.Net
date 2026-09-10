

using XXX.Net.Core.BaseEntitys.Admin;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Base.Dto;
using XXX.Net.Core.Services.Menu.Dto;
using System.Data;

namespace XXX.Net.Core.BaseEntitys;

/// <summary>
/// 树形数据工具 — 扁平列表 ↔ 层级树互转
/// </summary>
public static class TreeHelper
{

    #region 内部

    /// <summary>
    /// 将扁平列表转为层级树结构
    /// </summary>
    /// <param name="flatList">扁平列表（包含所有节点）</param>
    /// <param name="rootParentId">根节点的 ParentId 值，默认 0</param>
    public static List<PagedTreeOptions> BuildTree<TTreeEntity>(List<TTreeEntity> flatList, long rootParentId = 0) where TTreeEntity:BaseTreeEntity,new()
    {
        if (flatList == null || flatList.Count == 0)
            return new List<PagedTreeOptions>();

        var lookup = flatList.ToLookup(x => x.ParentId);
        return BuildNodes<TTreeEntity>(lookup, rootParentId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lookup"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    private static List<PagedTreeOptions> BuildNodes<TTreeEntity>(ILookup<long, TTreeEntity> lookup, long parentId) where TTreeEntity : BaseTreeEntity, new()
    {
        return lookup[parentId]
            .OrderBy(x => x.Sort)
            .Select(item => new PagedTreeOptions
            {
                Value = item.Id,
                ParentId = item.ParentId,
                Label = item.Name ?? "",
                Children = BuildNodes<TTreeEntity>(lookup, item.Id)
            })
            .ToList();
    }
    #endregion
    #region 内部

    /// <summary>
    /// 将扁平列表转为层级树结构
    /// </summary>
    /// <param name="flatList">扁平列表（包含所有节点）</param>
    /// <param name="builderOutput"></param>
    /// <param name="rootParentId">根节点的 ParentId 值，默认 0</param>
    public static List<TOutput> BuildTree<TTreeEntity, TOutput>(List<TTreeEntity> flatList, Func<TTreeEntity, List<TOutput>, TOutput> builderOutput=null, long rootParentId = 0) where TTreeEntity : BaseTreeEntity, new() where TOutput: IPagedTreeOutput<TOutput>
    {
        if (flatList == null || flatList.Count == 0)
            return new List<TOutput>();

        var lookup = flatList.ToLookup(x => x.ParentId);
        return BuildNodes<TTreeEntity, TOutput>(lookup, builderOutput,rootParentId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lookup"></param>
    /// <param name="builderOutput"></param>
    /// <param name="parentId"></param>
    /// <returns></returns>
    private static List<TOutput> BuildNodes<TTreeEntity, TOutput>(ILookup<long, TTreeEntity> lookup,Func<TTreeEntity, List<TOutput>,  TOutput> builderOutput = null, long parentId=0) where TTreeEntity : BaseTreeEntity, new() where TOutput : IPagedTreeOutput<TOutput>
    {
        return lookup[parentId]
            .OrderBy(x => x.Sort)
            .Select(item => {
                if (builderOutput != null) {
                    return builderOutput(item, BuildNodes<TTreeEntity, TOutput>(lookup, builderOutput, item.Id));
                }
                var mOutput = item.Adapt<TOutput>();
                var children= BuildNodes<TTreeEntity, TOutput>(lookup, builderOutput, item.Id);
                mOutput.Children = children;
                return mOutput;
                
            })
            .ToList();
    }
    #endregion

    public static List<PagedOptions> BuildTree(
    DataTable dt,
    string idField = "Id",
    string parentIdField = "ParentId",
    string valueField = "Id",
    string labelField = "Name",
    string sortField = "Sort",
    long rootParentId = 0)
    {
        if (dt == null || dt.Rows.Count == 0)
            return new List<PagedOptions>();

        var rows = dt.AsEnumerable()
            .Select(row => new
            {
                Id = Convert.ToInt64(row[idField]),
                ParentId = row[parentIdField] == DBNull.Value
                    ? rootParentId
                    : Convert.ToInt64(row[parentIdField]),

                Value = Convert.ToInt64(row[valueField]),

                Label = Convert.ToString(row[labelField] ?? ""),

                Sort = dt.Columns.Contains(sortField) &&
                       row[sortField] != DBNull.Value
                    ? Convert.ToInt32(row[sortField])
                    : 0
            })
            .ToList();

        var lookup = rows.ToLookup(x => x.ParentId);

        List<PagedOptions> BuildNodes(long parentId)
        {
            return lookup[parentId]
                .OrderBy(x => x.Sort)
                .Select(item =>
                {
                    var option = new PagedOptions
                    {
                        Value = item.Value,
                        Label = item.Label,
                        Children = BuildNodes(item.Id)
                    };

                    return option;
                })
                .ToList();
        }

        return BuildNodes(rootParentId);
    }
}
