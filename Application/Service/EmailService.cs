using Application.Common;
using Application.Interface;
using Application.Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class EmailService : IEmailService
    {
        private readonly ISendMailOTPRepository _sendMailOTPRepository;
        public EmailService(ISendMailOTPRepository sendMailOTPRepository)
        {
            _sendMailOTPRepository = sendMailOTPRepository;
        }
        public async Task<ServiceResponse<bool>> SendOTPMail(string email)
        {
            ServiceResponse<bool> result = new();
            try
            {
                var OTP = await _sendMailOTPRepository.OTPGenerator(email);
                var command = await _sendMailOTPRepository.SendEmailAsync(email, OTP);
                if (command)
                {
                    result.Response(true, true, "Send OTP mail successfully");
                }
                else result.Response(false, false, "Send OTP mail failed");
            }
            catch (Exception ex)
            {
                result.TryCatchResponse(ex);
            }
            return result;
        }

        public async Task<ServiceResponse<bool>> VerifyOTP(string email, string OTP)
        {
            ServiceResponse<bool> result = new();
            try
            {
                var command = await _sendMailOTPRepository.VerifyOTP(email, OTP);
                if (command)
                {
                    result.Response(true, true, "Verify OTP successfully");
                }
                else result.Response(false, false, "Verify OTP failed");
            }
            catch (Exception ex)
            {
                result.TryCatchResponse(ex);
            }
            return result;
        }
    }
}
