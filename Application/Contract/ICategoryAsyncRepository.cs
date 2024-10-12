using Domain;


namespace Application.Contract
{
    public interface ICategoryAsyncRepository : IBaseAyncRepository<Category>
    {
        Task<IReadOnlyCollection<Category>> GetAllCategoriesAsync(bool IncludePosts);

        Task<Category> GetCategoryByIdsAsync(Guid id, bool IncludePosts);
    }
}
