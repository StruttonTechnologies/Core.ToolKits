using StruttonTechnologies.Core.ToolKit.Pagination.Models;

namespace StruttonTechnologies.Core.ToolKit.Pagination.Validation
{
    /// <summary>
    /// Provides validation and normalization methods for paged requests.
    /// </summary>
    public static class PageValidation
    {
        /// <summary>
        /// Normalizes a paged request by ensuring page number and page size are within valid ranges.
        /// Invalid values are replaced with default values, and page size is capped at the maximum allowed.
        /// </summary>
        /// <param name="request">The paged request to normalize.</param>
        /// <returns>A normalized paged request with valid page number and page size values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
        public static PagedRequest Normalize(PagedRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            int pageNumber = request.PageNumber < 1
                ? PagedRequest.DefaultPageNumber
                : request.PageNumber;

            int pageSize = request.PageSize < 1
                ? PagedRequest.DefaultPageSize
                : request.PageSize;

            pageSize = Math.Min(pageSize, PagedRequest.MaxPageSize);

            return request with
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        /// <summary>
        /// Validates a paged request and throws an exception if any validation rules are violated.
        /// </summary>
        /// <param name="request">The paged request to validate.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when page number is less than 1, page size is less than 1, or page size exceeds the maximum allowed.
        /// </exception>
        public static void ThrowIfInvalid(PagedRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            if (request.PageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(request),
                    request.PageNumber,
                    "Page number must be greater than or equal to 1.");
            }

            if (request.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(request),
                    request.PageSize,
                    "Page size must be greater than or equal to 1.");
            }

            if (request.PageSize > PagedRequest.MaxPageSize)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(request),
                    request.PageSize,
                    $"Page size cannot exceed {PagedRequest.MaxPageSize}.");
            }
        }
    }
}
