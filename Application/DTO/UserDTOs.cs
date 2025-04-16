using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class QueryUserDTO
    {
        public required Guid Id { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
      
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
    }
    public class CommandUserDTO
    {

    }
}
