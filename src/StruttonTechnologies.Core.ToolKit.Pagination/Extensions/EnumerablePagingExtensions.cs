using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKit.Pagination.Extensions
{
    /// <summary>
    /// Provides extension methods for paginating <see cref="IEnumerable{T}"/> sequences.
    /// </summary>
    public static class EnumerablePagingExtensions
    {
        /// <summary>
        /// Converts an enumerable sequence into a paged result.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the sequence.</typeparam>
        /// <param name="source">The source enumerable to paginate.</param>
        /// <param name="request">The paging request containing page number and page size.</param>
        /// <returns>
        /// A <see cref="PagedResult{TItem}"/> containing the requested page of items,
        /// along with pagination metadata.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="source"/> or <paramref name="request"/> is null.
        /// </exception>
        /// <remarks>
        /// This method materializes the entire source sequence into memory before paginating.
        /// For large datasets, consider using a database-level pagination approach instead.
        /// </remarks>
        public static PagedResult<TItem> ToPagedResult<TItem>(
            this IEnumerable<TItem> source,
            PagedRequest request)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(request);

            PagedRequest normalizedRequest = PageValidation.Normalize(request);

            IReadOnlyCollection<TItem> allItems = source.ToArray();

            IReadOnlyCollection<TItem> pageItems = allItems
                .Skip(normalizedRequest.Skip)
                .Take(normalizedRequest.Take)
                .ToArray();

            return PagedResult<TItem>.Create(
                pageItems,
                normalizedRequest.PageNumber,
                normalizedRequest.PageSize,
                allItems.Count);
        }
    }
}
