namespace Domain.Entities
{
    public class Notarization : BaseEntity
    {
        //Field
        public required string Name { get; set; }
        public decimal Price { get; set; }
        //Relationship
        public virtual ICollection<Document>? Documents { get; set; }
    }
}
