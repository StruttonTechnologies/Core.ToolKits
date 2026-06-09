using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EntityFramework.Extensions;

/// <summary>
/// Provides extension methods for paging IQueryable sequences using Entity Framework.
/// </summary>
public static class QueryablePagingEntityFrameworkExtensions
{
    /// <summary>
    /// Converts an IQueryable sequence to a paged result asynchronously using Entity Framework.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the queryable sequence.</typeparam>
    /// <param name="source">The queryable sequence to page.</param>
    /// <param name="request">The paging request containing page number and page size.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a paged result with the requested page of items and total count.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="request"/> is null.</exception>
    /// <example>
    /// <code>
    /// var request = new PagedRequest { PageNumber = 1, PageSize = 10 };
    /// var result = await dbContext.Users.ToPagedResultAsync(request);
    /// </code>
    /// </example>
    public static async Task<PagedResult<TItem>> ToPagedResultAsync<TItem>(
        this IQueryable<TItem> source,
        PagedRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(request);

        PagedRequest normalizedRequest = PageValidation.Normalize(request);

        int totalItemCount = await EntityFrameworkQueryableExtensions
            .CountAsync(source, cancellationToken)
            .ConfigureAwait(false);

        TItem[] pageItems = await EntityFrameworkQueryableExtensions
            .ToArrayAsync(
                source
                    .Skip(normalizedRequest.Skip)
                    .Take(normalizedRequest.Take),
                cancellationToken)
            .ConfigureAwait(false);

        return PagedResult<TItem>.Create(
            pageItems,
            normalizedRequest.PageNumber,
            normalizedRequest.PageSize,
            totalItemCount);
    }
}