namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided string consists only of white-space characters.
        /// </summary>
        /// <param name="value">
        /// The string value to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the value consists only of white-space characters.
        /// </returns>
        /// <remarks>
        /// A <see langword="null"/> or empty string does not match this condition.
        /// </remarks>
        public static GuardCondition<string> IsWhiteSpace(string? value)
        {
            return new GuardCondition<string>(value, value is not null && value.Length > 0 && string.IsNullOrWhiteSpace(value));
        }

        /// <summary>
        /// Evaluates whether the selected string value from the provided object consists only of white-space characters.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the string value.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected string value consists only of white-space characters.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        /// <remarks>
        /// A <see langword="null"/> or empty selected string does not match this condition.
        /// </remarks>
        public static GuardCondition<T> IsWhiteSpace<T>(T? value, Func<T, string?> selector)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<T>(value, false);
            }

            string? selectedValue = selector(value);
            return new GuardCondition<T>(value, selectedValue is not null && selectedValue.Length > 0 && string.IsNullOrWhiteSpace(selectedValue));
        }
    }

    internal class IsWhiteSpace
    {
    }
}
