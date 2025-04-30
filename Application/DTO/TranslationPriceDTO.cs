namespace Application.DTO
{
    public class QueryTranslationPriceDTO
    {
        public Guid Id { get; set; }
        public string RootLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class CommandTranslationPriceDTO
    {
        public string RootLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public decimal Price { get; set; }
    }
}