using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;


namespace Application.Service
{
    public class DocumentService :  IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> CreateNewDocument(CommandDocumentDTO commandDocumentDTO)
        {
            ServiceResponse<bool> serviceResponse = new();
            try
            {
                var document = commandDocumentDTO.Adapt<Document>();
                var result = await _unitOfWork.GetRepository<Document>().AddItemAsync(document);
                await _unitOfWork.CommitAsync();
                serviceResponse.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<bool>> UpdateDocument(Guid id, CommandDocumentDTO commandDocumentDTO)
        {
            ServiceResponse<bool> serviceResponse = new();
            try
            {
                var document = commandDocumentDTO.Adapt<Document>();
                var result = await _unitOfWork.GetRepository<Document>().UpdateItemAsync(id, document);
                await _unitOfWork.CommitAsync();
                serviceResponse.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<bool>> SoftRemoveDocument(Guid id)
        {
            ServiceResponse<bool> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Document>().SoftRemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                serviceResponse.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<IEnumerable<QueryDocumentDTO>>> GetPagingDocuments(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryDocumentDTO>> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Document>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties,
                                                                                      searchDTO.sortField, searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryDocumentDTO>>();
                serviceResponse.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<QueryDocumentDTO>> GetDocumentById(Guid id)
        {
            ServiceResponse<QueryDocumentDTO> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Document>().GetByIdAsync(id);
                var resultDTO = result.Item1.Adapt<QueryDocumentDTO>();
                serviceResponse.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<bool>> RemoveDocument(Guid id)
        {
            ServiceResponse<bool> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Document>().RemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                serviceResponse.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<long>> CountAsync(CountDTO countDTO)
        {
            ServiceResponse<long> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Document>().CountAsync(countDTO.searchParams, countDTO.searchValue, countDTO.pageSize);
                serviceResponse.Response(result, result > 0, string.Empty);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;
        }
    }
}
