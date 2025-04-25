using Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IService
{
    public interface IEmailService
    {
        Task<ServiceResponse<bool>> SendOTPMail(string email);
        Task<ServiceResponse<bool>> VerifyOTP(string email, string OTP);
    }
}
