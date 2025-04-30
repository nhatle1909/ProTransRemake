namespace Domain.Entities
{
    public class Document : BaseEntity
    {
        //Field
        public required string DocumentCode { get; set; }
        public string? UrlPath { get; set; }
        public string? FileType { get; set; }
        public required string RootLanguage { get; set; }
        public required string TargetLanguage { get; set; }
        public int PageNumber { get; set; }
        public int NumberOfCopies { get; set; }
        public int NumberOfNotarizedCopies { get; set; }
        public required string Status { get; set; }

        //Foreignkey
        public Guid? DocumentTypeId { get; set; }
        public Guid? NotarizationId { get; set; }
        public Guid? AssignmentTranslationId { get; set; }
        public Guid? OrderId { get; set; }
        //Relationship

        public virtual Order? Order { get; set; }
        public virtual Notarization? Notarization { get; set; }
        public virtual DocumentType? DocumentType { get; set; }
        public virtual AssignmentTranslation? AssignmentTranslation { get; set; }
        //public virtual ImageShipping? ImageShipping { get; set; }
    }
}
