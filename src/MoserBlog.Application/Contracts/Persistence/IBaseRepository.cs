namespace MoserBlog.Application.Contracts.Persistence;

public interface IBaseRepository<T> where T : class
{
    Task<T> GetByIdAsync(object id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
