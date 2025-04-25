using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
