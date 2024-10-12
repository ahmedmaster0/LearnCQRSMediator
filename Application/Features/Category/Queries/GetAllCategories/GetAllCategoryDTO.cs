

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<GetAllCategory_PostDTO> Posts { get; set; }
    }
}
