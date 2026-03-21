namespace StruttonTechnologies.Core.ToolKit.Registration.Tests.TestDoubles
{
    /// <summary>
    /// Represents a sample service contract for composition tests.
    /// </summary>
    public interface ISampleService
    {
    }

    /// <summary>
    /// Represents the first implementation of <see cref="ISampleService"/>.
    /// </summary>
    public sealed class SampleService : ISampleService
    {
    }

    /// <summary>
    /// Represents a replacement implementation of <see cref="ISampleService"/>.
    /// </summary>
    public sealed class ReplacementSampleService : ISampleService
    {
    }

    /// <summary>
    /// Represents another service contract used for multi-source composition tests.
    /// </summary>
    public interface ISecondaryService
    {
    }

    /// <summary>
    /// Represents an implementation of <see cref="ISecondaryService"/>.
    /// </summary>
    public sealed class SecondaryService : ISecondaryService
    {
    }
}
