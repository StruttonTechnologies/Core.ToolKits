using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using System.Linq.Expressions;

namespace StruttonTechnologies.Core.ToolKit.Pagination.EF.Extensions
{
  /// <summary>
  /// Provides extension methods for creating paged results with Entity Framework tracking behavior control and projection support.
  /// </summary>
  public static class QueryablePagingProjectionTrackingEntityFrameworkExtensions
  {
    /// <summary>
    /// Converts the queryable to a paged result without change tracking and applies a projection.
    /// </summary>
    /// <typeparam name="TSource">The type of the source entity.</typeparam>
    /// <typeparam name="TResult">The type of the projected result.</typeparam>
    /// <param name="source">The queryable source.</param>
    /// <param name="request">The paging request containing page number and page size.</param>
    /// <param name="selector">The projection expression to transform source entities to result type.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation that returns a paged result.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static Task<PagedResult<TResult>> ToPagedResultWithoutTrackingAsync<TSource, TResult>(
        this IQueryable<TSource> source,
        PagedRequest request,
        Expression<Func<TSource, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TSource : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsNoTracking()
          .ToPagedResultAsync(request, selector, cancellationToken);
    }

    /// <summary>
    /// Converts the queryable to a paged result with change tracking enabled and applies a projection.
    /// </summary>
    /// <typeparam name="TSource">The type of the source entity.</typeparam>
    /// <typeparam name="TResult">The type of the projected result.</typeparam>
    /// <param name="source">The queryable source.</param>
    /// <param name="request">The paging request containing page number and page size.</param>
    /// <param name="selector">The projection expression to transform source entities to result type.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation that returns a paged result.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static Task<PagedResult<TResult>> ToPagedResultWithTrackingAsync<TSource, TResult>(
        this IQueryable<TSource> source,
        PagedRequest request,
        Expression<Func<TSource, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TSource : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsTracking()
          .ToPagedResultAsync(request, selector, cancellationToken);
    }

    /// <summary>
    /// Converts the queryable to a paged result without change tracking but with identity resolution enabled and applies a projection.
    /// </summary>
    /// <typeparam name="TSource">The type of the source entity.</typeparam>
    /// <typeparam name="TResult">The type of the projected result.</typeparam>
    /// <param name="source">The queryable source.</param>
    /// <param name="request">The paging request containing page number and page size.</param>
    /// <param name="selector">The projection expression to transform source entities to result type.</param>
    /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A task representing the asynchronous operation that returns a paged result.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="source"/> is null.</exception>
    public static Task<PagedResult<TResult>> ToPagedResultWithIdentityResolutionAsync<TSource, TResult>(
        this IQueryable<TSource> source,
        PagedRequest request,
        Expression<Func<TSource, TResult>> selector,
        CancellationToken cancellationToken = default)
        where TSource : class
    {
      ArgumentNullException.ThrowIfNull(source);

      return source
          .AsNoTrackingWithIdentityResolution()
          .ToPagedResultAsync(request, selector, cancellationToken);
    }
  }
}
