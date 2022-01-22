namespace Repository.EntityFrameworkCore;
public class EntryRepository<T> : IEntryRepository<T> where T : class
{
    private IEntryContext<T> _context;

    public EntryRepository(IEntryContext<T> context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _context.GetAllAsync();

    public async Task<IQueryable<T>> GetAllQueryableAsync() => await _context.GetAllQueryableAsync();

    public async Task AddAsync(T entry) => await _context.AddAsync(entry);

    public async Task AddRangeAsync(IEnumerable<T> entries) => await _context.AddRangeAsync(entries);

    public async Task RemoveAsync(T entry) => await _context.RemoveAsync(entry);

    public async Task RemoveRangeAsync(IEnumerable<T> entries) => await _context.RemoveRangeAsync(entries);

    public async Task SaveAsync(T entry) => await _context.SaveAsync(entry);

    public async Task SaveRangeAsync(IEnumerable<T> entries) => await _context.SaveRangeAsync(entries);

    public async Task<T> GetByIdAsync(object id) => await _context.GetByIdAsync(id);

    public async Task ReloadAsync(T entry) => await _context.ReloadAsync(entry);

    public void Dispose() => _context.Dispose();
}
