using Application.Common;
using Application.DTO;

namespace Application.Service
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> AddOrder(CommandOrderDTO orderDTO);
        Task<ServiceResponse<bool>> DeleteOrder(Guid id);
        Task<ServiceResponse<QueryOrderDTO>> GetOrderInfo(Guid id);
        Task<ServiceResponse<IEnumerable<QueryOrderDTO>>> GetPagingAsync(SearchDTO searchDTO);
        Task<ServiceResponse<bool>> SoftRemoveOrder(Guid id);
        Task<ServiceResponse<bool>> UpdateOrder(Guid id, CommandOrderDTO orderDTO);
        Task<ServiceResponse<bool>> UpdateOrderStatus(Guid id, string status);
    }
}