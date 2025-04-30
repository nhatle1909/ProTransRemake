namespace Application.DTO
{
    public class QueryDistanceDTO
    {

    }
    public class CommandDistanceDTO
    {
        public required decimal Value { get; set; }
        public required Guid RootAgencyId { get; set; }
        public required Guid TargetAgencyId { get; set; }
    }
}
