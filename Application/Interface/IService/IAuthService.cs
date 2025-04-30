using Application.Common;

namespace Application.Interface.IService
{
    public interface IAuthService
    {
        public Task<ServiceResponse<(bool, string)>> Login(string credential, string password);
        public Task<ServiceResponse<bool>> Register(string username, string password);
        public Task<ServiceResponse<bool>> ChangePassword(string username, string oldPassword, string newPassword);


        public Task Logout(string username);
    }
}
