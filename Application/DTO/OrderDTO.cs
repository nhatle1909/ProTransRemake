using Domain.Enums;

namespace Application.DTO
{
    public class QueryOrderDTO
    {
        public Guid Id { get; set; }
        public required string OrderCode { get; set; }

        public bool ShipRequest { get; set; }
        public bool PickUpRequest { get; set; }
        public required DateTime Deadline { get; set; }
        public required decimal TotalPrice { get; set; }
        public required OrderStatus Status { get; set; }
        public required string Reason { get; set; }

        //Foreignkey
        public Guid? AgencyId { get; set; }
        public Guid UserId { get; set; }
    }
    public class CommandOrderDTO
    {
        public required string OrderCode { get; set; }

        public bool ShipRequest { get; set; }
        public bool PickUpRequest { get; set; }
        public required DateTime Deadline { get; set; }
        public required decimal TotalPrice { get; set; }
        public required OrderStatus Status { get; set; }
        public required string Reason { get; set; }

        //Foreignkey
        public Guid? AgencyId { get; set; }
        public Guid UserId { get; set; }
    }
}
