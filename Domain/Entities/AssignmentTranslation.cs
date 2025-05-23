﻿namespace Domain.Entities
{
    public class AssignmentTranslation : BaseEntity
    {
        //Field
        public DateTime Deadline { get; set; }
        public string Status { get; set; }
        public string? UrlPath { get; set; }
        //Foreignkey
        public Guid? TranslatorId { get; set; }
        public required List<Guid> DocumentId { get; set; }
        //Relationship
        public virtual Employee? Translator { get; set; }
        public virtual ICollection<Document>? Document { get; set; }
    }
}
