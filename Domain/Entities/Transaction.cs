﻿namespace Domain.Entities
{
    public class Transaction
    {
        //Field
        public Guid Id { get; set; }
        //Foreignkey
        public Guid? UserId { get; set; }
        public Guid OrderId { get; set; }
        //Relationship
        public virtual User? User { get; set; }
        public virtual Order? Order { get; set; }
    }
}