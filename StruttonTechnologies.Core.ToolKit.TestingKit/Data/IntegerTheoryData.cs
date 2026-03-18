namespace StruttonTechnologies.Core.Toolkit.Testing.Data
{
    /// <summary>
    /// Provides reusable integer-based theory data sets for unit tests.
    /// </summary>
    public static class IntegerTheoryData
    {
        /// <summary>
        /// Gets a set of empty integer collections.
        /// </summary>
        public static TheoryData<IEnumerable<int>> EmptyCollections =>
            new()
            {
                Enumerable.Empty<int>(),
                Array.Empty<int>(),
                new List<int>(),
            };

        /// <summary>
        /// Gets a set of populated integer collections.
        /// </summary>
        public static TheoryData<IEnumerable<int>> PopulatedCollections =>
            new()
            {
                new[] { 1 },
                new[] { 1, 2, 3 },
                new List<int> { 1, 2, 3, 4 },
                Enumerable.Range(1, 5),
            };

        /// <summary>
        /// Gets a set of integer values useful for numeric boundary testing.
        /// </summary>
        public static TheoryData<int> BoundaryValues =>
            [
                int.MinValue,
                -1,
                0,
                1,
                int.MaxValue,
            ];

        /// <summary>
        /// Gets positive integer values.
        /// </summary>
        public static TheoryData<int> PositiveValues =>
            [
                1,
                2,
                10,
                100,
                int.MaxValue,
            ];

        /// <summary>
        /// Gets negative integer values.
        /// </summary>
        public static TheoryData<int> NegativeValues =>
            [
                -1,
                -2,
                -10,
                -100,
                int.MinValue,
            ];
    }
}
