namespace StruttonTechnologies.Core.ToolKit.Guards
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided collection is not <see langword="null"/> and contains at least one item.
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the collection.
        /// </typeparam>
        /// <param name="value">
        /// The collection to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the collection contains at least one item.
        /// </returns>
        public static GuardCondition<IEnumerable<T>> HasItems<T>(IEnumerable<T>? value)
        {
            return new GuardCondition<IEnumerable<T>>(value, value is not null && value.Any());
        }

        /// <summary>
        /// Evaluates whether the selected collection from the provided object is not <see langword="null"/> and contains at least one item.
        /// The guard does not match when the provided object itself is <see langword="null"/>.
        /// </summary>
        /// <typeparam name="TObject">
        /// The type of object being evaluated.
        /// </typeparam>
        /// <typeparam name="TItem">
        /// The type of items in the collection.
        /// </typeparam>
        /// <param name="value">
        /// The object to evaluate.
        /// </param>
        /// <param name="selector">
        /// The selector used to retrieve the collection.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the selected collection contains at least one item.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> HasItems<TObject, TItem>(TObject? value, Func<TObject, IEnumerable<TItem>?> selector)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, false);
            }

            IEnumerable<TItem>? selectedValue = selector(value);
            return new GuardCondition<TObject>(value, selectedValue is not null && selectedValue.Any());
        }
    }
}
