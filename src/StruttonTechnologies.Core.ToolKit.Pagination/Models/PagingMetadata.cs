namespace StruttonTechnologies.Core.ToolKit.Pagination
{
    /// <summary>
    /// Represents metadata for paginated data, including page numbers, sizes, and navigation information.
    /// </summary>
    public sealed record PagingMetadata
    {
        /// <summary>
        /// Gets the current page number (1-based).
        /// </summary>
        public required int PageNumber { get; init; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        public required int PageSize { get; init; }

        /// <summary>
        /// Gets the total number of items across all pages.
        /// </summary>
        public required int TotalItemCount { get; init; }

        /// <summary>
        /// Gets the total number of pages based on the page size and total item count.
        /// Returns 0 if <see cref="PageSize"/> is less than or equal to 0.
        /// </summary>
        public int TotalPageCount =>
            PageSize <= 0
                ? 0
                : (int)Math.Ceiling(TotalItemCount / (double)PageSize);

        /// <summary>
        /// Gets a value indicating whether there is a previous page available.
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page available.
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPageCount;

        /// <summary>
        /// Gets the index of the first item on the current page (1-based).
        /// Returns 0 if there are no items.
        /// </summary>
        public int FirstItemIndex =>
            TotalItemCount == 0
                ? 0
                : ((PageNumber - 1) * PageSize) + 1;

        /// <summary>
        /// Gets the index of the last item on the current page (1-based).
        /// </summary>
        public int LastItemIndex =>
            Math.Min(PageNumber * PageSize, TotalItemCount);
    }
}
