using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository.EntityFrameworkCore;

public class SqliteRepositoryFactory :
    RepositoryFactory<Context>,
    IDesignTimeDbContextFactory<Context>
{
    private readonly string? _connectionString = null;

    public SqliteRepositoryFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqliteRepositoryFactory()
    {}

    public override Context CreateDbContext(string[]? args = null)
    {
        DbContextOptionsBuilder<Context> builder = new();
        if (_connectionString is null)
            builder = builder.UseSqlite("Filename=bd.db");
        else
            builder.UseSqlite(_connectionString);
        builder = builder.EnableSensitiveDataLogging();
        return new Context(builder.Options);
    }
}
