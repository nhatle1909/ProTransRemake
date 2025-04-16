using Application.Common;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IService
{
    public interface IUserService
    {
        public Task<ServiceResponse<IEnumerable<QueryUserDTO>>> GetPagingAsync(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> CreateGuestUser(CommandUserDTO commandUserDTO);
        public Task<ServiceResponse<bool>> SoftRemoveUser(Guid id);
        public Task<ServiceResponse<bool>> UpdateProfile(Guid id, CommandUserDTO commandUserDTO);
        public Task<ServiceResponse<QueryUserDTO>> GetUserInfo(Guid id);
    }
}
