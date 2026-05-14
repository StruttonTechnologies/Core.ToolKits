namespace StruttonTechnologies.Core.ToolKit.Pagination.Models
{
    /// <summary>
    /// Represents a request for paginated data with sorting capabilities.
    /// </summary>
    public sealed record PagedRequest
    {
        /// <summary>
        /// The default page number when none is specified.
        /// </summary>
        public const int DefaultPageNumber = 1;

        /// <summary>
        /// The default number of items per page when none is specified.
        /// </summary>
        public const int DefaultPageSize = 25;

        /// <summary>
        /// The maximum number of items allowed per page.
        /// </summary>
        public const int MaxPageSize = 250;

        /// <summary>
        /// Gets the page number to retrieve. Defaults to 1.
        /// </summary>
        public int PageNumber { get; init; } = DefaultPageNumber;

        /// <summary>
        /// Gets the number of items per page. Defaults to 25.
        /// </summary>
        public int PageSize { get; init; } = DefaultPageSize;

        /// <summary>
        /// Gets the name of the property to sort by. If null, no sorting is applied.
        /// </summary>
        public string? SortBy { get; init; }

        /// <summary>
        /// Gets the direction to sort the results. Defaults to ascending.
        /// </summary>
        public SortDirection SortDirection { get; init; } = SortDirection.Ascending;

        /// <summary>
        /// Gets the number of items to skip based on the current page number and page size.
        /// </summary>
        public int Skip => (PageNumber - 1) * PageSize;

        /// <summary>
        /// Gets the number of items to take, equivalent to the page size.
        /// </summary>
        public int Take => PageSize;
    }
}
