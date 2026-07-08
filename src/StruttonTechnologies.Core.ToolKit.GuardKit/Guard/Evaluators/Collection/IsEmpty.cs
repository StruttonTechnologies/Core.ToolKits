namespace StruttonTechnologies.Core.ToolKit.GuardKit
{
    public static partial class Guard
    {
        /// <summary>
        /// Evaluates whether the provided collection is <see langword="null"/> or contains no items.
        /// </summary>
        /// <typeparam name="T">
        /// The type of items in the collection.
        /// </typeparam>
        /// <param name="value">
        /// The collection to evaluate.
        /// </param>
        /// <returns>
        /// A guard continuation that can apply a behavior when the collection is <see langword="null"/> or empty.
        /// </returns>
        public static GuardCondition<IEnumerable<T>> IsEmpty<T>(IEnumerable<T>? value)
        {
            return new GuardCondition<IEnumerable<T>>(value, value is null || !value.Any());
        }

        /// <summary>
        /// Evaluates whether the selected collection from the provided object is <see langword="null"/> or contains no items.
        /// The guard also matches when the provided object itself is <see langword="null"/>.
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
        /// A guard continuation that can apply a behavior when the object is <see langword="null"/> or the selected
        /// collection is <see langword="null"/> or empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static GuardCondition<TObject> IsEmpty<TObject, TItem>(TObject? value, Func<TObject, IEnumerable<TItem>?> selector)
            where TObject : class
        {
            ArgumentNullException.ThrowIfNull(selector);

            if (value is null)
            {
                return new GuardCondition<TObject>(value, true);
            }

            IEnumerable<TItem>? selectedValue = selector(value);
            return new GuardCondition<TObject>(value, selectedValue is null || !selectedValue.Any());
        }
    }
}
