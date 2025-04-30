namespace Domain.Entities
{
    public class BaseAccount : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }


        //public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
