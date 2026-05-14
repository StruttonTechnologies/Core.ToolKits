using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using System.Linq.Expressions;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EntityFramework.Extensions
{
    /// <summary>
    /// Provides extension methods for paging and ordering queryable collections with Entity Framework.
    /// </summary>
    public static class QueryablePagingOrderingEntityFrameworkExtensions
    {
        /// <summary>
        /// Orders the queryable collection in ascending order and returns a paged result asynchronously.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the collection.</typeparam>
        /// <typeparam name="TKey">The type of the key used for ordering.</typeparam>
        /// <param name="source">The queryable collection to order and page.</param>
        /// <param name="request">The paging request containing page number and page size.</param>
        /// <param name="orderBy">The expression used to order the collection.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns a paged result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="orderBy"/> is null.</exception>
        public static Task<PagedResult<TItem>> ToOrderedPagedResultAsync<TItem, TKey>(
            this IQueryable<TItem> source,
            PagedRequest request,
            Expression<Func<TItem, TKey>> orderBy,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(orderBy);

            return source
                .OrderBy(orderBy)
                .ToPagedResultAsync(request, cancellationToken);
        }

        /// <summary>
        /// Orders the queryable collection in descending order and returns a paged result asynchronously.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the collection.</typeparam>
        /// <typeparam name="TKey">The type of the key used for ordering.</typeparam>
        /// <param name="source">The queryable collection to order and page.</param>
        /// <param name="request">The paging request containing page number and page size.</param>
        /// <param name="orderBy">The expression used to order the collection.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns a paged result.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="orderBy"/> is null.</exception>
        public static Task<PagedResult<TItem>> ToOrderedPagedResultDescendingAsync<TItem, TKey>(
            this IQueryable<TItem> source,
            PagedRequest request,
            Expression<Func<TItem, TKey>> orderBy,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(orderBy);

            return source
                .OrderByDescending(orderBy)
                .ToPagedResultAsync(request, cancellationToken);
        }
    }
}
