using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Pagination.EF.Extensions;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EF.Extensions
{
    /// <summary>
    /// Provides extension methods for applying Entity Framework tracking behaviors to paginated queries.
    /// </summary>
    public static class QueryablePagingTrackingEntityFrameworkExtensions
    {
        /// <summary>
        /// Converts the queryable to a paged result without Entity Framework change tracking.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the query.</typeparam>
        /// <param name="source">The queryable source.</param>
        /// <param name="request">The paging request parameters.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paged result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static Task<PagedResult<TItem>> ToPagedResultWithoutTrackingAsync<TItem>(
            this IQueryable<TItem> source,
            PagedRequest request,
            CancellationToken cancellationToken = default)
            where TItem : class
        {
            ArgumentNullException.ThrowIfNull(source);

            return source
                .AsNoTracking()
                .ToPagedResultAsync(request, cancellationToken);
        }

        /// <summary>
        /// Converts the queryable to a paged result without Entity Framework change tracking, using identity resolution.
        /// This allows multiple instances of the same entity to be resolved to a single instance.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the query.</typeparam>
        /// <param name="source">The queryable source.</param>
        /// <param name="request">The paging request parameters.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paged result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static Task<PagedResult<TItem>> ToPagedResultWithIdentityResolutionAsync<TItem>(
            this IQueryable<TItem> source,
            PagedRequest request,
            CancellationToken cancellationToken = default)
            where TItem : class
        {
            ArgumentNullException.ThrowIfNull(source);

            return source
                .AsNoTrackingWithIdentityResolution()
                .ToPagedResultAsync(request, cancellationToken);
        }

        /// <summary>
        /// Converts the queryable to a paged result with Entity Framework change tracking enabled.
        /// Changes to the returned entities will be tracked by the DbContext.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the query.</typeparam>
        /// <param name="source">The queryable source.</param>
        /// <param name="request">The paging request parameters.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous operation, containing the paged result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
        public static Task<PagedResult<TItem>> ToPagedResultWithTrackingAsync<TItem>(
            this IQueryable<TItem> source,
            PagedRequest request,
            CancellationToken cancellationToken = default)
            where TItem : class
        {
            ArgumentNullException.ThrowIfNull(source);

            return source
                .AsTracking()
                .ToPagedResultAsync(request, cancellationToken);
        }
    }
}
