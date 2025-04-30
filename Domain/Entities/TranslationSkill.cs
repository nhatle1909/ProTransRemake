namespace Domain.Entities
{
    public class TranslationSkill : BaseEntity
    {
        //Field
        public string? CertificateUrl { get; set; }
        public required string Language { get; set; }
        //Foreignkey
        public Guid TranslatorId { get; set; }
        //Relationship
        public virtual Employee? Translator { get; set; }

    }
}
