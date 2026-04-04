using System.Diagnostics.CodeAnalysis;
using StruttonTechnologies.Core.ToolKit.Testing.Utilities;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.Utilities
{
    [ExcludeFromCodeCoverage]
    public class RandomDataGeneratorTests
    {
        [Fact]
        public void Constructor_ShouldUseSharedRandom_WhenSeedIsNull()
        {
            var generator = new RandomDataGenerator();

            var value = generator.NextInt(0, 100);

            Assert.InRange(value, 0, 99);
        }

        [Fact]
        public void Constructor_ShouldUseSeededRandom_WhenSeedProvided()
        {
            var generator1 = new RandomDataGenerator(12345);
            var generator2 = new RandomDataGenerator(12345);

            var value1 = generator1.NextString(10);
            var value2 = generator2.NextString(10);

            Assert.Equal(value1, value2);
        }

        [Fact]
        public void NextString_ShouldThrowArgumentOutOfRangeException_WhenLengthIsZero()
        {
            var generator = new RandomDataGenerator();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                generator.NextString(0));

            Assert.Equal("length", exception.ParamName);
        }

        [Fact]
        public void NextString_ShouldThrowArgumentOutOfRangeException_WhenLengthIsNegative()
        {
            var generator = new RandomDataGenerator();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                generator.NextString(-1));

            Assert.Equal("length", exception.ParamName);
        }

        [Fact]
        public void NextString_ShouldReturnStringOfCorrectLength()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextString(10);

            Assert.Equal(10, result.Length);
        }

        [Fact]
        public void NextString_ShouldUseDefaultAlphabet_WhenNotProvided()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextString(100);

            Assert.All(result, c => Assert.True(char.IsLetterOrDigit(c)));
        }

        [Fact]
        public void NextString_ShouldUseCustomAlphabet_WhenProvided()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextString(10, "ABC");

            Assert.All(result, c => Assert.Contains(c, "ABC"));
        }

        [Fact]
        public void NextString_ShouldHandleSingleCharAlphabet()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextString(5, "X");

            Assert.Equal("XXXXX", result);
        }

        [Fact]
        public void NextInt_ShouldReturnValueInRange()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextInt(10, 20);

            Assert.InRange(result, 10, 19);
        }

        [Fact]
        public void NextInt_ShouldReturnMinValue_WhenRangeIsOne()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextInt(5, 6);

            Assert.Equal(5, result);
        }

        [Fact]
        public void NextUtcDate_ShouldThrowArgumentOutOfRangeException_WhenEndBeforeStart()
        {
            var generator = new RandomDataGenerator();
            var start = new DateTime(2024, 1, 10, 0, 0, 0, DateTimeKind.Utc);
            var end = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                generator.NextUtcDate(start, end));

            Assert.Equal("endExclusiveUtc", exception.ParamName);
        }

        [Fact]
        public void NextUtcDate_ShouldThrowArgumentOutOfRangeException_WhenStartEqualsEnd()
        {
            var generator = new RandomDataGenerator();
            var date = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                generator.NextUtcDate(date, date));

            Assert.Equal("endExclusiveUtc", exception.ParamName);
        }

        [Fact]
        public void NextUtcDate_ShouldReturnDateInRange()
        {
            var generator = new RandomDataGenerator();
            var start = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var end = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc);

            var result = generator.NextUtcDate(start, end);

            Assert.True(result >= start);
            Assert.True(result < end);
        }

        [Fact]
        public void NextUtcDate_ShouldReturnUtcDate()
        {
            var generator = new RandomDataGenerator();
            var start = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var end = new DateTime(2024, 12, 31, 0, 0, 0, DateTimeKind.Utc);

            var result = generator.NextUtcDate(start, end);

            Assert.Equal(DateTimeKind.Utc, result.Kind);
        }

        [Fact]
        public void NextEnum_ShouldReturnValidEnumValue()
        {
            var generator = new RandomDataGenerator();

            var result = generator.NextEnum<DayOfWeek>();

            Assert.True(Enum.IsDefined(typeof(DayOfWeek), result));
        }

        [Fact]
        public void NextEnum_ShouldReturnDifferentValues_WithDifferentSeeds()
        {
            var generator1 = new RandomDataGenerator(1);
            var generator2 = new RandomDataGenerator(2);

            var values1 = Enumerable.Range(0, 50).Select(_ => generator1.NextEnum<DayOfWeek>()).ToList();
            var values2 = Enumerable.Range(0, 50).Select(_ => generator2.NextEnum<DayOfWeek>()).ToList();

            Assert.NotEqual(values1, values2);
        }
    }
}
