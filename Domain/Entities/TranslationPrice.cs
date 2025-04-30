namespace Domain.Entities
{
    public class TranslationPrice : BaseEntity
    {
        public required string RootLanguage { get; set; }
        public required string TargetLanguage { get; set; }
        public required decimal Price { get; set; }
    }
}
