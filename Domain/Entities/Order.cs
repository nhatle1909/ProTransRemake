namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        //Field
        public required string OrderCode {  get; set; }
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Address { get; set; }
        public bool ShipRequest { get; set; }
        public bool PickUpRequest { get; set; }
        public required DateTime Deadline { get; set; }
        public required decimal TotalPrice { get; set; }
        public required string Status { get; set; }
        public required string Reason { get; set; }

        //Foreignkey
        public Guid? AgencyId { get; set; }
      
        //Relationship
        public virtual Agency? Agency { get; set; }
        
        public virtual ICollection<Document>? Documents { get; set; }
        public virtual Transaction? Transaction { get; set; }
        public virtual AssignmentShipping? AssignmentShippings { get; set; }
    }
}
