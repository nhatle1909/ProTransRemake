using Application.Common;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IService
{
    public interface IAgencyService
    {
        public Task<ServiceResponse<bool>> CreateAgency(CommandAgencyDTO commandAgencyDTO);
        public Task<ServiceResponse<bool>> UpdateAgency(Guid id,CommandAgencyDTO commandAgencyDTO);
        public Task<ServiceResponse<bool>> SoftRemoveAgency(Guid id);
        public Task<ServiceResponse<IEnumerable<QueryAgencyDTO>>> GetPagingAgencies(SearchDTO searchDTO);
    }
}
