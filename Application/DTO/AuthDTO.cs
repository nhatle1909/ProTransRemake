using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AuthDTO
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }
    }
    public class RegisterDTO
    {
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
