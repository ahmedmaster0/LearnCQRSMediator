

namespace Application.Features.Post.Queries.GetAllPosts
{
    public class GetAllPostsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
