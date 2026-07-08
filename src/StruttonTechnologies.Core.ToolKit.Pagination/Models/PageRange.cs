namespace StruttonTechnologies.Core.ToolKit.Pagination.Models
{
    public sealed record PageRange
    {
        public required int Skip { get; init; }

        public required int Take { get; init; }
    }
}
