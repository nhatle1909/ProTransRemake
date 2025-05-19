namespace Application.DTO
{
    public class SearchDTO
    {
        public string[] searchParams { get; set; }
        public string[] searchValue { get; set; }
        public string? includeProperties { get; set; }
        public string? sortField { get; set; }
        public int? pageSize { get; set; }
        public int? skip { get; set; }
    }
    public class CountDTO
    {
        public string[]? searchParams { get; set; }
        public string[]? searchValue { get; set; }

        public int? pageSize { get; set; }
    }
}