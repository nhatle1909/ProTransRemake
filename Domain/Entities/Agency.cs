namespace Domain.Entities
{
    public class Agency : BaseEntity
    {
        //Field
        public string Name { get; set; }
        public string Address { get; set; }
        //Relationship
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Distance>? RootAgencyDistance { get; set; }
        public virtual ICollection<Distance>? TargetAgencyDistance { get; set; }
    }
}
