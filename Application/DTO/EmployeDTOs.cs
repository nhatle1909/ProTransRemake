﻿using Domain.Entities;

namespace Application.DTO
{
    public class QueryEmployeeDTO
    {
        public required Guid Id { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public required DateTime Dob { get; set; }
        public required string Gender { get; set; }

        public required string EmployeeCode { get; set; }
        public required string Role { get; set; }
        public required Agency Agency { get; set; }
    }
    public class CommandEmployeeDTO
    {
        public required string EmployeeCode { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }

        public required string Role { get; set; }
        public required DateTime Dob { get; set; }
        public required string Gender { get; set; }
        public required Guid AgencyId { get; set; }
    }
}
