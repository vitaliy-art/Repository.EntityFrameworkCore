namespace Repository.EntityFrameworkCore;
public interface IEntryContext<T> : IDisposable where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<IQueryable<T>> GetAllQueryableAsync();
    Task AddAsync(T entry);
    Task AddRangeAsync(IEnumerable<T> entries);
    Task RemoveAsync(T entry);
    Task RemoveRangeAsync(IEnumerable<T> entries);
    Task SaveAsync(T entry);
    Task SaveRangeAsync(IEnumerable<T> entries);
    Task<T> GetByIdAsync(object id);
    Task ReloadAsync(T entry);
}
