namespace StruttonTechnologies.Core.ToolKit.Exceptions.Dtos
{
    public sealed record ErrorDto
    {
        public required string Code { get; init; }

        public required string Message { get; init; }
    }
}
