

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategory_PostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
    }
}
