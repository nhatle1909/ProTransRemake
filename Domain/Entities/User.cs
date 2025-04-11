namespace Domain.Entities
{
    public class User : BaseAccount
    {
        public bool IsVerified { get; set; }
        //public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }

    }
}
