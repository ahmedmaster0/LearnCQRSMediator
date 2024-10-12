using Domain;


namespace Application.Features.Post.Queries.GetPostById
{
    public class GetPostByIdDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }

        public CategoryDTO Category { get; set; }

    }
}
