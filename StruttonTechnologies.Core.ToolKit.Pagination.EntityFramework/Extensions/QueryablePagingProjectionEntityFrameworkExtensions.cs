using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;
using System.Linq.Expressions;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EntityFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for paginating and projecting <see cref="IQueryable{T}"/> sequences
    /// asynchronously using Entity Framework Core.
    /// </summary>
    public static class QueryablePagingProjectionEntityFrameworkExtensions
    {
        /// <summary>
        /// Asynchronously converts a queryable sequence to a paged result with projection to a different type.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
        /// <typeparam name="TResult">The type of the elements in the projected result.</typeparam>
        /// <param name="source">The queryable sequence to paginate and project.</param>
        /// <param name="request">The paging request containing page number and page size information.</param>
        /// <param name="selector">An expression that projects each source element to a result element.</param>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a <see cref="PagedResult{TResult}"/> with the projected items for the requested page.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="source"/>, <paramref name="request"/>, or <paramref name="selector"/> is null.
        /// </exception>
        public static async Task<PagedResult<TResult>> ToPagedResultAsync<TSource, TResult>(
            this IQueryable<TSource> source,
            PagedRequest request,
            Expression<Func<TSource, TResult>> selector,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(request);
            ArgumentNullException.ThrowIfNull(selector);

            PagedRequest normalizedRequest = PageValidation.Normalize(request);

            int totalItemCount = await EntityFrameworkQueryableExtensions
                .CountAsync(source, cancellationToken)
                .ConfigureAwait(false);

            TResult[] pageItems = await EntityFrameworkQueryableExtensions
                .ToArrayAsync(
                    source
                        .Skip(normalizedRequest.Skip)
                        .Take(normalizedRequest.Take)
                        .Select(selector),
                    cancellationToken)
                .ConfigureAwait(false);

            return PagedResult<TResult>.Create(
                pageItems,
                normalizedRequest.PageNumber,
                normalizedRequest.PageSize,
                totalItemCount);
        }
    }
}
