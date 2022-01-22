using Microsoft.EntityFrameworkCore;

namespace Repository.EntityFrameworkCore;
public class EntryContext<C, T> : IEntryContext<T>
    where T : class, new()
    where C : DbContext
{
    private DbSet<T> _dbSet;
    private C _dbContext;

    public EntryContext(C dbContext, DbSet<T> dbSet)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
    }

    public Task<IEnumerable<T>> GetAllAsync() =>
        Task.FromResult(_dbSet.AsEnumerable());

    public Task<IQueryable<T>> GetAllQueryableAsync()
    {
        IQueryable<T> entries = _dbSet;
        return Task.FromResult(entries);
    }

    public Task<long> GetAllCountAsync() =>
        Task.FromResult(_dbSet.AsQueryable().LongCount());

    public async Task AddAsync(T entry)
    {
        await _dbSet.AddAsync(entry);
        _dbContext.Entry<T>(entry).State = EntityState.Added;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task AddRangeAsync(IEnumerable<T> entries)
    {
        await _dbSet.AddRangeAsync(entries);
        foreach (T entry in entries)
            _dbContext.Entry<T>(entry).State = EntityState.Added;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task RemoveAsync(T entry)
    {
        _dbContext.Entry<T>(entry).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entries)
    {
        foreach (T entry in entries)
            _dbContext.Entry<T>(entry).State = EntityState.Deleted;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task SaveAsync(T entry)
    {
        _dbContext.Entry(entry).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task SaveRangeAsync(IEnumerable<T> entries)
    {
        foreach(T entry in entries)
            _dbContext.Entry<T>(entry).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(default);
    }

    public async Task<T> GetByIdAsync(object id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity ?? new T();
    }

    public async Task ReloadAsync(T entry) => await _dbContext.Entry(entry).ReloadAsync();

    public void Dispose() => _dbContext.Dispose();
}
