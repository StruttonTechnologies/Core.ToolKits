using StruttonTechnologies.Core.ToolKit.Pagination.Models;
using StruttonTechnologies.Core.ToolKit.Pagination.Validation;

namespace StruttonTechnologies.Core.ToolKit.Pagination.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="PagedRequest"/> operations.
    /// </summary>
    public static class PagedRequestExtensions
    {
        /// <summary>
        /// Normalizes the paged request by applying default values and constraints.
        /// </summary>
        /// <param name="request">The paged request to normalize.</param>
        /// <returns>A normalized <see cref="PagedRequest"/> instance.</returns>
        public static PagedRequest Normalize(
            this PagedRequest request)
        {
            return PageValidation.Normalize(request);
        }

        /// <summary>
        /// Validates the paged request and throws an exception if it is invalid.
        /// </summary>
        /// <param name="request">The paged request to validate.</param>
        /// <exception cref="ArgumentException">Thrown when the request is invalid.</exception>
        public static void ThrowIfInvalid(
            this PagedRequest request)
        {
            PageValidation.ThrowIfInvalid(request);
        }

        /// <summary>
        /// Converts the paged request to a <see cref="PageRange"/> containing skip and take values.
        /// </summary>
        /// <param name="request">The paged request to convert.</param>
        /// <returns>A <see cref="PageRange"/> representing the normalized skip and take values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
        public static PageRange ToPageRange(
            this PagedRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            PagedRequest normalizedRequest = PageValidation.Normalize(request);

            return new PageRange
            {
                Skip = normalizedRequest.Skip,
                Take = normalizedRequest.Take
            };
        }
    }
}
