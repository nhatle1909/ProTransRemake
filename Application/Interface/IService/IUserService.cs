using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface IUserService
    {
        public Task<ServiceResponse<IEnumerable<QueryUserDTO>>> GetPagingAsync(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> CreateGuestUser(CommandUserDTO commandUserDTO);
        public Task<ServiceResponse<bool>> SoftRemoveUser(Guid id);
        public Task<ServiceResponse<bool>> UpdateProfile(Guid id, CommandUserDTO commandUserDTO);
        public Task<ServiceResponse<QueryUserDTO>> GetUserInfo(Guid id);
        Task<ServiceResponse<long>> CountAsync(CountDTO countDTO);
    }
}
