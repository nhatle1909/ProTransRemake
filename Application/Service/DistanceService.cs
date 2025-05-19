using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class DistanceService : IDistanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DistanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddDistance(CommandDistanceDTO distanceDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = distanceDTO.Adapt<Distance>();
                var result = await _unitOfWork.GetRepository<Distance>().AddItemAsync(newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> DeleteDistance(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Distance>().RemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<IEnumerable<QueryDistanceDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryDistanceDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Distance>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties, searchDTO.sortField,
                    searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryDistanceDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> UpdateDistance(Guid id, CommandDistanceDTO distanceDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = distanceDTO.Adapt<Distance>();
                var result = await _unitOfWork.GetRepository<Distance>().UpdateItemAsync(id, newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<long>> CountAsync(CountDTO countDTO)
        {
            ServiceResponse<long> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Distance>().CountAsync(countDTO.searchParams, countDTO.searchValue, countDTO.pageSize);
                response.Response(result, result > 0, string.Empty);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
