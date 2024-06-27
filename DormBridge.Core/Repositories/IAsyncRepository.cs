namespace DormBridge.Domain.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid guid);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
