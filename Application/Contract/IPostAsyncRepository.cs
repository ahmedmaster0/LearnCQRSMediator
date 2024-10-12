using Domain;


namespace Application.Contract
{
    public interface IPostAsyncRepository : IBaseAyncRepository<Post>
    {
        Task<IReadOnlyList<Post>> GetAllPostsAsync(bool IncludeCategory);
        Task<Post> GetPostByIdAsync(Guid id , bool IncludeCategory);
    }
}
