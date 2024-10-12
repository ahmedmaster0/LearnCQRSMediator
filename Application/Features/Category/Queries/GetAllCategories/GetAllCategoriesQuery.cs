

using Application.Generic;
using MediatR;

namespace Application.Features.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<GetResponse<GetAllCategoryDTO>>
    {
        public bool IncludePosts { get; set; } = false;
    }
}
