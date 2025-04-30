using Application.Common;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Service
{
    public class UserAuthService : IAuthService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly JWT _jwt;
        public UserAuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _jwt = new JWT(_configuration);
        }

        public async Task<ServiceResponse<bool>> ChangePassword(string email, string oldPassword, string newPassword)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var query = await _unitOfWork.GetRepository<User>().GetByFilterAsync(user => user.Email.Equals(email));
                var account = query.Item1.FirstOrDefault();
                if (account == null)
                {
                    response.Response(false, false, "Account not found");
                    return response;
                }
                if (account.Password.Equals(oldPassword) == false)
                {
                    response.Response(false, false, "Old password is incorrect");
                    return response;
                }
                account.Password = newPassword;
                var result = await _unitOfWork.GetRepository<User>().UpdateItemAsync(account.Id, account);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<(bool, string)>> Login(string username, string password)
        {
            ServiceResponse<(bool, string)> response = new();
            try
            {
                var query = await _unitOfWork.GetRepository<User>().GetByFilterAsync(user => user.Email.Equals(username));
                var result = query.Item1.FirstOrDefault();
                if (result == null || result.Password != password)
                {
                    response.Response((false, string.Empty), false, "Login failed");
                    return response;
                }
                var token = _jwt.GenerateJwtToken(result.Id.ToString(), "User", result.FullName, result.Email);
                response.Response((true, token), true, "Login successful");
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public Task Logout(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> Register(string username, string password)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var query = _unitOfWork.GetRepository<User>().GetByFilterAsync(user => user.Email.Equals(username));
                if (query.Result.Item1.Any())
                {
                    response.Response(false, false, "User already exists");
                    return response;
                }
                var user = new User
                {
                    Email = username,
                    Password = password,
                };
                var result = await _unitOfWork.GetRepository<User>().AddItemAsync(user);
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
