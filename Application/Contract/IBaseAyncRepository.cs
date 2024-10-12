

namespace Application.Contract
{
    public interface IBaseAyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);  

        Task<bool> DeleteByIdAsync(T entity);

        Task<bool> UpdateAsync(T entity);
    }
}
