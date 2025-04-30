using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;
namespace Application.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddTransaction(CommandTransactionDTO transactionDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = transactionDTO.Adapt<Transaction>();
                var result = await _unitOfWork.GetRepository<Transaction>().AddItemAsync(newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<QueryTransactionDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryTransactionDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Transaction>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties, searchDTO.sortField,
                    searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryTransactionDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }


        public async Task<ServiceResponse<QueryTransactionDTO>> GetTransactionInfoById(Guid id)
        {
            ServiceResponse<QueryTransactionDTO> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Transaction>().GetByIdAsync(id);
                var resultDTO = result.Item1.Adapt<QueryTransactionDTO>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
