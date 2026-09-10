using XXX.Net.Core.Entity.Sys;
using XXX.Net.Core.Services.Document.Dto;

namespace XXX.Net.Core.Services.Document;

public class DocumentService : BaseService<SysDocumentRule, DocumentNumberRuleDto>, IDynamicApiController
{
    public DocumentService(IMSRepository msRepository, ICurrentUser currentUser)
        : base(msRepository, currentUser)
    {
    }
}
