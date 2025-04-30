namespace Domain.Entities
{
    public class Employee : BaseAccount
    {
        public required string EmployeeCode { get; set; }
        public string Role { get; set; }
        public required Guid AgencyId { get; set; }

        public virtual required Agency Agency { get; set; }
        public virtual ICollection<TranslationSkill>? TranslationSkills { get; set; }
        public virtual ICollection<Feedback>? Feedbacks { get; set; }
        public virtual ICollection<AssignmentShipping>? AssignmentShippings { get; set; }
        public virtual ICollection<AssignmentTranslation>? AssignmentTranslations { get; set; }
        public virtual ICollection<AssignmentNotarization>? AssignmentNotarizations { get; set; }
    }
}
