using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EF.Extensions
{
  /// <summary>
  /// Provides Entity Framework-specific extension methods for applying pagination to queryable collections.
  /// </summary>
  public static class QueryablePagingApplyEntityFrameworkExtensions
  {
    /// <summary>
    /// Applies pagination to the queryable source by skipping and taking the specified number of items.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the queryable source.</typeparam>
    /// <param name="source">The queryable source to apply pagination to.</param>
    /// <param name="request">The paged request containing skip and take values.</param>
    /// <returns>A queryable with pagination applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> or <paramref name="request"/> is null.</exception>
    public static IQueryable<TItem> ApplyPaging<TItem>(
        this IQueryable<TItem> source,
        PagedRequest request)
    {
      ArgumentNullException.ThrowIfNull(source);
      ArgumentNullException.ThrowIfNull(request);

      PagedRequest normalizedRequest = PageValidation.Normalize(request);

      return source
          .Skip(normalizedRequest.Skip)
          .Take(normalizedRequest.Take);
    }

    /// <summary>
    /// Applies pagination to the queryable source without change tracking.
    /// Entities returned by the query will not be tracked by the DbContext.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the queryable source.</typeparam>
    /// <param name="source">The queryable source to apply pagination to.</param>
    /// <param name="request">The paged request containing skip and take values.</param>
    /// <returns>A queryable with pagination and no tracking applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static IQueryable<TItem> ApplyPagingWithoutTracking<TItem>(
        this IQueryable<TItem> source,
        PagedRequest request)
        where TItem : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsNoTracking()
          .ApplyPaging(request);
    }

    /// <summary>
    /// Applies pagination to the queryable source with change tracking enabled.
    /// Entities returned by the query will be tracked by the DbContext.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the queryable source.</typeparam>
    /// <param name="source">The queryable source to apply pagination to.</param>
    /// <param name="request">The paged request containing skip and take values.</param>
    /// <returns>A queryable with pagination and tracking applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static IQueryable<TItem> ApplyPagingWithTracking<TItem>(
        this IQueryable<TItem> source,
        PagedRequest request)
        where TItem : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsTracking()
          .ApplyPaging(request);
    }

    /// <summary>
    /// Applies pagination to the queryable source without change tracking but with identity resolution.
    /// Entities returned by the query will not be tracked, but duplicate entity instances will be resolved to the same instance.
    /// </summary>
    /// <typeparam name="TItem">The type of items in the queryable source.</typeparam>
    /// <param name="source">The queryable source to apply pagination to.</param>
    /// <param name="request">The paged request containing skip and take values.</param>
    /// <returns>A queryable with pagination and identity resolution applied.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static IQueryable<TItem> ApplyPagingWithIdentityResolution<TItem>(
        this IQueryable<TItem> source,
        PagedRequest request)
        where TItem : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsNoTrackingWithIdentityResolution()
          .ApplyPaging(request);
    }
  }
}
