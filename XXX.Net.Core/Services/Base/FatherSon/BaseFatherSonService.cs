using XXX.Net.Core.BaseEntitys.Dto;
using XXX.Net.Core.BaseEntitys.Entity;
using XXX.Net.Core.Services.Base;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using DnsClient.Protocol;

/// <summary>
/// 父子表一对多
///
/// </summary>
/// <typeparam name="TParent"></typeparam>
/// <typeparam name="TSon"></typeparam>
/// <typeparam name="TParentDto"></typeparam>
/// <typeparam name="TSonDto"></typeparam>
/// <typeparam name="TOutputDto"></typeparam>
public abstract class BaseFatherSonService<
    TParent,
    TSon,
    TParentDto,
    TSonDto
    >:BaseService<TParent, TParentDto>
    where TParent : BaseParentSonEntity<TSon>, IPrivateEntity, new()
    where TSon : BaseSonEntity, new()
    where TParentDto : BaseParentUpdate<TSonDto>, new()
    where TSonDto : BaseUpdate, new()
    //where TOutputDto : class, new()
{
    private readonly IMSRepository _msRepository;
    private readonly ICurrentUser _currentUser;
    public BaseFatherSonService(
        IMSRepository msRepository,
        ICurrentUser currentUser):base(msRepository,currentUser)
    {
        _msRepository = msRepository;
        _currentUser = currentUser;
    }
    #region 选择实现

    protected virtual async Task<TSon> ToSonEntity(TSonDto dto,TSon oldSon=null) {
        if (oldSon != null)
        {
            var now= DateTime.Now;
            oldSon.CreatedByName = _currentUser.UserName;
            oldSon.CreatedBy = _currentUser.UserId;
            oldSon.CreatedTime = now;
            oldSon.UpdatedByName = _currentUser.UserName;
            oldSon.UpdatedBy = _currentUser.UserId;
            oldSon.UpdatedTime = now;

            return dto.Adapt(oldSon);
        }
        return dto.Adapt<TSon>();
    }
    protected virtual async Task<List<TSon>> ToSonsEntity(List<TSonDto> dtos, List<TSon> oldSons = null)
    {
        var sons=new List<TSon>();
        foreach (var item in dtos)
        {
            var oldSon= oldSons?.FirstOrDefault(s => s.Id == item.Id)!;
            var son=  await ToSonEntity(item, oldSon);
            sons.Add(son);
        }
        return sons;
    }
    //protected virtual async Task<TOutputDto> MapOutput(TParent entity)
    //{
    //    return entity.Adapt<TOutputDto>();
    //}
    #endregion



    /// <summary>
    /// 1. 新增父子
    /// </summary>
    /// <param name="parentDto"></param>
    /// <returns></returns>
    [DisplayName("新增父子")]
    [ApiDescriptionSettings(Name = "Add", Order = 100), HttpPost]
    public override async Task<TParent> Add(TParentDto parentDto)
    {
        var entity = await ToEntity(parentDto);

        if (parentDto.Children!=null&& parentDto.Children?.Count > 0)
        {
            var children = entity.Children!;
            children= await ToSonsEntity(parentDto.Children);
            entity.Children = children;
        }
       return  (await _msRepository.Master<TParent>().InsertAsync(entity)).Entity;
    }

    /// <summary>
    /// 更新父子（Include 核心）
    /// </summary>
    /// <param name="parentDto"></param>
    /// <returns></returns>
    [DisplayName("更新父子")]
    [ApiDescriptionSettings(Name = "Update", Order = 200), HttpPost]
    public  override  async Task<TParent> Update(TParentDto parentDto)
    {
        if (!(parentDto.Id > 0)) {
            throw Oops.Oh("无对应数据");
        }
        var mParent= await _msRepository.Master<TParent>().AsQueryable().AsTracking().Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == parentDto.Id&&x.Deleted==false);
        if (mParent==null)
        {
            throw Oops.Oh("无对应数据");
        }

        var entity=await ToEntity(parentDto,mParent);
        var children = await ToSonsEntity(parentDto.Children, mParent.Children.ToList());
        return (await _msRepository.Master<TParent>().UpdateAsync(entity)).Entity;
    }

    /// <summary>
    /// 3. 查询详情（Include）
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    [DisplayName("查询详情")]
    [ApiDescriptionSettings(Name = "Detail", Order = 300), HttpGet]
    public override async Task<TParent> Detail(long parentId)
    {
        var parentEntity = await _msRepository.Master<TParent>()
            .AsQueryable().AsTracking()
            .Include(x=>x.Children)
            .FirstOrDefaultAsync(p => p.Id == parentId)
            ?? throw Oops.Oh($"数据不存在不存在：{parentId}");

        return parentEntity;
    }

}