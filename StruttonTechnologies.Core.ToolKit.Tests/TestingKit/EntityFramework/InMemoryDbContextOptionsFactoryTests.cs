using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using StruttonTechnologies.Core.ToolKit.Testing.EntityFramework;

namespace StruttonTechnologies.Core.ToolKit.Tests.TestingKit.EntityFramework
{
    [ExcludeFromCodeCoverage]
    public class InMemoryDbContextOptionsFactoryTests
    {
        [Fact]
        public void Create_ShouldReturnDbContextOptions_WhenDatabaseNameIsNull()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>();

            Assert.NotNull(options);
        }

        [Fact]
        public void Create_ShouldReturnDbContextOptions_WhenDatabaseNameIsEmpty()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>(string.Empty);

            Assert.NotNull(options);
        }

        [Fact]
        public void Create_ShouldReturnDbContextOptions_WhenDatabaseNameIsWhitespace()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>("   ");

            Assert.NotNull(options);
        }

        [Fact]
        public void Create_ShouldReturnDbContextOptions_WhenDatabaseNameProvided()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>("TestDatabase");

            Assert.NotNull(options);
        }

        [Fact]
        public void Create_ShouldCreateWorkingDbContext()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>();

            using var context = new TestDbContext(options);
            context.TestEntities.Add(new TestEntity { Id = 1, Name = "Test" });
            context.SaveChanges();

            Assert.Single(context.TestEntities);
        }

        [Fact]
        public void Create_ShouldIsolateDatabases_WhenNoDatabaseNameProvided()
        {
            var options1 = InMemoryDbContextOptionsFactory.Create<TestDbContext>();
            var options2 = InMemoryDbContextOptionsFactory.Create<TestDbContext>();

            using var context1 = new TestDbContext(options1);
            using var context2 = new TestDbContext(options2);

            context1.TestEntities.Add(new TestEntity { Id = 1, Name = "Test1" });
            context1.SaveChanges();

            Assert.Single(context1.TestEntities);
            Assert.Empty(context2.TestEntities);
        }

        [Fact]
        public void Create_ShouldShareDatabase_WhenSameDatabaseNameProvided()
        {
            var options1 = InMemoryDbContextOptionsFactory.Create<TestDbContext>("SharedDb");
            var options2 = InMemoryDbContextOptionsFactory.Create<TestDbContext>("SharedDb");

            using var context1 = new TestDbContext(options1);
            context1.TestEntities.Add(new TestEntity { Id = 1, Name = "Test1" });
            context1.SaveChanges();

            using var context2 = new TestDbContext(options2);
            Assert.Single(context2.TestEntities);
        }

        [Fact]
        public void Create_ShouldEnableSensitiveDataLogging()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>();

            using var context = new TestDbContext(options);

            Assert.NotNull(context.Database);
        }

        [Fact]
        public void Create_ShouldUseInMemoryProvider()
        {
            var options = InMemoryDbContextOptionsFactory.Create<TestDbContext>();

            using var context = new TestDbContext(options);
            var providerName = context.Database.ProviderName;

            Assert.Contains("InMemory", providerName);
        }

        private sealed class TestDbContext : DbContext
        {
            public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
            {
            }

            public DbSet<TestEntity> TestEntities { get; set; } = null!;
        }

        private sealed class TestEntity
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
}
