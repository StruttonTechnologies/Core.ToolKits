using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKit.Pagination.Extensions
{
    /// <summary>
    /// Provides extension methods for paginating <see cref="IQueryable{T}"/> sequences.
    /// </summary>
    public static class QueryablePagingExtensions
    {
        /// <summary>
        /// Converts an <see cref="IQueryable{T}"/> sequence into a paginated result.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the queryable sequence.</typeparam>
        /// <param name="source">The queryable sequence to paginate.</param>
        /// <param name="request">The paging request containing page number and page size.</param>
        /// <returns>
        /// A <see cref="PagedResult{TItem}"/> containing the requested page of items and metadata.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="source"/> or <paramref name="request"/> is null.
        /// </exception>
        public static PagedResult<TItem> ToPagedResult<TItem>(
            this IQueryable<TItem> source,
            PagedRequest request)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(request);

            PagedRequest normalizedRequest = PageValidation.Normalize(request);

            int totalItemCount = source.Count();

            IReadOnlyCollection<TItem> pageItems = source
                .Skip(normalizedRequest.Skip)
                .Take(normalizedRequest.Take)
                .ToArray();

            return PagedResult<TItem>.Create(
                pageItems,
                normalizedRequest.PageNumber,
                normalizedRequest.PageSize,
                totalItemCount);
        }
    }
}
