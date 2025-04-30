using Application.Common;
using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddOrder(CommandOrderDTO orderDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = orderDTO.Adapt<Order>();
                var result = await _unitOfWork.GetRepository<Order>().AddItemAsync(newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> DeleteOrder(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Order>().RemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<QueryOrderDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryOrderDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Order>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties, searchDTO.sortField,
                    searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryOrderDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> SoftRemoveOrder(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Order>().RemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<QueryOrderDTO>> GetOrderInfo(Guid id)
        {
            ServiceResponse<QueryOrderDTO> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Order>().GetByIdAsync(id);
                var resultDTO = result.Item1.Adapt<QueryOrderDTO>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> UpdateOrder(Guid id, CommandOrderDTO orderDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = orderDTO.Adapt<Order>();
                var result = await _unitOfWork.GetRepository<Order>().UpdateItemAsync(id, newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> UpdateOrderStatus(Guid id, string status)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var query = await _unitOfWork.GetRepository<Order>().GetByIdAsync(id);
                var order = query.Item1;
                order.Status = status;
                var result = await _unitOfWork.GetRepository<Order>().UpdateItemAsync(id, order);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
