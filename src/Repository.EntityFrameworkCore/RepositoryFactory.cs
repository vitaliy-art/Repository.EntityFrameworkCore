using Microsoft.EntityFrameworkCore;

namespace Repository.EntityFrameworkCore;
public abstract class RepositoryFactory<C> : IRepositoryFactory
    where C : DbContext
{
    public IEntryRepository<T> GetRepository<T>() where T : class, new()
    {
        var db = CreateDbContext();
        IEntryContext<T>? context = null;
        IEntryRepository<T>? repository = null;
        context = new EntryContext<C, T>(db, db.Set<T>());
        repository = new EntryRepository<T>(context);
        return repository;
    }

    public abstract C CreateDbContext(string[]? args = null);
}
