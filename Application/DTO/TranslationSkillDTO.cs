namespace Application.DTO
{
    public class QueryTranslationSkillDTO
    {
        public string? CertificateUrl { get; set; }
        public required string Language { get; set; }
    }
    public class CommandTranslationSkillDTO
    {
        public string? CertificateUrl { get; set; }
        public required string Language { get; set; }

        public Guid TranslatorId { get; set; }
    }
}
