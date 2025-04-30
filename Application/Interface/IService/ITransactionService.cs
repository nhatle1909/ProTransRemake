using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<bool>> AddTransaction(CommandTransactionDTO transactionDTO);
        Task<ServiceResponse<IEnumerable<QueryTransactionDTO>>> GetPagingAsync(SearchDTO searchDTO);
        Task<ServiceResponse<QueryTransactionDTO>> GetTransactionInfoById(Guid id);
    }
}