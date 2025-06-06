namespace Application.DTO
{
    public class QueryDistanceDTO
    {
        public required Guid Id { get; set; }
        public required string RootAgencyAddress { get; set; }
        public required string TargetAgencyAddress { get; set; }
        public required decimal Value { get; set; }
    }
    public class CommandDistanceDTO
    {
        public required decimal Value { get; set; }
        public required Guid RootAgencyId { get; set; }
        public required Guid TargetAgencyId { get; set; }
    }
}
