namespace Application.DTO
{
    public class QueryAgencyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class CommandAgencyDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
