using StruttonTechnologies.Core.ToolKit.Pagination.Models;

namespace StruttonTechnologies.Core.ToolKit.Pagination.Extensions
{
    /// <summary>
    /// Provides extension methods for mapping <see cref="PagedResult{TItem}"/> to different types.
    /// </summary>
    public static class PagedResultMappingExtensions
    {
        /// <summary>
        /// Maps the items in a <see cref="PagedResult{TItem}"/> to a new type using the specified selector function.
        /// </summary>
        /// <typeparam name="TItem">The type of items in the source paged result.</typeparam>
        /// <typeparam name="TResult">The type of items in the resulting paged result.</typeparam>
        /// <param name="result">The source paged result to map.</param>
        /// <param name="selector">A function to transform each item from <typeparamref name="TItem"/> to <typeparamref name="TResult"/>.</param>
        /// <returns>A new <see cref="PagedResult{TResult}"/> containing the mapped items and the original metadata.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="result"/> or <paramref name="selector"/> is null.</exception>
        public static PagedResult<TResult> Map<TItem, TResult>(
            this PagedResult<TItem> result,
            Func<TItem, TResult> selector)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(selector);

            return new PagedResult<TResult>
            {
                Items = result.Items.Select(selector).ToArray(),
                Metadata = result.Metadata
            };
        }
    }
}
