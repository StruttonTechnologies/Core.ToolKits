namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.Collection
{
    /// <summary>
    /// Contains test scenarios for <c>Guard.IsEmpty</c>.
    /// </summary>
    public class IsEmptyTests
    {
        [Fact]
        public void IsEmpty_WhenCollectionIsNull_ReturnsMatched()
        {
            IEnumerable<int>? value = null;

            bool matched = Guard.IsEmpty(value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(EnumerableTheoryData.EmptyIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void IsEmpty_WhenCollectionIsEmpty_ReturnsMatched(IEnumerable<int> value)
        {
            bool matched = Guard.IsEmpty(value).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(EnumerableTheoryData.PopulatedIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void IsEmpty_WhenCollectionHasItems_ReturnsNotMatched(IEnumerable<int> value)
        {
            bool matched = Guard.IsEmpty(value).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEmpty_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            EnumerableTestObject<int>? value = null;

            bool matched = Guard.IsEmpty(value, x => x.Items).Return(true, _ => false);

            Assert.True(matched);
        }

        [Fact]
        public void IsEmpty_WithSelector_WhenSelectedCollectionIsNull_ReturnsMatched()
        {
            var value = new EnumerableTestObject<int> { Items = null };

            bool matched = Guard.IsEmpty(value, x => x.Items).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(EnumerableTheoryData.EmptyIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void IsEmpty_WithSelector_WhenSelectedCollectionIsEmpty_ReturnsMatched(IEnumerable<int> items)
        {
            var value = new EnumerableTestObject<int> { Items = items };

            bool matched = Guard.IsEmpty(value, x => x.Items).Return(true, _ => false);

            Assert.True(matched);
        }

        [Theory]
        [MemberData(nameof(EnumerableTheoryData.PopulatedIntegers), MemberType = typeof(EnumerableTheoryData))]
        public void IsEmpty_WithSelector_WhenSelectedCollectionHasItems_ReturnsNotMatched(IEnumerable<int> items)
        {
            var value = new EnumerableTestObject<int> { Items = items };

            bool matched = Guard.IsEmpty(value, x => x.Items).Return(true, _ => false);

            Assert.False(matched);
        }

        [Fact]
        public void IsEmpty_WithSelector_WhenSelectorIsNull_ThrowsArgumentNullException()
        {
            var value = new EnumerableTestObject<int> { Items = [1] };
            Func<EnumerableTestObject<int>, IEnumerable<int>?> selector = null!;

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.IsEmpty(value, selector));

            Assert.Equal("selector", exception.ParamName);
        }
    }
}
