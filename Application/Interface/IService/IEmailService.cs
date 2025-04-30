using Application.Common;

namespace Application.Interface.IService
{
    public interface IEmailService
    {
        Task<ServiceResponse<bool>> SendOTPMail(string email);
        Task<ServiceResponse<bool>> VerifyOTP(string email, string OTP);
    }
}
