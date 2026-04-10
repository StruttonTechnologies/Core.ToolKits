using StruttonTechnologies.Core.ToolKits.Time.Clocks;

namespace StruttonTechnologies.Core.ToolKit.Testing.Utilities
{
    /// <summary>
    /// Creates a fake clock for tests without requiring each test to reference the time namespace directly.
    /// </summary>
    public static class TestClockFactory
    {
        public static FakeClock Create(DateTime? utcNow = null) =>
            utcNow.HasValue ? new FakeClock(utcNow.Value) : new FakeClock();
    }
}
