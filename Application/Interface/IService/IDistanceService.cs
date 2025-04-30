using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface IDistanceService
    {
        Task<ServiceResponse<bool>> AddDistance(CommandDistanceDTO distanceDTO);
        Task<ServiceResponse<bool>> DeleteDistance(Guid id);
        Task<ServiceResponse<IEnumerable<QueryDistanceDTO>>> GetPagingAsync(SearchDTO searchDTO);
        Task<ServiceResponse<bool>> UpdateDistance(Guid id, CommandDistanceDTO distanceDTO);
    }
}