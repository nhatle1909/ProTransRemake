namespace Application.DTO
{
    public class QueryUserDTO
    {
        public required Guid Id { get; set; }

        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }

        public required DateTime Dob { get; set; }
        public required string Gender { get; set; }
    }
    public class CommandUserDTO
    {
        public string? Password { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }

        public required DateTime Dob { get; set; }
        public required string Gender { get; set; }
    }
}
