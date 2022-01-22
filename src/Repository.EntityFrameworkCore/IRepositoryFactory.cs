namespace Repository.EntityFrameworkCore;
public interface IRepositoryFactory
{
    IEntryRepository<T> GetRepository<T>() where T : class, new();
}
