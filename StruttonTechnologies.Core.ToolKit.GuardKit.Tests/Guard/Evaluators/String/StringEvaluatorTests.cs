namespace StruttonTechnologies.Core.ToolKit.GuardKit.Tests.Guard.Evaluators.String
{
    /// <summary>
    /// Contains test scenarios for string guard evaluators.
    /// </summary>
    public class StringEvaluatorTests
    {
        [Theory]
        [MemberData(nameof(StringTheoryData.Populated), MemberType = typeof(StringTheoryData))]
        public void HasValue_WhenStringHasContent_ReturnsMatched(string value)
        {
            Assert.True(GuardTest.HasValue(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.NullOrWhiteSpace), MemberType = typeof(StringTheoryData))]
        public void HasValue_WhenStringIsNullOrWhiteSpace_ReturnsNotMatched(string? value)
        {
            Assert.False(GuardTest.HasValue(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.Empty), MemberType = typeof(StringTheoryData))]
        public void IsEmpty_WhenStringIsEmpty_ReturnsMatched(string value)
        {
            Assert.True(GuardTest.IsEmpty(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.Populated), MemberType = typeof(StringTheoryData))]
        public void IsEmpty_WhenStringHasContent_ReturnsNotMatched(string value)
        {
            Assert.False(GuardTest.IsEmpty(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.NullOrWhiteSpace), MemberType = typeof(StringTheoryData))]
        public void IsNullOrWhiteSpace_WhenStringIsNullOrWhiteSpace_ReturnsMatched(string? value)
        {
            Assert.True(GuardTest.IsNullOrWhiteSpace(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.Populated), MemberType = typeof(StringTheoryData))]
        public void IsNullOrWhiteSpace_WhenStringHasContent_ReturnsNotMatched(string value)
        {
            Assert.False(GuardTest.IsNullOrWhiteSpace(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.NullOrWhiteSpace), MemberType = typeof(StringTheoryData))]
        public void IsNullOrEmpty_WhenStringIsNullOrEmpty_ReturnsExpectedResult(string? value)
        {
            bool expected = string.IsNullOrEmpty(value);
            Assert.Equal(expected, GuardTest.IsNullOrEmpty(value).Return(true, _ => false));
        }

        [Theory]
        [MemberData(nameof(StringTheoryData.WhiteSpace), MemberType = typeof(StringTheoryData))]
        public void IsWhiteSpace_WhenStringIsWhiteSpace_ReturnsMatched(string value)
        {
            Assert.True(GuardTest.IsWhiteSpace(value).Return(true, _ => false));
        }

        [Fact]
        public void IsWhiteSpace_WhenStringIsNull_ReturnsNotMatched()
        {
            string? value = null;
            Assert.False(GuardTest.IsWhiteSpace(value).Return(true, _ => false));
        }

        [Fact]
        public void IsWhiteSpace_WhenStringIsEmpty_ReturnsNotMatched()
        {
            Assert.False(GuardTest.IsWhiteSpace(string.Empty).Return(true, _ => false));
        }

        [Fact]
        public void HasValue_WithSelector_WhenSelectedValueHasContent_ReturnsMatched()
        {
            ValueTestObject<string> value = new ValueTestObject<string> { Value = "hello" };
            Assert.True(GuardTest.HasValue(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsNullOrWhiteSpace_WithSelector_WhenObjectIsNull_ReturnsMatched()
        {
            ValueTestObject<string>? value = null;
            Assert.True(GuardTest.IsNullOrWhiteSpace(value, x => x.Value).Return(true, _ => false));
        }

        [Fact]
        public void IsWhiteSpace_WithSelector_WhenSelectedValueIsWhiteSpace_ReturnsMatched()
        {
            ValueTestObject<string> value = new ValueTestObject<string> { Value = "  " };
            Assert.True(GuardTest.IsWhiteSpace(value, x => x.Value).Return(true, _ => false));
        }
    }
}
