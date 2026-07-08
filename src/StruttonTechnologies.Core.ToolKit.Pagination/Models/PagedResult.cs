namespace StruttonTechnologies.Core.ToolKit.Pagination.Models
{
    /// <summary>
    /// Represents a paginated collection of items along with metadata describing the pagination state.
    /// </summary>
    /// <typeparam name="TItem">The type of items contained in the paged result.</typeparam>
    public sealed record PagedResult<TItem>
    {
        /// <summary>
        /// Gets the collection of items for the current page.
        /// </summary>
        public required IReadOnlyCollection<TItem> Items { get; init; }

        /// <summary>
        /// Gets the metadata describing the pagination state, including page number, page size, and total item count.
        /// </summary>
        public required PagingMetadata Metadata { get; init; }

        /// <summary>
        /// Creates an empty paged result with no items.
        /// </summary>
        /// <param name="pageNumber">The page number. Defaults to <see cref="PagedRequest.DefaultPageNumber"/>.</param>
        /// <param name="pageSize">The page size. Defaults to <see cref="PagedRequest.DefaultPageSize"/>.</param>
        /// <returns>A <see cref="PagedResult{TItem}"/> with an empty item collection and total count of zero.</returns>
        public static PagedResult<TItem> Empty(
            int pageNumber = PagedRequest.DefaultPageNumber,
            int pageSize = PagedRequest.DefaultPageSize)
        {
            return new PagedResult<TItem>
            {
                Items = Array.Empty<TItem>(),
                Metadata = new PagingMetadata
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItemCount = 0
                }
            };
        }

        /// <summary>
        /// Creates a paged result with the specified items and pagination metadata.
        /// </summary>
        /// <param name="items">The collection of items for the current page.</param>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <param name="totalItemCount">The total number of items across all pages.</param>
        /// <returns>A <see cref="PagedResult{TItem}"/> containing the provided items and metadata.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="items"/> is null.</exception>
        public static PagedResult<TItem> Create(
            IReadOnlyCollection<TItem> items,
            int pageNumber,
            int pageSize,
            int totalItemCount)
        {
            ArgumentNullException.ThrowIfNull(items);

            return new PagedResult<TItem>
            {
                Items = items,
                Metadata = new PagingMetadata
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalItemCount = totalItemCount
                }
            };
        }
    }
}
