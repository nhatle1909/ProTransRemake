using Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;
        public EmailController(IEmailService service)
        {
            _service = service;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] string email)
        {
            var result = await _service.SendOTPMail(email);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpPost("send-verify")]
        public async Task<IActionResult> VerifyOTP([FromBody] string email,string otp)
        {
            var result = await _service.VerifyOTP(email, otp);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
