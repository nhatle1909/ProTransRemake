using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface IDocumentService
    {
        Task<ServiceResponse<bool>> CreateNewDocument(CommandDocumentDTO commandDocumentDTO);
        Task<ServiceResponse<QueryDocumentDTO>> GetDocumentById(Guid id);
        Task<ServiceResponse<IEnumerable<QueryDocumentDTO>>> GetPagingDocuments(SearchDTO searchDTO);
        Task<ServiceResponse<bool>> RemoveDocument(Guid id);
        Task<ServiceResponse<bool>> SoftRemoveDocument(Guid id);
        Task<ServiceResponse<bool>> UpdateDocument(Guid id, CommandDocumentDTO commandDocumentDTO);
        Task<ServiceResponse<long>> CountAsync(CountDTO countDTO);
    }
}