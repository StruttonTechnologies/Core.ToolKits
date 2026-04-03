using Microsoft.EntityFrameworkCore;

namespace StruttonTechnologies.Core.ToolKit.Testing.EntityFramework;

/// <summary>
/// Creates isolated EF Core in-memory options for tests.
/// </summary>
public static class InMemoryDbContextOptionsFactory
{
    public static DbContextOptions<TContext> Create<TContext>(string? databaseName = null)
        where TContext : DbContext
    {
        string resolvedName = string.IsNullOrWhiteSpace(databaseName)
            ? Guid.NewGuid().ToString("N")
            : databaseName;

        return new DbContextOptionsBuilder<TContext>()
            .UseInMemoryDatabase(resolvedName)
            .EnableSensitiveDataLogging()
            .Options;
    }
}
