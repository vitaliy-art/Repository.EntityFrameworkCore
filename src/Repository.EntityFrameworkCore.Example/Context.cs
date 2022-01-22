using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    private static bool _migrated;

    public DbSet<Model>? Models { get; set; }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
        if (!_migrated)
        {
            _migrated = true;
            Database.Migrate();
        }
    }
}
