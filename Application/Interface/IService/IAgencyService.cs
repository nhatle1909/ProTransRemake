using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface IAgencyService
    {
        public Task<ServiceResponse<bool>> CreateAgency(CommandAgencyDTO commandAgencyDTO);
        public Task<ServiceResponse<bool>> UpdateAgency(Guid id, CommandAgencyDTO commandAgencyDTO);
        public Task<ServiceResponse<bool>> SoftRemoveAgency(Guid id);
        public Task<ServiceResponse<IEnumerable<QueryAgencyDTO>>> GetPagingAgencies(SearchDTO searchDTO);
        public Task<ServiceResponse<long>> CountAsync(CountDTO countDTO);
    }
}
